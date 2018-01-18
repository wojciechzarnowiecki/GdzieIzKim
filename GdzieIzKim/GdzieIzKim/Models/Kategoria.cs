using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GdzieIzKim.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        public string NazwaKat { get; set; }
        public string OpisKat { get; set; }

        public virtual ICollection<Lokalizacja> Lokalizacja { get; set; }
    }
}