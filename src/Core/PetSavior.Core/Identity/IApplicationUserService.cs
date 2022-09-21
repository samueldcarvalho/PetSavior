using System.Threading.Tasks;

namespace PetSavior.Core.Identity
{
    public interface IApplicationUserService<TUser> where TUser : class
    {
        Task<TUser> GetUser();
        int GetUserId();
    }
}