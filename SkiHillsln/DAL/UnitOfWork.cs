using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DAL.Models;

namespace DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly IDb db;
        public IRepository<Ski> SkiRepo { get; set; }
        public IRepository<Boot> BootsRepo { get; set; }
        public IRepository<Helmet> HelmetsRepo { get; set; }
        public IRepository<Binding> BindingsRepo { get; set; }

        public UnitOfWork()
        {
            this.db = new SkiHillDb();
            SkiRepo = new SkillHillRepo<Ski>();
            BootsRepo = new SkillHillRepo<Boot>();
            HelmetsRepo = new SkillHillRepo<Helmet>();
            BindingsRepo = new SkillHillRepo<Binding>();
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