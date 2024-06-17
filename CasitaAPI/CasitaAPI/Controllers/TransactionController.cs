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

        [HttpPost("buyCartItems")]
        public IActionResult Get(Guid userId)
        {
            var userList = _transactionRepository.ApplyCartItems(userId);
            return Ok(userList);
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

        [HttpPost("spentOnGoal")]
        public IActionResult AddGoalFunds(int goalId, decimal amount)
        {
            try
            {
                var transaction = _transactionRepository.AddGoalFunds(goalId, amount);
                return Ok(transaction);
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

        [HttpGet]
        public IActionResult ApplyCart(Guid userId)
        {
            try
            {
                var transaction = _transactionRepository.ApplyCartItems(userId);

                return Ok(transaction);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpGet("month")]
        public IActionResult GetMonth(Guid id)
        {
            return Ok(_transactionRepository.getMonthTransactions(id));
        }

    }
}
