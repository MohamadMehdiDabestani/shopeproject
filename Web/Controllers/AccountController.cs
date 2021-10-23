using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.ViewModels;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly IUserServices _user;

        private readonly IViewRenderService _render;
        public AccountController(IUserServices user, IViewRenderService render)
        {
            this._user = user;
            this._render = render;
        }
        [Route("/Register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Account");
            }
            return View();
        }
        [ValidateAntiForgeryToken]
        [Route("/Register")]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _user.AnyEmail(model.Email))
                {
                    ViewBag.Error = "ایمیل از قبل وارد شده";
                    return View(model);
                }
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    RegisterDate = DateTime.Now,
                    UserAvatar = "user.jpg",
                    SecureCode = RandowString.GetString(150),
                    Password = PasswordHelper.EncodePasswordMd5(model.Password),
                    PhoneNumber = "0"
                };
                await _user.AddUser(user);
                var emailModel = new ActiveAccountViewModel
                {
                    Url = Url.Action(nameof(ActivateAccount), "Account", new { email = user.Email, secureCode = user.SecureCode }, Request.Scheme),
                    userName = user.UserName
                };
                var body = await _render.RenderToStringAsync("_EmailActiveAccount", emailModel);
                SendEmail.Send(user.Email, "فعال کردن حساب کاربری", body);
                ViewBag.Succes = true;
                return View();
            }
            return View(model);
        }
        [Route("/Account/ActiveAccount")]
        public async Task<ActionResult> ActivateAccount(string email, string secureCode)
        {
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(secureCode))
            {
                return Redirect("/");
            }
            var user = await _user.GetUserByEmail(email);
            var check = user.SecureCode == secureCode;
            if (user == null || !check)
            {
                return NotFound();
            }
            user.IsActive = true;
            user.SecureCode = RandowString.GetString(150);
            await _user.Update(user);
            return Redirect("/Login?active=true");
        }

        [Route("/Login")]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Account");
            }
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("/Login")]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.GetUserByEmail(model.Email);

                if (user == null || !user.IsActive)
                {
                    ViewBag.Error = "کاربری یافت نشد";
                    return View(model);
                }
                var check = PasswordHelper.EncodePasswordMd5(model.Password) == user.Password;
                if (!check)
                {
                    ViewBag.Error = "کاربری یافت نشد";
                    return View(model);
                }
                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim("Type" , user.RoleId == 1 ? "Admin" : "User")
                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = model.RemmeberMe,
                };
                await HttpContext.SignInAsync(principal, properties);
                if (!string.IsNullOrEmpty(model.Redirect))
                {
                    if (Url.IsLocalUrl(model.Redirect))
                    {
                        return Redirect(model.Redirect);
                    }
                    else
                    {
                        return Redirect("/Account");
                    }
                }
                return Redirect("/Account");
            }
            return View(model);
        }
        [Route("/Home/ChangeEmail")]
        public async Task<IActionResult> ChangeEmail(string email, string secureCode)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(secureCode))
                return BadRequest();
            var user = await _user.GetUserByEmail(email);
            var check = user.SecureCode == secureCode;
            if (user == null || !check)
                return BadRequest();
            user.SecureCode = RandowString.GetString(150);
            user.IsActive = true;
            await _user.Update(user);
            return Redirect("/Login");
        }
        [Route("/Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Redirect("/");
            }
            return Redirect("/");
        }
        [Route("/Account/ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
                return Redirect("/Account");
            return View();
        }
        [HttpPost]
        [Route("/Account/ForgotPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _user.AnyEmail(model.Email))
                {
                    var user = await _user.GetUserByEmail(model.Email);
                    var emailModel = new ActiveAccountViewModel
                    {
                        Url = Url.Action(nameof(EnterNewPassword), "Account", new { email = user.Email, secureCode = user.SecureCode }, Request.Scheme),
                        userName = user.UserName
                    };
                    var body = await _render.RenderToStringAsync("_EmailForgotPassword", emailModel);
                    SendEmail.Send(user.Email, "فراموشی رمز عبور", body);
                    ViewBag.Succes = true;
                    return View();
                }
                else
                {
                    ViewBag.Error = true;
                    return View(model);
                }
            }
            return View(model);
        }
        [Route("/Account/EnterNewPassword")]
        public async Task<IActionResult> EnterNewPassword(string email, string secureCode)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(secureCode))
                return BadRequest();
            var user = await _user.GetUserByEmail
            (email);
            var check = user.SecureCode == secureCode;
            if (user == null || !check)
                return BadRequest();
            user.SecureCode = RandowString.GetString(150);
            var model = new EnterNewPasswordViewModel
            {
                UserId = user.Id
            };
            return View(model);
        }
        [Route("/Account/EnterNewPassword")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EnterNewPassword(EnterNewPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.GetUserById(model.UserId);
                if (user == null)
                    return NotFound();
                user.Password = PasswordHelper.EncodePasswordMd5(model.Password);
                await _user.Update(user);
                return Redirect("/login");
            }
            return View(model);
        }

    }

}