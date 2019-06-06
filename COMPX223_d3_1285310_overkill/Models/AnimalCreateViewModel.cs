using System;
using Microsoft.AspNetCore.Http;

namespace COMPX223_d3_1285310_overkill.Models
{
    public class AnimalCreateViewModel
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
    }
}
