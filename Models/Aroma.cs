using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roba_Andrei_Proiect.Models
{
    public class Aroma
    {
        public int ID { get; set; }
        public string NumeAroma  { get; set; }
        public ICollection<AromaParfum> AromeParfum  { get; set; }
    }
}
