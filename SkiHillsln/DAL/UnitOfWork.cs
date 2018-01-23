using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DAL.Models;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext db;
        public IRepository<Ski> SkiRepo { get; set; }
        public IRepository<Boot> BootsRepo { get; set; }
        public IRepository<Helmet> HelmetsRepo { get; set; }
        public IRepository<Binding> BindingsRepo { get; set; }

        public UnitOfWork(DbContext db)
        {
            this.db = db;
            SkiRepo = new SkillHillRepo<Ski>(this.db);
            BootsRepo = new SkillHillRepo<Boot>(this.db);
            HelmetsRepo = new SkillHillRepo<Helmet>(this.db);
            BindingsRepo = new SkillHillRepo<Binding>(this.db);
        }

        ////For Testing
        public UnitOfWork(DbContext db, IRepository<Ski> ski, IRepository<Boot> boots, IRepository<Helmet> helmets, IRepository<Binding> bindings)
        {
            this.db = db;
            SkiRepo = ski;
            BootsRepo = boots;
            HelmetsRepo = helmets;
            BindingsRepo = bindings;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Commit()
        {
            db.SaveChanges();
        }

    }
}