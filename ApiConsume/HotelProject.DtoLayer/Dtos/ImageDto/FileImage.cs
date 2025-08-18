using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.ImageDto
{
    public class FileImage
    {
        public IFormFile? FileName { get; set; }
    }
}
