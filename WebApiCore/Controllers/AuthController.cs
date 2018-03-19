using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebApiCore.DTO;

namespace WebApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth/[action]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public object GetToken([FromBody]ValidateDto validateDto)
        {
            var key = "WebApiTestingKey";

            if (validateDto.Account == validateDto.Password)
            {
                var claims = new[] {
                    new Claim(ClaimTypes.Name, validateDto.Account)
                };

                var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), 
                                                   SecurityAlgorithms.HmacSha256);
                
                var token = new JwtSecurityToken(
                     claims: claims,
                     expires: DateTime.Now.AddHours(1),
                     signingCredentials: creds
                    );

                var responseToken = new { token = new JwtSecurityTokenHandler().WriteToken(token) };
                return Ok(responseToken);

            }
            else
            {
                return BadRequest("wrong account or password");
            }
        }
    }
}