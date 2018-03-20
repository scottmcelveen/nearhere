using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nearhere
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Andrew Thompson", Description="25 Male, Belfast" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Brenda Nelson", Description="32 Female, Newtownards." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Chris Davidson", Description="31 Male, Bangor." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Dean Smith", Description="29 Male, Holywood." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ernie Rogers", Description="27 Male, Coleraine." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Francesca Mitchell", Description="26 Female, Enniskillen." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
