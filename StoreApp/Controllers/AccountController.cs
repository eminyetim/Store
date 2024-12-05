using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {   
            if(ModelState.IsValid)
            {
                IdentityUser user = await  _userManager.FindByNameAsync(model.Name);
                if(user is not null)
                {
                    await _singInManager.SignOutAsync();
                    if((await _singInManager.PasswordSignInAsync(user,model.Password,false,false)).Succeeded)
                    {
                        return Redirect(model?._returnurl ?? "/");
                    }
                }
                ModelState.AddModelError("Error","Invalid username or password.");
            }
            return View();
        }
    }
}