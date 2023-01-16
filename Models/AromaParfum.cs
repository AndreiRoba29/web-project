using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roba_Andrei_Proiect.Models
{
    public class AromaParfum
    {
        public int ID { get; set; }
        public int ParfumID { get; set; }
        public Parfum Parfum { get; set; }
        public int AromaID  { get; set; }
        public Aroma Aroma { get; set; }
    }
}
