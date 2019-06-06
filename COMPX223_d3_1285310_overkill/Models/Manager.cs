using System;
using System.Collections.Generic;

namespace COMPX223_d3_1285310_overkill.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public ICollection<TrapCatchEvent> TrapCatchEvents { get; set; }
    }
}