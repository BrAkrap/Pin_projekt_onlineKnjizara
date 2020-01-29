using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pin_projekt_onlineKnjizara.Models
{
    public class Knjiga
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public virtual Autor Autor { get; set; }
        public int AutorId { get; set; }
        public decimal Cijena { get; set; }
        [Display(Name = "Na skladištu")]
        public int Kolicina { get; set; }
    }
}
