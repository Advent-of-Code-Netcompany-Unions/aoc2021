using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2021.Model;

namespace AoC2021.Challenges
{
    internal class AoCTask04 : AoCTask
    {
        public AoCTask04(string filename) : base(filename) { }

        public override string RunPart1(List<string> lines)
        {
            var boards = new List<BingoBoard>();
            var numbers = ParseLineToListOfInts(lines[0]);
            for (var i = 1; i < lines.Count; i = i+6)
            {
                var input = $"{lines[i+1]} {lines[i+2]} {lines[i+3]} {lines[i+4]} {lines[i+5]}";
                boards.Add(new BingoBoard(input.Replace("  ", " ").Trim().Split(' ').Select(int.Parse).ToList()));

            }

            var winner = GetWinningBoard(boards, numbers);

            return (winner.Item1.GetSumOfBoard() * winner.Item2).ToString();
        }

        private Tuple<BingoBoard, int> GetWinningBoard(List<BingoBoard> boards, List<int> numbers)
        {
            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    board.CheckNumber(number);
                    if (board.CheckBingo())
                    {
                        return new Tuple<BingoBoard, int>(board, number);
                    }
                }
            }
            return null;
        }

        public override string RunPart2(List<string> lines)
        {
            var boards = new List<BingoBoard>();
            var numbers = ParseLineToListOfInts(lines[0]);
            for (var i = 1; i < lines.Count; i = i+6)
            {
                var input = $"{lines[i+1]} {lines[i+2]} {lines[i+3]} {lines[i+4]} {lines[i+5]}";
                boards.Add(new BingoBoard(input.Replace("  ", " ").Trim().Split(' ').Select(int.Parse).ToList()));

            }

            List<BingoBoard> winners = new List<BingoBoard>();
            int winningNumber = 0;
            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    if (winners.Contains(board))
                    {
                        continue;
                    }

                    board.CheckNumber(number);
                    if (board.CheckBingo())
                    {
                        winners.Add(board);
                        if (winners.Count == boards.Count)
                        {
                            winningNumber = number;
                            break;
                        }
                    }
                }
            }

            var winner = winners[winners.Count - 1];
            return (winner.GetSumOfBoard() * winningNumber).ToString();
        }  

        private List<int> ParseLineToListOfInts(string line)
        {
            return line.Split(',').Select(int.Parse).ToList();
        }
    }
}
