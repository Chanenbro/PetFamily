using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Value_Objects;

public class SocialNetwork:ValueObject
{

    // EF Core
    private SocialNetwork()
    {}

    private SocialNetwork(string nickname, TypeSocialNetworks typeSocialNetwork, string socialLink)
    {
        Nickname = nickname;
        TypeSocialNetwork = typeSocialNetwork;
        SocialLink = socialLink;
    }
    public string Nickname { get; }
    public TypeSocialNetworks TypeSocialNetwork { get; }
    public string SocialLink { get; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Nickname;
        yield return TypeSocialNetwork;
        yield return SocialLink;
    }

    public static Result<SocialNetwork> Create(string nickname, TypeSocialNetworks typeSocialNetwork, string socialLink)
    {
        if (string.IsNullOrWhiteSpace(nickname))
            return Result.Failure<SocialNetwork>("Nickname is required");
        if (string.IsNullOrWhiteSpace(socialLink))
            return Result.Failure<SocialNetwork>("SocialLink is required");
        
        return Result.Success(new SocialNetwork(nickname, typeSocialNetwork, socialLink));
    }
}