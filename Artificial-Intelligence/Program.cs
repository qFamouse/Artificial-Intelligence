using ArtificialIntelligence.DataStructures.ProductionModel.SortingAlgorithms;
using ArtificialIntelligence.DataStructures.ProductionModel.SortingAlgorithms.ReasoningChains;
using System;
using System.Reflection;

namespace Artificial_Intelligence
{
    internal class Program
    {
        public static void help(Knowledge knowledge, PropertyInfo property)
        {

            property?.SetValue(knowledge, DuplicateData.Nope);
            var h = property?.GetValue(knowledge);
            var c = 1;
        }



        static void Main(string[] args)
        {
            Knowledge knowledge = new Knowledge();

            var a = typeof(DataSize);

            //Rule<Knowledge> rule = new Rule<Knowledge>()
            //{
            //    Check = (knowledge, requestProperty) =>
            //    {
            //        requestProperty(knowledge, Rule<Knowledge>.GetPropertyInfo(nameof(knowledge.DuplicateData)));
            //        Console.WriteLine(knowledge.DuplicateData);
            //    }
            //};

            //rule.Check(knowledge, help);

            RuleSet<Knowledge> ruleSet = new RuleSet<Knowledge>(
                knowledge,
                help,
                new System.Collections.Generic.List<Act<Knowledge>>()
            {
                (know, req) =>
                {
                    know.DataSize = DataSize.Large;
                    req(nameof(know.NecessaryTime));
                }
            });

            //rule.Test(knowledge, help);
        }
    }
}
