using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication.Pages
{
    public class BrowseModel : PageModel
    {
        private readonly ILogger<BrowseModel> logger;

        public BrowseModel(ILogger<BrowseModel> logger) {
            this.logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
