using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    internal abstract class AoCTask
    {
        private string filename;
        public AoCTask(string filename)
        {
            this.filename = filename;
        }
        
        public void RunChallenge()
        {
            var lines = ReadLines();
            Console.WriteLine();
            Console.WriteLine($"--- {filename} ---");
            Console.WriteLine($"part 1: {RunPart1(lines)}");
            Console.WriteLine($"part 2: {RunPart2(lines)}");
        }

        public abstract string RunPart1(List<string> lines);
        public abstract string RunPart2(List<string> lines);

        private List<string> ReadLines()
        {
            return new List<string>();
        }
    }
}
