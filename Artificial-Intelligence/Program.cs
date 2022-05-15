using ArtificialIntelligence.DataStructures.ProductionModel.SortingAlgorithms;
using ArtificialIntelligence.DataStructures.ProductionModel.SortingAlgorithms.ReasoningChains;
using System;

namespace Artificial_Intelligence
{
    internal class Program
    {
        public static object help(Type type)
        {
            

            switch (type.Name)
            {
                case "DuplicateData": return DuplicateData.Many;
                default: throw new ArgumentNullException(nameof(type));
            }
        }

        static void Main(string[] args)
        {
            Knowledge knowledge = new Knowledge();

            var a = typeof(DataSize);

            Rule rule = new Rule();
            rule.Test(knowledge, help);

            Console.WriteLine("Hello World!");
        }
    }
}
