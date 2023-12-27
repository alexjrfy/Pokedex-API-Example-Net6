using Microsoft.AspNetCore.Mvc;
using Pokedex.Domain.Interfaces.Service;
using Pokedex.Domain.Dto.Pokemon;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<GetPokemonResponse>))]
    public async Task<ActionResult<IEnumerable<GetPokemonResponse>>> GetAll()
    {
        var pokemons = await _pokemonService.GetAllAsync();
        return Ok(pokemons);
    }

    [HttpGet("{number}")]
    [ProducesResponseType(200, Type = typeof(GetPokemonResponse))]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<GetPokemonResponse>> GetByNumber(int number)
    {
        if (number <= 0)
        {
            return BadRequest("Invalid number");
        }

        var pokemon = await _pokemonService.GetByNumberAsync(number);

        if (pokemon == null)
        {
            return NotFound("Pokemon not found");
        }

        return Ok(pokemon);
    }

    [HttpPut("{number}")]
    [ProducesResponseType(200, Type = typeof(UpdatePokemonResponse))]
    [ProducesResponseType(404)]
    [ProducesResponseType(500, Type = typeof(string))]
    public async Task<ActionResult<UpdatePokemonResponse>> UpdatePokemon(int number, UpdatePokemonRequest updateRequest)
    {
        try
        {
            var updatedPokemon = await _pokemonService.UpdatePokemonAsync(number, updateRequest);

            if (updatedPokemon == null)
            {
                return NotFound("Pokemon not found");
            }

            return Ok(updatedPokemon);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal error while updating the Pokemon: {ex.Message}");
        }
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(CreatePokemonResponse))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<CreatePokemonResponse>> CreatePokemon(CreatePokemonRequest createRequest)
    {
        var createdPokemon = await _pokemonService.CreatePokemonAsync(createRequest);

        if (createdPokemon == null)
        {
            return BadRequest("Failed to create the Pokemon");
        }

        return CreatedAtAction(nameof(GetByNumber), new { number = createdPokemon.Number }, createdPokemon);
    }
}