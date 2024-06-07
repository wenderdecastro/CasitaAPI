using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace CasitaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ListItemController : ControllerBase
    {
        private readonly IListItemRepository _listItemRepository;

        public ListItemController()
        {
            _listItemRepository = new ListItemRepository();
        }

        [HttpPost]
        public ActionResult Create(ListItem item)
        {
            try
            {
                _listItemRepository.Create(item);

                return Ok("");
            }
            catch (Exception)
            {

                throw;
            }
        
        }

      
    }
}
