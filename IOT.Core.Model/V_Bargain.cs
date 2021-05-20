using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class V_Bargain:Users
    {
        public int BargainId { get; set; }
        public string CommodityPic { get; set; }
        public string CommodityName { get; set; }
        public float ShopPrice { get; set; }
        public int KNum { get; set; }
        public int SurplusBargain { get; set; }
        public DateTime BeginDate { get; set; }
        public string BTime { get { return BeginDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public DateTime EndDate { get; set; }
        public string ETime { get { return EndDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
    }
}
