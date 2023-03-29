using Authentication.Models;
using Authentication.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Register([FromBody] Registration registration)
        {
            var jwt = new JwtSecurityToken();
            var user = new IdentityUser { UserName= registration.Email, Email=registration.Email };
           var result = await _userManager.CreateAsync(user, registration.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            _signInManager.SignInAsync(user, false);
            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
        [HttpGet]
        public ViewResult Register(AccountRegisterViewModel model)
        {
            return View(model);
        }

    }
}
