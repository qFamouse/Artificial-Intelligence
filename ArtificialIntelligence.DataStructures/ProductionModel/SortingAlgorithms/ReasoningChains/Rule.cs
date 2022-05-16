using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.DataStructures.ProductionModel.SortingAlgorithms.ReasoningChains
{
    public delegate void RequestPropertyByName(string nameofProperty);
    public delegate void Act<T>(T knowledge, RequestPropertyByName requestPropertyByName);
    public sealed class Rule<T>
    {
        private T Knowledge { get; set; }
        private RequestPropertyByName RequestPropertyByName { get; set; }
        private Act<T> Act { get; set; }
        public Rule(T knowledge, RequestPropertyByName requestPropertyByName, Act<T> act)
        {
            Knowledge = knowledge;
            RequestPropertyByName = requestPropertyByName;
            Act = act;
        }

        public void Check() => Act(Knowledge, RequestPropertyByName);
    }
}