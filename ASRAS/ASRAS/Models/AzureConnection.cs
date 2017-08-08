using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASRAS.Models
{
    public class AzureConnection
    {
        public void UploadFiletoblobStorage(string containerName,string blockBlogName,string fileName)
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

        }
    }
}