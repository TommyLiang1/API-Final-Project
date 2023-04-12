using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChattingAPI.Models;
using NuGet.Protocol;
using Microsoft.AspNetCore.Connections.Features;

namespace ChattingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ChattingAPIDBContext _context;

        public UserController(ChattingAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<Response>> GetUsers()
        {
            var res = new Response();

            var users = await _context.User.Include(i => i.UserInfo).ToListAsync();

            if (users.Count > 0)
            {
                res.User = users;
                res.statusCode = 200;
                res.statusDescription = "Users retrieved!";
            }
            else
            {
                res.statusCode = 404;
                res.statusDescription = "There are no users!";
            }
            return res;
        }

        // GET: api/User/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetUser(int id)
        {
            var res = new Response();

            var user = await _context.User.Where(user => user.UserId == id).Include(i => i.UserInfo).ToListAsync();

            if (user.Count > 0)
            {
                res.User = user;
                res.statusCode = 200;
                res.statusDescription = "User " + id + " retrieved!";
            }
            else
            {
                res.statusCode = 404;
                res.statusDescription = "User " + id + " doesn't exist!";
            }
            return res;
        }

        // PUT: api/User/:id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
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

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<Response>> PostUser(User user)
        {
            var res = new Response();
            try
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                res.statusCode = 201;
            }
            catch (DbUpdateConcurrencyException)
            {
                res.statusCode = 400;
                res.statusDescription = "Can't create user due to missing credentials";
                return res;
            }

            var newUser = await _context.User.Where(i => i.UserId == user.UserId).ToListAsync();
            res.User = newUser;
            res.statusDescription = "Created user!";
            return res;
        }

        // DELETE: api/User/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteUser(int id)
        {
            var res = new Response();
            var user = await _context.User.FindAsync(id);
           
            if(user == null)
            {
                res.statusCode = 400;
                res.statusDescription = "User " + id + " doesn't exist!";
                return NotFound(res);
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            res.statusCode = 200;
            res.statusDescription = "Deleted user!";
            return res;
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
