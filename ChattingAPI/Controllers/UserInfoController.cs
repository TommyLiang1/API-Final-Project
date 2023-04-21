using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChattingAPI.Models;

namespace ChattingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ChattingAPIDBContext _context;

        public UserInfoController(ChattingAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/UserInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUserInfo()
        {
            if (_context.UserInfo == null)
            {
                return NotFound();
            }
            return await _context.UserInfo.ToListAsync();
        }
    }
}
