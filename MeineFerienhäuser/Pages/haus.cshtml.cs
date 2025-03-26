using MeineFerienhäuser.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeineFerienhäuser.Pages
{
    public class HausModel : PageModel
    {
        private readonly ILogger<HausModel> _logger;

        public List<House> AllHouses { get; set; } // Full list of houses
        public List<House> Houses { get; set; } // Paginated list of houses

        public List<House> HousesWithError { get; set; } // Houses that have an error
        public string AltImg { get; set; } = AppSettings.DefaultImagePath;

        public int ItemsPerPage { get; set; } // Number of houses per page
        public int CurrentPage { get; set; } // Current page number
        public int TotalPages { get; set; } // Total number of pages

        public Boolean OpenErrorWindow { get; set; } = false;

        public HausModel(ILogger<HausModel> logger)
        {
            _logger = logger;
        }

         public void OnGet([FromQuery] int itemsPerPage = 6, [FromQuery] int page = 1)
         {
            // Load the full house list from the service
            AllHouses = HouseFactory.GetHouseList();
            HousesWithError = HouseFactory.GetErrorHouses();

            // Validate itemsPerPage and page parameters
            ItemsPerPage = itemsPerPage > 0 ? itemsPerPage : 6; // Default to 6 houses per page
            CurrentPage = page > 0 ? page : 1; // Default to the first page

            // Calculate total pages
            TotalPages = (int)Math.Ceiling((double)AllHouses.Count / ItemsPerPage);

            // Ensure the current page is within valid bounds
            if (CurrentPage > TotalPages) CurrentPage = TotalPages; // Don't allow page number beyond total pages
            if (CurrentPage < 1) CurrentPage = 1; // Ensure at least the first page

            // Get the paginated list of houses
            int skip = (CurrentPage - 1) * ItemsPerPage;
            Houses = AllHouses.Skip(skip).Take(ItemsPerPage).ToList();
         }


        public async Task OnPostLoadWithBooleanAsync(bool fire) // Benenne die Methode um
        {
            if (fire)
            {
                OpenErrorWindow = true;
                await HouseFactory.Load();
                OnGet(ItemsPerPage, CurrentPage);
            }
        }


    }
}
