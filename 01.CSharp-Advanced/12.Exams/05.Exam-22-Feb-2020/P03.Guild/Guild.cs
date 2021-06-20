using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private HashSet<Player> players;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.players = new HashSet<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.players.Count;

        public void AddPlayer(Player player)
        {
            if (players.Count < Capacity)
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            foreach (Player player in players)
            {
                if (player.Name == name)
                {
                    players.Remove(player);
                    return true;
                }
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            foreach(Player player in players)
            {
                if (player.Name == name)
                {
                    player.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = players.FirstOrDefault(p => p.Name == name);
            player.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] playersToKick = players.Where(p => p.Class == @class).ToArray();
            players.RemoveWhere(p => p.Class == @class);

            return playersToKick;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in players)
            {
                sb.AppendLine($"{player}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
