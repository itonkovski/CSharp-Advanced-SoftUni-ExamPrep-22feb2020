using System;

namespace ReVoltAgain
{
    class Program
    {
        static int currentRow = -1;
        static int currentCol = -1;
        static bool IsFound = false;
        static int counter;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int countOfCommand = int.Parse(Console.ReadLine());

            counter = countOfCommand;

            char[][] matrix = new char[size][];

            InitializeMatrix(size, matrix);


            for (int i = 0; i < countOfCommand; i++)
            {
                string command = Console.ReadLine();

                
                counter--;

                if (command == "up")
                {
                    MoveUp(matrix);
                }
                else if (command == "down")
                {
                    MoveDown(matrix);
                }
                else if (command == "left")
                {
                    MoveLeft(matrix);
                }
                else if (command == "right")
                {
                    MoveRight(matrix);
                }

                if (counter == 0 )
                {
                    Console.WriteLine($"Player lost!");
                    for (int row = 0; row < matrix.Length; row++)
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            Console.Write(matrix[row][col]);
                        }
                        Console.WriteLine();
                    }
                }
            }
            

        }

        private static void MoveRight(char[][] matrix)
        {
            if (currentCol + 1 < matrix.Length)
            {
                currentCol++;
                char symbol = matrix[currentRow][currentCol];
                if (symbol == 'B')
                {
                    if (currentCol + 1 > matrix.Length)
                    {
                        currentCol++;
                        matrix[currentRow][currentCol - 2] = '-';
                        matrix[currentRow][currentCol] = 'f';
                    }
                    else
                    {
                        currentCol = 0;
                        matrix[currentRow][currentCol] = 'f';
                        matrix[currentRow][currentCol + 3] = '-';
                    }

                }
                else if (symbol == 'T')
                {
                    currentCol--;
                }
                else if (symbol == 'F')
                {
                    FinishLine(matrix);
                }
                else
                {
                    matrix[currentRow][currentCol] = 'f';
                    matrix[currentRow][currentCol - 1] = '-';
                }
            }
            else
            {
                currentCol = 0;
                int oldPosition = matrix.Length - 1;
                matrix[oldPosition][currentCol] = '-';
                matrix[currentRow][currentCol] = 'f';
            }
        }

        private static void FinishLine(char[][] matrix)
        {
            matrix[currentRow][currentCol] = 'f';
            matrix[currentRow][currentCol - 1] = '-';
            Console.WriteLine($"Player won!");
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void MoveLeft(char[][] matrix)
        {
            if (currentCol - 1 >= 0)
            {
                currentCol--;
                char symbol = matrix[currentRow][currentCol];
                if (symbol == 'B')
                {
                    if (currentCol - 1 >= 0)
                    {
                        currentCol--;
                        matrix[currentRow][currentCol + 2] = '-';
                        matrix[currentRow][currentCol] = 'f';
                    }
                    else
                    {
                        currentCol = matrix[currentCol].Length - 1;
                        matrix[currentRow][currentCol] = 'f';
                        matrix[currentRow][currentCol - 3] = '-';
                    }

                }
                else if (symbol == 'T')
                {
                    currentCol++;
                }
                else if (symbol == 'F')
                {
                    FinishLine(matrix);
                }
                else
                {
                    matrix[currentRow][currentCol] = 'f';
                    matrix[currentRow][currentCol + 1] = '-';
                }
            }
            else
            {
                currentCol = matrix[currentCol].Length - 1;
                matrix[currentRow][0] = '-';
                matrix[currentRow][currentCol] = 'f';
            }
        }

        private static void MoveDown(char[][] matrix)
        {
            if (currentRow + 1 < matrix.Length)
            {
                currentRow++;
                char symbol = matrix[currentRow][currentCol];
                if (symbol == 'B')
                {
                    if (currentRow + 1 < matrix.Length)
                    {
                        currentRow++;
                        matrix[currentRow - 2][currentCol] = '-';
                        matrix[currentRow][currentCol] = 'f';
                    }
                    else
                    {
                        currentRow = 0;
                        matrix[currentRow][currentCol] = 'f';
                        matrix[currentRow + 3][currentCol] = '-';
                    }

                }
                else if (symbol == 'T')
                {
                    currentRow++;
                }
                else if (symbol == 'F')
                {
                    FinishLine(matrix);
                }
                else
                {
                    matrix[currentRow][currentCol] = 'f';
                    matrix[currentRow - 1][currentCol] = '-';
                }
            }
            else
            {
                currentRow = 0;
                int oldPosition = matrix.Length - 1;
                matrix[oldPosition][currentCol] = '-';
                matrix[currentRow][currentCol] = 'f';
            }
        }

        private static void MoveUp(char[][] matrix)
        {
            if (currentRow - 1 >= 0)
            {
                currentRow--;
                char symbol = matrix[currentRow][currentCol];
                if (symbol == 'B')
                {
                    if (currentRow - 1 >= 0)
                    {   
                        currentRow--;
                        matrix[currentRow + 2][currentCol] = '-';
                        matrix[currentRow][currentCol] = 'f';
                    }
                    else
                    {
                        currentRow = matrix[currentRow].Length - 1;
                        matrix[currentRow][currentCol] = 'f';
                        matrix[currentRow - 3][currentCol] = '-';
                    }

                }
                else if (symbol == 'T')
                {
                    currentRow++;
                }
                else if (symbol == 'F')
                {
                    FinishLine(matrix);
                }
                else
                {
                    matrix[currentRow][currentCol] = 'f';
                    matrix[currentRow + 1][currentCol] = '-';
                }
            }
            else
            {

                currentRow = matrix[currentRow].Length - 1;
                matrix[0][currentCol] = '-';
                matrix[currentRow][currentCol] = 'f';
            }
        }

        private static void InitializeMatrix(int size, char[][] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                char[] inputLine = Console.ReadLine()
                    .ToCharArray();

                if (!IsFound)
                {
                    for (int col = 0; col < inputLine.Length; col++)
                    {
                        if (inputLine[col] == 'f')
                        {
                            currentRow = row;
                            currentCol = col;
                            IsFound = true;
                            break;
                        }
                    }
                }
                matrix[row] = inputLine;
            }
        }
    }
}
