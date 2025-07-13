using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Value_Objects;

public class PetId:ValueObject
{
    // EF Core
    private PetId() { }

    private PetId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static PetId NewPetId() => new(Guid.NewGuid());
    
    public static PetId Empty() => new(Guid.Empty);
}