using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IDictionary<string, IRace> raceByName;

        public RaceRepository()
        {
            this.raceByName = new Dictionary<string, IRace>();
        }

        public void Add(IRace model)
        {
            if (this.raceByName.ContainsKey(model.Name))
            {
                throw new InvalidOperationException($"Race {model.Name} is already created.");
            }

            this.raceByName.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.raceByName.Values.ToList();
        }

        public IRace GetByName(string name)
        {
            IRace race = null;

            if (raceByName.ContainsKey(name))
            {
                race = raceByName[name];
            }

            return race;
        }

        public bool Remove(IRace model)
        {
            return raceByName.Remove(model.Name);
        }
    }
}
