using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Dishes;

public class IndexModel : PageModel
{
    public List<Dish> Dishes { get; set; } = new();

    public void OnGet()
    {
        Dishes = DishData.GetDishes();
    }
}