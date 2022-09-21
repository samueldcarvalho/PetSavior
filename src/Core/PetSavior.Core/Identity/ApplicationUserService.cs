using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetSavior.Core.Identity
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly HttpContext _httpContext;

        public ApplicationUserService(HttpContext httpContent)
        {
            _httpContext = httpContent;
        }

        public int GetUserId()
        {
            string idLogged = _httpContext.User.Identity.Name;

            if (string.IsNullOrWhiteSpace(idLogged) || !int.TryParse(idLogged, out int id))
                return 0;

            return id;
        }
    }
}
