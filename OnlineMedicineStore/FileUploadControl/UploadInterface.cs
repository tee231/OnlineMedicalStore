using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineMedicineStore.FileUploadControl
{
    public interface UploadInterface
    {
        void uploadfilemultiple(IList<IFormFile> files);
    }
}
