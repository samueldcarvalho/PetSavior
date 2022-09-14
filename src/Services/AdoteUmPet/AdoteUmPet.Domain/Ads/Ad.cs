using AdoteUmPet.Core.Domain;
using AdoteUmPet.Core.Infrastructure;
using AdoteUmPet.Domain.Ads.Enums;
using AdoteUmPet.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Domain.Ads
{
    public class Ad : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int PetId { get; private set; }
        public Pet Pet { get; private set; }
        public int UserId { get; private set; }
        public AdStatusEnum AdStatus { get; private set; }
    }
}
