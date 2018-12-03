namespace Infrastructure.Data.API.Settings
{
    public static class SteamSettings
    {
        public const string URL = "https://store.steampowered.com/search/?ignore_preferences=1&page=";
        public const string XPATH = "//span[@class=\"title\"]";
        public const int MAXPAGES = 2218;
        
        
        
    }
}