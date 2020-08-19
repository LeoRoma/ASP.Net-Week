using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using music_asp_web_page.Models;

namespace music_asp_web_page.Pages
{
    public class IndexModel : PageModel
    {
        private readonly music_asp_web_page.Models.MusicContext _context;

        public IndexModel(music_asp_web_page.Models.MusicContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; }

        public async Task OnGetAsync()
        {
            Artist = await _context.Artists.ToListAsync();
        }
    }
}
