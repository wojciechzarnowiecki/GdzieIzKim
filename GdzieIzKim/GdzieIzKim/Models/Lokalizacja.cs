using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

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

        [Display(Name = "Kategoria")]
        public int KategoriaId { get; set; }
        [Display(Name = "Kategoria")]
        public virtual Kategoria Kategoria { get; set; }

        public void GeoCodeLat()
        {
            //var mapskey = "AIzaSyDsvXhEPlkCvqXapHw_En7QwyOML_Wvffc";
            var url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key=AIzaSyDsvXhEPlkCvqXapHw_En7QwyOML_Wvffc", AdresLoc);

            var webClient = new WebClient();
            var sr = new StreamReader(webClient.OpenRead(url));

            var xmlTextReader = new XmlTextReader(sr);
            var coordread = false;

            while (xmlTextReader.Read())
            {
                xmlTextReader.MoveToElement();
                switch (xmlTextReader.Name)
                {
                    case "lat":
                        if (!coordread)
                        {
                            xmlTextReader.Read();

                            SzerokoscLoc = xmlTextReader.Value;

                            coordread = true;

                        }
                        break;
                }
            }          
        }

        public void GeoCodeLng()
        {
            //var mapskey = "AIzaSyDsvXhEPlkCvqXapHw_En7QwyOML_Wvffc";
            var url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key=AIzaSyDsvXhEPlkCvqXapHw_En7QwyOML_Wvffc", AdresLoc);

            var webClient = new WebClient();
            var sr = new StreamReader(webClient.OpenRead(url));

            var xmlTextReader = new XmlTextReader(sr);
            var coordread = false;

            while (xmlTextReader.Read())
            {
                xmlTextReader.MoveToElement();
                switch (xmlTextReader.Name)
                {
                    case "lng":
                        if (!coordread)
                        {
                            xmlTextReader.Read();

                            DlugoscLoc = xmlTextReader.Value;

                            coordread = true;

                        }
                        break;
                }
            }
        }
    }
}