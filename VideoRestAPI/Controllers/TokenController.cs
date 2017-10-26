using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using VideoRestAPI.Helpers;
using VideoRestAPI.Models;

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("/token")]
    public class TokenController : Controller
    {
        private readonly BllFacade _facade = new BllFacade();

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _facade.UserService.GetAll()
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new
                {
                    username = user.Username,
                    token = GenerateToken(user)
                });
            }
        }


        private string GenerateToken(UserBO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    JwtSecurityKey.Key,
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null,
                    null,
                    claims,
                    DateTime.Now,
                    DateTime.Now.AddDays(1)));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}