using Pokedex.Domain.Dto.Pokemon;
using Pokedex.Domain.Model;

namespace Pokedex.Service.Mappers
{
    public class PokemonMapper
    {
        public static GetPokemonResponse? EntityToGetResponse(Pokemon pokemon)
        {
            return pokemon == null ? null : new GetPokemonResponse
            {
                Number = pokemon.Number,
                Name = pokemon.Name,
                Type1 = pokemon.Type1?.Name,
                Type2 = pokemon.Type2?.Name
            };
        }

        public static void UpdateRequestToEntity(UpdatePokemonRequest updateRequest, Pokemon pokemon, Domain.Model.Type type1, Domain.Model.Type type2)
        {
            pokemon.Name = updateRequest.Name;
            pokemon.Type1 = type1;
            pokemon.Type2 = type2;
        }

        public static UpdatePokemonResponse? EntityToUpdateResponse(Pokemon pokemon)
        {
            return pokemon == null ? null : new UpdatePokemonResponse
            {
                Number = pokemon.Number,
                Name = pokemon.Name,
                Type1 = pokemon.Type1?.Name ?? string.Empty,
                Type2 = pokemon.Type2?.Name ?? string.Empty
            };
        }

        public static Pokemon? CreateRequestToEntity(CreatePokemonRequest createRequest, Domain.Model.Type type1, Domain.Model.Type? type2)
        {
            return createRequest == null ? null : new Pokemon
            {
                Number = createRequest.Number,
                Name = createRequest.Name,
                Type1 = type1,
                Type2 = type2
            };
        }

        public static CreatePokemonResponse? EntityToCreateResponse(Pokemon pokemon)
        {
            return pokemon == null ? null : new CreatePokemonResponse
            {
                Number = pokemon.Number,
                Name = pokemon.Name,
                Type1 = pokemon.Type1?.Name ?? string.Empty,
                Type2 = pokemon.Type2?.Name ?? string.Empty
            };
        }
    }
}
