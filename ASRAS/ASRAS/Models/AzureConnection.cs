using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASRAS.Models
{
    public class AzureConnection
    {
        public void UploadFileToBlobStorage(string containerName,string blockBlogName, HttpFileCollectionBase files)
        {
            //Retrive storage account from connection string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DefaultEndpointsProtocol=https;AccountName=academicsenatedemo;AccountKey=JzngmTlAZLhXzKxIzoApjJkL/++n/I3Cxmom8BiKxkTsPu00VsePFAZIm2bmkaOJBflBNxn12B/eqfaz0N1IOQ==;EndpointSuffix=core.windows.net"));

            //create a blob client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //retrieve refernce to previously created container
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            container.SetPermissions(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob

                });

            //Rettrive reference to a blob named myBlob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(blockBlogName);

            blockBlob.UploadFromStream(files[0].InputStream);

            // Create or overwrite the "myblob" blob with contents from a local file.
            //using (var fileStream = System.IO.File.OpenRead(fileName))
            //{
            //    blockBlob.UploadFromStream(fileStream);
            //}

        }

        
    }
}