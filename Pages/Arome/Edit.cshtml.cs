using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Roba_Andrei_Proiect.Data;
using Roba_Andrei_Proiect.Models;

namespace Roba_Andrei_Proiect.Pages.Arome
{
    public class EditModel : PageModel
    {
        private readonly Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext _context;

        public EditModel(Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Aroma Aroma { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aroma = await _context.Aroma.FirstOrDefaultAsync(m => m.ID == id);

            if (Aroma == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Aroma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AromaExists(Aroma.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AromaExists(int id)
        {
            return _context.Aroma.Any(e => e.ID == id);
        }
    }
}
