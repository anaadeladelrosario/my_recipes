using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using my_recipes.Model;

namespace my_recipes.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public required string TagName { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Recipe>? Recipes { get; set; }  // Navigation property
    }
}
