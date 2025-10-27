using Cars_WebAPI.Areas.Identity.Data;
using Cars_WebAPI.Data;
using Cars_WebAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cars_WebAPI.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<Cars_WebAPIUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public UserController(
             UserManager<Cars_WebAPIUser> userManager,
             ApplicationDbContext context,
             IConfiguration configuration
         )
        {
            _configuration = configuration;
            _userManager = userManager;
            _context = context;
        }

        [Route("Login")] // /login
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var guid = Guid.NewGuid().ToString();
                // https://datatracker.ietf.org/doc/html/rfc7519#section-4
                var claims = new List<Claim> {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, guid),
            new Claim(JwtRegisteredClaimNames.NameId, user.Id)
        };

                var roles = await _userManager.GetRolesAsync(user);

                foreach (var role in roles)
                {
                    var roleClaim = new Claim(ClaimTypes.Role, role);
                    claims.Add(roleClaim);
                }

                var signingKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: _configuration["Jwt:Site"],
                  audience: _configuration["Jwt:Site"],
                  claims: claims,
                  expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(
                  new
                  {
                      access_token = new JwtSecurityTokenHandler().WriteToken(token),
                      userName = model.Username,
                      expiration = token.ValidTo
                  });
            }
            return Unauthorized();
        }
    }
}
