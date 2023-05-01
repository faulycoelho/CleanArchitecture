using Clean.API.Models;
using Clean.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TokenController : ControllerBase
    {
        readonly IAuthenticate _authenticate;
        readonly IConfiguration _configuration;
        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate;
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
      
        public async Task<ActionResult> CreateUser([FromBody] Register model)
        {
            var result = await _authenticate.RegisterUser(model.Email, model.Password);
            if(result)
            {
                return Ok();
            }  
            return BadRequest(model);
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] Login model)
        {
            var result = await _authenticate.Authenticate(model.Email, model.Password);
            if (result)
            {
                return GenerateToken(model);
            }
            ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
            return BadRequest(ModelState);
        }

        private ActionResult<UserToken> GenerateToken(Login model)
        {
            //user declarations
            var claims = new[]
            {
                new Claim("email", model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //TokenId
            };

            //generate private key
            var privatekey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]!));

            //generate sign
            var credentials = new SigningCredentials(privatekey, SecurityAlgorithms.HmacSha256);

            //expiration
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //generate token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience : _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
