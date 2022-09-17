namespace AdoteUmPet.API.Configurations
{
    public class AppSettingsModel
    {
        public string Secret { get; set; }
        public int ExpirationTime { get; set; }
        public string Emitter { get; set; }
        public string AllowedHost { get; set; }
    }
}
