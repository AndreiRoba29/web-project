using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roba_Andrei_Proiect.Models
{
    public class ParfumData
    {
        public IEnumerable<Parfum> Parfumuri  { get; set; }
        public IEnumerable<Aroma> Arome  { get; set; }
        public IEnumerable<AromaParfum>  AromeParfum { get; set; }
    }
}
