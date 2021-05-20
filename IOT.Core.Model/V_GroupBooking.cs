using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class V_GroupBooking
    {
        public int GroupBookingID { get; set; }
        public string NickName { get; set; }
        public int CommodityId { get; set; }
        public string CommodityPic { get; set; }
        public string Remark { get; set; }
        public int ShopNum { get; set; }
        public decimal GroupBookingPrice { get; set; }
        public int GroupBookingResults { get; set; }
        public int GroupBookingNumber { get; set; }
        public DateTime GroupBookingZdate { get; set; }
        public string GZdTime{ get { return GroupBookingZdate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public int GroupBookingState { get; set; }
    }
}
