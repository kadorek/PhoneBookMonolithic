namespace PhoneBookMonolithic.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string ContactsCollectionName { get; set; } = null;
        public string ReportsCollectionName { get; set; } = null;
    }
}
