using Microsoft.EntityFrameworkCore;
using my_recipes.Model;

namespace my_recipes.Models
{
    public static class DatabaseSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {

            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            // Ensure the database is created and migrated
            context.Database.Migrate();

            // Check if the database already has data
            if (context.Recipes.Any())
            {
                return; // Database has been seeded already
            }

            // Create a new recipe with ingredients, instructions, and tags
            context.Recipes.AddRange(
                new Recipe
                {
                    Title = "Pasta",
                    Description = "Delicious pasta recipe",
                    Category = Category.MainCourse,
                    Cuisine = Cuisine.Italian,
                    PreparationTime = 10,
                    CookingTime = 20,
                    Servings = 4,
                    Difficulty = Difficulty.Easy,
                    Ingredients =
                [
                    new() { Name = "Pasta", Quantity = 200, Unit = "grams" },
                    new() { Name = "Tomato Sauce", Quantity = 100, Unit = "ml" },
                    new() { Name = "Cheese", Quantity = 50, Unit = "grams" }
                ],
                    Instructions =
                [
                    new Instruction { Step = 1, Description = "Boil water" },
                    new Instruction { Step = 2, Description = "Add pasta and cook for 10 minutes"},
                    new Instruction { Step = 3, Description = "Add sauce and cheese" }
                ],
                    Tags =
                [
                    new Tag { TagName = "Italian" },
                    new Tag { TagName = "Vegetarian" }
                ]
                },
                new Recipe
                {
                    Title = "Aussie Meat Pie",
                    Description = "A classic Australian meat pie with a savory beef filling wrapped in flaky pastry.",
                    Category = Category.MainCourse,
                    Cuisine = Cuisine.Australian,
                    PreparationTime = 15,
                    CookingTime = 45,
                    Servings = 4,
                    Difficulty = Difficulty.Medium,
                    Ingredients =
                [
                    new Ingredient { Name = "Ground Beef", Quantity = 500, Unit = "grams" },
                    new Ingredient { Name = "Onion", Quantity = 1, Unit = "medium, chopped" },
                    new Ingredient { Name = "Garlic", Quantity = 2, Unit = "cloves, minced" },
                    new Ingredient { Name = "Beef Broth", Quantity = 250, Unit = "ml" },
                    new Ingredient { Name = "Worcestershire Sauce", Quantity = 2, Unit = "tbsp" },
                    new Ingredient { Name = "Tomato Paste", Quantity = 2, Unit = "tbsp" },
                    new Ingredient { Name = "Frozen Puff Pastry", Quantity = 1, Unit = "sheet" },
                    new Ingredient { Name = "Salt", Quantity = 1, Unit = "tsp" },
                    new Ingredient { Name = "Pepper", Quantity = 1, Unit = "tsp" },
                    new Ingredient { Name = "Egg", Quantity = 1, Unit = "beaten, for egg wash" }
                ],
                    Instructions =
                [
                    new Instruction { Step = 1, Description = "Preheat the oven to 200°C (400°F)." },
                    new Instruction { Step = 2, Description = "In a large pan, sauté onion and garlic until softened." },
                    new Instruction { Step = 3, Description = "Add ground beef to the pan and cook until browned." },
                    new Instruction { Step = 4, Description = "Stir in beef broth, Worcestershire sauce, tomato paste, salt, and pepper. Simmer for 15-20 minutes until the mixture thickens." },
                    new Instruction { Step = 5, Description = "Roll out the puff pastry and line a pie dish with it. Spoon the meat filling into the pie shell." },
                    new Instruction { Step = 6, Description = "Cover with another layer of puff pastry and seal the edges. Make a small slit in the top for steam to escape." },
                    new Instruction { Step = 7, Description = "Brush the top of the pie with the beaten egg for a golden finish." },
                    new Instruction { Step = 8, Description = "Bake for 35-40 minutes or until the pastry is golden and crispy." },
                    new Instruction { Step = 9, Description = "Allow to cool for a few minutes before serving." }
                ],
                    Tags =
                [
                    new Tag { TagName = "Australian" },
                    new Tag { TagName = "ComfortFood" },
                    new Tag { TagName = "Meat" }
                ]
                },
                new Recipe
                {
                    Title = "Flan",
                    Description = "A creamy, smooth, and caramelized dessert, popular in many cultures, with a rich custard base and a silky caramel topping.",
                    Category = Category.Dessert,
                    Cuisine = Cuisine.Cuban,  // or Cuisine.Hispanic if you prefer a specific origin
                    PreparationTime = 15,
                    CookingTime = 60,
                    Servings = 6,
                    Difficulty = Difficulty.Medium,
                    Ingredients =
                [
                    new Ingredient { Name = "Sugar", Quantity = 200, Unit = "grams" },  // For caramel
                    new Ingredient { Name = "Water", Quantity = 60, Unit = "ml" },      // For caramel
                    new Ingredient { Name = "Eggs", Quantity = 4, Unit = "large" },      // For custard base
                    new Ingredient { Name = "Egg Yolks", Quantity = 2, Unit = "large" }, // For custard base
                    new Ingredient { Name = "Milk", Quantity = 500, Unit = "ml" },       // For custard base
                    new Ingredient { Name = "Heavy Cream", Quantity = 250, Unit = "ml" },// For custard base
                    new Ingredient { Name = "Vanilla Extract", Quantity = 1, Unit = "tsp" }, // For flavoring
                    new Ingredient { Name = "Sugar", Quantity = 100, Unit = "grams" },  // For custard base
                ],
                    Instructions =
                [
                    new Instruction { Step = 1, Description = "Preheat the oven to 160°C (320°F)." },
                    new Instruction { Step = 2, Description = "In a medium saucepan, combine the 200g sugar and 60ml water over medium heat. Stir until the sugar dissolves, then stop stirring and allow the mixture to cook until it turns a golden amber color." },
                    new Instruction { Step = 3, Description = "Once the caramel is golden, immediately pour it into the bottom of a 6-cup baking dish or individual ramekins. Swirl the dish to coat the bottom evenly, and allow it to cool and harden." },
                    new Instruction { Step = 4, Description = "In a separate saucepan, combine the milk and heavy cream over medium heat. Heat until just before it starts to boil, then remove from heat." },
                    new Instruction { Step = 5, Description = "In a mixing bowl, whisk the eggs, egg yolks, and 100g sugar until smooth and well combined." },
                    new Instruction { Step = 6, Description = "Slowly pour the warm milk and cream mixture into the egg mixture while whisking continuously to prevent curdling." },
                    new Instruction { Step = 7, Description = "Stir in the vanilla extract." },
                    new Instruction { Step = 8, Description = "Pour the custard mixture over the cooled caramel in the baking dish or ramekins." },
                    new Instruction { Step = 9, Description = "Place the baking dish or ramekins in a larger pan and add hot water to the outer pan to create a water bath (about halfway up the sides of the ramekins)." },
                    new Instruction { Step = 10, Description = "Bake for 50-60 minutes, or until the flan is set (a knife inserted should come out clean). Remove from the water bath and let cool to room temperature." },
                    new Instruction { Step = 11, Description = "Refrigerate for at least 2 hours or overnight to chill. Before serving, run a knife around the edges to loosen the flan and invert onto a plate." }
                ],
                    Tags =
                [
                    new Tag { TagName = "Cuban" },
                    new Tag { TagName = "Dessert" },
                    new Tag { TagName = "Custard" }
                ]
                },
                new Recipe
                {
                    Title = "Swedish Meatballs",
                    Description = "A classic Swedish dish featuring tender meatballs served with creamy gravy and lingonberry sauce.",
                    Category = Category.MainCourse,
                    Cuisine = Cuisine.Swedish,
                    PreparationTime = 20,
                    CookingTime = 30,
                    Servings = 4,
                    Difficulty = Difficulty.Medium,
                    Ingredients =
                [
                    new Ingredient { Name = "Ground Beef", Quantity = 400, Unit = "grams" },
                    new Ingredient { Name = "Ground Pork", Quantity = 200, Unit = "grams" },
                    new Ingredient { Name = "Breadcrumbs", Quantity = 50, Unit = "grams" },
                    new Ingredient { Name = "Milk", Quantity = 100, Unit = "ml" },
                    new Ingredient { Name = "Egg", Quantity = 1, Unit = "large" },
                    new Ingredient { Name = "Onion", Quantity = 1, Unit = "small, finely chopped" },
                    new Ingredient { Name = "Salt", Quantity = 1, Unit = "tsp" },
                    new Ingredient { Name = "Pepper", Quantity = 1, Unit = "tsp" },
                    new Ingredient { Name = "Butter", Quantity = 2, Unit = "tbsp" },
                    new Ingredient { Name = "Flour", Quantity = 2, Unit = "tbsp" },
                    new Ingredient { Name = "Beef Broth", Quantity = 300, Unit = "ml" },
                    new Ingredient { Name = "Heavy Cream", Quantity = 100, Unit = "ml" },
                    new Ingredient { Name = "Soy Sauce", Quantity = 1, Unit = "tbsp" },
                    new Ingredient { Name = "Lingonberry Sauce", Quantity = 4, Unit = "tbsp" } // Optional, for serving
                ],
                    Instructions =
                [
                    new Instruction { Step = 1, Description = "In a small bowl, combine the breadcrumbs and milk. Let it soak for 5 minutes." },
                    new Instruction { Step = 2, Description = "In a large bowl, mix together the ground beef, ground pork, soaked breadcrumbs, egg, chopped onion, salt, and pepper. Use your hands to combine the ingredients until smooth." },
                    new Instruction { Step = 3, Description = "Form the mixture into small meatballs, about 1 inch in diameter." },
                    new Instruction { Step = 4, Description = "Heat a large skillet over medium heat and melt the butter. Add the meatballs in batches and cook until browned on all sides and cooked through (about 8-10 minutes). Remove the meatballs from the skillet and set aside." },
                    new Instruction { Step = 5, Description = "In the same skillet, add the flour and stir it into the remaining butter and drippings. Cook for 1-2 minutes to form a roux." },
                    new Instruction { Step = 6, Description = "Slowly add the beef broth, stirring constantly to avoid lumps. Bring to a simmer and cook until the gravy thickens." },
                    new Instruction { Step = 7, Description = "Stir in the heavy cream and soy sauce. Let the gravy simmer for another 2-3 minutes." },
                    new Instruction { Step = 8, Description = "Return the meatballs to the skillet and stir to coat them in the gravy. Cook for an additional 5-10 minutes until the meatballs are heated through." },
                    new Instruction { Step = 9, Description = "Serve the Swedish meatballs with the creamy gravy and lingonberry sauce on the side." }
                ],
                    Tags =
                [
                    new Tag { TagName = "Swedish" },
                    new Tag { TagName = "ComfortFood" },
                    new Tag { TagName = "Meat" },
                    new Tag { TagName = "Gravy" }
                ]
                }

            );

            context.SaveChanges();  // Add the recipe to the context and save changes
        }
    }
}