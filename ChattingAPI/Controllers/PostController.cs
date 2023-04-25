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
    public class PostController : ControllerBase
    {
        private readonly ChattingAPIDBContext _context;

        public PostController(ChattingAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<Response>> GetPost()
        {
            var res = new Response();
            var posts = await _context.Post.ToListAsync();

            if (posts.Count > 0)
            {
                res.Post = posts;
                res.statusCode = 200;
                res.statusDescription = "Posts retrieved!";
            }
            else
            {
                res.statusCode = 404;
                res.statusDescription = "There are no posts!";
            }      
            return res;
        }

        // GET: api/Post/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetPost(int id)
        {
            var res = new Response();
            var post = await _context.Post.Where(post => post.PostId == id).ToListAsync();

            if (post.Count > 0)
            {
                res.Post = post;
                res.statusCode = 200;
                res.statusDescription = "Post " + id + " retrieved!";
            }
            else
            {
                res.statusCode = 404;
                res.statusDescription = "Post " + id + " doesn't exist!";
            }

            return res;
        }

        // PUT: api/Post/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutPost(int id, Post post)
        {
            var res = new Response();

            if (id != post.PostId)
            {
                res.statusCode = 404;
                res.statusDescription = "Post id and given id doesn't match";
                return BadRequest(res);
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    res.statusCode = 404;
                    res.statusDescription = "Post " + id + " doesn't exist!";
                    return NotFound(res);
                }
                else
                {
                    throw;
                }
            }

            res.statusCode = 404;
            res.statusDescription = "Post updated!";
            return res;
        }

        // POST: api/Post/:id
        [HttpPost]
        public async Task<ActionResult<Response>> PostPost(Post post)
        {
            var res = new Response();
            try
            {
                _context.Post.Add(post);
                await _context.SaveChangesAsync();
                res.statusCode = 201;
            }
            catch (DbUpdateConcurrencyException)
            {
                res.statusCode = 400;
                res.statusDescription = "Can't create post due to invalid arguments";
                return res;
            }

            var newPost = await _context.Post.Where(i => i.PostId == post.PostId).ToListAsync();
            res.Post = newPost;
            res.statusDescription = "Created post!";

            return res;
        }

        // DELETE: api/Post/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeletePost(int id)
        {
            var res = new Response();
            var post = await _context.Post.FindAsync(id);

            if (post == null)
            {
                res.statusCode = 400;
                res.statusDescription = "Post " + id + " doesn't exist!";
                return NotFound(res);
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            res.statusCode = 200;
            res.statusDescription = "Deleted post!";
            return res;
        }

        private bool PostExists(int id)
        {
            return (_context.Post?.Any(e => e.PostId == id)).GetValueOrDefault();
        }
    }
}
