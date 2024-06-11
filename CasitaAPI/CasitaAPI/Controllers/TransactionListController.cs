using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Repository;
using CasitaAPI.Utils;
using CasitaAPI.ViewModels;
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

        [HttpPost]
        public IActionResult Create(TransactionList tList) 
        {
            try
            {
                _transactionRepository.Create(tList);

                return Ok(tList);
            }
            catch (Exception e )
            {

              return BadRequest(e);
            }
        
        }



        [HttpPut]
        public IActionResult Update(int id, TransactionList tList) 
        {
            try
            {
                _transactionRepository.Update(id, tList);

                return Ok(tList + "foi atualizada");
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpGet("List")]
        public IActionResult GetList(Guid id) 
        {
            try
            {
                return Ok(_transactionRepository.GetList(id));
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }

        }

        [HttpGet("limits")]
        public IActionResult Get(Guid idUser)
        {
            return Ok(_transactionRepository.GetLimits(idUser));   
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            try
            {
                _transactionRepository.Delete(id);

                return Ok("transacao deletada");
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpPut("AlterarFotoTransacao")]
        public async Task<IActionResult> UpdateProfileImage(int id, [FromForm] UserViewModel form)
        {
            try
            {
                TransactionList transactionFound = _transactionRepository.GetTransaction(id);

                if (transactionFound == null)
                {
                    return NotFound();
                }

                var containerName = "casita";
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=casitastorage;AccountKey=SUbgY9W4S0NwGe1yufbl0AVygbkn25RfE6rvuDJZP1lU3QBfSJw1RX7phvHOPj10+IW69fh9Rj7R+AStL+jXKA==;EndpointSuffix=core.windows.net";

                string fotoUrlFound = await AzureBlobStorageHelper.UploadImageBlobAsync(form.Arquivo!, connectionString!, containerName!);

                transactionFound.PhotoUrl = fotoUrlFound;


                _transactionRepository.UploadPhoto(id, fotoUrlFound);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
