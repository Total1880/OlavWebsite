using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OlavWebsite.Pages
{
    public class WhoAmIModel : PageModel
    {
        private readonly IConfiguration _config;

        public string Name { get; set; }
        public string Message { get; set; }

        public WhoAmIModel(IConfiguration config)
        {
            _config = config;
        }

        public void OnGet()
        {
            Name = "Olav Hendrickx";
            Message = _config["Message"];
        }
    }
}
