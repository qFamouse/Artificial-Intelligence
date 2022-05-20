using ArtificialIntelligence.DataStructures.ProductionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Artificial_Intelligence.DataStructures.ProductionModel.SortingAlgorithms
{
    public static class SortingAlgorithms
    {
        public static int ReadInt()
        {
            bool isInt = false;
            int parseInt = 0;

            while (!isInt)
            {
                string key = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                isInt = Int32.TryParse(key, out parseInt);
            }

            return parseInt;
        }

        public static int ReadByRange(int min, int max)
        {
            while (true)
            {
                int num = ReadInt();
                if (num >= min && num <= max)
                {
                    return num;
                }
            }
        }

        public static void RequestProperty(Knowledge knowledge, PropertyInfo propertyInfo)
        {
            int i = 0;
            string[] enumNames = null;
            switch (propertyInfo.Name)
            {
                case nameof(Knowledge.DataSize):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.DataSize)}");
                    enumNames = Enum.GetNames(typeof(DataSize));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (DataSize)i);
                    break;

                case nameof(Knowledge.SortingType):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.SortingType)}");
                    enumNames = Enum.GetNames(typeof(SortingType));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (SortingType)i);
                    break;

                case nameof(Knowledge.MemoryUsed):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.MemoryUsed)}");
                    enumNames = Enum.GetNames(typeof(MemoryUsed));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (MemoryUsed)i);
                    break;

                case nameof(Knowledge.NecessaryTime):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.NecessaryTime)}");
                    enumNames = Enum.GetNames(typeof(NecessaryTime));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (NecessaryTime)i);
                    break;

                case nameof(Knowledge.Stability):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.Stability)}");
                    enumNames = new string[] {"No", "Yes"};
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, Convert.ToBoolean(i));
                    break;

                case nameof(Knowledge.ExecutionSpeed):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.ExecutionSpeed)}");
                    enumNames = Enum.GetNames(typeof(ExecutionSpeed));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (ExecutionSpeed)i);
                    break;

                case nameof(Knowledge.DuplicateData):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.DuplicateData)}");
                    enumNames = Enum.GetNames(typeof(DuplicateData));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (DuplicateData)i);
                    break;

                case nameof(Knowledge.Result):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.Result)}");
                    enumNames = Enum.GetNames(typeof(Sorting));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (Sorting)i);
                    break;
                default:
                    throw new NotSupportedException("Not supported type");
            }
        }

        private static List<Rule<Knowledge>> GetRules()
        {
            return new List<Rule<Knowledge>>()
            {
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.DataSize), nameof(Knowledge.ExecutionSpeed)},
                    Returns = nameof(Knowledge.NecessaryTime),
                    Act = (knowledge, request) =>
                    {
                        Fact dataSizeFact = new Fact(nameof(knowledge.DataSize), knowledge.DataSize, DataSize.Large);
                        Fact executionSpeedFact = new Fact(nameof(knowledge.ExecutionSpeed), knowledge.ExecutionSpeed, ExecutionSpeed.Slow);

                        if (Rule<Knowledge>.CheckFacts(knowledge, request, dataSizeFact, executionSpeedFact))
                        {
                            knowledge.NecessaryTime = NecessaryTime.Many;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.ExecutionSpeed), nameof(Knowledge.DuplicateData), nameof(Knowledge.Stability)},
                    Returns = nameof(Knowledge.Result),
                    Act = (knowledge, request) =>
                    {
                        Fact speedFact = new Fact(nameof(knowledge.ExecutionSpeed), knowledge.ExecutionSpeed, ExecutionSpeed.Medium);
                        Fact duplicateDataFact = new Fact(nameof(knowledge.DuplicateData), knowledge.DuplicateData, DuplicateData.Many);
                        Fact stabilityFact = new Fact(nameof(knowledge.Stability), knowledge.Stability, false);

                        if (Rule<Knowledge>.CheckFacts(knowledge, request, speedFact, duplicateDataFact, stabilityFact))
                        {
                            knowledge.Result = Sorting.Quicksort;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.SortingType), nameof(Knowledge.MemoryUsed)},
                    Returns = nameof(Knowledge.Result),
                    Act = (knowledge, request) =>
                    {
                        Fact fact1 = new Fact(nameof(knowledge.SortingType), knowledge.SortingType, SortingType.External);
                        Fact fact2 = new Fact(nameof(knowledge.MemoryUsed), knowledge.MemoryUsed, MemoryUsed.Low);

                        if (Rule<Knowledge>.CheckFacts(knowledge, request, fact1, fact2))
                        {
                            knowledge.Result = Sorting.Cascade;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.SortingType), nameof(Knowledge.DuplicateData)},
                    Returns = nameof(Knowledge.MemoryUsed),
                    Act = (knowledge, request) =>
                    {
                        Fact fact1 = new Fact(nameof(knowledge.SortingType), knowledge.SortingType, SortingType.External);
                        Fact fact2 = new Fact(nameof(knowledge.DuplicateData), knowledge.DuplicateData, DuplicateData.Many);

                        if (Rule<Knowledge>.CheckFacts(knowledge, request, fact1, fact2))
                        {
                            knowledge.MemoryUsed = MemoryUsed.High;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.SortingType), nameof(Knowledge.MemoryUsed), nameof(Knowledge.Stability)},
                    Returns = nameof(Knowledge.Result),
                    Act = (knowledge, request) =>
                    {
                        Fact fact1 = new Fact(nameof(knowledge.SortingType), knowledge.SortingType, SortingType.External);
                        Fact fact2 = new Fact(nameof(knowledge.MemoryUsed), knowledge.MemoryUsed, MemoryUsed.High);
                        Fact fact3 = new Fact(nameof(knowledge.Stability), knowledge.Stability, true);

                        if (Rule<Knowledge>.CheckFacts(knowledge, request, fact1, fact2, fact3))
                        {
                            knowledge.Result = Sorting.Polyphase;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.DataSize)},
                    Returns = nameof(Knowledge.Result),
                    Act = (knowledge, request) =>
                    {
                        if (knowledge.DataSize == DataSize.Small)
                        {
                            knowledge.Result = Sorting.Bubble;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.ExecutionSpeed), nameof(Knowledge.Stability)},
                    Returns = nameof(Knowledge.Result),
                    Act = (knowledge, request) =>
                    {
                        Fact fact1 = new Fact(nameof(knowledge.ExecutionSpeed), knowledge.ExecutionSpeed, ExecutionSpeed.Medium);
                        Fact fact2 = new Fact(nameof(knowledge.Stability), knowledge.Stability, true);

                        if (Rule<Knowledge>.CheckFacts(knowledge, request, fact1, fact2))
                        {
                            knowledge.Result = Sorting.Heapsort;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.NecessaryTime), nameof(Knowledge.MemoryUsed)},
                    Returns = nameof(Knowledge.Stability),
                    Act = (knowledge, request) =>
                    {
                        Fact fact1 = new Fact(nameof(knowledge.NecessaryTime), knowledge.NecessaryTime, NecessaryTime.Many);
                        Fact fact2 = new Fact(nameof(knowledge.MemoryUsed), knowledge.MemoryUsed, MemoryUsed.High);

                        if (Rule<Knowledge>.CheckFacts(knowledge, request, fact1, fact2))
                        {
                            knowledge.Stability = true;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.SortingType), nameof(Knowledge.ExecutionSpeed)},
                    Returns = nameof(Knowledge.Result),
                    Act = (knowledge, request) =>
                    {
                        Fact fact1 = new Fact(nameof(knowledge.SortingType), knowledge.SortingType, SortingType.Intenal);
                        Fact fact2 = new Fact(nameof(knowledge.ExecutionSpeed), knowledge.ExecutionSpeed, ExecutionSpeed.Medium);

                        if (Rule<Knowledge>.CheckFacts(knowledge, request, fact1, fact2))
                        {
                            knowledge.Result = Sorting.Insertion;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.DuplicateData)},
                    Returns = nameof(Knowledge.DataSize),
                    Act = (knowledge, request) =>
                    {
                        if (knowledge.DuplicateData == DuplicateData.Many)
                        {
                            knowledge.DataSize = DataSize.Large;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.DataSize), nameof(Knowledge.ExecutionSpeed)},
                    Returns = nameof(Knowledge.Result),
                    Act = (knowledge, request) =>
                    {
                        Fact fact1 = new Fact(nameof(knowledge.DataSize), knowledge.DataSize, DataSize.Large);
                        Fact fact2 = new Fact(nameof(knowledge.ExecutionSpeed), knowledge.ExecutionSpeed, ExecutionSpeed.Fast);

                        if (Rule<Knowledge>.CheckFacts(knowledge, request, fact1, fact2))
                        {
                            knowledge.Result = Sorting.Timsort;
                            return true;
                        };

                        return false;
                    },
                },
                new Rule<Knowledge>()
                {
                    Input = new string[] {nameof(Knowledge.DataSize)},
                    Returns = nameof(Knowledge.ExecutionSpeed),
                    Act = (knowledge, request) =>
                    {
                        if (knowledge.DataSize == DataSize.Large)
                        {
                            knowledge.ExecutionSpeed = ExecutionSpeed.Slow;
                            return true;
                        };

                        return false;
                    },
                },
            };
        }

        public static void Test()
        {
            //Knowledge knowledge = new Knowledge();

            //knowledge.ExecutionSpeed = ExecutionSpeed.Medium;
            //knowledge.DuplicateData = DuplicateData.Many;

            //Console.WriteLine($"Result: {ForwardChaining(knowledge)}");

            Knowledge knowledge = new Knowledge();

            string desiredProperty = nameof(knowledge.NecessaryTime);

            var rules = GetRules();
            Stack<Rule<Knowledge>> ruleStack = new Stack<Rule<Knowledge>>();

            PushDependencies(rules, ruleStack, desiredProperty);

            ruleStack.TryPeek(out Rule<Knowledge> rule1);

            foreach(var input in rule1.Input)
            {
                RequestProperty(knowledge, typeof(Knowledge).GetProperty(input));
            }



            while (ruleStack.TryPop(out Rule<Knowledge> rule))
            {
                rule.Act(knowledge, RequestProperty);
            }

            var c = 1;

        }

        public static void PushDependencies(List<Rule<Knowledge>> rules, Stack<Rule<Knowledge>> ruleStack, string desiredProperty)
        {
            Rule<Knowledge> desiredRule = rules.Find(r => r.Returns.Equals(desiredProperty));

            if (desiredRule != null)
            {
                ruleStack.Push(desiredRule);
                rules.Remove(desiredRule);

                foreach (var input in desiredRule.Input)
                {
                    PushDependencies(rules, ruleStack, input);
                }
            }
        }


        public static Sorting ForwardChaining(Knowledge knowledge)
        {
            var rules = new LinkedList<Rule<Knowledge>>(GetRules());

            var currentRule = rules.First;
            while (knowledge.Result == Sorting.Unknown && rules.Count > 0 && currentRule != null)
            {
                if (currentRule.Value.Act(knowledge, RequestProperty))
                {
                    rules.Remove(currentRule);
                    currentRule = rules.First;
                }
                else
                {
                    currentRule = currentRule.Next;
                }
            }

            return knowledge.Result;
        }

        
    }
}
