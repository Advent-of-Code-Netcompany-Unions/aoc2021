using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AoC2021.Model;

namespace AoC2021.Challenges
{
    internal class AoCTask03 : AoCTask
    {
        public AoCTask03(string filename) : base(filename) { }

        public override string RunPart1(List<string> lines)
        {
            var matrix = RotateMatrix(GetMatrix(lines));
            var gammaRate = FindMostCommonCharacterPerRowInMatrix(matrix);
            var epsilonRate = GetTheInverseBinaryString(gammaRate);
            return (ConvertBinaryStringToInt(epsilonRate) * ConvertBinaryStringToInt(gammaRate)).ToString();
        }

        // Takes a list of strings and returns a matric of characters
        private char[,] GetMatrix(List<string> lines)
        {
            char[,] matrix = new char[lines.Count, lines[0].Length];
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    matrix[i, j] = lines[i][j];
                }
            }
            return matrix;
        }

        private char[,] RotateMatrix(char[,] matrix)
        {
            int width = matrix.GetLength(1);
            int height = matrix.GetLength(0);
            char[,] rotatedMatrix = new char[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    rotatedMatrix[i, j] = matrix[height - j - 1, i];
                }
            }
            return rotatedMatrix;
        }
        private char FindMostCommonCharacterInRow(char[] row, bool inverse){
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in row)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount.Add(c, 1);
                }
            }
            if (inverse && charCount.Keys.Count > 1 && charCount['0'] == charCount['1']){
                return '1';
            }
            return charCount.OrderByDescending(x => x.Value).First().Key;
        }

        private string FindMostCommonCharacterPerRowInMatrix(char[,] matrix, bool inverse = false)
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += FindMostCommonCharacterInRow(GetRowFromCharacterMatrix(matrix, i), inverse);
            }
            return result;
        }

        private char[] GetRowFromCharacterMatrix(char[,] matrix, int row)
        {
            char[] rowArray = new char[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                rowArray[i] = matrix[row, i];
            }
            return rowArray;
        }

        private string GetTheInverseBinaryString(string binaryString)
        {
            string result = "";
            for (int i = 0; i < binaryString.Length; i++)
            {
                result += binaryString[i] == '0' ? '1' : '0';
            }
            return result;
        }

        private int ConvertBinaryStringToInt(string binaryString)
        {
            int result = 0;
            for (int i = 0; i < binaryString.Length; i++)
            {
                result += (int)Math.Pow(2, binaryString.Length - i - 1) * (binaryString[i] - '0');
            }
            return result;
        }

        public override string RunPart2(List<string> lines)
        {
            var matrix = ConvertMatrixToListOfLists(GetMatrix(lines));
            
            for (int i = 0; i < 12; i++)
            {
                if (matrix.Count() == 1) break;
                var gammaRate = FindMostCommonCharacterPerRowInMatrix(RotateMatrix(ConvertMatrixToCharacterMatrix(matrix)));
                matrix = FilterMatrixRowsWithCharacterInColumn(matrix, i, gammaRate[i]);
            }

            var oxygenRating = ConvertBinaryStringToInt(CharListToString(matrix[0]));
            
            matrix = ConvertMatrixToListOfLists(GetMatrix(lines));
            for (int i = 0; i < 12; i++)
            {
                if (matrix.Count() == 1) break;
                var gammaRate = GetTheInverseBinaryString(FindMostCommonCharacterPerRowInMatrix(RotateMatrix(ConvertMatrixToCharacterMatrix(matrix)),true));
                matrix = FilterMatrixRowsWithCharacterInColumn(matrix, i, gammaRate[i]);
            }

            var CO2ScrubberRating = ConvertBinaryStringToInt(CharListToString(matrix[0]));

            return (oxygenRating * CO2ScrubberRating).ToString();
        }  

        private char[,] ConvertMatrixToCharacterMatrix(List<List<char>> matrix)
        {
            char[,] result = new char[matrix.Count, matrix[0].Count];
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    result[i, j] = matrix[i][j];
                }
            }
            return result;
        }

        private string CharListToString(List<char> list)
        {
            string result = "";
            foreach (char c in list)
            {
                result += c;
            }
            return result;
        }

        private List<List<char>> ConvertMatrixToListOfLists(char[,] matrix)
        {
            List<List<char>> result = new List<List<char>>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<char> row = new List<char>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row.Add(matrix[i, j]);
                }
                result.Add(row);
            }
            return result;
        }

        private List<List<char>> FilterMatrixRowsWithCharacterInColumn(List<List<char>> matrix, int column, char character)
        {
            List<List<char>> result = new List<List<char>>();
            foreach (List<char> row in matrix)
            {
                if (row[column] == character)
                {
                    result.Add(row);
                }
            }
            return result;
        }
    }
}
