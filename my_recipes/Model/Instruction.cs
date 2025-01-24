namespace my_recipes.Model
{
    public class Instruction
    {
        public required int Step { get; set; } // Step number
        public required string Description { get; set; } // Description of the step
        public string? Image { get; set; } // Optional image for the step
    }
}
