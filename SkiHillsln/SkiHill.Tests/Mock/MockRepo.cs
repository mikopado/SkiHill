using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DAL.Models;
using DAL;

namespace SkiHill.Tests.Mock
{
    public class MockRepo<T> : IRepository<T> 
    {
        public ISet<T> Set { get; set; }

        public void Add(T element)
        {
            Set.Add(element);
        }

        public int Count()
        {
            return Set.Count;
        }

        public void Delete(T element)
        {
            Set.Remove(element);
        }

        public T GetElement(Func<T, bool> func)
        {
            return Set.Where(func).FirstOrDefault();
        }

        public IEnumerable<T> GetElements(Func<T, bool> func)
        {
            return Set.Where(func);
        }

        public void Update(T element)
        {
            throw new NotImplementedException();
        }
    }
}