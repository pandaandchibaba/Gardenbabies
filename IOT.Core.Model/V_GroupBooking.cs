using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class V_GroupBooking: GroupBooking
    {
        
        public string CommodityPic { get; set; }
        public string Remark { get; set; }
        public int ShopNum { get; set; }
        public float MinPrice { get; set; }
        public string ShopPrice { get; set; }
        public int ActionState { get; set; }
        public string NickName { get; set; }
        public int Sex { get; set; }
        public string Phone { get; set; }
        public string ColonelName { get; set; }
        public string MemberNum { get; set; }
        public string PColonelId { get; set; }
        public string Region { get; set; }
        public string Estate { get; set; }
        public string Address { get; set; }
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
        public int Days { get; set; }
        public int months { get; set; }
        public int years { get; set; }
    }
}
