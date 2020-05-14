using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookStore.API.DbContexts;
using BookStore.API.Entities;
using BookStore.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TokenController : ControllerBase
  {
    public IConfiguration _configuration;
   // private readonly UserContext _context;

    public TokenController(IConfiguration config)
    {
      _configuration = config;
   //   _context = context;
    }

    [HttpGet]
    public ActionResult GetToken()
    {
      //security key
      string securityKey = _configuration["Jwt:Key"];
      //string securityKey = "security_key_for_bookstore$2020";
      //symmetric security key
      var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

      //signing credentials
      var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

      //add claims
      var claims = new List<Claim>();
      claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
      claims.Add(new Claim(ClaimTypes.Role, "Reader"));
     // claims.Add(new Claim("Our_Custom_Claim", "Our custom value"));


      //create token
      var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Issuer"],
              audience: _configuration["Jwt:Audience"],
              expires: DateTime.Now.AddHours(1),
              signingCredentials: signingCredentials
              , claims: claims
          );

      //return token
      return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }

    //[HttpPost]
    //public async Task<IActionResult> Post(User _userData)
    //{

    //  if (_userData != null && _userData.Email != null && _userData.Password != null)
    //  {
    //    var user = await GetUser(_userData.Email, _userData.Password);

    //    if (user != null)
    //    {
    //      //create claims details based on the user information
    //      var claims = new[] {
    //                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
    //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
    //                new Claim("Id", user.UserId.ToString()),
    //                new Claim("FirstName", user.FirstName),
    //                new Claim("LastName", user.LastName),
    //                new Claim("UserName", user.UserName),
    //                new Claim("Email", user.Email)
    //               };

    //      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

    //      var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //      var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

    //      return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    //    }
    //    else
    //    {
    //      return BadRequest("Invalid credentials");
    //    }
    //  }
    //  else
    //  {
    //    return BadRequest();
    //  }
    //}

    //private async Task<User> GetUser(string email, string password)
    //{
    //  return await _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
    //}
  }
}