using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class V_Com_Comment: Com_Comment
    {
        public int Days { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }
        public string CommodityName { get; set; }
        public string CommodityPic { get; set; }
        public string UserName { get; set; }
    }
}
