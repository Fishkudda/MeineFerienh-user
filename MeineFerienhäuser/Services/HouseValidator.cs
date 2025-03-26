using System.Net.Http;

namespace MeineFerienhäuser.Services
{
    public class HouseValidator
    {
        private List<House> _haus_has_error;
        private List<House> _houses;
        private readonly HttpClient _httpClient;

        public HouseValidator(List<House> houses)
        {
            this._houses = houses;
            _haus_has_error = new List<House>();
            _httpClient = new HttpClient();
        }

        public async Task RunCheckAsync()
        {
            foreach (House house in _houses)
            {
                string pk = house.PK;
                string image = house.GetImageUrl();
                string ferienhausurl = house.GetLinkUrl();
                                          
                Boolean avaliable = await IsWebSiteAvailable(image);
                if (!avaliable)
                {
                    _haus_has_error.Add(house);
                    house.HandleImageError();
                }

                avaliable = await IsWebSiteAvailable(ferienhausurl);
                if (!avaliable)
                {
                    house.HandleHouseURLError();
                    _haus_has_error.Add(house);
                }
                //_haus_has_error.Add(house);//nur fürs testen
            }
            
            HouseFactory.SetErrorHouses(_haus_has_error);

        }





        public async Task<bool> IsWebSiteAvailable(string url)
        {
            try
            {
                // Sende eine Get-Anfrage, um nur die Header zu erhalten
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
