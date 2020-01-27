using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pin_projekt_onlineKnjizara.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public virtual ICollection<Knjiga> Knjige { get; set; }
    }
}
