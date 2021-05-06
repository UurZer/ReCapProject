using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete
{
    public class FileUpload
    {
        public IFormFile files { get; set; }
    }
}
