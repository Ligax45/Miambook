using System;
using System.Collections.Generic;

namespace MiamBook.Business.Domain.Entities;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int PreparationTime { get; set; }
    public int CookingTime { get; set; }
    public int RestTime { get; set; }
    public int Servings { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TypeRecipeId { get; set; }
    public int? PhotoRecipeId { get; set; }
    public ICollection<Step> Steps { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    public TypeRecipe TypeRecipe { get; set; }
    public PhotoRecipe? Photo { get; set; }
    public ICollection<Comment> Comments { get; set; }

    public Recipe()
    {
        Steps = new List<Step>();
        RecipeIngredients = new List<RecipeIngredient>();
    }

    public Recipe(string title, string description, int preparationTime, int cookingTime, int restTime, int servings, TypeRecipe typeRecipe, PhotoRecipe? photoRecipe = null)
    {
        Title = title;
        Description = description;
        PreparationTime = preparationTime;
        CookingTime = cookingTime;
        RestTime = restTime;
        Servings = servings;
        CreatedAt = DateTime.UtcNow;
        TypeRecipe = typeRecipe ?? throw new ArgumentNullException(nameof(typeRecipe));
        Steps = new List<Step>();
        RecipeIngredients = new List<RecipeIngredient>();
        Comments = new List<Comment>();
        Photo = photoRecipe;
    }
}
