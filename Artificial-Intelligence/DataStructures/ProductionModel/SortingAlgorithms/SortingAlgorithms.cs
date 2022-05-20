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

        public static string RequestProperty(Knowledge knowledge, PropertyInfo propertyInfo)
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
                    return enumNames[i];

                case nameof(Knowledge.SortingType):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.SortingType)}");
                    enumNames = Enum.GetNames(typeof(SortingType));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (SortingType)i);
                    return enumNames[i];

                case nameof(Knowledge.MemoryUsed):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.MemoryUsed)}");
                    enumNames = Enum.GetNames(typeof(MemoryUsed));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (MemoryUsed)i);
                    return enumNames[i];

                case nameof(Knowledge.NecessaryTime):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.NecessaryTime)}");
                    enumNames = Enum.GetNames(typeof(NecessaryTime));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (NecessaryTime)i);
                    return enumNames[i];

                case nameof(Knowledge.Stability):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.Stability)}");
                    enumNames = new string[] {"No", "Yes"};
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, Convert.ToBoolean(i));
                    return Convert.ToBoolean(i).ToString();

                case nameof(Knowledge.ExecutionSpeed):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.ExecutionSpeed)}");
                    enumNames = Enum.GetNames(typeof(ExecutionSpeed));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (ExecutionSpeed)i);
                    return enumNames[i];

                case nameof(Knowledge.DuplicateData):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.DuplicateData)}");
                    enumNames = Enum.GetNames(typeof(DuplicateData));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (DuplicateData)i);
                    return enumNames[i];

                case nameof(Knowledge.Result):
                    Console.WriteLine($"Please enter: {nameof(Knowledge.Result)}");
                    enumNames = Enum.GetNames(typeof(Sorting));
                    enumNames.ToList().ForEach(name => Console.WriteLine($"{i++}. {name}"));
                    i = ReadByRange(0, enumNames.Length);
                    propertyInfo.SetValue(knowledge, (Sorting)i);
                    return enumNames[i];
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
                        };
                    },
                }
            };
        }

        public static void Test()
        {


            //var a = GetRules();

            //Knowledge knowledge = new Knowledge();
            //var s = knowledge.DataSize;
            //{
            //    ExecutionSpeed = ExecutionSpeed.Medium,
            //    DuplicateData = null,
            //    Stability = false
            //};

            //a[1].Act(knowledge, null);

            //Console.WriteLine(RequestProperty(knowledge, typeof(Knowledge).GetProperty(nameof(knowledge.ExecutionSpeed))));
        }
    }
}
