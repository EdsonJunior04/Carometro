using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FaceCheck.webAPI.Utils
{
    public class UploadBase64Image
    {
        public string UploadBase64Imagem(string base64Image, string container)
        {
            // Gera um nome randomico para imagem
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            // Gera um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            // Define o BLOB no qual a imagem será armazenada
            var blobClient = new BlobClient("SUA CONN STRING", container, fileName);

            // Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            // Retorna a URL da imagem
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
