namespace PetSavior.Application.Models.ViewModels.Users
{
    public class UserToken
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public UserToken(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
