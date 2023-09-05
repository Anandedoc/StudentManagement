using Microsoft.AspNetCore.Http;

public interface IUserContext
{
    long CurrentUserId { get; }
    string UserRole { get; }
}

public class UserContext : IUserContext
{
    public long CurrentUserId { get; }
    public string UserRole { get; }

    public UserContext(IHttpContextAccessor contextAccessor)
    {
        CurrentUserId = GetClaimValue<long>("UserId", contextAccessor.HttpContext);
        UserRole = GetClaimValue<string>("Role", contextAccessor.HttpContext);
    }

    private static T? GetClaimValue<T>(string claimName, HttpContext? context)
    {
        var userClaims = context?.User.Claims.ToArray();

        if (userClaims == null || userClaims.Length == 0)
            return default;

        var value = userClaims.FirstOrDefault(x => x.Type == claimName)?.Value;

        return (T)Convert.ChangeType(value, typeof(T));
    }
}