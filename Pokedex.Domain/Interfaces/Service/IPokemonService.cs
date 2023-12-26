using Pokedex.Domain.Dto.Pokemon;
using Pokedex.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Domain.Interfaces.Service
{
    public interface IPokemonService
    {
        Task<IEnumerable<GetPokemonResponse>> GetAllAsync();
        Task<GetPokemonResponse> GetByNumberAsync(int number);
        Task<UpdatePokemonResponse?> UpdatePokemonAsync(int number, UpdatePokemonRequest updateRequest);
        Task<CreatePokemonResponse?> CreatePokemonAsync(CreatePokemonRequest createRequest);
    }
}