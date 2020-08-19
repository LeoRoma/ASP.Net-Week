using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_45_asp_core_demo.Pages
{
    public class LeoModel : PageModel
    {
        public static List<string> items = new List<string>() { "one", "two", "three" };
        public void OnGet()
        {
            items.Add("Another item");
        }
    }
}
