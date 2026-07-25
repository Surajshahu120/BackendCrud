using Microsoft.AspNetCore.Identity;

namespace CrudBackend.TokenService
{
    public interface ITokenService
    {
        Task<string> GenerateAccessToken(IdentityUser entity);
    }
}
