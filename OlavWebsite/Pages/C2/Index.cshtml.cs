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
    public class IndexModel : PageModel
    {
        private readonly OlavWebsite.Data.OlavWebsiteDbContext _context;

        public IndexModel(OlavWebsite.Data.OlavWebsiteDbContext context)
        {
            _context = context;
        }

        public IList<Cookie> Cookie { get;set; }

        public async Task OnGetAsync()
        {
            Cookie = await _context.CookieList.ToListAsync();
        }
    }
}
