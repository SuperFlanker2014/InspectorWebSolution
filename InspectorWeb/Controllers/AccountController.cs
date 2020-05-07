using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using InspectorWeb.ModelsDB;
using InspectorWeb.ViewModels;

namespace InspectorWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly InspectorWebDBContext _context;

        public AccountController(InspectorWebDBContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            if (Guid.TryParse(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value, out var userGuid))
            {
                return RedirectToAction("Index", "DocsExaminationTasks");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            ClaimsIdentity identity = null;
            bool isAuthenticated = false;

            var hash = PasswordHash(password);
            var user = _context.DirUsers.FirstOrDefault(u => u.Login == login && u.PasswordHash == hash);

            if (user != null)
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Guid.ToString()),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "DocsExaminationTasks");
            }

            ModelState.AddModelError(nameof(LoginViewModel.Error), "неверный логин или пароль");

            return View(new LoginViewModel());
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult ChangePassword([Bind("PasswordOld,PasswordNew1,PasswordNew2")] ChangePasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();

                if (Guid.TryParse(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value, out var userGuid))
                {
                    var user = _context.DirUsers.First(u => u.Guid == userGuid);

                    if (PasswordHash(viewModel.PasswordOld) != user.PasswordHash)
                    {
                        ModelState.AddModelError(nameof(viewModel.PasswordOld), "неверный пароль");
                    }

                    if (string.IsNullOrWhiteSpace(viewModel.PasswordNew1))
                    {
                        ModelState.AddModelError(nameof(viewModel.PasswordNew1), "пустой пароль");
                    }

                    if (viewModel.PasswordNew1 != viewModel.PasswordNew2)
                    {
                        ModelState.AddModelError(nameof(viewModel.PasswordNew2), "пароли не совпадают");
                    }

                    ModelState.AddModelError(nameof(viewModel.Message), "пароль изменён!");

                    user.PasswordHash = PasswordHash(viewModel.PasswordNew1);
                    _context.SaveChanges();
                }                
            }

            return View(viewModel);
        }

        private string PasswordHash(string password)
        {
            //byte[] salt = new byte[128 / 8];
            //using (var rng = RandomNumberGenerator.Create())
            //{
            //    rng.GetBytes(salt);
            //}

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: new byte[0],
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}