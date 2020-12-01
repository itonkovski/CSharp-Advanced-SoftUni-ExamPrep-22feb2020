using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
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
            List<int> claimedItems = new List<int>();

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int currentFirstBoxItem = firstBox.Peek();
                int currentSecondBoxItem = secondBox.Peek();

                if ((currentFirstBoxItem + currentSecondBoxItem) % 2 == 0)
                {
                    claimedItems.Add(currentFirstBoxItem + currentSecondBoxItem);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {

                    secondBox.Pop();
                    firstBox.Enqueue(currentSecondBoxItem);
                }
            }

            
            if (firstBox.Count <= 0)
            {
                Console.WriteLine($"First lootbox is empty");
            }
            else
            {
                Console.WriteLine($"Second lootbox is empty");
            }

            string result = claimedItems.Sum() >= 100 ? $"Your loot was epic! Value: {claimedItems.Sum()}" : $"Your loot was poor... Value: {claimedItems.Sum()}";
            Console.WriteLine(result);

            //if (claimedItems.Sum() >= 100)
            //{
            //    Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            //}
            //else
            //{
            //    Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            //}
        }
    }
}
