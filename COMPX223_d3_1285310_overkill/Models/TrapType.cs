using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMPX223_d3_1285310_overkill.Models
{
    public class TrapType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Trap> Traps { get; set; }
    }
}
