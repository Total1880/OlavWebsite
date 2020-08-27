using Microsoft.AspNetCore.Mvc;
using OlavWebsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlavWebsite.Pages.ViewComponents
{
    public class CookieCountViewComponent : ViewComponent
    {
        private readonly ICookieData _cookieData;

        public CookieCountViewComponent(ICookieData cookieData)
        {
            _cookieData = cookieData;
        }

        public IViewComponentResult Invoke()
        {
            var count = _cookieData.GetCountOfCookies();

            return View(count);
        }
    }
}
