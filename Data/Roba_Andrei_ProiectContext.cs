using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roba_Andrei_Proiect.Models;

namespace Roba_Andrei_Proiect.Data
{
    public class Roba_Andrei_ProiectContext : DbContext
    {
        public Roba_Andrei_ProiectContext (DbContextOptions<Roba_Andrei_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Roba_Andrei_Proiect.Models.Parfum> Parfum { get; set; }

        public DbSet<Roba_Andrei_Proiect.Models.Brand> Brand { get; set; }

        public DbSet<Roba_Andrei_Proiect.Models.Aroma> Aroma { get; set; }

        public DbSet<Roba_Andrei_Proiect.Models.Gen> Gen { get; set; }

    
    }
}
