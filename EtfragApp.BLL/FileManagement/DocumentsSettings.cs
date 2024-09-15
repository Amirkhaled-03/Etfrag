using Microsoft.AspNetCore.Http;

namespace EtfragApp.BLL.FileManagement
{
    public class DocumentsSettings
    {
        public static string UploadFile(IFormFile file, string FolderName)
        {
            // 1. get the location of the directory (path)
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName);

            // 2. get the file name and make it unique
            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            // 3. get the file path
            var filePath = Path.Combine(folderPath, fileName);

            // 4. upload the file
            using var fileStream = new FileStream(filePath, FileMode.Create);

            // create the file 
            file.CopyTo(fileStream);

            return fileName; // stored in the data base

        }

        public static void DeleteFile(string fileUrl, string FolderName)
        {
            // 1. get the location of the directory (path)
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName, fileUrl);


            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}
