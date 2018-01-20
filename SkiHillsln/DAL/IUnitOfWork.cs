using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public interface IUnitOfWork
    {
        IRepository<Ski> SkiRepo { get; set; }
        IRepository<Boot> BootsRepo { get; set; }
        IRepository<Helmet> HelmetsRepo { get; set; }
        IRepository<Binding> BindingsRepo { get; set; }

        void Commit();
    }
}
