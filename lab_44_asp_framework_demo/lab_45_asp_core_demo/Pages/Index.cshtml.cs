using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab_45_asp_core_demo.Models;

namespace lab_45_asp_core_demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly lab_45_asp_core_demo.Models.NorthwindContext _context;

        public IndexModel(lab_45_asp_core_demo.Models.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
