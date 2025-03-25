using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeineFerienhäuser.Pages;

public class HausModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public HausModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
