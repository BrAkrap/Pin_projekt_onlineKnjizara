using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pin_projekt_onlineKnjizara.Models
{
    public class Kosarica
    {
        public int Id { get; set; }
        public string KosaricaId { get; set; }
        public int KnjigaId { get; set; }

        [Range(0, 50, ErrorMessage="Moguće je naručiti do 50 knjiga!")]
        public int Kolicina { get; set; }
        public virtual Knjiga Knjiga { get; set; }
    }
}
