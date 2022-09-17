using AdoteUmPet.Core.Domain;
using AdoteUmPet.Core.Infrastructure;
using AdoteUmPet.Domain.Ads.Enums;
using AdoteUmPet.Domain.Pets;
using AdoteUmPet.Domain.Users;
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
        public string Description { get; private set; } = "";
        public int PetId { get; private set; }
        public Pet Pet { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public AdoptionStatusEnum AdoptionStatus { get; private set; } = AdoptionStatusEnum.Available;
        public AdStatusEnum AdStatus { get; private set; } = AdStatusEnum.Draft;

        protected Ad() { }
        public Ad(string title, string description, Pet pet, User user)
        {
            Title = title;
            Description = description;
            Pet = pet;
            User = user;
        }

        public void ChangeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("Title cannot be null or empty");

            Title = title;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void ChangeAdStatus(AdStatusEnum status)
        {

            if(status == AdStatusEnum.Draft)
                throw new Exception("Ad status cannot be changed for Draft");

            AdStatus = status;
        }


        public void ChangeAdoptionStatus(AdoptionStatusEnum status)
        {
            AdoptionStatus = status;
        }
    }
}
