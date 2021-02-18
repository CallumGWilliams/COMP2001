using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2001API.Models;
using Microsoft.Data.SqlClient;

namespace _2001API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly COMP2001_CGormanWilliamsContext _context;

        public UsersController(COMP2001_CGormanWilliamsContext context)
        {
            _context = context;
        }

        //// GET: api/Users
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //  var user = await _context.Users.FindAsync(id);

        //if (user == null)
        //     {
        //return NotFound();
        //   }

        // return user;
        //}

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        //}

        // DELETE: api/Users/5


        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.UserId == id);
        //}

        [HttpPost]
        public IActionResult Register(User user)
        {
            var rowsAffected = _context.Database.ExecuteSqlRaw("EXEC Register @FirstName, @LastName, @Email, @Password",

                new SqlParameter("@FirstName", user.FirstName),
                new SqlParameter("@LastName", user.LastName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password));

            Console.WriteLine(rowsAffected);
            return Ok();

        }

        [HttpGet]
        public IActionResult ValidateUser([FromBody] ValidateUser user)
        {
            _context.Database.ExecuteSqlRaw("EXEC ValidateUser @Email, @Password",
                new SqlParameter("@Email", user.Email),
                new SqlParameter("Password", user.Password));

            if (user.Validated == 1)
            {
                 _context.Database.ExecuteSqlRaw("SELECT * FROM USERS");
                return Ok();
            }

            return BadRequest();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(User user)
        {
            _context.Database.ExecuteSqlRaw("EXEC UpdateUser @id, @Password",
                new SqlParameter("@id", user.UserId),
                new SqlParameter("@Password", user.Password));

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(User user)
        {
            _context.Database.ExecuteSqlRaw("EXEC DeleteUser @id",
                new SqlParameter("@id", user.UserId));

            return Ok();
             
        }
    }
}
