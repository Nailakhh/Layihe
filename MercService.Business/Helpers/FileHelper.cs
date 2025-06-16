using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Business.Helpers
{
    public static class FileHelper
    {
        public static string UploadFile(this IFormFile file, string rootPath, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Fayl boşdur.");

            var extension = Path.GetExtension(file.FileName);
            var originalName = Path.GetFileNameWithoutExtension(file.FileName);

            if (originalName.Length > 64)
                originalName = originalName.Substring(originalName.Length - 64);

            var fileName = $"{Guid.NewGuid()}-{originalName}{extension}";
            var fullPath = Path.Combine(rootPath, folderName, fileName);

            // Yoxla folder mövcuddurmu
            Directory.CreateDirectory(Path.Combine(rootPath, folderName));

            using var stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }

        public static void DeleteFile(this string fileName, string rootPath, string folderName)
        {
            if (string.IsNullOrEmpty(fileName)) return;

            var filePath = Path.Combine(rootPath, folderName, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
