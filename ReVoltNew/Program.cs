using System;
using System.Linq;
using System.Collections.Generic;

namespace ReVoltNew
{
    class Program
    {
        static char[][] matrix;

        static int playersRow;
        static int playersCol;
        static bool isFound = false;
        static bool finishLineReached = false;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            InitializeMatrix(n, matrix);

            while (countOfCommands > 0 && !finishLineReached)
            {
                string command = Console.ReadLine();
                countOfCommands--;

                if (command == "up")
                {
                    if (playersRow - 1 >= 0)
                    {
                        playersRow--;
                        char symbol = matrix[playersRow][playersCol];

                        if (symbol != '-')
                        {
                            if (symbol == 'B')
                            {
                                if (playersRow - 1 >= 0)
                                {
                                    playersRow--;
                                    matrix[playersRow + 2][playersCol] = '-';
                                    matrix[playersRow][playersCol] = 'f';
                                }
                                else
                                {
                                    matrix[playersRow + 1][playersCol] = '-';
                                    playersRow = matrix[playersRow].Length - 1;
                                    matrix[playersRow][playersCol] = 'f';
                                }
                            }
                            else if (symbol == 'T')
                            {
                                playersRow++;
                                continue;
                            }
                            else if (symbol == 'F')
                            {
                                matrix[playersRow + 1][playersCol] = '-';
                                matrix[playersRow][playersCol] = 'f';
                                finishLineReached = true;
                                break;
                            }
                        }
                        else
                        {
                            matrix[playersRow][playersCol] = 'f';
                            matrix[playersRow + 1][playersCol] = '-';
                        }
                    }
                    else
                    {
                        playersRow = matrix[playersRow].Length - 1;
                        if (matrix[playersRow][playersCol] == 'F')
                        {
                            matrix[playersRow][playersCol] = 'f';
                            matrix[0][playersCol] = '-';
                            finishLineReached = true;
                            break;
                        }
                        matrix[playersRow][playersCol] = 'f';
                        matrix[0][playersCol] = '-';
                    }
                }
                else if (command == "down")
                {
                    if (playersRow + 1 < matrix.Length)
                    {
                        playersRow++;
                        char symbol = matrix[playersRow][playersCol];

                        if (symbol != '-')
                        {
                            if (symbol == 'B')
                            {
                                if (playersRow + 1 < matrix.Length)
                                {
                                    playersRow++;
                                    matrix[playersRow - 2][playersCol] = '-';
                                    matrix[playersRow][playersCol] = 'f';
                                }
                                else
                                {
                                    matrix[playersRow - 1][playersCol] = '-';
                                    matrix[0][playersCol] = 'f';
                                }
                            }
                            else if (symbol == 'T')
                            {
                                playersRow--;
                                continue;
                            }
                            else if (symbol == 'F')
                            {
                                matrix[playersRow - 1][playersCol] = '-';
                                matrix[playersRow][playersCol] = 'f';
                                finishLineReached = true;
                                break;
                            }
                        }
                        else
                        {
                            matrix[playersRow][playersCol] = 'f';
                            matrix[playersRow + 1][playersCol] = '-';
                        }
                    }
                    else
                    {
                        playersRow = matrix[playersRow].Length - 1;
                        matrix[playersRow][playersCol] = 'f';
                        matrix[0][playersCol] = '-';
                    }
                }
                else if (command == "left")
                {
                    if (playersCol - 1 >= 0)
                    {
                        playersCol--;
                        char symbol = matrix[playersRow][playersCol];

                        if (symbol != '-')
                        {
                            if (symbol == 'B')
                            {
                                if (playersCol - 1 >= 0)
                                {
                                    playersCol--;
                                    matrix[playersRow][playersCol + 2] = '-';
                                    matrix[playersRow][playersCol] = 'f';
                                }
                                else
                                {
                                    matrix[playersRow][playersCol + 1] = '-';
                                    playersCol = matrix[playersCol].Length - 1;
                                    matrix[playersRow][playersCol] = 'f';
                                }
                            }
                            else if (symbol == 'T')
                            {
                                playersCol++;
                                continue;
                            }
                            else if (symbol == 'F')
                            {
                                matrix[playersRow][playersCol + 1] = '-';
                                matrix[playersRow][playersCol] = 'f';
                                finishLineReached = true;
                                break;
                            }
                        }
                        else
                        {
                            matrix[playersRow][playersCol] = 'f';
                            matrix[playersRow][playersCol + 1] = '-';
                        }
                    }
                    else
                    {
                        playersRow = matrix[playersRow].Length - 1;
                        matrix[playersRow][playersCol] = 'f';
                        matrix[0][playersCol] = '-';
                    }
                }
                else if (command == "right")
                {
                    if (playersCol + 1 < matrix.Length)
                    {
                        playersCol++;
                        char symbol = matrix[playersRow][playersCol];

                        if (symbol != '-')
                        {
                            if (symbol == 'B')
                            {
                                if (playersCol + 1 < matrix.Length)
                                {
                                    playersCol++;
                                    matrix[playersRow][playersCol - 2] = '-';
                                    matrix[playersRow][playersCol] = 'f';
                                }
                                else
                                {
                                    matrix[playersRow][playersCol - 1] = '-';
                                    playersCol = 0;
                                    matrix[playersRow][playersCol] = 'f';
                                }
                            }
                            else if (symbol == 'T')
                            {
                                playersCol--;
                                continue;
                            }
                            else if (symbol == 'F')
                            {
                                matrix[playersRow][playersCol + 1] = '-';
                                matrix[playersRow][playersCol] = 'f';
                                finishLineReached = true;
                                break;
                            }
                        }
                        else
                        {
                            matrix[playersRow][playersCol] = 'f';
                            matrix[playersRow][playersCol + 1] = '-';
                        }
                    }
                    else
                    {
                        playersRow = matrix[playersRow].Length - 1;
                        matrix[playersRow][playersCol] = 'f';
                        matrix[0][playersCol] = '-';
                    }
                }
            }
            if (finishLineReached)
            {
                Console.WriteLine($"Player won!");
            }
            else
            {
                Console.WriteLine($"Player lost!");
            }
            PrintMatrix(matrix);
        }

        private static void InitializeMatrix(int n, char[][] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                char[] currentInput = Console.ReadLine()
                    .ToCharArray();

                if (!isFound)
                {
                    for (int col = 0; col < currentInput.Length; col++)
                    {
                        if (currentInput[col] == 'f')
                        {
                            playersRow = row;
                            playersCol = col;
                            isFound = true;
                            break;
                        }
                    }

                }
                matrix[row] = currentInput;
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col <matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}


