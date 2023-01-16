﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Roba_Andrei_Proiect.Data;
using Roba_Andrei_Proiect.Models;

namespace Roba_Andrei_Proiect.Pages.Arome
{
    public class DeleteModel : PageModel
    {
        private readonly Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext _context;

        public DeleteModel(Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aroma = await _context.Aroma.FindAsync(id);

            if (Aroma != null)
            {
                _context.Aroma.Remove(Aroma);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
