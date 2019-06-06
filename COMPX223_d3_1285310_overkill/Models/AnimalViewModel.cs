using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace COMPX223_d3_1285310_overkill.Models
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }

        public ICollection<TrapCatchEvent> TrapCatchEvents { get; set; }

    }
   
}
