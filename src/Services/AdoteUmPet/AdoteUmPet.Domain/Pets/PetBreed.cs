using AdoteUmPet.Core.Domain;

namespace AdoteUmPet.Domain.Pets
{
    public class PetBreed : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Group { get; private set; }
        public string ArticleURL { get; private set; }

        protected PetBreed() { }
        public PetBreed(string name, string description, string group, string articleURL = "")
        {
            Name = name;
            Description = description;
            ArticleURL = articleURL;
            Group = group;
        }
    }
}