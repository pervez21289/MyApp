using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public EmailController(UserManager<IdentityUser> userManager)
        {
                      _userManager = userManager;
        }


        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string email,string token)
        {
            IdentityUser user= await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // Handle user not found
                var redirectResult = new RedirectResult("https://www.failed.com");
                return redirectResult;
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                var redirectResult = new RedirectResult("https://www.example.com");
                return redirectResult;
            }
            else
            {
                // Handle confirmation error
                var redirectResult = new RedirectResult("https://www.failed.com");
                return redirectResult;
            }
          
        }
    }
}
