using IOT.Core.Common;
using IOT.Core.IRepository.Withdrawal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Withdrawal
{
    public class WithdrawalRepository : IWithdrawalRepository
    {
        public List<Model.Withdrawal> Query(string name)
        {
            string sql = $"select a.*,b.MName FROM Withdrawal a JOIN Store b ON a.Mid=b.Mid";
            return DapperHelper.GetList<Model.Withdrawal>(sql);
        }
    }
}
