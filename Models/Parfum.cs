using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roba_Andrei_Proiect.Models
{
    public class Parfum
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Parfum")]
        public string Denumire  { get; set; }
        public string Descriere { get; set; }
        [Range(1, 3000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret  { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataAparitie  { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public int GenID { get; set; }
        public Gen Gen  { get; set; }
        public ICollection<AromaParfum> AromeParfum  { get; set; }
     

    }
}
