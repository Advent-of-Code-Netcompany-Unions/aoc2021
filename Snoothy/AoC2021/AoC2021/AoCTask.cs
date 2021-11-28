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
            Console.WriteLine();
            Console.WriteLine($"--- {filename} ---");
            var lines = ReadLines();
            Console.WriteLine($"part 1: {RunPart1(lines)}");
            Console.WriteLine($"part 2: {RunPart2(lines)}");
        }

        public abstract string RunPart1(List<string> lines);
        public abstract string RunPart2(List<string> lines);

        // Reads lines from file and returns them as a list
        private List<string> ReadLines()
        {
            try {
                return System.IO.File.ReadAllLines($"../ChallengeInput/{filename}.txt").ToList();
            } catch (Exception e) {
                Console.WriteLine($"Error reading file {filename}: {e.Message}");
                return new List<string>();
            }
        }
    }
}
