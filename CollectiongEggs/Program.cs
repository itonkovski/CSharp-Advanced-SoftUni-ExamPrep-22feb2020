using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectiongEggs
{
    class Program
    {
        private static int eggCounter = 0;
        private static int eggMaxCounter = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            Queue<char> eggBasket = new Queue<char>();

            int playerRow = -1;
            int playerCol = -1;
            
            InitializeMatrix(n, matrix, ref playerRow, ref playerCol);

            string command;

            while ((command = Console.ReadLine()) != "end" && eggCounter != 0)
            {
                if (command == "up")
                {
                    playerRow = MoveUp(matrix, eggBasket, playerRow, playerCol);
                }
                else if (command == "down")
                {
                    playerRow = MoveDown(matrix, eggBasket, playerRow, playerCol);
                }
                else if (command == "left")
                {
                    playerCol = MoveLeft(matrix, eggBasket, playerRow, playerCol);
                }
                else if (command == "right")
                {
                    playerCol = MoveRight(matrix, eggBasket, playerRow, playerCol);
                }
            }
            if (eggCounter == 0)
            {
                Console.WriteLine($"Happy Easter! The Easter bunny collected {eggBasket.Count} eggs: {string.Join(", ",eggBasket)}.");
            }
            else
            {
                Console.WriteLine($"The Easter bunny failed to gather every egg. There are {eggMaxCounter - eggCounter} eggs left to collect.");
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static int MoveRight(char[][] matrix, Queue<char> eggBasket, int playerRow, int playerCol)
        {
            if (playerCol + 1 <= matrix.Length - 1)
            {
                playerCol++;
                char symbol = matrix[playerRow][playerCol];

                if (char.IsUpper(symbol))
                {
                    int currentColPossition = playerCol;
                    //opposite movememnt
                    if (currentColPossition == matrix.Length - 1)
                    {
                        playerCol = 0;
                        char symbolAfterLeap = matrix[playerRow][playerCol];
                        //if symbol after the leap is an egg
                        if (char.IsLetter(symbolAfterLeap))
                        {
                            eggBasket.Enqueue(symbolAfterLeap);
                            matrix[playerRow][playerCol] = 'B';
                            matrix[playerRow][currentColPossition] = '-';
                            matrix[playerRow][currentColPossition - 1] = '-';
                        }
                        //if symbol is '-'
                        else
                        {
                            matrix[playerRow][playerCol] = 'B';
                            matrix[playerRow][currentColPossition] = '-';
                            matrix[playerRow][currentColPossition - 1] = '-';
                        }
                    }
                    //movement by previous direction
                    else
                    {
                        playerCol = matrix.Length - 1;
                        char symbolAfterLeap = matrix[playerRow][playerCol];
                        //if symbol after the leap is an egg
                        if (char.IsLetter(symbolAfterLeap))
                        {
                            eggBasket.Enqueue(symbolAfterLeap);
                            matrix[playerRow][playerCol] = 'B';
                            matrix[playerRow][currentColPossition] = '-';
                            matrix[playerRow][currentColPossition - 1] = '-';
                        }
                        //if symbol is '-'
                        else
                        {
                            matrix[playerRow][playerCol] = 'B';
                            matrix[playerRow][currentColPossition] = '-';
                            matrix[playerRow][currentColPossition - 1] = '-';
                        }

                    }
                }
                else if (char.IsLetter(symbol))
                {
                    eggBasket.Enqueue(symbol);
                    eggCounter--;
                    matrix[playerRow][playerCol] = 'B';
                    matrix[playerRow][playerCol - 1] = '-';
                }
                else
                {
                    matrix[playerRow][playerCol] = 'B';
                    matrix[playerRow][playerCol - 1] = '-';
                }

            }
            else
            {
                if (eggBasket.Any())
                {
                    eggBasket.Dequeue();
                    eggCounter++;
                }
            }

            return playerCol;
        }

        private static int MoveLeft(char[][] matrix, Queue<char> eggBasket, int playerRow, int playerCol)
        {
            if (playerCol - 1 >= 0)
            {
                playerCol--;
                char symbol = matrix[playerRow][playerCol];

                if (char.IsUpper(symbol))
                {
                    int currentColPossition = playerCol;
                    //opposite movememnt
                    if (currentColPossition == 0)
                    {
                        playerCol = matrix.Length - 1;
                        char symbolAfterLeap = matrix[playerRow][playerCol];
                        //if symbol after the leap is an egg
                        if (char.IsLetter(symbolAfterLeap))
                        {
                            eggBasket.Enqueue(symbolAfterLeap);
                            matrix[playerRow][playerCol] = 'B';
                            matrix[playerRow][currentColPossition] = '-';
                            matrix[playerRow][currentColPossition + 1] = '-';
                        }
                        //if symbol is '-'
                        else
                        {
                            matrix[playerRow][playerCol] = 'B';
                            matrix[playerRow][currentColPossition] = '-';
                            matrix[playerRow][currentColPossition + 1] = '-';
                        }
                    }
                    //movement by previous direction
                    else
                    {
                        playerCol = 0;
                        char symbolAfterLeap = matrix[playerRow][playerCol];
                        //if symbol after the leap is an egg
                        if (char.IsLetter(symbolAfterLeap))
                        {
                            eggBasket.Enqueue(symbolAfterLeap);
                            matrix[playerRow][playerCol] = 'B';
                            matrix[playerRow][currentColPossition] = '-';
                            matrix[playerRow][currentColPossition + 1] = '-';
                        }
                        //if symbol is '-'
                        else
                        {
                            matrix[playerRow][playerCol] = 'B';
                            matrix[playerRow][currentColPossition] = '-';
                            matrix[playerRow][currentColPossition + 1] = '-';
                        }

                    }
                }
                else if (char.IsLetter(symbol))
                {
                    eggBasket.Enqueue(symbol);
                    eggCounter--;
                    matrix[playerRow][playerCol] = 'B';
                    matrix[playerRow][playerCol + 1] = '-';
                }
                else
                {
                    matrix[playerRow][playerCol] = 'B';
                    matrix[playerRow][playerCol + 1] = '-';
                }

            }
            else
            {
                if (eggBasket.Any())
                {
                    eggBasket.Dequeue();
                    
                }
            }

            return playerCol;
        }

        private static int MoveDown(char[][] matrix, Queue<char> eggBasket, int playerRow, int playerCol)
        {
            if (playerRow + 1 <= matrix.Length - 1)
            {
                playerRow++;
                char symbol = matrix[playerRow][playerCol];

                if (char.IsUpper(symbol))
                {
                    int currentRowPossition = playerRow;
                    //opposite movememnt if 'C'
                    if (currentRowPossition == matrix.Length - 1)
                    {
                        playerRow = 0;
                        char symbolAfterLeap = matrix[playerRow][playerCol];
                        //if symbol after the leap is an egg
                        if (char.IsLetter(symbolAfterLeap))
                        {
                            eggBasket.Enqueue(symbolAfterLeap);
                            matrix[playerRow][playerCol] = 'B';
                            matrix[currentRowPossition][playerCol] = '-';
                            matrix[currentRowPossition - 1][playerCol] = '-';
                        }
                        //if symbol is '-'
                        else
                        {
                            matrix[playerRow][playerCol] = 'B';
                            matrix[currentRowPossition][playerCol] = '-';
                            matrix[currentRowPossition - 1][playerCol] = '-';
                        }
                    }
                    //movement by previous direction
                    else
                    {
                        playerRow = matrix.Length - 1;
                        char symbolAfterLeap = matrix[playerRow][playerCol];
                        //if symbol after the leap is an egg
                        if (char.IsLetter(symbolAfterLeap))
                        {
                            eggBasket.Enqueue(symbolAfterLeap);
                            matrix[playerRow][playerCol] = 'B';
                            matrix[currentRowPossition][playerCol] = '-';
                            matrix[currentRowPossition - 1][playerCol] = '-';
                        }
                        //if symbol is '-'
                        else
                        {
                            matrix[playerRow][playerCol] = 'B';
                            matrix[currentRowPossition][playerCol] = '-';
                            matrix[currentRowPossition - 1][playerCol] = '-';
                        }

                    }
                }
                else if (char.IsLetter(symbol))
                {
                    eggBasket.Enqueue(symbol);
                    eggCounter--;
                    matrix[playerRow][playerCol] = 'B';
                    matrix[playerRow - 1][playerCol] = '-';
                }
                else
                {
                    matrix[playerRow][playerCol] = 'B';
                    matrix[playerRow - 1][playerCol] = '-';
                }

            }
            else
            {
                if (eggBasket.Any())
                {
                    eggBasket.Dequeue();
                    eggCounter++;
                }
            }

            return playerRow;
        }

        private static int MoveUp(char[][] matrix, Queue<char> eggBasket, int playerRow, int playerCol)
        {
            if (playerRow - 1 >= 0)
            {
                playerRow--;
                char symbol = matrix[playerRow][playerCol];

                if (char.IsUpper(symbol))
                {
                    int currentRowPossition = playerRow;
                    //opposite movememnt
                    if (currentRowPossition == 0)
                    {
                        playerRow = matrix.Length - 1;
                        char symbolAfterLeap = matrix[playerRow][playerCol];
                        //if symbol after the leap is an egg
                        if (char.IsLetter(symbolAfterLeap))
                        {
                            eggBasket.Enqueue(symbolAfterLeap);
                            matrix[playerRow][playerCol] = 'B';
                            matrix[currentRowPossition][playerCol] = '-';
                            matrix[currentRowPossition + 1][playerCol] = '-';
                        }
                        //if symbol is '-'
                        else
                        {
                            matrix[playerRow][playerCol] = 'B';
                            matrix[currentRowPossition][playerCol] = '-';
                            matrix[currentRowPossition + 1][playerCol] = '-';
                        }
                    }
                    //movement by previous direction
                    else
                    {
                        playerRow = 0;
                        char symbolAfterLeap = matrix[playerRow][playerCol];
                        //if symbol after the leap is an egg
                        if (char.IsLetter(symbolAfterLeap))
                        {
                            eggBasket.Enqueue(symbolAfterLeap);
                            matrix[playerRow][playerCol] = 'B';
                            matrix[currentRowPossition][playerCol] = '-';
                            matrix[currentRowPossition + 1][playerCol] = '-';
                        }
                        //if symbol is '-'
                        else
                        {
                            matrix[playerRow][playerCol] = 'B';
                            matrix[currentRowPossition][playerCol] = '-';
                            matrix[currentRowPossition + 1][playerCol] = '-';
                        }

                    }
                }
                else if (char.IsLetter(symbol))
                {
                    eggBasket.Enqueue(symbol);
                    eggCounter--;
                    matrix[playerRow][playerCol] = 'B';
                    matrix[playerRow + 1][playerCol] = '-';
                }
                else
                {
                    matrix[playerRow][playerCol] = 'B';
                    matrix[playerRow + 1][playerCol] = '-';
                }

            }
            else
            {
                if (eggBasket.Any())
                {
                    eggBasket.Dequeue();
                    eggCounter++;
                }
            }

            return playerRow;
        }

        private static void InitializeMatrix(int n, char[][] matrix, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                
                 for (int col = 0; col < currentRow.Length; col++)
                 {
                     if (currentRow[col] == 'B')
                     {
                         playerRow = row;
                         playerCol = col; 
                     }
                    char symbol = currentRow[col];
                    if (char.IsLower(symbol))
                    {
                        eggCounter++;
                        eggMaxCounter = eggCounter;
                    }
                    if (char.IsWhiteSpace(symbol))
                    {

                    }
                 }
                

                matrix[row] = currentRow;
            }
        }
    }
}
