using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_recipes.Model;

namespace my_recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecipeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/recipes
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        //{
        //     return await _context.Recipes.ToListAsync();
        //}

        //Get: api/recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeResponseDto>>> GetRecipesResponse()
        {
            var recipes = await _context.Recipes.ToListAsync();


            // Map each Recipe entity to a RecipeResponseDto
            var recipeDtos = recipes.Select(recipe => new RecipeResponseDto
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Category = recipe.Category.ToString(),
                // Map other properties from Recipe to RecipeResponseDto as needed
            }).ToList();

            return Ok(recipeDtos);


        }

        // GET: api/recipes/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            // var recipe = await _context.Recipes.FindAsync(id);

            // Fetch the recipe with its ingredients and instructions
            var recipe = await _context.Recipes
                .Include(r => r.Ingredients) // Include ingredients
                .Include(r => r.Instructions) // Include instructions
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }
            return recipe;
        }

        // POST: api/recipes
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostProduct(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }
    }
}
