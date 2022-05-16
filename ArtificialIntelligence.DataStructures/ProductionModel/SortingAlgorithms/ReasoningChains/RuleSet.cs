using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ArtificialIntelligence.DataStructures.ProductionModel.SortingAlgorithms.ReasoningChains
{
    public delegate void RequestProperty<T>(T knowledge, PropertyInfo propertyInfo);
    public sealed class RuleSet<T>
    {
        private LinkedList<Rule<T>> Rules { get; set; }
        private T Knowledge { get; set; }
        private RequestProperty<T> RequestProperty { get; set; }

        private LinkedListNode<Rule<T>> _currentNode;
        public Rule<T> CurrentRule
        {
            get => _currentNode.Value;
        }

        public RuleSet(T knowledge, RequestProperty<T> requestProperty, List<Act<T>> acts)
        {
            Knowledge = knowledge ?? throw new NullReferenceException(nameof(knowledge));
            RequestProperty = requestProperty ?? throw new NullReferenceException(nameof(requestProperty));
            Rules = new LinkedList<Rule<T>>();

            foreach (var act in acts)
            {
                Rules.AddLast(new Rule<T>(knowledge, RequestPropertyByName, act));
                Rules.First.Value.Check();
            }
        }

        private void RequestPropertyByName(string nameofProperty)
        {
            RequestProperty(Knowledge, typeof(T).GetProperty(nameofProperty));
        }
    }
}