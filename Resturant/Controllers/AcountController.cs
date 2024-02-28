using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resturant.Models;
using Resturant.Models.ViewModel;

namespace Resturant.Controllers
{
    public class AcountController : Controller
    {
        private readonly UserManager<AppUser> mangerUser;
        private readonly SignInManager<AppUser> saginInManger;

        public AcountController(UserManager<AppUser> mangerUser,SignInManager<AppUser> SaginInManger)
        {
            this.mangerUser = mangerUser;
            saginInManger = SaginInManger;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register(CustomerViewModel custVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = custVM.FirstName + custVM.LastName;
                user.Email = custVM.Email;
                user.PhoneNumber = custVM.PhoneNumber;
                user.PasswordHash = custVM.Password;
                IdentityResult result = await mangerUser.CreateAsync(user,custVM.Password);
                if (result.Succeeded)
                {
                    await mangerUser.AddToRoleAsync(user, "User");
                    await saginInManger.SignInAsync(user, false);

                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }


            return View("login");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Login(LoginViewModel userlog)
        {
            if (ModelState.IsValid)
            {
                AppUser modeluser = await mangerUser.FindByNameAsync(userlog.userName);
                if (modeluser != null)
                {
                    bool found = await mangerUser.CheckPasswordAsync(modeluser,userlog.Password);
                    if(found)
                    {
                        await saginInManger.SignInAsync(modeluser, userlog.RememberMe);
                    }
                    else
                    {
                        ModelState.AddModelError("", "invalid User Name or Password");
                        return View(userlog);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Signout()
        {
            await saginInManger.SignOutAsync();

            return RedirectToAction("Login");
        }


    }
}
