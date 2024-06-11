using Azure.Storage.Blobs;

namespace CasitaAPI.Utils
{
    public static class AzureBlobStorageHelper
    {

        public static async Task<string> UploadImageBlobAsync(IFormFile arquivo, string stringConexao, string nomeContainer)
        {
            try
            {
                //Verifica se existe o arquivo 
                if (arquivo != null)
                {
                    //Gera um nome único para a imagem
                    var blobName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(arquivo.FileName);

                    //Cria uma instância do BlobServiceClient passando a string de conexão com o blob da Azure
                    var blobServiceClient = new BlobServiceClient(stringConexao);

                    //Obtem dados do container client
                    var blobContainerClient = blobServiceClient.GetBlobContainerClient(nomeContainer);

                    //Obtem um blobClient usando o blob name
                    var blobClient = blobContainerClient.GetBlobClient(blobName);

                    //Abre o fluxo de entrada do arquivo (foto)
                    using (var stream = arquivo.OpenReadStream())
                    {
                        //Carrega o arquivo para o blob de forma assincrona
                        await blobClient.UploadAsync(stream, true);
                    }

                    //Retorna a uri do blob como uma string
                    return blobClient.Uri.ToString();
                }
                else
                {
                    //Retorna a uri de uma imagem padrão caso nenhuma imagem seja enviada na requisição 
                    return "https://blobvitalhub06.blob.core.windows.net/vitalcontainer06/profile.png";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
