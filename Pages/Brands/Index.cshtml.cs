using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Roba_Andrei_Proiect.Data;
using Roba_Andrei_Proiect.Models;

namespace Roba_Andrei_Proiect.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext _context;

        public IndexModel(Roba_Andrei_Proiect.Data.Roba_Andrei_ProiectContext context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; }

        public async Task OnGetAsync()
        {
            Brand = await _context.Brand.ToListAsync();
        }
    }
}
