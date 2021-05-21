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


        //////////////////////////
        /// <summary>
        /// //商品表
        /// </summary>
        public string CommodityName { get; set; }
        public string CommodityPic { get; set; }
        public float ShopPrice { get; set; }
        public int SId { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string STime { get { return StartTime.ToString("yyyy-MM-dd HH:MM:ss"); } }

        //团长

        public int Sex { get; set; }

        public string ColonelName { get; set; }
        public string MemberNum { get; set; }
        public string PColonelId { get; set; }
        public string Region { get; set; }
        public string Estate { get; set; }

        public string Coordinates { get; set; }
        public DateTime RegisterTime { get; set; }
        public string RTime { get { return RegisterTime.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public int Integral { get; set; }
        public decimal Saleroom { get; set; }
        public int DeliveryStatus { get; set; }
        public decimal Cost { get; set; }
        public string Alipay { get; set; }
        public string BankSite { get; set; }
        public string CardName { get; set; }
        public string BankCard { get; set; }
        public string HeadPortrait { get; set; }
        public string CommIds { get; set; }
    }
}
