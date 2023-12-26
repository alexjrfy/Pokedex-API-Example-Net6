using Microsoft.EntityFrameworkCore;
using Pokedex.Domain.Model;

namespace Pokedex.Infrastructure.Context
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {
        }
        public DbSet<Pokedex.Domain.Model.Pokemon> Pokemon { get; set; }
        public DbSet<Pokedex.Domain.Model.Type> Types { get; set; }
    }
}
