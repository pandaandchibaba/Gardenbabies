using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class V_SeckillCom: SeckillCom
    {
        public string nickName { get; set; }
        public string CommodityName { get; set; }
        public string CommodityPic { get; set; }
        public string ActivityName { get; set; }
        public string Remark { get; set; }
        public DateTime BeginTime { get; set; }
        public string BeTime { get { return BeginTime.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public DateTime EndTime { get; set; }
        public string ENTime { get { return EndTime.ToString("yyyy-MM-dd HH:MM:ss"); } }

    }
}
