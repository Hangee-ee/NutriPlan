using Microsoft.AspNetCore.Mvc;

namespace NutriPlan.Controllers
{
    public class MealPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
