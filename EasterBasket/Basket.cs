using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterBasket
{
    public class Basket
    {
        private List<Egg> data;

        public Basket()
        {
            this.data = new List<Egg>();
        }

        public Basket(string material, int capacity)
            :this()
        {
            this.Material = material;
            this.Capacity = capacity;
        }

        public string Material { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void AddEgg(Egg egg)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(egg);
            }
        }

        public bool RemoveEgg(string color)
        {
            if (this.data.Any(x => x.Color == color))
            {
                Egg eggToRemove = this.data
                    .Where(x => x.Color == color)
                    .FirstOrDefault();

                this.data.Remove(eggToRemove);
                return true;
            }
            return false;
        }

        public Egg GetStrongestEgg()
        {
            Egg strongestEgg = this.data
                .OrderByDescending(x => x.Strength)
                .FirstOrDefault();

            return strongestEgg;
        }

        public Egg GetEgg(string color)
        {
            Egg egg = this.data
                .OrderByDescending(x => x.Color == color)
                .FirstOrDefault();

            return egg;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.Material} basket contains:");
            
            foreach (var egg in this.data)
            {
                sb
                    .AppendLine($"{egg}");
            }

            return sb.ToString().TrimEnd();
            
        }

        

        
}
}
