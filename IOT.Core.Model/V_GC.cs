using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class V_GC: Colonel
    {
        public DateTime GroupBookingSdate { get; set; }
        public string CSTime { get { return GroupBookingSdate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public DateTime GroupBookingZdate { get; set; }
        public string GZTime { get { return GroupBookingZdate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public int GroupBookingNumber { get; set; }
        public int GroupBookingState { get; set; }
        public string  MyProperty { get; set; }
        public int GroupBookingID { get; set; }
        public int Group_State { get; set; }
        public int PeopleNum { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 商品图
        /// </summary>
        public string CommodityPic { get; set; }
        /// <summary>
        /// 商品售价
        /// </summary>
        public string ShopPrice { get; set; }

        public int State { get; set; }
        public decimal GroupBookingPrice { get; set; }
        public int Group_CommId { get; set; }
    }
}
