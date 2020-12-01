using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild()
        {
            this.roster = new List<Player>();
        }

        public Guild(string name, int capacity)
            :this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.roster.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count + 1 <= this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.roster
                .FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                this.roster.Remove(player);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = this.roster
                .First(p => p.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster
                .First(p => p.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classs)
        {
            Player[] players = this.roster
                .Where(p => p.Class == classs)
                .ToArray();

            this.roster.RemoveAll(p => p.Class == classs);
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                sb
                    .AppendLine($"{player}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
