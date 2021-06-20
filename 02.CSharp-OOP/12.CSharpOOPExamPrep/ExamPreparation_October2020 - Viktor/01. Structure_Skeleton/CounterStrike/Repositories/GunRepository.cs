using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> guns;

        public GunRepository()
        {
            guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
        {
            get => this.guns.AsReadOnly();
        }

        public void Add(IGun model)
        {
            if (model is null)
            {
                throw new ArgumentException("Cannot add null in Gun Repository");
            }

            guns.Add(model);
        }

        public IGun FindByName(string name)
        {
            return guns.FirstOrDefault(g => g.Name == name);
        }

        public bool Remove(IGun model)
        {
            if (this.guns.Contains(model))
            {
                guns.Remove(model);
                return true;
            }

            return false;
        }
    }
}
