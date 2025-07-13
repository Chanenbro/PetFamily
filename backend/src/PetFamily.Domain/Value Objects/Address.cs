using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Value_Objects;

public class Address:ValueObject
{
       
        // EF Core
        private Address() { }

        private Address(string street, string city, string state, string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }
        public String Street { get; }
        public String City { get; }
        public String State { get; }
        public String Country { get; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
        }
        
        public static Result<Address> Create(string street, string city, string state, string country)
        {
            if (string.IsNullOrWhiteSpace(street))
                return Result.Failure<Address>("Street cannot be null or empty");
            if (string.IsNullOrWhiteSpace(city))
                return Result.Failure<Address>("City cannot be null or empty");
            if (string.IsNullOrWhiteSpace(state))
                return Result.Failure<Address>("State cannot be null or empty");
            if (string.IsNullOrWhiteSpace(country))
                return Result.Failure<Address>("Country cannot be null or empty");

            return Result.Success(new Address(street, city, state, country));
        }
        
    }