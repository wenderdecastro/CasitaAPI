using CasitaAPI.Interfaces;
using CasitaAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasitaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionListController : ControllerBase
    {

        private readonly ITransactionListRepository _transactionRepository;

        public TransactionListController()
        {
            _transactionRepository = new TransactionListRepository();   
        }

        [HttpGet("limits")]
        public IActionResult Get(Guid idUser)
        {
            return Ok(_transactionRepository.GetLimits(idUser));   
        }
    }
}
