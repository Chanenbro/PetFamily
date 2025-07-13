using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Value_Objects;

namespace PetFamily.Domain;

public class Volunteer:Shared.Entity<VolunteerId>
{
    private readonly List<Requisites> _requisites = [];
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Pet> _pets = [];
    private readonly List<Photo> _photos = [];
    
    //EF Core
    private Volunteer(VolunteerId volunteerId):base(volunteerId)
    {}
    private Volunteer(VolunteerId volunteerId,
        string fullName,
        string description,
        int yearExperience,
        string phoneNumber,
        string email):base(volunteerId)
    {
        FullName = fullName;
        Description = description;
        YearExperience = yearExperience;
        PhoneNumber = phoneNumber;
        Email = email;
    }
    
    public VolunteerId VolunteerId { get; private set; }
    public string FullName { get; private set; }
    public string Description { get; private set; }
    public int YearExperience { get; private set; }
    public IReadOnlyList<Pet> Pets => _pets;
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public IReadOnlyList<SocialNetwork> VolonteerSocialNetworks => _socialNetworks;
    public IReadOnlyList<Requisites> VolonteerRequisites => _requisites;
    public IReadOnlyList<Photo> Photos => _photos;

    public static Result<Volunteer> Create(VolunteerId volunteerId,
        string fullName,
        string description,
        int yearExperience,
        string phoneNumber,
        string email,
        List<Pet> pets,
        List<SocialNetwork> volunteerSocialNetworks,
        List<Requisites> requisites,
        List<Photo> photos)
    {
        if(string.IsNullOrEmpty(fullName))
            return Result.Failure<Volunteer>("Full name cannot be null or empty");
        if(string.IsNullOrEmpty(description))
            return Result.Failure<Volunteer>("Description cannot be null");
        if(string.IsNullOrEmpty(email))
            return Result.Failure<Volunteer>("Email cannot be null");
        if(string.IsNullOrEmpty(phoneNumber))
            return Result.Failure<Volunteer>("Phone number cannot be null");

        var volunteer = new Volunteer(volunteerId,fullName, description, yearExperience, phoneNumber, email);
        
        volunteer._pets.AddRange(pets);
        volunteer._photos.AddRange(photos);
        volunteer._socialNetworks.AddRange(volunteerSocialNetworks);
        volunteer._requisites.AddRange(requisites);
        
        return Result.Success(volunteer);
    }
    
    public int PetsHomeFounded() => _pets.Count(p => p.HelpStatus == HelpStatus.Home);
    public int PetsHomeFound =>  _pets.Count(p => p.HelpStatus == HelpStatus.HomeFound);
    public int PetsNeedHelp =>  _pets.Count(p => p.HelpStatus == HelpStatus.NeedHelp);

    
    
}