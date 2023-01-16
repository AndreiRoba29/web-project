using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roba_Andrei_Proiect.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string NumeBrand  { get; set; }
        public ICollection<Parfum> Parfum  { get; set; }
    }
}
