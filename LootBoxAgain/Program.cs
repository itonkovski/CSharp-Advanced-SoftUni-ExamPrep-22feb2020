using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBoxAgain
{
    public class Program
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

            Queue<int> firstLootBox = new Queue<int>(firstInput);
            Stack<int> secondLootBox = new Stack<int>(secondInput);

            List<int> claimedItems = new List<int>();

            while (firstLootBox.Any() && secondLootBox.Any())
            {
                int currentFirstItem = firstLootBox.Peek();
                int currentSecItem = secondLootBox.Pop();
                


                if ((currentFirstItem + currentSecItem) % 2 == 0)
                {
                    claimedItems.Add(currentFirstItem + currentSecItem);
                    firstLootBox.Dequeue();
                }
                else
                {
                    firstLootBox.Enqueue(currentSecItem);
                }
            }

            if (!firstLootBox.Any())
            {
                Console.WriteLine($"First lootbox is empty");
            }

            if (!secondLootBox.Any())
            {
                Console.WriteLine($"Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
