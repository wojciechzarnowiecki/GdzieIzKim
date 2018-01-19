using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GdzieIzKim.Models
{
    public class Lokalizacja
    {
        [ScaffoldColumn(false)]
        public int LokalizacjaId { get; set; }
        [Display(Name = "Nazwa")]
        public string NazwaLoc { get; set; }
        [Display(Name = "Adres")]
        public string AdresLoc { get; set; }
        [Display(Name = "Opis")]
        public string InformacjeLoc { get; set; }
        [Display(Name = "Szerokość geograficzna")]
        public string SzerokoscLoc { get; set; }
        [Display(Name = "Długość geograficzna")]
        public string DlugoscLoc { get; set; }

        public int KategoriaId { get; set; }
        [Display(Name = "Kategoria")]
        public virtual Kategoria Kategoria { get; set; }
    }
}