using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public IEnumerable<INotification> Notifications { get; set; }
    }
}
