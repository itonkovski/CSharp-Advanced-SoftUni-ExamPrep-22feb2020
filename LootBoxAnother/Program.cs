using System;
using System.Linq;
using System.Collections.Generic;

namespace LootBoxAnother
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> firstBox = new Queue<int>(firstInput);
            Stack<int> secondBox = new Stack<int>(secondInput);

            int lootSum = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int currentFirstItem = firstBox.Peek();
                int currentSecondItem = secondBox.Peek();

                if ((currentFirstItem + currentSecondItem) % 2 == 0)
                {
                    lootSum = lootSum + (currentFirstItem + currentSecondItem);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(currentSecondItem);
                    secondBox.Pop();
                }
            }
            if (firstBox.Count <= 0)
            {
                Console.WriteLine($"First lootbox is empty");
            }
            else if (secondBox.Count <= 0)
            {
                Console.WriteLine($"Second lootbox is empty");
            }

            if (lootSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {lootSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {lootSum}");
            }
        }
    }
}
