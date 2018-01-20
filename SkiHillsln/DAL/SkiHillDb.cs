using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DAL.Models;


namespace DAL
{
    public class SkiHillDb : DbContext, IDb
    {
        public DbSet<Ski> Ski { get; set; }
        public DbSet<Boot> Boots { get; set; }
        public DbSet<Helmet> Helmets { get; set; }
        public DbSet<Binding> Bindings { get; set; }

        public SkiHillDb() : base("SkiHillDb")
        {
            
        }

    }
}