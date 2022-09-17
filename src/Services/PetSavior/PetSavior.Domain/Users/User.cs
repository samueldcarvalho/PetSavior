using AdoteUmPet.Core.Infrastructure;
using AdoteUmPet.Domain.Ads;
using AdoteUmPet.Domain.Favorites;
using AdoteUmPet.Domain.Pets;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Domain.Users
{
    public class User: IdentityUser<int>, IAggregateRoot
    {
        public string Name { get; private set; }
        public ICollection<Ad> Ads { get; private set; }
        public ICollection<Pet> Pets { get; private set; }
        public ICollection<Favorite> Favorites { get; private set; }

        public User(string name, string email)
        {
            Name = name;
            UserName = email;
            Email = email;
            EmailConfirmed = true;
        }

        public void ChangeFavorite(Favorite newFavorite)
        {
            if (newFavorite == null)
                throw new Exception("Favorite cannot be null");

            Favorite favorite = Favorites.FirstOrDefault(f => 
                f.UserId == newFavorite.UserId && 
                f.OptionId == newFavorite.OptionId &&           
                f.OptionType == newFavorite.OptionType);

            if (favorite == null)
            {
                Favorites.Add(newFavorite);
            }
            else
            {
                Favorites.Remove(favorite);
            }
        }

        public void AddNewAd(Ad ad)
        {
            if (ad == null)
                throw new Exception("Ad cannot be null");

            if (Ads.Any(a => a.Id == ad.Id))
                return;

            Ads.Add(ad);
        }

        public void AddNewPet(Pet pet)
        {
            if (pet == null)
                throw new Exception("Pet cannot be null");

            if (Pets.Any(p => p.Id == pet.Id))
                return;

            Pets.Add(pet);
        }
    }
}
