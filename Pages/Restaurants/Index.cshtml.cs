using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Restaurants;

public class IndexModel : PageModel
{
    public List<Restaurant> Restaurants { get; set; } = new();

    public void OnGet()
    {
        Restaurants = RestaurantData.GetAll();
    }
}