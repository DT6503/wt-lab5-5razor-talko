using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Dishes;

public class CreateModel : PageModel
{
    [BindProperty]
    public Dish Dish { get; set; } = new(0, "", 0, "");

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();
        var newId = DishData.NextId();

        var newDish = new Dish(newId, Dish.Name, Dish.Price, Dish.Category)
        {
            Description = Dish.Description,
            ImageUrl = string.IsNullOrWhiteSpace(Dish.ImageUrl)
                ? "https://placehold.co/400x300/ffd700/333?text=Dish"
                : Dish.ImageUrl,
            IsAvailable = Dish.IsAvailable
        };

        DishData.Add(newDish);
        return RedirectToPage("./Index");
    }
}