using Authentication.Models;
using Authentication.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authentication.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register( Registration register)
        {
            var jwt = new JwtSecurityToken();
            var user = new IdentityUser { UserName= register.Email, Email=register.Email };
           var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            await _signInManager.SignInAsync(user, false);

            //return Ok(new JwtSecurityTokenHandler().WriteToken(jwt)); 
            return RedirectToAction("Index", "Home");
            
        }
        [HttpGet]
        public ViewResult Register(AccountRegisterViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public  IActionResult SignOut()
        {
          _signInManager.SignOutAsync();
          return RedirectToAction("Index", "Home");
        }

    }
}
