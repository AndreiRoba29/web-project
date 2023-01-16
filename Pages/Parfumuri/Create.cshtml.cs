using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Roba_Andrei_Proiect.Data;
using Roba_Andrei_Proiect.Models;

namespace Roba_Andrei_Proiect.Pages.Parfumuri
{
    public class CreateModel : AromeParfumPageModel
    {
        private readonly Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext _context;

        public CreateModel(Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "NumeBrand");
            ViewData["GenID"] = new SelectList(_context.Set<Gen>(), "ID", "NumeGen");
            var parfum  = new Parfum();
            parfum.AromeParfum = new List<AromaParfum>();
            PopulateAtributAromaData(_context, parfum);

            return Page();
        }

        [BindProperty]
        public Parfum Parfum { get; set; }

      
        public async Task<IActionResult> OnPostAsync(string[] selectedArome)
        {
            var newParfum = new Parfum();
            if (selectedArome != null)
            {
                newParfum.AromeParfum = new List<AromaParfum>();
                foreach (var cat in selectedArome)
                {
                    var catToAdd = new AromaParfum
                    {
                        AromaID = int.Parse(cat)
                    };
                    newParfum.AromeParfum.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Parfum>(
            newParfum,
            "Parfum",
            i => i.Denumire, i => i.Descriere,
            i => i.Pret, i => i.DataAparitie, i => i.BrandID, i =>i.GenID))
            {
                _context.Parfum.Add(newParfum);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAtributAromaData(_context, newParfum);
            return Page();
        }

    }
}
