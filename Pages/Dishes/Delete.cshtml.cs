using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Dishes;

public class DeleteModel : PageModel
{
    public Dish? Dish { get; set; }

    public IActionResult OnGet(int id)
    {
        Dish = DishData.GetById(id);
        return Dish == null ? NotFound() : Page();
    }

    public IActionResult OnPost(int id)
    {
        
        DishData.Remove(id);

        return RedirectToPage("./Index");
    }
}