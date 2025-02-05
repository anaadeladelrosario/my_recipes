using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using my_recipes.Model;

namespace my_recipes.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; } // Name of the ingredient
        [Required]
        public required double Quantity { get; set; } // Quantity of the ingredient
        [Required]
        public required string Unit { get; set; } // Unit of measurement (e.g., grams, cups)
        public bool Optional { get; set; } // Whether the ingredient is optional
        public string? Preparation { get; set; } // Optional preparation instructions
                                                 // Foreign key property

        public int RecipeId { get; set; }  // Foreign key to Recipe
    }
}
