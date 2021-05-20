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

        public int GroupBookingID { get; set; }
        public int Group_State { get; set; }
        public int PeopleNum { get; set; }


    }
}
