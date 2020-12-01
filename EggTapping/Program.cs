using System;
using System.Collections.Generic;
using System.Linq;

namespace EggTapping
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            char[] secondInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            Queue<char> firstEggSet = new Queue<char>(firstInput);
            Stack<char> secondEggSet = new Stack<char>(secondInput);

            int firstPlayerPointsCounter = 0;
            int secondPlayerPointsCounter = 0;

            while (firstEggSet.Count > 0 &&
                secondEggSet.Count > 0)
            {
                int currentFirstEgg = firstEggSet.Dequeue();
                int currentSecondEgg = secondEggSet.Pop();

                if (currentFirstEgg < currentSecondEgg)
                {
                    currentFirstEgg += 1;
                    firstPlayerPointsCounter += currentSecondEgg;
                    firstEggSet.Enqueue((char)currentFirstEgg);
                }
                if (currentFirstEgg > currentSecondEgg)
                {
                    currentSecondEgg += 1;
                    secondPlayerPointsCounter += currentFirstEgg;
                    secondEggSet.Push((char)currentSecondEgg);

                }
                if (currentFirstEgg == currentSecondEgg)
                {
                    continue;
                }
                if (firstPlayerPointsCounter == secondPlayerPointsCounter)
                {
                    Console.WriteLine($"Draw! Nobody wins.");
                    return;
                }
            }
            if (firstPlayerPointsCounter > secondPlayerPointsCounter)
            {
                Console.WriteLine($"The winner ends with {firstPlayerPointsCounter} points.");
                Console.WriteLine($"There are {string.Join(", ",firstEggSet)} in his collection.");
            }
            else
            {
                Console.WriteLine($"The winner ends with {secondPlayerPointsCounter} points.");
                Console.WriteLine($"There are {string.Join(", ", secondEggSet)} in his collection.");
            }
        }
    }
}
