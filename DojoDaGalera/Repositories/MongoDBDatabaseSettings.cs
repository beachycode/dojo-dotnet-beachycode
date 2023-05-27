namespace DojoDotnet.Repositories
{
    public class MongoDBDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string DojoCollectionName { get; set; }
    }
}