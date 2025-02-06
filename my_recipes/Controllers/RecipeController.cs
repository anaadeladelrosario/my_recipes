using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_recipes.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        // PUT: api/recipes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe updatedRecipe)
        {
            // Find the existing recipe asynchronously
            var existingRecipe = await _context.Recipes.FindAsync(id);
            if (existingRecipe == null)
            {
                return NotFound("Recipe not found.");
            }

            // Update the recipe properties with the new values
            existingRecipe.Title = updatedRecipe.Title;
            existingRecipe.Description = updatedRecipe.Description;
            existingRecipe.Category = updatedRecipe.Category;
            existingRecipe.Cuisine = updatedRecipe.Cuisine;   
            existingRecipe.PreparationTime = updatedRecipe.PreparationTime;
            existingRecipe.Servings = updatedRecipe.Servings;
            existingRecipe.Notes = updatedRecipe.Notes;
            existingRecipe.CostRange = updatedRecipe.CostRange;
            existingRecipe.CookingTime = updatedRecipe.CookingTime;
            existingRecipe.Difficulty = updatedRecipe.Difficulty;
            existingRecipe.Instructions = updatedRecipe.Instructions;
            existingRecipe.Ingredients = updatedRecipe.Ingredients;
            existingRecipe.Tags = updatedRecipe.Tags;
            existingRecipe.IsVegetarian = updatedRecipe.IsVegetarian;


            // Save the changes asynchronously to the database
            await _context.SaveChangesAsync();

            // Return a success response with the updated recipe data
            return Ok(existingRecipe);
        }

        // DELETE: api/recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            // Find the recipe by id
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                // If recipe is not found, return 404 (Not Found)
                return NotFound();
            }

            // Remove the recipe from the list (simulating deletion from a database)
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync(); // Save changes asynchronously to persist deletion

            // Return status 200 OK with a success message
            return Ok(new { message = "Recipe deleted successfully" });
        }
    }
}
