using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L4_3_WebApi_Identity.Data;
using L4_3_WebApi_Identity.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace L4_3_WebApi_Identity.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public UsersController(SqlDbContext context)
        {
            _context = context;
        }




        // GET: api/Users//hämta alla users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }





        // GET: api/Users/5
        [HttpGet("{id}")]  //hämta specifik user
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }






        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }






        // POST: api/Users//skapa

        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}
        [AllowAnonymous]
        [HttpPost("register")]

        public async Task<ActionResult<User>> Register([FromBody] RegisterModel model)
        {
            if (_context.Users.Any(user => user.Email == model.Email)) //om vi hitta user med samma email
                return Conflict(); //error msg 401

            try   //annars /kan ha automapper
            {
                var user = new User()
                //var user = new User(model.FirstName, model.LastName, model.Email).CreatePasswordHash(model.Password)
                //++tomt ctor i User.cs ++ctor (4 prop from usermodel)  //här-med error
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };

                user.CreatePasswordHash(model.Password);//hantera password

                _context.Users.Add(user);//skapa
                await _context.SaveChangesAsync();
            }
            catch //400 error
            {
                return new BadRequestResult();
            }

            return new OkResult();
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return new BadRequestObjectResult("Invalid Email or Password");

            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(user => user.Email == model.Email);

                if (user == null)
                    return new BadRequestObjectResult("User Not Found");

                if (!user.ValidatePasswordHash(model.Password))
                    return new BadRequestObjectResult("Invalid Email or Password");


                var tokenHandler = new JwtSecurityTokenHandler();
                var secretKey = Encoding.UTF8.GetBytes(Configuration.GetSection("SecretKey").Value);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),

                    Expires = DateTime.UtcNow.AddDays(7),

                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(secretKey),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return new OkObjectResult(new
                {
                    Id = user.Id,
                    Email = user.Email,
                    Token = tokenString
                });

            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }




        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
