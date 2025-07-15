using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Value_Objects;

public class VolunteerId:ValueObject
{
    // EF Core
    private VolunteerId() { }

    private VolunteerId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static VolunteerId NewVolunteerId() => new(Guid.NewGuid());
    
    public static VolunteerId Empty() => new(Guid.Empty);
}