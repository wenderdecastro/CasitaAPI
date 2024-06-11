using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Repository;
using CasitaAPI.Utils;
using CasitaAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace CasitaAPI.Controllers
{
    public class TransactionListController : Controller
    {
        private readonly ITransactionList _transactionRepository;

        public TransactionListController()
        {
            _transactionRepository = new TransactionListRepository(); 
        }

        [HttpPut("AlterarFotoPerfil")]
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
