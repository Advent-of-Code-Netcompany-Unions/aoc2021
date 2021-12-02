using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2021.Model;

namespace AoC2021.Challenges
{
    internal class AoCTask02 : AoCTask
    {
        public AoCTask02(string filename) : base(filename) { }

        public override string RunPart1(List<string> lines)
        {
            var submarine = new Submarine();
            lines.ForEach(line => submarine.AddInstruction(line));
            return submarine.GetResult().ToString();
        }

        public override string RunPart2(List<string> lines)
        {
            var submarine = new Submarine();
            lines.ForEach(line => submarine.AddInstruction(line));
            return submarine.GetResult().ToString();
        }

        // Splits string into a string and an int
        private static Tuple<string, int> SplitString(string input)
        {
            string[] split = input.Split('x');
            return new Tuple<string, int>(split[0], int.Parse(split[1]));
        }   
    }
}
