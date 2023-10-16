using BE_API.Models;

namespace BE_API.Repository;

public interface IItemRepository
{
    IEnumerable<Item> GetAll();  
    
    Item? Get(string id);  
    
    Item Add(Item item);
    
    bool Remove(string id);  
    
    bool Update(Item item); 
}