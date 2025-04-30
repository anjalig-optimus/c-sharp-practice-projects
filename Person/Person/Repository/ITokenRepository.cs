using Microsoft.AspNetCore.Identity;

namespace Person_json.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
