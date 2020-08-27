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
    public class DeleteModel : PageModel
    {
        private readonly ICookieData _cookieData;

        public Cookie Cookie { get; set; }

        public DeleteModel(ICookieData cookieData)
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

        public IActionResult OnPost(int cookieId)
        {
            var cookie =_cookieData.Delete(cookieId);
            _cookieData.Commit();

            if (cookie == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{cookie.Name} deleted";
            return RedirectToPage("./Cookies");
        }
    }
}