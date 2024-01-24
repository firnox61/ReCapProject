using Core.Utilities.Helper.FileHelper.Constants;
using Core.Utilities.Helper.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Constants;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelper : IFileHelper
    {
    

        public string Add(IFormFile file)
        {
            //dosyanın uzantısını alıyorum.
            string fileExtension = Path.GetExtension(file.FileName);
            //Guid ile uzantıyı birleştiriyorum.
            string uniqueFileName = GuidHelper_.Create() + fileExtension;
            //GuidHelper_.Create() + fileExtension;
            //kaydetmek istediğim yerin tam yolunu alıyorum.
            var imagePath = FilePath.Full(uniqueFileName);
            using FileStream fileStream = new(imagePath, FileMode.Create);
            // FilMode.Create
            // İşletim sisteminin yeni bir dosya oluşturması gerektiğini 
            // belirtir. Dosya zaten mevcutsa, üzerine yazılacaktır.
            file.CopyTo(fileStream); //yola kopyalıyorum.
            fileStream.Flush(); // ara belleği temizliyorum.
            return uniqueFileName;

        }

        public void Delete(string path)
        {
            if (File.Exists(FilePath.Full(path))) //varsa true
            {
                File.Delete(FilePath.Full(path));
            }
            else
            {
                throw new DirectoryNotFoundException(Messages.FileNotFound);
            }
        }

        public void Update(IFormFile file, string imagePath)
        {
            var fullpath = FilePath.Full(imagePath);
            if (File.Exists(fullpath))
            {
                using FileStream fileStream = new(fullpath, FileMode.Create);
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            else
            {
                throw new DirectoryNotFoundException(Messages.FileNotFound);
            }
        }
    }
}
