using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TurulFoods.Models;
using Microsoft.AspNetCore.Authorization;


namespace TurulFoods.Controllers
{
    public class AccountController : Controller
    {
       // [HttpGet]
       
        public ViewResult Register() => View();
        public IActionResult EventsAccount()
        {
            return View(repo.Products);
        }
        public ViewResult Login() => View();
        //public ViewResult Order() => View();
        public ViewResult UserPage() => View();
        private IProductRepo repo;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public AccountController(UserManager<User> usrMgr, SignInManager<User> signinMgr, IProductRepo repository)
        {
            userManager = usrMgr;
            signInManager = signinMgr;
            repo = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("UserPage", "Account");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }


            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(details.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(
                            user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        Response.Cookies.Append("UserID", user.UserID.ToString());
                        Response.Cookies.Append("UserName", user.UserName);
                        //Response.Cookies.Append(user.UserId.ToString(), user.UserName);

                        //return RedirectToAction("userPage");
                        return RedirectToAction("UserPage", "Account");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Name),
                    "Invalid user or password");
            }

            return View(details);
        }
    }
}