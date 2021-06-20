using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;

        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
        {
            get => this.decorations.AsReadOnly();
        }

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = this.decorations.FirstOrDefault(d => d.GetType().Name == type);

            if (decoration == null)
            {
                return null;
            }

            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            if (this.decorations.Contains(model))
            {
                this.decorations.Remove(model);
                return true;
            }

            return false;
        }
    }
}
