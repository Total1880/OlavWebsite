using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OlavWebsite.Core;
using OlavWebsite.Data;

namespace OlavWebsite.Pages.C2
{
    public class DetailsModel : PageModel
    {
        private readonly OlavWebsite.Data.OlavWebsiteDbContext _context;

        public DetailsModel(OlavWebsite.Data.OlavWebsiteDbContext context)
        {
            _context = context;
        }

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
    }
}
