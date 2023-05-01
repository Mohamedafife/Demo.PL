using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Demo.PL.Helpers
{
    public static class DocumentsSessting
    {
        public static string UploadFile(FormFile file,string FolderName)
        {
            //Get Folder Path
            //string FolderPath = "C:\\Users\\Star Academy\\source\\repos\\Demo.PL\\Demo.PL\\wwwroot\\Files\\Images\\";
            //string FolderPath = Directory.GetCurrentDirectory() + "\\wwwroot\\Files\\" + FolderName;
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            //Get File Name And Make It UNIQUE
            string FileName = $"{Guid.NewGuid()}{file.FileName}";
            //Get File Path
            string FilePath = Path.Combine(FolderPath,FileName);
            //Save File Name As a Streams (Stream : Data Par Time)
            using var FS = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(FS);
            return FileName;
        }
        public static void DeleteFile(string FileName, string FolderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName, FileName);
            if(File.Exists(FilePath))
                File.Delete(FilePath);
        }

    }
}
