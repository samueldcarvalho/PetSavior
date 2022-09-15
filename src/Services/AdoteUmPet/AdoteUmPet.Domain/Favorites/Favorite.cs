using AdoteUmPet.Core.Domain;
using AdoteUmPet.Domain.Favorites.Enums;
using AdoteUmPet.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoteUmPet.Domain.Favorites
{
    public class Favorite : Entity
    {
        public int UserId { get; private set; }
        public User User { get; private set; }
        public int OptionId { get; private set; }
        public FavoriteTypesEnum OptionType { get; private set; }

        protected Favorite() { }
        public Favorite(User user, int optionId, FavoriteTypesEnum optionType)
        {
            User = user;
            OptionId = optionId;
            OptionType = optionType;
        }
    }
}
