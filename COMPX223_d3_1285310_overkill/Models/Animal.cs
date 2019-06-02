using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace COMPX223_d3_1285310_overkill.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public ICollection<TrapCatchEvent> TrapCatchEvents { get; set; }

    }
}
