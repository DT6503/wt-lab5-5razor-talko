using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab5_5razor_talko.Data;
using wt_lab5_5razor_talko.Models;

namespace wt_lab5_5razor_talko.Pages.Couriers;

public class IndexModel : PageModel
{
    public List<Courier> Couriers { get; set; } = new();

    public void OnGet()
    {
        Couriers = CourierData.GetAll();
    }
}