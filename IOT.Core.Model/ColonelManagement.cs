using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 团长管理
    /// </summary>
    public class ColonelManagement
    {
        public int CMId         { get; set; }
        public int ColonelID    { get; set; }
        public string CheckName    { get; set; }
        public string CityName { get; set; }
        public DateTime AapplyTime   { get; set; }
        public string ATime { get { return AapplyTime.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public DateTime CheckTime    { get; set; }
        public string CTime { get { return CheckTime.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public int CheckStatus  { get; set; }





        ////////////////
        public string HeadPortrait { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal Cost { get; set; }

    }
}
