using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Value_Objects;

public class SpeciesId: ValueObject
{
        // EF Core
        private SpeciesId() { }

        private SpeciesId(Guid value)
        {
            Value = value;
        }
        public Guid Value { get; }
    
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    
        public static SpeciesId NewSpeciesId() => new(Guid.NewGuid());
    
        public static SpeciesId Empty() => new(Guid.Empty);

}