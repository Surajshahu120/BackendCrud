using MediatR;
using Microsoft.EntityFrameworkCore.Query;

namespace CrudBackend.Features.UserFeature.CreateUser
{
    public class CreateUserRequestModel : IRequest<CreateUserResponseModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
