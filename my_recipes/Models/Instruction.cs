using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using my_recipes.Model;

namespace my_recipes.Models
{
    public class Instruction
    {
        [Key]
        public int Id { get; set; } // Primary key
        [Required]
        public int Step { get; set; } // Step number
        [Required]
        public required string Description { get; set; } // Description of the step
        public string? Image { get; set; } // Optional image for the step


        public int RecipeId { get; set; }  // Foreign key to Recipe
        public Recipe? Recipe { get; set; }  // Navigation property back to Recipe
    }
}
