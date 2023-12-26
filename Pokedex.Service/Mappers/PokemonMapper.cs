using Pokedex.Domain.Dto.Pokemon;
using Pokedex.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Service.Mappers
{
    public class PokemonMapper
    {
        public static GetPokemonResponse EntityToGetResponse(Pokemon pokemon)
        {
            if (pokemon == null)
                return null;

            return new GetPokemonResponse
            {
                Number = pokemon.Number,
                Name = pokemon.Name,
                type1 = pokemon.Type1?.Name,
                type2 = pokemon.Type2?.Name
            };
        }

        public static void UpdateRequestToEntity(UpdatePokemonRequest updateRequest, Pokemon pokemon, Domain.Model.Type type1, Domain.Model.Type type2)
        {
            pokemon.Name = updateRequest.Name;
            pokemon.Type1 = type1;
            pokemon.Type2 = type2;
        }

        public static UpdatePokemonResponse EntityToUpdateResponse(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return null;
            }

            return new UpdatePokemonResponse
            {
                Number = pokemon.Number,
                Name = pokemon.Name,
                Type1 = pokemon.Type1?.Name ?? string.Empty,
                Type2 = pokemon.Type2?.Name ?? string.Empty
            };
        }

        public static Pokemon CreateRequestToEntity(CreatePokemonRequest createRequest, Domain.Model.Type type1, Domain.Model.Type? type2)
        {
            if (createRequest == null)
            {
                return null;
            }

            return new Pokemon
            {
                Number = createRequest.Number,
                Name = createRequest.Name,
                Type1 = type1,
                Type2 = type2
            };
        }

        public static CreatePokemonResponse EntityToCreateResponse(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return null;
            }

            return new CreatePokemonResponse
            {
                Number = pokemon.Number,
                Name = pokemon.Name,
                Type1 = pokemon.Type1?.Name ?? string.Empty,
                Type2 = pokemon.Type2?.Name ?? string.Empty
            };
        }
    }
}
