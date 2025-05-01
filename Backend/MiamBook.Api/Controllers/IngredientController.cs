using MiamBook.Api.Models;
using MiamBook.Business.Application.Managers;
using MiamBook.Business.Domain.Entities;
using MiamBook.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MiamBook.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IngredientManager _ingredientManager;

    public IngredientController(IngredientManager ingredientManager) 
    {
        _ingredientManager = ingredientManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetAll()
    {
        var ingredients = await _ingredientManager.GetAllAsync();
        return Ok(ingredients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientResponseModel>> GetById(int id)
    {
        var ingredient = await _ingredientManager.GetByIdAsync(id);
        if (ingredient == null)
        {
            return NotFound();
        }

        return Ok(ingredient);
    }

    [HttpPost]
    public async Task<ActionResult<IngredientResponseModel>> Create([FromBody] IngredientCreateModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Appel au manager pour gérer la création
        var responseModel = await _ingredientManager.CreateAsync(model);

        return CreatedAtAction(nameof(GetById), new { id = responseModel.Id }, responseModel);
    }
} 
