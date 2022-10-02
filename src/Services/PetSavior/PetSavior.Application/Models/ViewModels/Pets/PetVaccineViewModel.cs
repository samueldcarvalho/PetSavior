namespace PetSavior.Application.Models.ViewModels.Pets
{
    public class PetVaccineViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DosesRemaining { get; set; }
        public bool Completed { get; set; }
        public int PetId { get; set; }
    }
}