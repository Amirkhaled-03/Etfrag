
using EtfragApp.BLL.DTOs.User;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace EtfragApp.BLL.Sevices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser?> LogIn(LogInDto logInDto)
        {
            var user = await _userManager.FindByEmailAsync(logInDto.Email);
            if (user != null)
            {
                bool isCorrectPassword = await _userManager.CheckPasswordAsync(user, logInDto.Password);
                if (isCorrectPassword)
                {
                    var res = await _signInManager.PasswordSignInAsync(user, logInDto.Password, logInDto.RememberMe, false);
                    if (res.Succeeded)
                        return user;
                }
            }
            return null;
        }

        public async Task<List<string>> SignUp(RegisterDto registerDto)
        {
            List<string> errors = new List<string>();

            var user = new ApplicationUser
            {
                UserName = registerDto.Name,
                Email = registerDto.Email,
            };

            var res = await _userManager.CreateAsync(user, registerDto.Password);
            await _userManager.AddToRoleAsync(user, "User");

            if (!res.Succeeded)
                foreach (var error in res.Errors)
                {
                    errors.Add(error.Description);
                }

            return errors;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> IsEmailExists(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            return true;
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<List<string>> ResetPassword(ResetPasswordDto dto)
        {
            List<string> errors = new List<string>();

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.Password);
                if (result.Succeeded)
                    return errors;

                foreach (var error in result.Errors)
                    errors.Add(error.Description);
            }
            return errors;
        }

        public async Task<IList<string>> GetRole(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}
