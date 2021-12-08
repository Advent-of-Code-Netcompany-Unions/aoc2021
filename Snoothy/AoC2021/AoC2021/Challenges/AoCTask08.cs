using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2021.Model;
using System.Drawing;

namespace AoC2021.Challenges
{
    internal class AoCTask08 : AoCTask
    {
        public AoCTask08(string filename) : base(filename) { }

        public override string RunPart1(List<string> lines)
        {
            var result = 0;
            foreach (string line in lines)
            {
                string[] split = line.Split('|');
                var segment = new SevenSegment(split[0], split[1]);
                result += segment.GetSumOfEasyNumbers();
            }
            return result.ToString();
        }

        public override string RunPart2(List<string> lines)
        {
            return "TODO";
        }  
    }

    internal class SevenSegment {
        List<HashSet<char>> numbers = new List<HashSet<char>>();
        List<HashSet<char>> output = new List<HashSet<char>>();

        public SevenSegment(string numbers, string output) {
            splitStringOnSpace(numbers).ForEach(x => this.numbers.Add(splitStringToHashSet(x)));
            splitStringOnSpace(output).ForEach(x => this.output.Add(splitStringToHashSet(x)));
        }

        private List<string> splitStringOnSpace(string input) {
            List<string> result = new List<string>();
            string[] split = input.Split(' ');
            foreach (string s in split) {
                result.Add(s);
            }
            return result;
        }

        private HashSet<char> splitStringToHashSet(string input) {
            HashSet<char> result = new HashSet<char>();
            foreach (char c in input) {
                result.Add(c);
            }
            return result;
        }

        public int GetSumOfEasyNumbers(){
            return countEntries(output);
        }

        // Counts entries of length 2, 3, 4 and 7 in the output
        private int countEntries(List<HashSet<char>> output) {
            int result = 0;
            foreach (HashSet<char> set in output) {
                if (set.Count == 2) {
                    result++;
                } else if (set.Count == 3) {
                    result++;
                } else if (set.Count == 4) {
                    result++;
                } else if (set.Count == 7) {
                    result++;
                }
            }
            return result;
        }
    }
}
