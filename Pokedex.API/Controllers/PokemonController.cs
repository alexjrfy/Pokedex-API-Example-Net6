using Microsoft.AspNetCore.Mvc;
using Pokedex.Domain.Interfaces.Service;
using Pokedex.Domain.Dto.Pokemon;
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
    public async Task<ActionResult<IEnumerable<GetPokemonResponse>>> GetAll()
    {
        var pokemons = await _pokemonService.GetAllAsync();
        return Ok(pokemons);
    }

    [HttpGet("{number}")]
    public async Task<ActionResult<GetPokemonResponse>> GetByNumber(int number)
    {
        var pokemon = await _pokemonService.GetByNumberAsync(number);

        if (pokemon == null)
        {
            return NotFound();
        }

        return Ok(pokemon);
    }
    [HttpPut("{number}")]
    public async Task<ActionResult<UpdatePokemonResponse>> UpdatePokemon(int number, UpdatePokemonRequest updateRequest)
    {
        try
        {
            var updatedPokemon = await _pokemonService.UpdatePokemonAsync(number, updateRequest);

            if (updatedPokemon == null)
            {
                return NotFound(); 
            }

            return Ok(updatedPokemon);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno ao atualizar o Pokémon");
        }
    }

    [HttpPost]
    public async Task<ActionResult<CreatePokemonResponse>> CreatePokemon(CreatePokemonRequest createRequest)
    {
        var createdPokemon = await _pokemonService.CreatePokemonAsync(createRequest);

        if (createdPokemon == null)
        {
            return BadRequest(); 
        }

        return CreatedAtAction(nameof(GetByNumber), new { number = createdPokemon.Number }, createdPokemon);
    }
}