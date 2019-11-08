using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using App1.Entity;
using Newtonsoft.Json;

namespace App1.Service
{
    class FileService : IFileService
    {
        public async Task<bool> SeveToFile(MemberCredential memberCredential)
        {
            try
            {
                var storageFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("SavedFile",
                    CreationCollisionOption.OpenIfExists);
                var storageFile =
                    await storageFolder.CreateFileAsync("token.txt", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(storageFile, JsonConvert.SerializeObject(memberCredential));
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("loi save file");
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<MemberCredential> ReadFile()
        {
            var storageFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("SavedFile",
                CreationCollisionOption.OpenIfExists);
            try
            {
                var storageFile =
                    await storageFolder.GetFileAsync("token.txt");
                if (storageFile != null)
                {
                    var jsonContent = await FileIO.ReadTextAsync(storageFile);
                    return JsonConvert.DeserializeObject<MemberCredential>(jsonContent);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("doc file that bai");
            }
            return null;
        }
     public async Task<bool> DeleteFile()
        {
            try {
                var storageFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("SavedFile",
                 CreationCollisionOption.OpenIfExists);
               
            }
            catch (Exception) 
            {
                Debug.WriteLine("ko xoa dc file");
            }
            return false;
        }
    }
}
