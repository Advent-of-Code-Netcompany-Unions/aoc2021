using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2021.Model;
using System.Drawing;

namespace AoC2021.Challenges
{
    internal class AoCTask05 : AoCTask
    {
        public AoCTask05(string filename) : base(filename) { }

        public override string RunPart1(List<string> lines)
        {
            var actualLines = new List<Line>();
            lines.ForEach(line => actualLines.Add(GetLineFromString(line)));
            var points = new Dictionary<Point, int>();
            foreach(var line in actualLines)
            {
                if (!(line.IsHorizontal() || line.IsVertical())) continue;
                foreach(var point in line.GetPoints())
                {
                    if (points.ContainsKey(point))
                        points[point]++;
                    else
                        points.Add(point, 1);
                }
            }
            return CountDictionaryEntriesLargerThanOne(points).ToString();
        }


        private int CountDictionaryEntriesLargerThanOne(Dictionary<Point, int> points)
        {
            var count = 0;
            foreach(var point in points)
            {
                if (point.Value > 1)
                {
                    count++;
                }
            }
            return count;
        }

        private Line GetLineFromString(string line)
        {
            string[] parts = line.Split(" -> ");
            return new Line(GetPointFromString(parts[0]), GetPointFromString(parts[1]));
        }

        private Point GetPointFromString(string input)
        {
            string[] split = input.Trim().Split(',');
            return new Point(int.Parse(split[0]), int.Parse(split[1]));
        }

        public override string RunPart2(List<string> lines)
        {
            var actualLines = new List<Line>();
            lines.ForEach(line => actualLines.Add(GetLineFromString(line)));
            var points = new Dictionary<Point, int>();
            foreach(var line in actualLines)
            {
                foreach(var point in line.GetPoints())
                {
                    if (points.ContainsKey(point))
                        points[point]++;
                    else
                        points.Add(point, 1);
                }
            }
            return CountDictionaryEntriesLargerThanOne(points).ToString();
        }  

        public class Line {
            public Point Start { get; set; }
            public Point End { get; set; }
            public Line(Point start, Point end) {
                Start = start;
                End = end;
            }

            public List<Point> GetPoints() {
                List<Point> points = new List<Point>();
                int x = Start.X;
                int y = Start.Y;
                int dx = End.X - Start.X;
                int dy = End.Y - Start.Y;
                int step = Math.Sign(dx);
                int stepy = Math.Sign(dy);
                int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
                for (int i = 0; i <= steps; i++) {
                    points.Add(new Point(x, y));
                    x += step;
                    y += stepy;
                }
                return points;
            }

            public bool IsHorizontal() {
                return Start.X == End.X;
            }

            public bool IsVertical() {
                return Start.Y == End.Y;
            }

            public override string ToString() {
                return $"{Start.X},{Start.Y} -> {End.X},{End.Y}";
            }
        }
    }
}
