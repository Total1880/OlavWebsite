using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlavWebsite.Core;
using OlavWebsite.Data;

namespace OlavWebsite.Pages.C2
{
    public class CreateModel : PageModel
    {
        private readonly OlavWebsite.Data.OlavWebsiteDbContext _context;

        public CreateModel(OlavWebsite.Data.OlavWebsiteDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cookie Cookie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CookieList.Add(Cookie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
