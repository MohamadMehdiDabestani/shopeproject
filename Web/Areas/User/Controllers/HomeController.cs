using System.Reflection.Metadata;
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
using Data.Models;
using Microsoft.Extensions.Configuration;

namespace Web.Areas.Controllers
{
    [Area("User")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserServices _user;
        private readonly ICommonServices _common;
        private readonly IViewRenderService _render;
        private readonly IConfiguration _config;
        public HomeController(IUserServices user, ICommonServices common, IViewRenderService render, IConfiguration config)
        {
            this._config = config;
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
                Phone = user.PhoneNumber,
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
                        Url = $"{_config["Url"]}/Home/ChangeEmail?email={user.Email}&secureCode={user.SecureCode}",
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
                var check = user.Password == PasswordHelper.EncodePasswordMd5(model.CurrectPassword);
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
        [Route("/Account/AddWhishList")]
        public async Task<IActionResult> AddWhishList(int productId)
        {
            var whishList = new WhishList()
            {
                ProductId = productId,
                UserId = int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value)
            };
            await _user.AddWhishList(whishList);
            return Redirect($"/product/{productId}?succes=true");
        }
        [Route("/Account/Wishlist")]
        public async Task<IActionResult> GetWishlist()
        {
            var model = await _user.GetWishList(int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
            return View(model);
        }
        [Route("/Account/DeleteWish")]
        public async Task<IActionResult> DeleteWish()
        {
            await _user.DeleteWish(0, int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
            return Redirect("/Account/WishList");
        }

        [Route("/Account/DeleteWish/{id}")]
        public async Task<IActionResult> DeleteWish(int id)
        {
            await _user.DeleteWish(id, int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
            return Redirect("/Account/WishList");
        }
        [Route("/Account/DeleteCart")]
        public async Task<IActionResult> DeleteCart()
        {
            await _user.DeleteCart(0, int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
            return Redirect("/Account/Cart");
        }
        [Route("/Account/DeleteCart/{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _user.DeleteCart(id, int.Parse(User.Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value));
            return Redirect("/Account/Cart");
        }
        [Route("/Account/UpdateCart")]
        [HttpPost]
        public async Task<IActionResult> UpdateCart(UpdateCartViewModel model)
        {
            await _user.UpdateCart(model);
            return Redirect("/Account/Cart");
        }
        [HttpGet]
        [Route("/Account/Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        [Route("/Account/Checkout")]
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Price += 20000;
                int userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
                var walletprice = await _user.GetWalletPrice(userId);
                if (walletprice >= model.Price)
                {
                    var products = await _user.GetProductsOfCart(userId);
                    var factor = new Factor()
                    {
                        Count = model.TotalCount,
                        Addres = model.Addres,
                        CreateDate = DateTime.Now,
                        LastName = model.LastName,
                        Phone = model.PhoneNumber,
                        PostalCode = model.PostalCode,
                        UserId = userId,
                        Status = "PROCESSING",
                        Price = model.Price,
                        UserName = model.UserName,
                        products = products
                    };
                    products.ForEach(p => p.Quantity -= model.TotalCount);
                    await _user.AddFactor(factor, products);
                    return Redirect("/Account/Order");
                }
                ViewBag.Error = true;
                return View(model);
            }
            return View(model);
        }
        [Route("/Account/Wallet")]
        public async Task<IActionResult> Wallet()
        {
            return View();
        }

        [Route("/Account/Wallet")]
        [HttpPost]
        public async Task<IActionResult> Wallet(ChargeWalletViewModel model)
        {
            if (ModelState.IsValid)
            {
                var transaction = new Transaction
                {
                    CreateDate = DateTime.Now,
                    Status = true,
                    Price = model.Price,
                    WalletId = model.WalletId
                };
                await _user.ChargeWallet(transaction);
                return Redirect("/Account/Wallet");
            }
            return View(model);
        }
        [Route("/Account/CreateWallet")]
        public async Task<IActionResult> CreateWallet()
        {
            await _user.CreateWallet(int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
            return Redirect("/Account/Wallet");
        }
        [Route("/Account/Order")]
        public async Task<IActionResult> Order()
        {
            var model = await _user.GetAllOrder(int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value));
            return View(model);
        }
        [Route("/Account/Order/Details/{id}")]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var model = await _user.GetOrder(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
    }
}
