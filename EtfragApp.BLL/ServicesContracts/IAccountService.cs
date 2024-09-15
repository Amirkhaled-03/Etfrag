

using EtfragApp.BLL.DTOs.User;
using EtfragApp.DAL.Entities;

namespace EtfragApp.BLL.ServicesContracts
{
    public interface IAccountService
    {
        public Task<ApplicationUser?> LogIn(LogInDto logInDto);

        public Task<List<string>> SignUp(RegisterDto registerDto);

        public Task SignOut();

        public Task<bool> IsEmailExists(string email);

        public Task<ApplicationUser> GetUserByEmail(string email);

        public Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);

        public Task<List<string>> ResetPassword(ResetPasswordDto dto);

        public Task<IList<string>> GetRole(ApplicationUser user);

    }
}
