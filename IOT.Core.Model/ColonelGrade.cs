using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 团长等级
    /// </summary>
    public class ColonelGrade
    {
        public int CGId            { get; set; }
        public string CGradeName      { get; set; }
        public string GradeExperience { get; set; }
        public decimal FirstPY         { get; set; }
        public DateTime AwardRatio      { get; set; }
        public string ATime { get { return AwardRatio.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public int GradeStatus     { get; set; }
    }
}
