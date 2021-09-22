using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorTeste.Pages
{
    public class HelloWorldModel : PageModel
    {
        private readonly ILogger<HelloWorldModel> _logger;

        public HelloWorldModel(ILogger<HelloWorldModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
