using IOT.Core.Common;
using IOT.Core.IRepository.CommissionRecord;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.CommissionRecord
{
    public class CommissionRecordRepository : ICommissionRecordRepository
    {
        /// <summary>
        /// 显示查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<V_CommissionRecord> GetCommissionRecords(string key = "")
        {
            //获取全部数据
            List<V_CommissionRecord> lst = DapperHelper.GetList<V_CommissionRecord>("select * from V_CommissionRecord");
            //查询
            if (!string.IsNullOrEmpty(key))
            {
                lst = lst.Where(x => x.SName.Contains(key)).ToList();
            }
            return lst;
        }
    }
}
