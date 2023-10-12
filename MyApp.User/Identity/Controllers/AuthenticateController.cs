using Identity.DAL.Interfaces;
using Identity.DAL.Models;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SupplierMaster.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Controllers
{
    [Route("api/authenticate/supplier")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ISupplierService _supplierService;
        private readonly ICommonService _commonService;
        private readonly IConfiguration _configuration; 
        private readonly IEmail _email ;
        private readonly ILog _logger;

        public AuthenticateController(
            ISupplierService supplierService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, ICommonService commonService, IEmail email,ILog logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _supplierService = supplierService;
            _configuration = configuration;
            _commonService = commonService;
            _email = email;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = GetToken(authClaims);
                    await _logger.Log(model.Username, "LoginSuccess", "Success");
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                await _logger.Log(model.Username, "LoginFailed", "UnauthorizedUser");
                return Unauthorized();
            }
            catch(Exception ex)
            {
                await _logger.Log(model.Username, "LoginFailed", ex.Message);
                throw;
            }
        }

    ////    try
    ////{
    ////    string UserType = Convert.ToInt32(dt.Rows[0]["parentID"]) == 0 ? "Agent" : "SubAgent";
    ////    var authClaims = new[]
    ////    {
    ////        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    ////        new Claim("UserId",Convert.ToString(dt.Rows[0]["UserId"])),
    ////        new Claim("UserType",UserType),
    ////        new Claim("ParentID",Convert.ToString(0)),
    ////        new Claim("EmailID",Convert.ToString(dt.Rows[0]["EmailID1"])),

    ////    };
    ////    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwttoken.SigningKey));
    ////    var token = new JwtSecurityToken(
    ////        issuer: _jwttoken.Site,
    ////        audience: _jwttoken.Site,
    ////        claims: authClaims,
    ////        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
    ////    );
    ////    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
    ////    var tmp = new Tuple<string>(encodedJwt);
    ////    return await Task.FromResult(tmp);
    ////}

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username ,
                
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            
                await _userManager.AddToRoleAsync(user, UserRoles.User);
                
                model.UserId=user.Id;
                model.SupplierCode = "SUPP-001";
                await _supplierService.SaveSupplier(model);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
                //EmailHelper emailHelper = new EmailHelper();
                //bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);
                //Email obj = new Email();
                await _email.SendEmail(user.Email, "", "Confirm Email", null, false, "", "");

                //if (emailResponse)

                //else
                //{
                //    // log email failed 
                //}
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {

            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User not exists!" });

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!resetPassResult.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Reset Password is failed" });

            return Ok(new Response { Status = "Success", Message = "Reset Password is successful!" });
        }

        [HttpPost]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword( string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User not exists!" });

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
            ////EmailHelper emailHelper = new EmailHelper();
            ////bool emailResponse = emailHelper.SendEmailPasswordReset(user.Email, link);
            return Ok(new Response { Status = "Success", Message = "Forgot password link is sent!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}

////    try
////{
////    string UserType = Convert.ToInt32(dt.Rows[0]["parentID"]) == 0 ? "Agent" : "SubAgent";
////    var authClaims = new[]
////    {
////        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
////        new Claim("UserId",Convert.ToString(dt.Rows[0]["UserId"])),
////        new Claim("UserType",UserType),
////        new Claim("ParentID",Convert.ToString(0)),
////        new Claim("EmailID",Convert.ToString(dt.Rows[0]["EmailID1"])),

////    };
////    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwttoken.SigningKey));
////    var token = new JwtSecurityToken(
////        issuer: _jwttoken.Site,
////        audience: _jwttoken.Site,
////        claims: authClaims,
////        signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
////    );
////    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
////    var tmp = new Tuple<string>(encodedJwt);
////    return await Task.FromResult(tmp);
////}
