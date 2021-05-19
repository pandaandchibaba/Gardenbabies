using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.OrderInfo
{
    public interface IOrderInfoRepository:IBaseRepository<IOT.Core.Model.OrderInfo>
    {
        List<IOT.Core.Model.OrderInfo> GetOrderInfos(string name, string state, string end, int tui, int dingt, int uid, string cname, string ziti);
        

        
    }
}
