using MediatR;

namespace CrudBackend.Features.LoginFeature
{
    public class LoginRequestModel : IRequest<LoginResponseModel>
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
