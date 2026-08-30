using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrudBackend.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        public TokenService(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<string> GenerateAccessToken(IdentityUser identityUser)
        {
            var data = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]!));
            var credentials = new SigningCredentials(data, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, identityUser.Email),
                new Claim(ClaimTypes.Name, identityUser.UserName),
                new Claim("refreshToken", Guid.NewGuid().ToString())
            };
            var roles=await _userManager.GetRolesAsync(identityUser);
            foreach(var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }
            var token = new JwtSecurityToken
            (
                     _configuration["jwt:issuer"],
                     _configuration["jwt:audience"],
                     claims,
                     expires : DateTime.Now.AddMinutes(60),
                     signingCredentials : credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
