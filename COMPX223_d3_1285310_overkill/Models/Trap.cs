using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMPX223_d3_1285310_overkill.Models
{
    public class Trap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegistrationNumber { get; set; }

        public int TrapTypeId { get; set; }
        public int TrapUserId { get; set; }

        [ForeignKey("TrapUserId")]
        public TrapUser TrapUser { get; set; }

        [ForeignKey("TrapTypeId")]
        public TrapType TrapType { get; set; }

        public ICollection<TrapCatchEvent> TrapCatchEvents { get; set; }

    }
}
