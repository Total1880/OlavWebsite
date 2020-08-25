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
    public class CookiesModel : PageModel
    {
        private readonly ICookieData _cookieData;

        public IEnumerable<Cookie> Cookies{ get; set; }

        public CookiesModel(ICookieData cookieData)
        {
            _cookieData = cookieData;
        }

        public void OnGet()
        {
            Cookies = _cookieData.GetAllCookies();
        }
    }
}