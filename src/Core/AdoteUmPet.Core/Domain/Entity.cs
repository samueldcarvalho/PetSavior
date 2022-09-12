using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Core.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime AlteredAt { get; set; } = DateTime.MinValue;
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
        public bool Removed { get; set; } = false;

        protected Entity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
