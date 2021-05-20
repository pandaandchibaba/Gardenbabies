using IOT.Core.Common;
using IOT.Core.IRepository.Brokerage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Brokerage
{
    public class BrokerageRepository : IBrokerageRepository
    {
        public List<Model.Brokerage> GetBrokerages()
        {
            string sql = "select b.HeadPortrait,b.NickName,a.BrokerageType,a.Income,a.State,a.EndTime,a.OrderFormStatus from brokerage a join Colonel b ON a.ColonelID=b.ColonelID";
            return DapperHelper.GetList<Model.Brokerage>(sql);
        }
    }
}
