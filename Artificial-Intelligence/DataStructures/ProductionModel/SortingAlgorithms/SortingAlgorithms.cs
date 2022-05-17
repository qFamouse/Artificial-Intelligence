using ArtificialIntelligence.DataStructures.ProductionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial_Intelligence.DataStructures.ProductionModel.SortingAlgorithms
{
    public static class SortingAlgorithms
    {
        private static bool RequestCondition(out string nameof, params object[] @params)
        {
            // 2+ null is bad
            // 1 null is good
        }
        private static List<Act<Knowledge>> GetActs()
        {
            return new List<Act<Knowledge>>()
            {
                (k, request) => // k - knowledge
                {
                    if (k.DataSize == null && k.ExecutionSpeed != null)
                    {
                        request(nameof(k.DataSize));
                    }
                    else if (k.DataSize != null && k.ExecutionSpeed == null)
                    {
                        request(nameof(k.ExecutionSpeed));
                    }

                    if (k.DataSize == DataSize.Large &&
                        k.ExecutionSpeed == ExecutionSpeed.Slow)
                    {
                        k.NecessaryTime = NecessaryTime.Many;
                    }
                },
                (k, request) =>
                {
                    if (k.ExecutionSpeed == null && k.DuplicateData != null && k.Stability != null)
                    {
                        request(nameof(k.ExecutionSpeed));
                    }
                    else if (k.ExecutionSpeed != null && k.DuplicateData == null && k.Stability != null)
                    {
                        request(nameof(k.DuplicateData));
                    }
                    else if (k.ExecutionSpeed != null && k.DuplicateData != null && k.Stability == null)
                    {
                        request(nameof(k.Stability));
                    }

                    if (k.ExecutionSpeed == ExecutionSpeed.Medium &&
                        k.DuplicateData == DuplicateData.Many &&
                        k.Stability ==  false)
                    {
                        k.Result = Sorting.Quicksort;
                    }
                },
                (k, request) =>
                {
                    if (k.SortingType == null && k.MemoryUsed != null)
                    {
                        request(nameof(k.SortingType));
                    }
                    else if (k.SortingType != null && k.MemoryUsed == null)
                    {
                        request(nameof(k.MemoryUsed));
                    }

                    if (k.DataSize == DataSize.Large &&
                        k.ExecutionSpeed == ExecutionSpeed.Slow)
                    {
                        k.NecessaryTime = NecessaryTime.Many;
                    }
                },
                (k, request) =>
                {

                },
                (k, request) =>
                {

                },
                (k, request) =>
                {

                },
                (k, request) =>
                {

                },
                (k, request) =>
                {

                },
                (k, request) =>
                {

                },
                (k, request) =>
                {

                },
                (k, request) =>
                {

                },

            };
        }

        public static void Test()
        {

        }
    }
}
