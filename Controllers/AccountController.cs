using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr,
            SignInManager<IdentityUser> signInMgr)
        {
            this.userManager = userMgr;
            this.signInManager = signInMgr;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await this.userManager
                    .FindByNameAsync(loginModel.Name);

                if (user != null)
                {
                    if ((await this.signInManager.PasswordSignInAsync(user,
                        loginModel.Password,false,false)).Succeeded)
                    {
                        return Redirect(loginModel.ReturnUrl ??
                            "/Admin/Index");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid name or password!");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await this.signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}