using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Model;
using IOT.Core.IRepository;
namespace IOT.Core.IRepository.Delivery
{
    public interface IDeliveryRepository : IBaseRepository<IOT.Core.Model.Delivery>
    {
        int Update(IOT.Core.Model.Delivery Model);
    }
}
