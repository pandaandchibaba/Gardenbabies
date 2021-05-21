using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.CommissionRecord
{
    public interface ICommissionRecordRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<IOT.Core.Model.V_CommissionRecord> GetCommissionRecords(string key = "");
    }
}
