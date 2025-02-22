﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using my_recipes.Models;

namespace my_recipes.Model
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public required string Category { get;set; }
        [Required]
        public required string Cuisine { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public int Servings { get; set; }
        public required string Difficulty { get; set; }
        public  string? CostRange { get; set; }
        public bool IsVegetarian { get; set; } // Whether the recipe is vegetarian
        public string? Notes { get; set; } // Additional notes
        public ICollection<Tag>? Tags { get; set; } = []; // Tags (e.g., Vegetarian, Gluten-Free)
        public ICollection<Ingredient> Ingredients { get; set; } = []; // List of ingredients
        public ICollection<Instruction> Instructions { get; set; } = []; // List of instructions

        [IgnoreDataMember]
        public string CategoryName => Category.ToString();
    }
}


namespace my_recipes.Model
{
    public class RecipeResponseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Category { get; set; }
    }
}