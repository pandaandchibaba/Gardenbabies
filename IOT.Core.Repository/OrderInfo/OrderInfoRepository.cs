using IOT.Core.Common;
using IOT.Core.IRepository.OrderInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.OrderInfo
{
    public  class OrderInfoRepository : IOrderInfoRepository
    {


        /// <summary>
        /// 三表联查各种数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="state"></param>
        /// <param name="end"></param>
        /// <param name="tui"></param>
        /// <param name="dingt"></param>
        /// <param name="uid"></param>
        /// <param name="cname"></param>
        /// <param name="ziti"></param>
        /// <returns></returns>
        public List<Model.OrderInfo> GetOrderInfos(string name, string state, string end, int tui, int dingt, int uid, string cname, string ziti)
        {
            string sql = $@"select b.CommodityName ,b.CommodityPic ,b.ShopPrice  ,b.SId ,
             c.NickName ,c.UserName ,c.Phone ,c.Address ,
			 a.SendWay ,a.CommodityPrice ,a.DistributionCosts ,a.OrderPrice ,a.CouponPrice ,a.AmountPaid ,a.StartTime ,a.remark,a.Orderid,a.CommodityId,a.UserId,a.OrderState
            from OrderInfo a
            join Commodity b on a.CommodityId = b.CommodityId
            join Users c on a.UserId = c.UserId 
            join Colonel d on c.ColonelID=d.ColonelID";
            return DapperHelper.GetList<Model.OrderInfo>(sql);
        }

        public int Delete(string ids)
        {
            string sql = $@"delete from OrderInfo where Orderid={ids}";
            return DapperHelper.Execute(sql);
        }

       

        public int Insert(Model.OrderInfo Model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询订单表
        /// </summary>
        /// <returns></returns>
        public List<Model.OrderInfo> Query()
        {
            string sql = $@"select* from OrderInfo";
            return DapperHelper.GetList<Model.OrderInfo>(sql);
        }

        public int UptRemark(Model.OrderInfo Model)
        {
            string sql = $"UPDATE OrderInfo SET Remark='{Model.Remark}' where Orderid={Model.Orderid}";
            return DapperHelper.Execute(sql);
        }

        public int UptSendWay(Model.OrderInfo Model)
        {
            string sql = $"UPDATE OrderInfo SET SendWay='{Model.SendWay}' where Orderid={Model.Orderid}";
            return DapperHelper.Execute(sql);
        }

        public int UptOrderState(Model.OrderInfo Model)
        {
            string sql = $"UPDATE OrderInfo SET OrderState='{Model.OrderState}' where Orderid={Model.Orderid}";
            return DapperHelper.Execute(sql);
        }


    }
}
