using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.Parse("9d70b801-e27d-4650-b633-60f7930e2fb8"), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 49, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 44, CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {                
            return items.Where(item => item.Id == id).SingleOrDefault() ?? throw new KeyNotFoundException($"Item with id {id} not found");
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}