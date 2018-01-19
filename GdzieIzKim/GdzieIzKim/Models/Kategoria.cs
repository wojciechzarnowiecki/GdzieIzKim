using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GdzieIzKim.Models
{
    public class Kategoria
    {
        [ScaffoldColumn(false)]
        public int KategoriaId { get; set; }
        [Display(Name = "Kategoria")]
        public string NazwaKat { get; set; }
        [Display(Name = "Opis")]
        public string OpisKat { get; set; }

        public virtual ICollection<Lokalizacja> Lokalizacja { get; set; }
    }
}