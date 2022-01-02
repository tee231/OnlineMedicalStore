﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace OnlineMedicineStore.FileUploadControl
{
    public class uploadfilerepo : UploadInterface
    {
        private IHostingEnvironment hostingEnvironment;
        public uploadfilerepo(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public async void uploadfilemultiple(IList<IFormFile> files)
        {
            long totalBytes = files.Sum(f => f.Length);
            foreach (IFormFile item in files)
            {
                string filename = item.FileName.Trim('"');
                byte[] buffer = new byte[16 * 1024];
                using (FileStream output = System.IO.File.Create(this.GetpathAndFilename(filename)))
                {
                    using (Stream input = item.OpenReadStream())
                    {
                        int readBytes;
                        while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }

        private string GetpathAndFilename(string filename)
        {
            string path = this.hostingEnvironment.WebRootPath + "\\upload\\";
            if (Directory.Exists(path))

                Directory.CreateDirectory(path);
            return path + filename;

        }

    }
}
    