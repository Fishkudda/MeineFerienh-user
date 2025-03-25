using MeineFerienhäuser.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeineFerienhäuser.Pages;

public class HausModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public List<House> houses;
    public String altImg = AppSettings.DefaultImagePath;
    public int ItemsPerPage { get; set; }
    public int ItemSides { get; set; }
    public int CurrentPage { get; set; }


    public HausModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        this.houses = HouseFactory.GetHouseList();

    }
}
