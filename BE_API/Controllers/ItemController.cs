using BE_API.Models;
using BE_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BE_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    private readonly IItemRepository _itemRepository;
    
    public ItemController(ILogger<ItemController> logger, IItemRepository itemRepository)
    {
        _logger = logger;
        _itemRepository = itemRepository;
    }

    [HttpGet]
    public ActionResult<IList<Item>> Get()
    {
        return _itemRepository.GetAll().ToList();
    }
    
    [HttpGet]
    [Route("/xml")]
    [Produces("application/xml")]
    public ActionResult<IList<Item>> GetXml()
    {
        return _itemRepository.GetAll().ToList();
    }

    [HttpGet]
    [Route("/{id}")]
    public ActionResult<Item> Get(string id)
    {
        var item = _itemRepository.Get(id);
        if (item == null)
        {
            return NotFound();
        }

        return item;
    }
    
    [HttpPut]
    public ActionResult<Item> Create(Item item)
    {
        return _itemRepository.Add(item);
    }
    
    [HttpPost]
    public ActionResult<Item> Update(Item item)
    {
        if (_itemRepository.Update(item))
        {
            return item;
        }

        return NotFound();
    }
    
    [HttpDelete]
    public ActionResult<bool> Delete(string id)
    {
        if (_itemRepository.Remove(id))
        {
            return true;
        }

        return NotFound();
    }
    
}