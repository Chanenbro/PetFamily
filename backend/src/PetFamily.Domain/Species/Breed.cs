using CSharpFunctionalExtensions;
using PetFamily.Domain.Value_Objects;

namespace PetFamily.Domain.Species;

public class Breed:Shared.Entity<BreedId>
{
    // EF Core
    private Breed(BreedId breedId) : base(breedId) { }

    private Breed(BreedId breedId, string name) : base(breedId)
    {
        Name = name;
    }

    public BreedId BreedId { get; private set; }
    public string Name { get; private set; }

    public static Result<Breed> Create(BreedId breedId,string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            return Result.Failure<Breed>("Species name cannot be empty");
        
        return Result.Success(new Breed(breedId,name));
    }
}