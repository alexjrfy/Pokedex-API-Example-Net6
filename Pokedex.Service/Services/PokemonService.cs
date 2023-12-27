using Pokedex.Domain.Dto.Pokemon;
using Pokedex.Domain.Interfaces.Repository;
using Pokedex.Domain.Interfaces.Service;
using Pokedex.Domain.Model;
using Pokedex.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Service.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly ITypeRepository _typeRepository;

        public PokemonService(IPokemonRepository pokemonRepository, ITypeRepository typeRepository)
        {
            _pokemonRepository = pokemonRepository ?? throw new ArgumentNullException(nameof(pokemonRepository));
            _typeRepository = typeRepository ?? throw new ArgumentNullException(nameof(typeRepository));
        }

        public async Task<IEnumerable<GetPokemonResponse>> GetAllAsync()
        {
            var pokemons = await _pokemonRepository.GetAllAsync();
            return pokemons.Select(PokemonMapper.EntityToGetResponse);
        }

        public async Task<GetPokemonResponse> GetByNumberAsync(int number)
        {
            var pokemon = await _pokemonRepository.GetByNumber(number);
            return PokemonMapper.EntityToGetResponse(pokemon);
        }

        public async Task<UpdatePokemonResponse?> UpdatePokemonAsync(int number, UpdatePokemonRequest updateRequest)
        {
            var existingPokemon = await _pokemonRepository.GetByNumber(number);

            if (existingPokemon == null)
            {
                return null;
            }

            var t1 = await _typeRepository.GetTypeByNameAsync(updateRequest.Type1);
            var t2 = await _typeRepository.GetTypeByNameAsync(updateRequest.Type2);

            PokemonMapper.UpdateRequestToEntity(updateRequest, existingPokemon, t1, t2);

            await _pokemonRepository.UpdateAsync(existingPokemon);

            return PokemonMapper.EntityToUpdateResponse(existingPokemon);
        }

        public async Task<CreatePokemonResponse?> CreatePokemonAsync(CreatePokemonRequest createRequest)
        {
            try
            {
                var t1 = await _typeRepository.GetTypeByNameAsync(createRequest.Type1);
                var t2 = !string.IsNullOrEmpty(createRequest.Type2) ? await _typeRepository.GetTypeByNameAsync(createRequest.Type2) : null;

                var newPokemon = PokemonMapper.CreateRequestToEntity(createRequest, t1, t2);

                await _pokemonRepository.AddAsync(newPokemon);

                return PokemonMapper.EntityToCreateResponse(newPokemon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}