using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBoxAgainNNew
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> firstLootBox = new Queue<int>(firstLine);

            Stack<int> secondLootBox = new Stack<int>(secondLine);

            List<int> claimedItems = new List<int>();

            while (firstLootBox.Count > 0 &&
                secondLootBox.Count > 0)
            {
                int currentQueueItem = firstLootBox.Peek();
                int currentStackItem = secondLootBox.Pop();

                if ((currentQueueItem + currentStackItem) % 2 == 0)
                {
                    claimedItems.Add(currentQueueItem + currentStackItem);
                    firstLootBox.Dequeue();
                }
                else
                {
                    firstLootBox.Enqueue(currentStackItem);
                }
            }
            if (firstLootBox.Count == 0)
            {
                Console.WriteLine($"First lootbox is empty");
            }
            else
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
