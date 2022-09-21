using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetSavior.Core.Identity
{
    public class ApplicationUserService<TUser> : IApplicationUserService<TUser> where TUser : class
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<TUser> _userManager;

        public ApplicationUserService(UserManager<TUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserId()
        {
            string idLogged = _httpContextAccessor.HttpContext.User.Identity.Name;

            if (string.IsNullOrWhiteSpace(idLogged) || !int.TryParse(idLogged, out int id))
                return 0;

            return id;
        }

        public Task<TUser> GetUser()
        {
            string idLogged = _httpContextAccessor.HttpContext.User.Identity.Name;

            return _userManager.FindByIdAsync(idLogged);
        }
    }
}
