using MiamBook.Api.Models;
using MiamBook.Business.Domain.Entities;

namespace MiamBook.Business.Application.Extensions;

public static class IngredientExtensions
{
    public static Ingredient ToEntity(this IngredientCreateModel model)
    {
        return new Ingredient
        {
            Name = model.Name
        };
    }

    public static IngredientResponseModel ToDto(this Ingredient ingredient)
    {
        return new IngredientResponseModel
        {
            Id = ingredient.Id,
            Name = ingredient.Name
        };
    }
}
