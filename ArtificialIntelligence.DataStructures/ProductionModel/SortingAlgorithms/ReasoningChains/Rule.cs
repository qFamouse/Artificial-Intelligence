using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntelligence.DataStructures.ProductionModel.SortingAlgorithms.ReasoningChains
{
    public class Rule
    {
        public delegate object MoreInfo(Type type);

        public void Test(Knowledge knowledge, MoreInfo moreInfo)
        {
            knowledge.DuplicateData = (DuplicateData) moreInfo(typeof(DuplicateData));
            Console.WriteLine(knowledge.DuplicateData);
        }
    }
}