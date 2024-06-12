using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasitaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionRepository _transactionRepository;

        public TransactionController()
        {
            _transactionRepository = new TransactionRepository();
        }

        [HttpPost]
        public IActionResult GetTransaction(Transaction transaction) 
        {

            try
            {

                 _transactionRepository.Create(transaction);

                return Ok("A transacao" + transaction + "foi criada");
            }
            catch (Exception e)
            {

              return BadRequest(e.Message);
            }
        
        }

        [HttpDelete]
        public IActionResult DeleteTransaction(int id) 
        {

            try
            {
                _transactionRepository.Delete(id);

                return Ok("transacao deletada");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
