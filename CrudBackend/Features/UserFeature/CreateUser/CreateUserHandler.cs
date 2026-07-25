using CrudBackend.RepositoryPattern;
using CrudBackend.UnitWorkPattern;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CrudBackend.Features.UserFeature.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequestModel, CreateUserResponseModel>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork, UserManager<IdentityUser> usermanager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = usermanager;
            _roleManager = roleManager;
        }
        public async Task<CreateUserResponseModel> Handle(CreateUserRequestModel request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Email
            };
            var data = await _userManager.CreateAsync(user,request.Password);
            if (!data.Succeeded)
            {
                throw new Exception("Something went wrong");
            }
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            await _userManager.AddToRoleAsync(user,"Admin");
            return new CreateUserResponseModel
            {
                id = user.Id,
                message = "User Created Successfully"
            };
        }
    }
}
