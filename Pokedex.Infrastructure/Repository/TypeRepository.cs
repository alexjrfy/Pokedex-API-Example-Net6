using Microsoft.EntityFrameworkCore;
using Pokedex.Domain.Interfaces.Repository;
using Pokedex.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Domain.Model;
namespace Pokedex.Infrastructure.Repository
{
    public class TypeRepository : Repository<Domain.Model.Type>, ITypeRepository
    {
        public TypeRepository(PokemonContext context) : base(context)
        {
        }

        public async Task<Domain.Model.Type?> GetTypeByNameAsync(string typeName)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Name.Equals(typeName));
        }
    }
}
