using System;

namespace IOT.Core.Model
{
    /// <summary>
    /// 活动表
    /// </summary>
    public class Activity
    {
        public int ActivityId   { get; set; }
        public string ActivityName { get; set; }
        public DateTime BeginTime    { get; set; }
        public string BTime { get { return BeginTime.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public DateTime EndTime      { get; set; }
        public string ETime { get { return EndTime.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public string Slideshow    { get; set; }
        public int State        { get; set; }
        public DateTime  CreateDate   { get; set; }
        public string Date { get { return CreateDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public int ActivityTime { get; set; }
    }
}
