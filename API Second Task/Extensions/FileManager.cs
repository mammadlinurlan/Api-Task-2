using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Extensions
{
    public static class FileManager
    {
        public static string SaveImg(this IFormFile file, string root, string folder)
        {
            string rootPath = Path.Combine(root, folder);
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(rootPath, fileName);
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }
    }
}
