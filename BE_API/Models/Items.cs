namespace BE_API.Models;

public class Item
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Category { get; set; }
    
    public decimal? Price { get; set; }
}