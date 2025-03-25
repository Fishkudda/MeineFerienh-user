
using static System.Net.WebRequestMethods;
using System.Text.Json;

namespace MeineFerienhäuser.Services
{
    public class Dataloader
    {
        private static readonly string _url = "https://img.dansk.de/challenge/houses.json";
        private List<House> houses;
        public Dataloader()
        {
            houses = new List<House>();
            //Wenn noch lust eine Config mit den config kram anlegen.
        }

        public async Task<List<House>> GetHouseListAsync()
        {
            HouseValidator validator = new HouseValidator(houses);
            //await validator.RunCheckAsync();
            HouseFactory.SetHouseList(houses);
            return houses;
        }

        public async Task LoadHouses()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(_url),
                Method = HttpMethod.Get
            };

            request.Headers.Add("Accept", "*/*");
            //request.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.com)");

            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            // Parse JSON into a list of House objects
            try
            {
                houses = JsonSerializer.Deserialize<List<House>>(result);

            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
        }

    }
}
