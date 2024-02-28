using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models.ViewModel;

namespace Resturant.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManger;

        public RoleController(RoleManager<IdentityRole> RoleManger)
        {
            roleManger = RoleManger;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel newRole)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = newRole.RoleName;
                IdentityResult result = await roleManger.CreateAsync(role);
                if (result.Succeeded)
                {
                    //////////
                    RedirectToAction("Index", "Home");
                    /////
                    //RedirectToAction("index", "");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(newRole);
        }
    }
}

