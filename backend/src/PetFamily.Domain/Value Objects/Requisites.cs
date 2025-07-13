using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Value_Objects;

public class Requisites : ValueObject
{

    // EF Core
    private Requisites() { }
    private Requisites(string bankTitle, string bankAccountNumber)
    {
        BankTitle = bankTitle;
        BankAccountNumber = bankAccountNumber;
    }
    
    public string BankTitle { get; }
    public string BankAccountNumber { get; }
    
    public static Result<Requisites> Create(string bankTitle, string bankAccountNumber)
    {
        if(string.IsNullOrWhiteSpace(bankTitle))
            return Result.Failure<Requisites>("Bank Title is required");
        if (string.IsNullOrWhiteSpace(bankAccountNumber))
            return Result.Failure<Requisites>("Bank Account Number is required");
        
        var requisites = new Requisites(bankTitle, bankAccountNumber);
        
        return Result.Success(requisites);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return BankTitle;
        yield return BankAccountNumber;
    }
}