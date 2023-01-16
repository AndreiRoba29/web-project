﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Roba_Andrei_Proiect.Data;
using Roba_Andrei_Proiect.Models;

namespace Roba_Andrei_Proiect.Pages.Parfumuri
{
    public class DetailsModel : PageModel
    {
        private readonly Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext _context;

        public DetailsModel(Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext context)
        {
            _context = context;
        }

        public Parfum Parfum { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parfum = await _context.Parfum.FirstOrDefaultAsync(m => m.ID == id);

            if (Parfum == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
