using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Domain.Dto.Pokemon
{
    public class GetPokemonResponse
    {
        public int Number { get; set; }
        public string Name {  get; set; }
        public string type1 { get; set; }
        public string type2 { get; set; }
    }
}
