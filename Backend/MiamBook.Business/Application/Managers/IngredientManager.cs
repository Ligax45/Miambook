using MiamBook.Api.Models;
using MiamBook.Business.Application.Extensions;
using MiamBook.Business.Domain.Entities;
using MiamBook.Business.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiamBook.Business.Application.Managers;

public class IngredientManager
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientManager(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public async Task<IEnumerable<Ingredient>> GetAllAsync()
    {
        return await _ingredientRepository.GetAllAsync();
    }

    public async Task<IngredientResponseModel> GetByIdAsync(int id)
    {
        var ingredient = await _ingredientRepository.GetByIdAsync(id);
        return ingredient?.ToDto();
    }

    public async Task<IngredientResponseModel> CreateAsync(IngredientCreateModel model)
    {
        var ingredient = model.ToEntity();

        await _ingredientRepository.AddAsync(ingredient);

        return ingredient.ToDto();
    }
}
