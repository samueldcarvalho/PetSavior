using AdoteUmPet.Core.Infrastructure;
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

        public User(string name, string email)
        {
            Name = name;
            UserName = email;
            Email = email;
            EmailConfirmed = true;
        }
    }
}
