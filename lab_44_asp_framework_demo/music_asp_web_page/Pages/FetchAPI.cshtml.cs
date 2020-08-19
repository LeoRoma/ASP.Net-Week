using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace music_asp_web_page.Pages
{
    public class FetchAPIModel : PageModel
    {
        public void OnGet()
        {
            ViewData["ThisDataField"] = "Some Data Stored Here";
        }
    }
}
