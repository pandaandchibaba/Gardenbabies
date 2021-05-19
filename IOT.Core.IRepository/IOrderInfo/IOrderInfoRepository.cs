using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.IOrderInfo
{
    public interface IOrderInfoRepository:IBaseRepository<IOT.Core.Model.OrderInfo>
    {
        //模糊查询
        List<IOT.Core.Model.OrderInfo> GetList(string name,string state,string end,string tui,string dingt,string uid,string cname,string ziti);
    }
}
