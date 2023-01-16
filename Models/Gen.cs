using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roba_Andrei_Proiect.Models
{
    public class Gen
    {
        public int ID { get; set; }
        public string NumeGen { get; set; }
        public ICollection<Parfum> Parfumuri { get; set; }
    }
}
