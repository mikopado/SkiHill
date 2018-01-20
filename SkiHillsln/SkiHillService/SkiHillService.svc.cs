using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL.Models;
using DAL;

namespace SkiHillService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SkiHillService : ISkiHillService
    {
        public IEnumerable<Binding> GetAllBindings()
        {
            return new SkillHillRepo<Binding>(new SkiHillDb()).GetElements(x => x.Id != 0);
        }

        public IEnumerable<Boot> GetAllBoots()
        {
            return new SkillHillRepo<Boot>(new SkiHillDb()).GetElements(x => x.Id != 0);
        }

        public IEnumerable<Helmet> GetAllHelmets()
        {
            return new SkillHillRepo<Helmet>(new SkiHillDb()).GetElements(x => x.Id != 0);
        }

        public IEnumerable<Ski> GetAllSki()
        {
            return new SkillHillRepo<Ski>(new SkiHillDb()).GetElements(x => x.Id != 0);
        }

        public IEnumerable<Binding> GetBindingByCategory(BindingCategory categ)
        {
            return new SkillHillRepo<Binding>(new SkiHillDb()).GetElements(x => x.Category == categ);
        }

        public IEnumerable<Boot> GetBootByCategory(BootCategory categ)
        {
            return new SkillHillRepo<Boot>(new SkiHillDb()).GetElements(x => x.Category == categ);
        }

        public IEnumerable<Helmet> GetHelmetByCategory(HelmetCategory categ)
        {
            return new SkillHillRepo<Helmet>(new SkiHillDb()).GetElements(x => x.Category == categ);
        }

        public IEnumerable<Ski> GetSkiByCategory(SkiCategory categ)
        {
            return new SkillHillRepo<Ski>(new SkiHillDb()).GetElements(x => x.Category == categ);
        }
    }
}
