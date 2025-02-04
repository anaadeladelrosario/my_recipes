using System;
using Microsoft.EntityFrameworkCore;
using my_recipes.Models;
using my_recipes.Model;


namespace my_recipes
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration (e.g., seed data, relationships) can go here

            // Configure the one-to-many relationship
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients); // A recipe has many ingredients

            // Configure one-to-many relationship between Recipe and Instruction
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Instructions);

            // Configure many-to-many relationship between Recipe and Tag
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Tags);
        }
    }
}
