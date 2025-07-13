using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Value_Objects;

namespace PetFamily.Domain
{
    public class Pet:Shared.Entity<PetId>
    {
        private readonly List<Requisites>  _requisites = [];
        private readonly List<Photo>   _photos = [];
        
        // EF Core
        private Pet(PetId petId):base(petId) { }
        private Pet(PetId petId,
            string nickname,
            string description,
            Color color,
            string healthInfo,
            Address address,
            decimal weight,
            decimal height,
            string ownerPhoneNumber,
            bool isCastrated,
            HelpStatus helpStatus,
            DateTime birthdate,
            bool isVaccinated):base(petId)
        {
            Nickname = nickname;
            Description = description;
            Color = color;
            HealthInfo = healthInfo;
            PetAddress = address;
            Weight = weight;
            Height = height;
            OwnerPhoneNumber = ownerPhoneNumber;
            IsCastrated = isCastrated;
            HelpStatus = helpStatus;
            Birthdate = birthdate;
            IsVaccinated = isVaccinated;
            CreationDate = DateTime.Now;
            Likes = 0;
        }
        public PetId PetId { get; private set; }            
        public string Nickname { get; private set; } 
        public VolunteerId VolunteerId { get; private set; }  
        public SpeciesId SpeciesId { get; private set; }    
        public BreedId BreedId { get; private set; }      
        public string Description { get; private set; } 
        public Color Color{ get; private set; }
        public string HealthInfo { get; private set; }
        public Address PetAddress { get; private set; }     
        public decimal Weight {  get; private set; }
        public decimal Height { get; private set; }
        public string? OwnerPhoneNumber { get; private set; } 
        public bool IsCastrated { get; private set; }
        public HelpStatus HelpStatus { get; private set; }
        public DateTime Birthdate { get; private set; }
        public bool IsVaccinated { get; private set; }
        public IReadOnlyList<Requisites> PetRequisites => _requisites;
        public DateTime CreationDate { get; private set; }
        public int Likes { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public IReadOnlyList<Photo> PetPhotos => _photos;
        
        
        public static Result<Pet> Create(PetId petId,
            string nickname,
            string description,
            Color color, 
            string healthInfo,
            Address address,
            decimal weight,
            decimal height,
            string ownerPhoneNumber,
            bool isCastrated,
            HelpStatus helpStatus,
            DateTime birthdate,
            bool isVaccinated, 
            List<Requisites>  requisites,
            List<Photo> photos)
        {
            if(string.IsNullOrWhiteSpace(nickname))
                return Result.Failure<Pet>("Pet name cannot be empty");
            if(string.IsNullOrWhiteSpace(healthInfo))
                return Result.Failure<Pet>("Health info cannot be empty");
            if(weight == 0)
                return Result.Failure<Pet>("Weight cannot be 0");
            if(height == 0)
                return Result.Failure<Pet>("Height cannot be 0");
            
            var pet = new Pet(petId,nickname,description,color, healthInfo,
                address,weight,height,ownerPhoneNumber,
                isCastrated,helpStatus,birthdate, isVaccinated);
            
            pet._photos.AddRange(photos);
            pet._requisites.AddRange(requisites);
            
            return Result.Success(pet);
        }
    }
}
