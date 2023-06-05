using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R52_Ex_08_Evidence.ViewModels
{
    public class ImageUpload
    {
        
        public IFormFile Picture { get; set; } = default!;
    }
}