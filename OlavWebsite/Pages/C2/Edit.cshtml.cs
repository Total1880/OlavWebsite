using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OlavWebsite.Core;
using OlavWebsite.Data;

namespace OlavWebsite.Pages.C2
{
    public class EditModel : PageModel
    {
        private readonly OlavWebsite.Data.OlavWebsiteDbContext _context;

        public EditModel(OlavWebsite.Data.OlavWebsiteDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cookie Cookie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cookie = await _context.CookieList.FirstOrDefaultAsync(m => m.Id == id);

            if (Cookie == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cookie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CookieExists(Cookie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CookieExists(int id)
        {
            return _context.CookieList.Any(e => e.Id == id);
        }
    }
}
