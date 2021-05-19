using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Model;

namespace IOT.Core.IRepository.Warehouse
{
    public interface IWarehouseRepository : IBaseRepository<IOT.Core.Model.Warehouse>
    {
        int Update(IOT.Core.Model.Warehouse warehouse);

    }
}
