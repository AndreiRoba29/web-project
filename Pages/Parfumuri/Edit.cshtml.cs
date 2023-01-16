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

namespace Roba_Andrei_Proiect.Pages.Parfumuri
{
    public class EditModel : AromeParfumPageModel
    {
        private readonly Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext _context;

        public EditModel(Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parfum Parfum { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

        Parfum = await _context.Parfum
              .Include(b => b.Brand)
               .Include(b => b.Gen)
              .Include(b => b.AromeParfum).ThenInclude(b => b.Aroma)
              .AsNoTracking()
              .FirstOrDefaultAsync(m => m.ID == id);

        if (Parfum == null)
            {
                return NotFound();
            }
        PopulateAtributAromaData(_context, Parfum);
        ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "NumeBrand");
            ViewData["GenID"] = new SelectList(_context.Set<Gen>(), "ID", "NumeGen");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedArome )
    {
        if (id == null)
        {
            return NotFound();
        }
        var parfumToUpdate = await _context.Parfum
        .Include(i => i.Brand)
        .Include(i => i.Gen)
        .Include(i => i.AromeParfum)
        .ThenInclude(i => i.Aroma)
        .FirstOrDefaultAsync(s => s.ID == id);
        if (parfumToUpdate == null)
        {
            return NotFound();
        }
        if (await TryUpdateModelAsync<Parfum>(
        parfumToUpdate,
        "Parfum",
        i => i.Denumire, i => i.Descriere,
        i => i.Pret, i => i.DataAparitie, i => i.Brand, i =>i.GenID))
        {
            UpdateAromeParfum(_context, selectedArome, parfumToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
        //este editata
        UpdateAromeParfum(_context, selectedArome, parfumToUpdate);
        PopulateAtributAromaData(_context, parfumToUpdate);
        return Page();
    }
}
}
