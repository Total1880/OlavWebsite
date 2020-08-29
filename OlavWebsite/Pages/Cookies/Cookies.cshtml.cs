using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OlavWebsite.Core;
using OlavWebsite.Data;

namespace OlavWebsite.Pages
{
    public class CookiesModel : PageModel
    {
        private readonly ICookieData _cookieData;
        private readonly ILogger<CookiesModel> _logger;

        public IEnumerable<Cookie> Cookies{ get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public CookiesModel(ICookieData cookieData, ILogger<CookiesModel> logger)
        {
            _cookieData = cookieData;
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError("Executing Cookiesmodel");
            Cookies = _cookieData.GetCookiesByName(SearchTerm);
        }
    }
}