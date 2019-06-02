using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using COMPX223_d3_1285310_overkill.Models;

    public class MyTrapAppContext : DbContext
    {
        public MyTrapAppContext (DbContextOptions<MyTrapAppContext> options)
            : base(options)
        {
        }

        public DbSet<COMPX223_d3_1285310_overkill.Models.Animal> Animal { get; set; }

        public DbSet<COMPX223_d3_1285310_overkill.Models.Landowner> Landowner { get; set; }

        public DbSet<COMPX223_d3_1285310_overkill.Models.TrapUser> TrapUser { get; set; }

        public DbSet<COMPX223_d3_1285310_overkill.Models.TrapType> TrapType { get; set; }

        public DbSet<COMPX223_d3_1285310_overkill.Models.Trap> Trap { get; set; }

        public DbSet<COMPX223_d3_1285310_overkill.Models.TrapCatchEvent> TrapCatchEvent { get; set; }
    }
