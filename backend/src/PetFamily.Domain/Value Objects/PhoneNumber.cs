using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Value_Objects;

public class PhoneNumber:ValueObject
{
    private readonly string _pattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
    
    private PhoneNumber(){}
    private PhoneNumber(string number) => Number = number;
    
    public string Number { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }
    public Result<PhoneNumber> Create(string number)
    {
        if(string.IsNullOrWhiteSpace(number))
            return Result.Failure<PhoneNumber>("Number cannot be empty");
        
        if(!Regex.IsMatch(number,_pattern))
            return Result.Failure<PhoneNumber>("Invalid number");
        
        return Result.Success(new PhoneNumber(number));
    }
}