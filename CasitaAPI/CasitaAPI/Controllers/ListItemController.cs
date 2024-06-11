using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

               
                return Ok("Lista Criada");
            }
           
            catch (Exception e)
            {

               
                return BadRequest(e.Message);
            }

        }


        [HttpDelete]
        public ActionResult Delete(Guid id)
        {

            try
            {
                _listItemRepository.Delete(id);

                return Ok("Item Deletado");
            }
            catch (Exception e)
            {


                return BadRequest(e.Message);
            }

        }


        [HttpPost("Concluir Lista")]
        public ActionResult Conclude(Guid id)
        {
            try
            {
                _listItemRepository.Conclude(id);

                return Ok("Lista Concluida");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public ActionResult Update(ListItem item, Guid id)
        {

            try
            {
                _listItemRepository.Update(id, item);

                return Ok("Item Atualizado");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
