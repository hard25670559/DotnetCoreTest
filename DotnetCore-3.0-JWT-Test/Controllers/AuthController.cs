using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DotnetCore_3._0_JWT_Test.Controllers
{

    public class LoginModel
    {
        public string name { get; set; }
        public string password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration Config;

        public AuthController(IConfiguration configuration)
        {
            this.Config = configuration;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel login)
        {
            string md5 = string.Empty;
            using (MD5 bryptoMD5 = MD5.Create())
            {
                byte[] tmp = Encoding.UTF8.GetBytes(login.password + Guid.NewGuid().ToString());
                byte[] hash = bryptoMD5.ComputeHash(tmp);
                md5 = BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();
            }

            ClaimsIdentity userClaims = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, login.name),
                new Claim(JwtRegisteredClaimNames.Jti, md5),
                new Claim("CustomClaim", "WTF")
            });

            SymmetricSecurityKey securityKey = 
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Config["Jwt:Key"]));
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = this.Config["Jwt:Issuer"],
                Audience = this.Config["Jwt:Issuer"],
                Subject = userClaims,
                Expires = new DateTime(2020, 1, 1),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string serializeToken = tokenHandler.WriteToken(token);

            return Ok(new
            {
                token = serializeToken
            });
        }

    }
}