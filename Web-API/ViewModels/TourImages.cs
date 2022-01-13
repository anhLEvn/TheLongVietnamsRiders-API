using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.ViewModels
{
    public class TourImages
    {
        public List<IFormFile> Images { get; set; }
        public TourPackage TourPackage { get; set; }
    }
}
