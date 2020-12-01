using System;

namespace Re_Volt
{
    public class Program
    {
        static int playersPositionRow;
        static int playersPositionCol;

        static char[][] matrix;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            int countOfCommands = int.Parse(Console.ReadLine());

            InitializeMatrix(matrix, countOfCommands);

            for (int i = 0; i < countOfCommands; i++)
            {
                string commandToDo = Console.ReadLine();

                if (commandToDo == "up")
                {
                    playersPositionRow--;

                    if (playersPositionRow < 0)
                    {
                        playersPositionRow = matrix.Length - 1;
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[0][playersPositionCol] = '-';
                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'B')
                    {
                        playersPositionRow--;
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow + 2][playersPositionCol] = '-';
                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'T')
                    {
                        playersPositionRow++;
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        
                    }

                    if (matrix[playersPositionRow][playersPositionCol] == '-')
                    {
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow + 1][playersPositionCol] = '-';
                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'F')
                    {
                        
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow + 1][playersPositionCol] = '-';
                        Console.WriteLine($"Player won!");
                        PrintMatrix();
                        return;
                    }

                }
                else if (commandToDo == "down")
                {
                    playersPositionRow++;

                    if (playersPositionRow == matrix.Length)
                    {
                        playersPositionRow = 0;
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[n - 1][playersPositionCol] = '-';

                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'B')
                    {
                        playersPositionRow++;
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow - 2][playersPositionCol] = '-';

                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'T')
                    {
                        playersPositionRow--;
                        matrix[playersPositionRow][playersPositionCol] = 'f';

                    }

                    if (matrix[playersPositionRow][playersPositionCol] == '-')
                    {
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow - 1][playersPositionCol] = '-';
                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'F')
                    {
                        
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow - 1][playersPositionCol] = '-';
                        Console.WriteLine($"Player won!");
                        PrintMatrix();
                        return;
                    }
                }
                else if (commandToDo == "left")
                {
                    playersPositionCol--;

                    if (playersPositionCol < 0)
                    {
                        playersPositionCol = matrix[playersPositionRow].Length - 1;
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow][0] = '-';

                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'B')
                    {
                        playersPositionCol--;
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow][playersPositionCol + 2] = '-';
                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'T')
                    {
                        playersPositionCol++;
                        matrix[playersPositionRow][playersPositionCol] = 'f';

                    }

                    if (matrix[playersPositionRow][playersPositionCol] == '-')
                    {
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow][playersPositionCol + 1] = '-';
                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'F')
                    {
                        
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow][playersPositionCol + 1] = '-';
                        Console.WriteLine($"Player won!");
                        PrintMatrix();
                        return;
                    }
                }
                else if (commandToDo == "right")
                {
                    playersPositionCol++;

                    if (playersPositionCol == matrix.Length)
                    {
                        playersPositionCol = 0;
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow][n - 1] = '-';

                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'B')
                    {
                        playersPositionCol--;
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        
                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'T')
                    {
                        playersPositionCol--;
                        matrix[playersPositionRow][playersPositionCol] = 'f';

                    }

                    if (matrix[playersPositionRow][playersPositionCol] == '-')
                    {
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow][playersPositionCol - 1] = '-';
                    }

                    if (matrix[playersPositionRow][playersPositionCol] == 'F')
                    {
                        
                        matrix[playersPositionRow][playersPositionCol] = 'f';
                        matrix[playersPositionRow][playersPositionCol - 1] = '-';
                        Console.WriteLine($"Player won!");
                        PrintMatrix();
                        return;
                    }
                }
            }
            
            Console.WriteLine($"Player lost!");
            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void InitializeMatrix(char[][] matrix, int countOfCommands)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] inputLine = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = inputLine;

                for (int col = 0; col < inputLine.Length; col++)
                {
                    matrix[playersPositionRow][playersPositionCol] = inputLine[playersPositionCol];
                    if (matrix[row][col] == 'f')
                    {
                        playersPositionRow = row;
                        playersPositionCol = col;
                        
                    }
                }
            }
        }
    }
}
