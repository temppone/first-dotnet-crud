namespace Catalog.Api.Settings
{
    public class MongoDbSettings
    {
        public required string Host { get; set; }
        public required string User { get; set; }
        public required string Password { get; set; }
        public int Port { get; set; }
        public string ConnectionString => $"mongodb://{User}:{Password}@{Host}:{Port}";
    }
}