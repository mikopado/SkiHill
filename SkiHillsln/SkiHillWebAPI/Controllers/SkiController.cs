using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkiHillWebAPI.Controllers
{
    public class SkiController : ApiController
    {
        private UnitOfWork unit = new UnitOfWork(new SkiHillDb());

        [ActionName("index")]
        public IEnumerable<Ski> GetAllSki()
        {
            return new SkillHillRepo<Ski>(new SkiHillDb()).GetElements(x => x.Id != 0);
        }

        [ActionName("index")]
        public Ski GetSki(int id)
        {
            return new SkillHillRepo<Ski>(new SkiHillDb()).GetElement(x => x.Id == id);
        }

        [ActionName("byCategory")]
        public IEnumerable<Ski> GetSkiByCategory(SkiCategory id)
        {
            return new SkillHillRepo<Ski>(new SkiHillDb()).GetElements(x => x.Category == id);
        }
    }
}
