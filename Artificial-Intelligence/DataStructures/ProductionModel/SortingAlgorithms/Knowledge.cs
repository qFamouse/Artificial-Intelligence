using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial_Intelligence.DataStructures.ProductionModel.SortingAlgorithms
{
    public enum DataSize
    {
        Small, Medium, Large
    }

    public enum SortingType
    {
        Intenal, External
    }

    public enum MemoryUsed
    {
        Low, Medium, High
    }

    public enum NecessaryTime
    {
        Small, Many
    }

    public enum ExecutionSpeed
    {
        Slow, Medium, Fast
    }

    public enum DuplicateData
    {
        Nope, Few, Many
    }

    public enum Sorting
    {
        Unknown,
        // Intenal
        Bubble,
        Heapsort,
        Quicksort,
        Insertion,
        Timsort,
        // External
        Cascade,
        Polyphase,
    }

    public class Knowledge
    {
        public DataSize? DataSize { get; set; }
        public SortingType? SortingType { get; set; }
        public MemoryUsed? MemoryUsed { get; set; }
        public NecessaryTime? NecessaryTime { get; set; }
        public bool? Stability { get; set; }
        public ExecutionSpeed? ExecutionSpeed { get; set; }
        public DuplicateData? DuplicateData { get; set; }

        public Sorting Result { get; set; }
    }
}
