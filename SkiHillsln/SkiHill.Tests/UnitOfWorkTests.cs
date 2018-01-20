using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using SkiHill.Tests.Mock;

namespace SkiHill.Tests
{
    [TestClass()]
    public class UnitOfWorkTests
    {
        [TestMethod()]
        public void Test_Add_Element_To_Db()
        {
            MockDb db = new MockDb();
            IUnitOfWork unit = new UnitOfWork(db, db.Ski, db.Boots, db.Helmets, db.Bindings);

            Ski ski = new Ski
            {
                Id = 12,
                Brand = "Rossignol",
                Model = "Pro t",
                Price = 299M,
                Category = SkiCategory.Race
            };

            Boot boot = new Boot
            {
                Id = 12,
                Brand = "Fischer",
                Model = "Cax",
                Price = 120M,
                Category = BootCategory.CrossCountry
            };

            db.Ski.Add(ski);
            db.Boots.Add(boot);
            Assert.AreEqual(7, db.Ski.Set.Count);
            Assert.AreEqual(7, db.Boots.Set.Count);
        }

        [TestMethod()]
        public void Test_Delete_Element_From_Db()
        {
            MockDb db = new MockDb();
            IUnitOfWork unit = new UnitOfWork(db, db.Ski, db.Boots, db.Helmets, db.Bindings);

            Binding bind = db.Bindings.Set.ElementAt(2);

            db.Bindings.Delete(bind);

            foreach(var binds in db.Bindings.Set)
            {
                
                Assert.AreNotEqual(3, binds.Id);
            }
        }

        [TestMethod()]
        public void Test_Get_Element_From_Db()
        {
            MockDb db = new MockDb();
            IUnitOfWork unit = new UnitOfWork(db, db.Ski, db.Boots, db.Helmets, db.Bindings);

            Helmet helmet = db.Helmets.GetElement(x => x.Id == 2);

            Helmet expected = new Helmet { Id = 2, Brand = "Alpina", Size = 55, Model = "Carat LX", Category = HelmetCategory.Junior, Price = 62.95M };
            Assert.AreEqual(expected.Id, helmet.Id);
            Assert.AreEqual(expected.Model, helmet.Model);
            Assert.AreEqual(expected.Category, helmet.Category);            

        }
        [TestMethod()]
        public void Test_Get_Element_No_Existing_From_Db()
        {
            MockDb db = new MockDb();
            IUnitOfWork unit = new UnitOfWork(db, db.Ski, db.Boots, db.Helmets, db.Bindings);

            Helmet helmet = db.Helmets.GetElement(x => x.Id == 24);

            Assert.IsNull(helmet);

        }

        [TestMethod()]
        public void Test_Get_Elements_by_Category_From_Db()
        {
            MockDb db = new MockDb();
            IUnitOfWork unit = new UnitOfWork(db, db.Ski, db.Boots, db.Helmets, db.Bindings);

            IEnumerable<Binding> bindings = db.Bindings.GetElements(x => x.Category == BindingCategory.Touring);

            Assert.AreEqual(2, bindings.Count());
        }

        [TestMethod()]
        public void Test_Get_Elements_by_Category_correct_Category_From_Db()
        {
            MockDb db = new MockDb();
            IUnitOfWork unit = new UnitOfWork(db, db.Ski, db.Boots, db.Helmets, db.Bindings);

            IEnumerable<Binding> bindings = db.Bindings.GetElements(x => x.Category == BindingCategory.Touring);

            foreach(var bind in bindings)
            {
                Assert.AreEqual(BindingCategory.Touring, bind.Category);
            }
        }
    }
}