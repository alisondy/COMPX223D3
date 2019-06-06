using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace COMPX223_d3_1285310_overkill.Models
{

    public class TrapCatchEventView
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int TrapId { get; set; }
        public int AnimalId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerPassword { get; set; }


        [ForeignKey("TrapId")]
        public Trap Trap { get; set; }

        [ForeignKey("AnimalId")]
        public Animal Animal { get; set; }

        [ForeignKey("ManagerId")]
        public Manager Manager { get; set; }
    }
}
