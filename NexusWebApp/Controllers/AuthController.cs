using AutoMapper;
using NexusWebApp.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NexusWebApp.Models;
using NexusWebApp.ViewModels;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NexusWebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly NaxusWebAppContext _appContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger, NaxusWebAppContext appContext, IMapper mapper )
        {
            _mapper = mapper;
            _logger = logger;
            _appContext = appContext;
        }

        #region Login
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var user = _appContext.Users.SingleOrDefault(u => u.UserName == model.UserName);
                if (user == null)
                {
                    ViewData["Message"] = "Username or password is incorrect !";
                }
                else
                {
                    if (user.Status == false)
                    {
                        ViewData["Message"] = "Account has been locked. Please contact Admin!";
                    }
                    else
                    {
                        if (user.Password != model.Password.ToMd5Hash(user.RandomKey))
                        {
                            ViewData["Message"] = "Username or password is incorrect !";
                        }
                        else
                        {
                            var claims = new List<Claim> {
                                new Claim(ClaimTypes.Email, user.UserName),
								//claim - role động
								new Claim(ClaimTypes.Role, "Customer")
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                            await HttpContext.SignInAsync(claimsPrincipal);

                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                return Redirect("/");
                            }
                        }
                    }
                }
            }
            return View();
        }

        #endregion
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM model) {
            if (ModelState.IsValid)
            {
                var check = _appContext.Users.FirstOrDefault(c => c.UserName.ToUpper().Equals(model.UserName.ToUpper()));
                if (check != null)
                {
                    ViewData["Message"] = "Email already exists.";
                    return View();
                }
                var RandomKey = MyUtil.GenerateRamdomKey();
                var user = new User
                {
                    UserName = model.UserName,
                    Password = model.Password.ToMd5Hash(RandomKey),
                    Level = 0,
                    Status = true,
                    RandomKey = RandomKey,
                };

                _appContext.Users.Add(user);
                _appContext.SaveChanges();
                return RedirectToAction("AccountD", "Home");
            }
            return View();
            
        }
        #endregion
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
