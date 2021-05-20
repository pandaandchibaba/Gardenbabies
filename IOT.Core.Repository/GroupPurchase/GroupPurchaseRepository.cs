using IOT.Core.Common;
using IOT.Core.IRepository.GroupPurchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.GroupPurchase
{
    public class GroupPurchaseRepository : IGroupPurchaseRepository
    {
        public List<Model.GroupPurchase> GetModels()
        {
            string sql = "SELECT * from GroupPurchase";
            return DapperHelper.GetList<Model.GroupPurchase>(sql);
        }

        public int insert(Model.GroupPurchase a)
        {
            string sql = $"insert into GroupPurchase VALUES(null,'{a.IsGroup}','{a.Notice}','{a.CloseTime}','{a.PosterOne}','{a.PosterTwo}','{a.PosterThree}','{a.DespatchMode}','{a.HeadName}','{a.CoverageArea}','{a.ServiceCharge}','{a.WithdrawDeposit}','{a.Commission}')";

            return DapperHelper.Execute(sql); 
        }
    }
}
