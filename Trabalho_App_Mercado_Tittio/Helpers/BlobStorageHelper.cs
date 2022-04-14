using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Trabalho_App_Mercado_Tittio.Helpers
{
    class BlobStorageHelper
    {
        static string connection = "DefaultEndpointsProtocol=https;AccountName=mercadoonline;AccountKey=MYYikySbsnSdc35De4TK/ps6vVHQuqukZR3fWcbL3Vf7E75FquylKltG9VvDE6eQtqD/9yYmW360+AStejyEgg==;EndpointSuffix=core.windows.net";
        string key = "MYYikySbsnSdc35De4TK/ps6vVHQuqukZR3fWcbL3Vf7E75FquylKltG9VvDE6eQtqD/9yYmW360+AStejyEgg==";
        public static void Upload(string conteinerLocal, string newNameImage, Stream stream)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(connection);
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(conteinerLocal);
            container.CreateIfNotExistsAsync();
            CloudBlockBlob blob = container.GetBlockBlobReference(newNameImage + ".png");
            blob.UploadFromStreamAsync(stream);
        }
        public static void Deletar(string conteinerLocal, string nomeImagemLocal)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(connection);
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(conteinerLocal);
            container.CreateIfNotExistsAsync();
            CloudBlockBlob blob = container.GetBlockBlobReference(nomeImagemLocal + ".png");
            blob.DeleteIfExistsAsync();
        }

     
    }
}
