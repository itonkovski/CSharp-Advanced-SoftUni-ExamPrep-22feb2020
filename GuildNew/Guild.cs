using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuildSecond
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

        public string Name { get; private set; }

        public int Capacity { get; private set; }

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
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.roster.Any(x => x.Name == name))
            {
                Player player = roster
                    .Where(x => x.Name == name)
                    .FirstOrDefault();

                this.roster.Remove(player);

                return true; 
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                Player myPromotedPlayer = roster
                    .Where(x => x.Name == name)
                    .FirstOrDefault();

                myPromotedPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                Player myDemotedPlayer = roster
                    .Where(x => x.Name == name)
                    .FirstOrDefault();

                myDemotedPlayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classy)
        {
            List<Player> myList = new List<Player>();

            foreach (var player in this.roster)
            {
                if (player.Class == classy)
                {
                    myList.Add(player);
                    
                }
            }
            Player[] arrayToReturn = myList.ToArray();

            this.roster = roster
                .Where(x => x.Class == classy)
                .ToList();

            return arrayToReturn;

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in roster)
            {
                sb
                    .AppendLine($"Player {player.Name}: {player.Class}")
                    .AppendLine($"Rank: {player.Rank}")
                    .AppendLine($"Description: {player.Description}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
