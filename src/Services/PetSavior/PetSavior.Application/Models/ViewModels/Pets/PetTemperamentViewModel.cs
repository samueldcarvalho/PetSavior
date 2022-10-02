namespace PetSavior.Application.Models.ViewModels.Pets
{
    public class PetTemperamentViewModel
    {
        public int Id { get; set; }
        public string TemperamentName { get; set; }
        public int TemperamentLevel { get; set; }
        public int PetId { get; set; }
    }
}