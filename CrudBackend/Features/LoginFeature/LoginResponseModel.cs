namespace CrudBackend.Features.LoginFeature
{
    public class LoginResponseModel
    {
        public string message { get; set; } = "User Authenticated Successfully";
        public string? accessToken { get; set; }
        public string? refreshToken { get; set; }

    }
}
