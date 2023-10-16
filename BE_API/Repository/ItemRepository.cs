using BE_API.Models;

namespace BE_API.Repository;

public class ItemRepository : IItemRepository
{
    private List<Item> items = new List<Item>();

    public ItemRepository()
    {
        Add(new Item { Name = "Item1", Category = "Category1", Price = 100 });
        Add(new Item { Name = "Item2", Category = "Category1", Price = 150 });
        Add(new Item { Name = "Item3", Category = "Category2", Price = 200 });
    }

    public IEnumerable<Item> GetAll()
    {
        return items;
    }

    public Item? Get(string id)
    {
        return items.Find(p => p.Id == id);
    }

    public Item Add(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("item");
        }

        item.Id = Guid.NewGuid().ToString();
        items.Add(item);
        return item;
    }

    public bool Remove(string id)
    {
        return items.RemoveAll(p => p.Id == id) > 0;
    }

    public bool Update(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("item");
        }

        int index = items.FindIndex(p => p.Id == item.Id);
        if (index == -1)
        {
            return false;
        }

        items.RemoveAt(index);
        items.Add(item);
        return true;
    }
}