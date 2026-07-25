using CrudBackend.TokenService;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CrudBackend.Features.LoginFeature
{
    public class LoginHandler : IRequestHandler<LoginRequestModel, LoginResponseModel>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<IdentityRole> _signInManager;
        public LoginHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<LoginResponseModel> Handle(LoginRequestModel request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            var verifyPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            //var userData = new IdentityUser { UserName=user.UserName, Email=user.Email, PasswordHash=user.PasswordHash};
            if (user == null && !verifyPassword) {
                return new LoginResponseModel
                {
                    message = "Bad Request"
                };    
            }
            var token = _tokenService.GenerateAccessToken(user!);
            return new LoginResponseModel
            {
                accessToken = await token,
                refreshToken= Guid.NewGuid().ToString()
            };

        }
    }
}
