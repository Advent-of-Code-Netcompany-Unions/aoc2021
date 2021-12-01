using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021.Challenges
{
    internal class AoCTask01 : AoCTask
    {
        public AoCTask01(string filename) : base(filename) { }

        public override string RunPart1(List<string> lines)
        {
            var intList = convertListToInteger(lines);
            return countNextLarger(intList).ToString();
        }

        // Counts number of times the next element is larger than the current element
        private int countNextLarger(List<int> intList)
        {
            int count = 0;
            for (int i = 0; i < intList.Count - 1; i++)
            {
                if (intList[i] < intList[i + 1])
                {
                    count++;
                }
            }
            return count;
        }

        public override string RunPart2(List<string> lines)
        {
            var intList = convertListToInteger(lines);
            return countNextLargerSlidingWindow(intList).ToString();
        }

        // Counts next larger element in list using sliding window
        private int countNextLargerSlidingWindow(List<int> intList){
            int count = 0;
            int windowSize = 3;
            for (int i = 0; i < intList.Count - windowSize; i++)
            {
                if (intList[i] < intList[i + windowSize])
                {
                    count++;
                }
            }
            return count;
        }
        
    
    }
}
