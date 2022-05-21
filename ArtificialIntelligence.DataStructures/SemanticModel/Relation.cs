using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.DataStructures.SemanticModel
{
    public sealed class Relation
    {
        public string Predicate { get; init; }
        public Entity Entity { get; init; }
    }
}