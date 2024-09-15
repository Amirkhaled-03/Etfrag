
using EtfragApp.BLL.DTOs.User;
using EtfragApp.BLL.ServicesContracts;
using EtfragApp.DAL.Entities;
using EtfragApp.PL.Helpers;
using EtfragApp.PL.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace EtfragApp.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(
        IAccountService accountService

            )

        {
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginDt = new LogInDto
                {
                    Email = model.Email,
                    Password = model.Password,
                    RememberMe = model.RememberMe,
                };

                ApplicationUser? user = await _accountService.LogIn(loginDt);

                if (user != null)
                {
                    var roles = await _accountService.GetRole(user);
                    string? firstRole = roles.FirstOrDefault();

                    if (firstRole == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Email Does Not Exist");
            return View(model);
        }

        public IActionResult SignUp()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new RegisterDto
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    IsAgreed = model.IsAgreed,
                };

                List<string> errors = await _accountService.SignUp(user);

                if (errors.IsNullOrEmpty())
                    return RedirectToAction("LogIn");

                foreach (var error in errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _accountService.SignOut();
            return RedirectToAction("LogIn");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isFound = await _accountService.IsEmailExists(model.Email);

                if (isFound == false)
                {
                    ModelState.AddModelError("", "Invalid Email");
                    return View(model);
                }

                var res = await SendPasswordResetEmailAsync(model.Email);
                if (!res)
                {
                    ModelState.AddModelError("", "Failed to send password reset email. Please try again.");
                    return View(model);
                }
                return RedirectToAction("CompleteResetPassword");

            }
            return View(model);
        }
        private async Task<bool> SendPasswordResetEmailAsync(string email)
        {
            ApplicationUser user = await _accountService.GetUserByEmail(email);

            string token = await _accountService.GeneratePasswordResetTokenAsync(user);

            var resetPasswordLink = Url.Action("ResetPassword", "Account", new { Email = email, token = token }, Request.Scheme);

            var emailMessage = new Email
            {
                To = user.Email,
                Subject = "Password Reset",
                Body = resetPasswordLink
            };

            await EmailSettings.SendEmailAsync(emailMessage);

            return true;

        }
        public IActionResult CompleteResetPassword()
        {
            return View();
        }
        public IActionResult ResetPassword(string email, string token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resetPasswordDto = new ResetPasswordDto
                {
                    ConfirmPassword = model.ConfirmPassword,
                    Email = model.Email,
                    Password = model.Password,
                    Token = model.Token
                };

                List<string> errors = await _accountService.ResetPassword(resetPasswordDto);
                if (errors.IsNullOrEmpty())
                    return RedirectToAction("LogIn");

                foreach (var error in errors)
                    ModelState.AddModelError(string.Empty, error);
            }

            return View(model);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
