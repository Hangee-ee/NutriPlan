using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriPlan.Data;
using NutriPlan.Models;
using System.Reflection;

namespace NutriPlan.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext _context;

        public RecipeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, RecipeType? typeFilter)
        {
            var recipes = await _context.Recipes.ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                //OrdinalIgnoreCase = becomes case insensitive!!!!
                recipes = recipes
                    .Where(i => i.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            //order by name
            recipes = recipes
                    .OrderBy(i => i.Name)
                    .ToList();

            //filter system
            if (typeFilter.HasValue)
            {
                recipes = recipes
                    .Where(i => i.Type == typeFilter.Value)
                    .ToList();
            }

            ViewData["SelectedType"] = typeFilter;

            return View(recipes);
        }

        public async Task<IActionResult> Details(int recipeID)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.RecipeId == recipeID);
            if (recipe == null) return NotFound();
            return View(recipe);
        }
        public async Task<IActionResult> Create()
        {
            var ingredients = await _context.Ingredients
                                .OrderBy(i => i.Name)
                                .ToListAsync();
            ViewData["Ingredients"] = ingredients;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                var ingredients = await _context.Ingredients
                                    .OrderBy(i => i.Name)
                                    .ToListAsync();
                ViewData["Ingredients"] = ingredients;
                return View(recipe); 
            }

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int recipeId)
        {
            var recipe = await _context.Recipes.FindAsync(recipeId);
            if (recipe == null) return BadRequest();

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}