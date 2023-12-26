using Pokedex.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Domain.Interfaces.Repository
{
    public interface IPokemonRepository : IRepository<Pokemon>
    {
        Task<Pokemon?> GetByNumber(int number);
        Task<List<Pokemon>?> GetAllAsync();
        Task UpdatePokemonAsync(Pokemon updatedPokemon);
    }
}
