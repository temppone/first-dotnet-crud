using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDBProductsRepository : IProductsRepository
    {
        private const string databaseName = "catalog";
        private const string collectionName = "products";
        private readonly IMongoCollection<Product> collection;
        private readonly FilterDefinitionBuilder<Product> filterBuilder = Builders<Product>.Filter;

        public MongoDBProductsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            collection = database.GetCollection<Product>(collectionName);
        }
        public void CreateProduct(Product product)
        {
            collection.InsertOne(product);
        }

        public void DeleteProduct(Guid id)
        {
            collection.FindOneAndDelete(product => product.Id == id);
        }

        public Product GetProduct(Guid id)
        {
            var filter = filterBuilder.Eq(product => product.Id, id);

            return collection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var filter = filterBuilder.Eq(existingProduct => product.Id, product.Id);

            collection.ReplaceOne(filter, product);
        }
    }
}