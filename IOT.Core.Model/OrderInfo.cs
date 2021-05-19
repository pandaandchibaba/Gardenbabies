using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class OrderInfo
    {
        public int Orderid           { get; set; }
        public int CommodityId       { get; set; }
        public int UserId            { get; set; }
        public int SendWay           { get; set; }
        public int OrderState        { get; set; }
        public string Remark            { get; set; }
        public float CommodityPrice    { get; set; }
        public float DistributionCosts { get; set; }
        public float OrderPrice        { get; set; }
        public float CouponPrice       { get; set; }
        public float AmountPaid        { get; set; }
        public DateTime StartTime         { get; set; }



        /////////////////////////////////////////////
        public string CommodityName { get; set; }
        public string CommodityPic { get; set; }
        public float ShopPrice { get; set; }
        public int SId { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
