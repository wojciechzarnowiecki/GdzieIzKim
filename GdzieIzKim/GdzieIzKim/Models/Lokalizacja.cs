using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GdzieIzKim.Models
{
    public class Lokalizacja
    {
        public int LokalizacjaId { get; set; }
        public string NazwaLoc { get; set; }
        public string AdresLoc { get; set; }
        public string InformacjeLoc { get; set; }
        public string SzerokoscLoc { get; set; }
        public string DlugoscLoc { get; set; }

        public int KategoriaId { get; set; }
        public virtual Kategoria Kategoria { get; set; }
    }
}