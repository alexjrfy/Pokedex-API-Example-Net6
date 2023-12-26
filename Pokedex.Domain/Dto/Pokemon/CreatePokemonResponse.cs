using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Domain.Dto.Pokemon
{
    public class CreatePokemonResponse
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string? Type2 { get; set; }
    }
}
