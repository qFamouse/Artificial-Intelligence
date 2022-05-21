using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.DataStructures.SemanticModel
{
    public sealed class Entity
    {
        public string Name { get; init; }
        public LinkedList<Relation> Relations { get; init; }

        public Entity(string name, LinkedList<Relation> relations)
        {
            Name = name ?? throw new NullReferenceException(nameof(name));
            Relations = relations ?? throw new NullReferenceException(nameof(name));
        }

        public Entity(string name)
        {
            Name = name ?? throw new NullReferenceException(nameof(name));
            Relations = new LinkedList<Relation>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}