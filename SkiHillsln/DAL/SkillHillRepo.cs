using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Linq.Expressions;


namespace DAL
{
    public class SkillHillRepo<T> : IRepository<T> where T: class
    {
        public DbContext Db { get; set; }
        public DbSet<T> Entities { get; set; }

        public SkillHillRepo(DbContext db)
        {
            Db = db;
            Entities = Db.Set<T>();
        }

        public void Add(T element)
        {
            Entities.Add(element);
        }

        public void Delete(T element)
        {
            Entities.Remove(element);
        }

        public T GetElement(Func<T, bool> func)
        {
            return Entities.Where(func).FirstOrDefault();
        }

        public IEnumerable<T> GetElements(Func<T, bool> func)
        {
            return Entities.Where(func).ToList();
        }

        public void Update(T element)
        {
            Db.Entry(element).State = EntityState.Modified;
        }

        public int Count()
        {
            return Entities.Count();
        }
    }
}