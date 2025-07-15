using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Value_Objects;

public class BreedId:ValueObject
{
    // EF Core
    private BreedId() { }

    private BreedId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static BreedId NewBreedId() => new(Guid.NewGuid());
    
    public static BreedId Empty() => new(Guid.Empty);
}