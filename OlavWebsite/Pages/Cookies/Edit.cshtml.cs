using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlavWebsite.Core;
using OlavWebsite.Data;

namespace OlavWebsite.Pages
{
    public class EditModel : PageModel
    {
        private readonly ICookieData _cookieData;
        [BindProperty]
        public Cookie Cookie { get; set; }
        public IEnumerable<SelectListItem> CookieTypes { get; set; }
        public IHtmlHelper _htmlHelper { get; }

        public EditModel(ICookieData cookieData, IHtmlHelper htmlHelper)
        {
            _cookieData = cookieData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? cookieId)
        {
            CookieTypes = _htmlHelper.GetEnumSelectList<CookieType>();
            if (cookieId.HasValue)
            {
                Cookie = _cookieData.GetById(cookieId.Value);
            }
            else
            {
                Cookie = new Cookie();
            }

            if (Cookie == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CookieTypes = _htmlHelper.GetEnumSelectList<CookieType>();

                return Page();
            }

            if (Cookie.Id > 0)
            {
                Cookie = _cookieData.Update(Cookie);
            }
            else
            {
                Cookie = _cookieData.Add(Cookie);
            }

            _cookieData.Commit();
            TempData["Message"] = "Cookie saved!";

            return RedirectToPage("./Detail", new { cookieId = Cookie.Id });
        }
    }
}