using System.Net.Http;

namespace MeineFerienhäuser.Services
{
    public class HouseValidator
    {
        private List<House> _haus_has_error;
        private List<House> _houses;
        private DateTime timestamp;
        private readonly HttpClient _httpClient;

        public HouseValidator(List<House> houses)
        {
            this._houses = houses;
            _haus_has_error = new List<House>();
            _httpClient = new HttpClient();
        }

        public async Task RunCheckAsync()
        {
            if (IsNotOlderThan30Minutes(timestamp))
            {
                return;
            }

            timestamp = DateTime.Now.AddMinutes(-35);
            foreach (House house in _houses)
            {
                string pk = house.PK;
                string image = house.ImageUrl;
                string ferienhausurl = house.HouseUrl;
                //CheckForImage
                string baseUrlHouse = AppSettings.BaseUrlHouse;
                
                image = baseUrlHouse.Replace("{}",image);
                
                
                Boolean avaliable = await IsWebSiteAvailable(image);
                if (!avaliable)
                {
                    _haus_has_error.Add(house);
                    house.HandleImageError();
                }
                string baseUrlLink = AppSettings.BaseUrlLink;
                ferienhausurl = baseUrlLink.Replace("{}", ferienhausurl);
                avaliable = await IsWebSiteAvailable(ferienhausurl);
                if (!avaliable)
                {
                    house.HandleHouseURLError();
                    _haus_has_error.Add(house);
                }
            }

        }



        private static bool IsNotOlderThan30Minutes(DateTime timestamp)
        {

            // Get the current time and subtract 30 minutes
            DateTime thirtyMinutesAgo = DateTime.Now.AddMinutes(-30);

            // Compare the timestamp with the time 30 minutes ago
            return timestamp > thirtyMinutesAgo;
        }



        public async Task<bool> IsWebSiteAvailable(string url)
        {
            try
            {
                // Sende eine HEAD-Anfrage, um nur die Header zu erhalten
                HttpResponseMessage response = await _httpClient.SendAsync(new HttpRequestMessage
                {
                    //Method = HttpMethod.Head, nicht erlaubt daher Get
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url)
                });

                // Prüfe den Statuscode, um festzustellen, ob das Bild verfügbar ist
                if (response.IsSuccessStatusCode)
                {
                    
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
          
                return false;
            }
        }
    }
}
