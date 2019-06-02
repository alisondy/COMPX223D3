using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMPX223_d3_1285310_overkill.Models
{
    public class TrapUser
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; }

        public int LandownerId { get; set; }

        [ForeignKey("LandownerId")]
        public Landowner Landowner { get; set; }

    }
}
