using System.Collections.Generic;

namespace MiamBook.Business.Domain.Entities;

public class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
}
