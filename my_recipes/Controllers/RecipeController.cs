using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_recipes.Model;

namespace my_recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private static List<Recipe> recipes = new List<Recipe>
    {
        new Recipe { Id = 1, Title = "Flan", Description="Almost like Crème brûlée", Category="Dessert", Cuisine="Cuba", PreparationTime= 15, CookingTime=60, Servings= 10, Difficulty= "easy", CostRange = 100 },
    };

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> Get()
        {
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> Get(int id)
        {
            var recipe = recipes.FirstOrDefault(p => p.Id == id);
            if (recipe == null)
                return NotFound();
            return Ok(recipe);
        }
    }
}
