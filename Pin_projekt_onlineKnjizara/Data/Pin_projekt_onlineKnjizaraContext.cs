using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Pin_projekt_onlineKnjizara.Models;

namespace Pin_projekt_onlineKnjizara.Data
{
    public class Pin_projekt_onlineKnjizaraContext : DbContext
    {
        public Pin_projekt_onlineKnjizaraContext() { }

        public Pin_projekt_onlineKnjizaraContext(DbContextOptions<Pin_projekt_onlineKnjizaraContext> options) : base(options)
        {

        }

        public DbSet<Knjiga> Knjige { get; set; }
        public DbSet<Autor> Autori { get; set; }
        
    }
}
