using System.Xml.Schema;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Value_Objects;

namespace PetFamily.Domain.Species;

public class Species: Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];
    // EF Core
    private Species(SpeciesId speciesId):base(speciesId) {}
    private Species(SpeciesId speciesId, string name,List<Breed> breeds): base(speciesId)
    {
        Name = name;
        _breeds.AddRange(breeds);
    }

    public SpeciesId SpeciesId { get; private set; }
    public string Name { get; private set; }

    public List<Breed> Breeds => _breeds;

    public static Result<Species> Create(SpeciesId speciesId,string name,List<Breed> breeds)
    {
        if(string.IsNullOrWhiteSpace(name))
            return Result.Failure<Species>("Species name cannot be empty");
        
        var species = new Species(speciesId,name, breeds);

        return Result.Success(species);
    }
}