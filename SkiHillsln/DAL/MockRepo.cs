using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DAL.Models;

namespace DAL
{
    public class MockSki : IRepository<Ski> 
    {
        public MockDb Db { get; set; }


        public void Add(Ski element)
        {
            Db.Ski.Add(element);
        }

        public void Delete(Ski element)
        {
            Db.Ski.Remove(element);
        }

        public Ski GetElement(Func<Ski, bool> func)
        {
            return Db.Ski.Where(func).FirstOrDefault();
        }

        public IEnumerable<Ski> GetElements(Func<Ski, bool> func)
        {
            return Db.Ski.Where(func);
        }

        public void Update(Ski element)
        {
            throw new NotImplementedException();
        }
    }
}