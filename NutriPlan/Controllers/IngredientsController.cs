using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriPlan.Data;
using NutriPlan.Models;

namespace NutriPlan.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly AppDbContext _context;

        public IngredientsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, IngredientType? typeFilter)
        {
            var ingredients = await _context.Ingredients.ToListAsync();

            //Search system
            if (!String.IsNullOrEmpty(searchString))
            {
                //OrdinalIgnoreCase = becomes case insensitive!!!!
                ingredients = ingredients
                    .Where(i => i.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            //sort system
            ingredients = ingredients
                .OrderBy(i => i.Name)
                .ToList();

            //filter system
            if (typeFilter.HasValue)
            {
                ingredients = ingredients
                    .Where(i => i.Type == typeFilter.Value)
                    .ToList();
            }

            ViewData["SelectedType"] = typeFilter;

            return View(ingredients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return View(ingredient);
            }
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int ingredientId)
        {
            var ingredient = await _context.Ingredients.FindAsync(ingredientId);
            if (ingredient == null) return NotFound();
            return View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int ingredientId, Ingredient ingredient)
        {
            if (ingredientId != ingredient.IngredientId) return BadRequest();

            if (ModelState.IsValid)
            {
                _context.Update(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int ingredientId)
        {
            var ingredient = await _context.Ingredients.FindAsync(ingredientId);
            if (ingredient == null) return BadRequest();

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
