using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Model;
namespace IOT.Core.IRepository.PayStore
{
    public interface IPayStoreRepository
    {
        int UptWhether(IOT.Core.Model.PayStore Model);
        int UptCollection(IOT.Core.Model.PayStore Model);
    }
}
