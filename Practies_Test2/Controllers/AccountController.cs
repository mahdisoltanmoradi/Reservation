using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Practies.Core.Convertors;
using Practies.Core.DTOs;
using Practies.Core.Generator;
using Practies.Core.Security;
using Practies.Core.Services.Interface;
using Practies.DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Practies_Test2.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        #region Register
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userService.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمی باشد");
                return View(register);
            }

            if (_userService.IsExistEmail(FixedText.FixeEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل معتبر نمی باشد");
                return View(register);
            }
           string hashPassword= PasswordHelper.EncodePasswordMd5(register.Password);
            User user = new User()
            {
                UserName = register.UserName,
                Email = register.Email,
                RegisterDate = DateTime.Now,
                Password = hashPassword,
                UserAvatar = "Defult.jpg",
                ActiveCode = NameGenerator.GeneratorUniqCode(),
                IsActive=true
            };
            _userService.AddUser(user);
            ViewBag.IsSuccess = true; ;
            return View("Active",user);
        }

        #endregion


        #region Login

        [Route("Login")]
        public IActionResult Login(bool EditProfile = false)
        {
            ViewBag.EditProfile = EditProfile;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {

            }
            var user = _userService.IsExistEmailAndPassword(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var Claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                    };
                    var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمیباشد");
                }

            }
            ModelState.AddModelError("Email", "کاربری با این مشخصات یافت نشد");
            return View(login);
        }
        #endregion


        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }
        #endregion


        #region ActiveAccount

        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = _userService.ActiveAccount(id);
            return View();
        }

        #endregion


        #region ForgotPassword

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid)
            {
                return View(forgot);
            }
            string FixdEmail = FixedText.FixeEmail(forgot.Email);
            User user = _userService.IsExistUserByUserEmail(FixdEmail);

            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری یافت نشد");
                return View(forgot);
            }

            return RedirectToAction("ResetForgotPassword", user);
        }
        #endregion


        #region ResetForgotPassword

        [Route("ResetForgotPassword")]
        public IActionResult ResetForgotPassword(User user)
        {
            ViewData["UserId"] = user.UserId;
            return View();
        }

        [Route("ResetForgotPassword")]
        [HttpPost]
        public IActionResult ResetForgotPassword(ResetForgotPasswordViewModel reset)
        {
            if (!ModelState.IsValid)
            {
                return View(reset);
            }

            var user = _userService.GetUserByUserId(reset.UserId);
            string hashPassword = PasswordHelper.EncodePasswordMd5(reset.Password);
            user.Password = hashPassword;
            _userService.UpdateUser(user);

            ViewBag.IsSuccess = true;
            return View();
        }

        #endregion
    }
}
