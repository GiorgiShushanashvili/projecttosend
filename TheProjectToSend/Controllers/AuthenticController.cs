using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TheProjectToSend.Models;
using TheProjectToSend.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheProjectToSend.Controllers
{
    [Authorize]
    [Route("api/controller")]
    public class AuthenticController : Controller
    {
        private readonly IAuthService _service;
        private readonly TokenCredential _credential;

        public AuthenticController(IAuthService service, IOptions<TokenCredential> credential)
        {
            _service = service;
            _credential = credential.Value;
        }

        [AllowAnonymous]
        [HttpGet("login/user")]
        public async Task<IActionResult> LoginUser(string email, string password)
        {
            try
            {
                var activeuser = await _service.LoginUser(email, password);
                if (activeuser == null)
                    return NotFound("email or password is incorrect, try again");

                string tokenstring = GenerateToken(activeuser);

                return Ok(new {activeuser.Usermail,Token = tokenstring });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GenerateToken(Person person)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_credential.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, person.Usermail.ToString()),
                    new Claim(ClaimTypes.Role, person.Password.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}

