using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pin_projekt_onlineKnjizara.Data;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Pin_projekt_onlineKnjizara.Models
{
    public class Kos
    {
        private string KosId { get; set; }
        private const string KosSessionKey = "KosId";
        private Pin_projekt_onlineKnjizaraContext db = new Pin_projekt_onlineKnjizaraContext();
        
        private string GetKosId()
        {
            Guid tempKosId = Guid.NewGuid();
            
            return "haha";
        }

        private static Kos GetKos()
        {
            Kos kos = new Kos();
            kos.KosId = kos.GetKosId();
            return kos;
        }
    }
}
