namespace my_recipes.Model
{
    public class Ingredient
    {
        public required string Name { get; set; } // Name of the ingredient
        public required double Quantity { get; set; } // Quantity of the ingredient
        public required string Unit { get; set; } // Unit of measurement (e.g., grams, cups)
        public bool Optional { get; set; } // Whether the ingredient is optional
        public string? Preparation { get; set; } // Optional preparation instructions
    }
}
