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

        [HttpGet("cart")]
        public IActionResult GetList(Guid id)
        {
            return Ok(_listRepository.GetListOfLists(id));
        }
        [HttpGet("otherLists")]
        public IActionResult GetCart(Guid id)
        {
            return Ok(_listRepository.getCart(id));
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

        [HttpGet("home")]
        public ActionResult GetHome(Guid userId)
        {

            return Ok( _listRepository.GetHomeLists(userId));
        }

        
        [HttpGet("default")]
        public ActionResult GetDefault(Guid userId)
        {

            return Ok(_listRepository.GetDefaultLists(userId));
        }
        [HttpGet("custom")]
        public ActionResult GetCustom(Guid userId)
        {

            return Ok(_listRepository.GetCustomLists(userId));
        }
    }
}
