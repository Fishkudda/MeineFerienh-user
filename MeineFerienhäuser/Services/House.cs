using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace MeineFerienhäuser.Services
{
    public class House :  PageModel
    {

        public Boolean imageOK { get; set; } = true; // Ob das Image erreichbar ist.
        public Boolean urlOK { get; set; } = true;  // Ob die URL erreichbar ist.
        public string PK { get; set; }                  // Primärschlüssel
        public string CatalogNumber { get; set; }      // Katalognummer
        public int Adults { get; set; }                // Anzahl der Erwachsenen
        public int Children { get; set; }              // Anzahl der Kinder
        public int Pets { get; set; }                  // Anzahl der Haustiere
        public string Address { get; set; }            // Adresse des Hauses
        public string ZipCode { get; set; }            // Postleitzahl
        public string City { get; set; }               // Stadt
        public string ImageUrl { get; set; }           // Bild-URL
        public string Description { get; set; }        // Beschreibung des Hauses
        public string HouseUrl { get; set; }           // URL des Hauses
        public int AreaPK { get; set; }                // Primärschlüssel des Gebiets
        public string AreaName { get; set; }           // Name des Gebiets
        public int RegionPK { get; set; }              // Primärschlüssel der Region
        public string RegionName { get; set; }         // Name der Region
        public double Latitude { get; set; }           // Breitengrad
        public double Longitude { get; set; }          // Längengrad

        public void HandleImageError()
        {

            imageOK = false;

            this.ImageUrl = AppSettings.DefaultImagePath;
            


        }

        public void HandleHouseURLError()
        {
            this.urlOK = false;

            this.HouseUrl = AppSettings.DefaultHouseLink;
        }

        public String GetImageUrl()
        {
            return AppSettings.BaseUrlHouse.Replace("{}", this.ImageUrl);
        }

        public String GetLinkUrl()
        {
            return AppSettings.BaseUrlLink.Replace("{}", this.HouseUrl);
        }


        public String GetDescription()
        {
            String htmldescription = this.Description;
            htmldescription = WebUtility.HtmlDecode(htmldescription);
            string plainText = Regex.Replace(htmldescription, "<.*?>", String.Empty);
            return plainText;
        }

    }
}
