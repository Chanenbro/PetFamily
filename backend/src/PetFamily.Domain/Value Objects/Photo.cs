using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Value_Objects;

public class Photo: ValueObject
{
  
    // EF Core
    private Photo() {}
    private Photo(string path) => Path = path;

    public string Path { get; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Path;
    }
    
    public Result<Photo> Create(string path)
    {
        if(string.IsNullOrWhiteSpace(path))
            return Result.Failure<Photo>("path is empty");

        return Result.Success(new Photo(path));
    }
}