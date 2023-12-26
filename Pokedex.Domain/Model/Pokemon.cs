using Pokedex.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Domain.Model
{
    public class Pokemon : BaseEntity
    {
        public int Number { get; set; }
        public String Name { get; set; }
        public Type Type1 { get; set; }
        public Type? Type2 { get; set; }
    }
}
