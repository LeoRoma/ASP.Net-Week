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
    public class DeleteModel : PageModel
    {
        private readonly music_asp_web_page.Models.MusicContext _context;

        public DeleteModel(music_asp_web_page.Models.MusicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Artist Artist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artists.FirstOrDefaultAsync(m => m.ArtistId == id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artists.FindAsync(id);

            if (Artist != null)
            {
                _context.Artists.Remove(Artist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
