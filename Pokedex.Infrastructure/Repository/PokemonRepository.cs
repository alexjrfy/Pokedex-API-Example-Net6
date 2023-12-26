using Pokedex.Domain.Model;
using Pokedex.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Pokedex.Infrastructure.Repository
{
    public class PokemonRepository : Repository<Pokemon>, IPokemonRepository
    {
        public PokemonRepository(DbContext context) : base(context)
        {
        }

        public async Task<Pokemon?> GetByNumber(int number)
        {
            return await _dbSet
                .Include(p => p.Type1)
                .Include(p => p.Type2)
                .FirstOrDefaultAsync(p => p.Number == number);
        }
        public async Task<List<Pokemon>?> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Type1)
                .Include(p => p.Type2)
                .OrderBy(p => p.Number)
                .ToListAsync();
        }

        public async Task UpdatePokemonAsync(Pokemon updatedPokemon)
        {
         
            var existingPokemon = await _dbSet.FindAsync(updatedPokemon.Id);

            if (existingPokemon == null)
            {
                throw new ArgumentException("Pokémon não encontrado");
            }

            existingPokemon.Number = updatedPokemon.Number;
            existingPokemon.Name = updatedPokemon.Name;
            existingPokemon.Type1 = updatedPokemon.Type1;
            existingPokemon.Type2 = updatedPokemon.Type2;

            await SaveChanges();
        }


    }
}
