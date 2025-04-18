namespace GamesEthic.Server.Models.Config
{
    public sealed class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
