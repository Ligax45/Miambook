using MiamBook.Business.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiamBook.Business.Domain.Interfaces;

public interface IIngredientRepository
{
    Task<IEnumerable<Ingredient>> GetAllAsync();
    Task<Ingredient?> GetByIdAsync(int id);
    Task AddAsync(Ingredient ingredient);
}
