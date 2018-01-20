using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL.Models;


namespace SkiHillService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISkiHillService
    {

        [OperationContract]
        IEnumerable<Ski> GetSkiByCategory(SkiCategory categ);
        [OperationContract]
        IEnumerable<Boot> GetBootByCategory(BootCategory categ);
        [OperationContract]
        IEnumerable<Helmet> GetHelmetByCategory(HelmetCategory categ);
        [OperationContract]
        IEnumerable<Binding> GetBindingByCategory(BindingCategory categ);
        [OperationContract]
        IEnumerable<Ski> GetAllSki();
        [OperationContract]
        IEnumerable<Boot> GetAllBoots();
        [OperationContract]
        IEnumerable<Helmet> GetAllHelmets();
        [OperationContract]
        IEnumerable<Binding> GetAllBindings();
    }


    
}
