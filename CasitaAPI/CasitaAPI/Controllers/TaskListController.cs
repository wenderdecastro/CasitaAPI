using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasitaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        public readonly IListRepository _listRepository;

        public TaskListController()
        {
            _listRepository = new ListRepository();
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return Ok(_listRepository.GetAllLists(id));
        }

        [HttpPost]
        public IActionResult Post(AppList list)
        {
            try
            {
                _listRepository.Create(list);
                return Ok();

            }
            catch (Exception e)
            {

                return BadRequest(e.InnerException);
            }
            
        }
   
    }
}
