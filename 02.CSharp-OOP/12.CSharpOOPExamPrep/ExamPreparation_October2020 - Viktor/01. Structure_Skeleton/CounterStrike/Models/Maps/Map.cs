using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.counterTerrorists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            SeperateTeams(players);

            while (true)
            {
                AttackersAttackDefenders(terrorists, counterTerrorists);

                if (this.counterTerrorists.Any(ct => ct.IsAlive) == false)
                {
                    return "Terrorist wins!";
                }

                AttackersAttackDefenders(counterTerrorists, terrorists);

                if (this.terrorists.Any(t=>t.IsAlive) == false)
                {
                    return "Counter Terrorist wins!";
                }
            }
        }

        private void SeperateTeams(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is Terrorist)
                {
                    terrorists.Add(player);
                }
                else
                {
                    counterTerrorists.Add(player);
                }
            }
        }

        private void AttackersAttackDefenders(List<IPlayer> attackers, List<IPlayer> defenders)
        {
            foreach (var attacker in attackers)
            {
                if (attacker.IsAlive == false)
                {
                    continue;
                }

                foreach (var defender in defenders)
                {
                    if (defender.IsAlive)
                    {
                        defender.TakeDamage(attacker.Gun.Fire());
                    }
                }

            }
        }
    }
}
