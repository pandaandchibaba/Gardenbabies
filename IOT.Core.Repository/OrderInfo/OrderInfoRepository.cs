using IOT.Core.Common;
using IOT.Core.IRepository;
using IOT.Core.IRepository.IOrderInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.OrderInfo
{
    public class OrderInfoRepository : IBaseRepository<IOT.Core.Model.OrderInfo>, IOrderInfoRepository
    {

        //模糊查询
        public List<Model.OrderInfo> GetList(string name, string state, string end, string tui, string dingt, string uid, string cname, string ziti)
        {
            string sql = $@"select b.CommodityName ,b.CommodityPic ,b.ShopPrice  ,b.SId ,
			 c.NickName ,c.UserName ,c.Phone ,c.Address ,
			 a.SendWay ,a.CommodityPrice ,a.DistributionCosts ,a.OrderPrice ,a.CouponPrice ,a.AmountPaid ,a.StartTime ,a.remark,a.Orderid,a.CommodityId,a.UserId,a.OrderState
             from OrderInfo  a 
             join Commodity b on a.CommodityId=b.CommodityId 
             join Users c on a.UserId=c.UserId ";
            return DapperHelper.GetList<Model.OrderInfo>(sql);
        }

        public int Insert(Model.OrderInfo Model)
        {
            throw new NotImplementedException();
        }

        public List<Model.OrderInfo> Query()
        {
            throw new NotImplementedException();
        }
        public int Delete(string ids)
        {
            throw new NotImplementedException();
        }


    }
}
