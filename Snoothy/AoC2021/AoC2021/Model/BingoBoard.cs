namespace AoC2021.Model
{
    public class BingoBoard
    {
        
        public int[,] board = new int[5, 5];
        public Dictionary<int, Tuple<int, int>> bingoNumbers = new Dictionary<int, Tuple<int, int>>();

        public BingoBoard(List<int> numbers)
        {
            for (int i = 0; i < 25; i++)
            {
                board[i / 5, i % 5] = numbers[i];
                bingoNumbers.Add(numbers[i], new Tuple<int, int>(i / 5, i % 5));
            }
        } 

        public void PrintBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool CheckRow(int row)
        {
            for (int i = 0; i < 5; i++)
            {
                if (board[row, i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckColumn(int column)
        {
            for (int i = 0; i < 5; i++)
            {
                if (board[i, column] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckBingo()
        {
            for (int i = 0; i < 5; i++)
            {
                if (CheckRow(i) || CheckColumn(i))
                {
                    return true;
                }
            }
            return false;
        }

        // Checks number in row and column
        public bool CheckNumber(int number)
        {
            if (bingoNumbers.ContainsKey(number))
            {
                int row = bingoNumbers[number].Item1;
                int column = bingoNumbers[number].Item2;
                if (board[row, column] != 0)
                {
                    board[row, column] = 0;
                    return true;
                }
            }
            return false;
        }

        public int GetSumOfBoard()
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sum += board[i, j];
                }
            }
            return sum;
        }
    }
}