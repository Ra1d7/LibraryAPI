using API.Context;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ElibraryDbContext _context;

        public record UserData(string email, string password);
        public record User(string username,int Id,string Role);
        public AuthenticationController(IConfiguration config, ElibraryDbContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpPost]
        [Route("CreateToken")]
        [AllowAnonymous]
        public IActionResult GetToken([FromBody]UserData data)
        {
            var user = CheckData(data);
            return (user is null) ? Unauthorized() : Ok(GenToken(user));
        }

        private IUser? CheckData(UserData data) 
        {
            var user = data.email;
            var hash = Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(data.password)));
            var borrower = _context.Borrowers.FirstOrDefault(x => x.Contact.Email == user);
            var author = _context.Authors.FirstOrDefault(x => x.Contact.Email == user);
            var publisher = _context.Authors.FirstOrDefault(x => x.Contact.Email == user);
            if (borrower != null && borrower.Password == hash) return borrower;
            if (author != null && author.Password == hash) return author;
            if (publisher != null && publisher.Password == hash) return publisher;
            return null;
        }
        private string? GenToken(IUser user)
        {
            string email = _context.ContactDetails.Where(x => x.ContactId == user.ContactId).FirstOrDefault()!.Email!;
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Authentication:SecretKey")));
            var SigningCreds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new();
            claims.Add(new(JwtRegisteredClaimNames.Sub, email));
            claims.Add(new("Role", user.GetType().Name));
            var token = new JwtSecurityToken(
                _config.GetValue<string>("Authentication:Issuer"),
                _config.GetValue<string>("Authentication:Audience"),
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(1),
                SigningCreds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
