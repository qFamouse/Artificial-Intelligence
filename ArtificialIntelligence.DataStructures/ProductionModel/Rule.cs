using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.DataStructures.ProductionModel
{
    public delegate string RequestProperty<T>(T knowledge, PropertyInfo propertyInfo);
    public delegate void Act<T>(T knowledge, RequestProperty<T> request);
    public sealed class Rule<T>
    {
        public bool IsSimple => Input.Length == 1;

        public Act<T> Act { get; init; }
        public String[] Input { get; init; }
        public String Returns { get; init; }
        public Rule(Act<T> act, string returns, params string[] input)
        {
            Act = act ?? throw new NullReferenceException(nameof(act));
            Returns = returns ?? throw new NullReferenceException(nameof(returns));
            Input = input ?? throw new NullReferenceException(nameof(input)); ;
        }

        public Rule() { }

        public static bool CheckFacts(T knowledge, RequestProperty<T> request, params Fact[] facts)
        {
            int trueFactsNumber = 0; // The number of true facts
            Fact nullFact = null;

            foreach (var fact in facts)
            {
                if (fact.CurrentValue is null)
                {
                    nullFact = fact;
                }
                else if (fact.CurrentValue.Equals(fact.TrueValue))
                {
                    trueFactsNumber++;
                }
            }

            if (nullFact is not null && trueFactsNumber == facts.Length - 1)
            {
                nullFact.CurrentValue = request(knowledge, typeof(T).GetProperty(nullFact.PropertyName));
                trueFactsNumber += nullFact.CurrentValue == nullFact.TrueValue ? 1 : 0;
            }

            return trueFactsNumber == facts.Length ? true : false;
        }
    }

    public sealed class Fact
    {
        public string PropertyName { get; set; }
        public object CurrentValue { get; set; }
        public object TrueValue { get; set; }

        public Fact(string propertyName, object currentValue, object trueValue)
        {
            PropertyName = propertyName;
            CurrentValue = currentValue;
            TrueValue = trueValue;
        }
    }
}