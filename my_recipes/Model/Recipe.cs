namespace my_recipes.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Category { get;set; }
        public required string Cuisine { get; set; }

        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public int Servings { get; set; }
        public required string Difficulty { get; set; }
        public  int? CostRange { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>(); // List of ingredients
        public List<Instruction> Instructions { get; set; } = new List<Instruction>(); // List of instructions
        public List<string> Tags { get; set; } = new List<string>(); // Tags (e.g., Vegetarian, Gluten-Free)
        public bool IsVegetarian { get; set; } // Whether the recipe is vegetarian
        public string? Notes { get; set; } // Additional notes
    }
}
