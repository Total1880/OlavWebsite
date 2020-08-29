using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlavWebsite.Core;
using OlavWebsite.Data;

namespace OlavWebsite.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookiesController : ControllerBase
    {
        private readonly OlavWebsiteDbContext _context;

        public CookiesController(OlavWebsiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Cookies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cookie>>> GetCookieList()
        {
            return await _context.CookieList.ToListAsync();
        }

        // GET: api/Cookies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cookie>> GetCookie(int id)
        {
            var cookie = await _context.CookieList.FindAsync(id);

            if (cookie == null)
            {
                return NotFound();
            }

            return cookie;
        }

        // PUT: api/Cookies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookie(int id, Cookie cookie)
        {
            if (id != cookie.Id)
            {
                return BadRequest();
            }

            _context.Entry(cookie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CookieExists(id))
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

        // POST: api/Cookies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cookie>> PostCookie(Cookie cookie)
        {
            _context.CookieList.Add(cookie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCookie", new { id = cookie.Id }, cookie);
        }

        // DELETE: api/Cookies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cookie>> DeleteCookie(int id)
        {
            var cookie = await _context.CookieList.FindAsync(id);
            if (cookie == null)
            {
                return NotFound();
            }

            _context.CookieList.Remove(cookie);
            await _context.SaveChangesAsync();

            return cookie;
        }

        private bool CookieExists(int id)
        {
            return _context.CookieList.Any(e => e.Id == id);
        }
    }
}
