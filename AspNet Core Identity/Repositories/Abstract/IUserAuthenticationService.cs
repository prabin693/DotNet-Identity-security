using AspNet_Core_Identity.Models.Dto;

namespace AspNet_Core_Identity.Repositories.Abstract
{
    public interface IUserAuthenticationservice
    {

        Task<Status> LoginAsync(LoginModel model);

        Task LogoutAsync();

        Task<Status> RegisterAsync(RegistrationModel model);

        Task<Status> ChangePassword(ChangePassword model, string username);
    }
}
