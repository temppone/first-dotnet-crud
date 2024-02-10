using Catalog.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Api.Repositories
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
        public async Task CreateProductAsync(Product product)
        {
            await collection.InsertOneAsync(product);
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            var filter = filterBuilder.Eq(product => product.Id, id);

            return await collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            var filter = filterBuilder.Eq(existingProduct => product.Id, product.Id);

            await collection.ReplaceOneAsync(filter, product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var filter = filterBuilder.Eq(product => product.Id, id);

            await collection.DeleteOneAsync(filter);
        }
    }
}