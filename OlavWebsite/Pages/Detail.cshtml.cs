using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OlavWebsite.Core;
using OlavWebsite.Data;

namespace OlavWebsite.Pages
{
    public class DetailModel : PageModel
    {
        private readonly ICookieData _cookieData;

        [TempData]
        public string Message { get; set; }
        public Cookie Cookie { get; set; }

        public DetailModel(ICookieData cookieData)
        {
            _cookieData = cookieData;
        }

        public IActionResult OnGet(int cookieId)
        {
            Cookie = _cookieData.GetById(cookieId);

            if (Cookie == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}