using System.IO;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Core.ViewModels;
using Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Web.Areas.Controllers
{
    [Area("User")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserServices _user;
        private readonly ICommonServices _common;
        private readonly IViewRenderService _render;
        public HomeController(IUserServices user, ICommonServices common, IViewRenderService render)
        {
            this._render = render;
            this._common = common;
            this._user = user;
        }
        [Route("/Account")]
        public async Task<IActionResult> Index()
        {
            var model = await _user.GetUserAccount(int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
            return View(model);
        }
        [Route("/Account/edite")]
        public async Task<IActionResult> Edite()
        {
            var user = await _user.GetUserById(int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
            var model = new EditeAccountViewModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                Phone = user.PhoneNumber
            };
            return View(model);
        }
        [Route("/Account/edite")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edite(EditeAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.GetUserById(int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
                if (user == null)
                    return NotFound();
                user.UserName = model.UserName;
                user.PhoneNumber = model.Phone;
                if (model.Image != null)
                {
                    if (!_common.FilterImage(Path.GetExtension(model.Image.FileName)))
                    {
                        ViewBag.Error = "یک عکس معتبر وارد کنید";
                        return View(model);
                    }
                    user.UserAvatar = await _common.UploadImage(model.Image, "user");
                }
                if (user.Email != model.Email)
                {
                    user.Email = model.Email;
                    var emailModel = new ActiveAccountViewModel
                    {
                        Url = Url.Action(nameof(ChangeEmail), "Home", new { email = user.Email, secureCode = user.SecureCode }, Request.Scheme),
                        userName = user.UserName
                    };
                    var body = await _render.RenderToStringAsync("_EmailActiveAccount", emailModel);
                    SendEmail.Send(user.Email, "فعال کردن حساب کاربری", body);
                    user.IsActive = false;
                }
                await _user.Update(user);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Redirect("/Login");
            }
            return View(model);
        }
        public async Task<IActionResult> ChangeEmail(string email, string secureCode)
        {
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(secureCode))
                return BadRequest();
            var user = await _user.GetUserByEmail(email);
            var check = user.SecureCode == secureCode;
            if (user == null || !check)
                return BadRequest();
            user.SecureCode = RandowString.GetString(150);
            user.IsActive = true;
            return Redirect("/Login");
        }
        [Route("/Account/ResetPassword")]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [Route("/Account/ResetPassword")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _user.GetUserById(int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
                if (user == null)
                    return NotFound();
                var check = user.Password == model.CurrectPassword;
                if (!check)
                {
                    ViewBag.Error = "رمز عبور فعلی اشتباه می باشد";
                    return View(model);
                }
                user.Password = PasswordHelper.EncodePasswordMd5(model.NewPassword);
                await _user.Update(user);
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Redirect("/Login");
            }
            return View(model);
        }
        [Route("/Account/Cart")]
        public async Task<IActionResult> GetCart()
        {
            var model = await _user.GetCart(int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
            return View(model);
        }
        [Route("/Account/AddCart")]
        [HttpPost]
        public async Task<IActionResult> AddCart(AddCartViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _user.AddCart(model, int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
                return Redirect($"/product/{model.ProductId}?succes=true");
            }
            return Redirect("/");
        }
    }
}
