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
    public class SongsModel : PageModel
    {
        private readonly music_asp_web_page.Models.MusicContext _context;
        public SongsModel(music_asp_web_page.Models.MusicContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get; set; }

        public async Task OnGetAsync()
        {
            Song = await _context.Songs.ToListAsync();
        }
    }
}
