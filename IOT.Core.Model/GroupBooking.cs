﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 拼团
    /// </summary>
    public class GroupBooking
    {
        public int GroupBookingID           { get; set; }
        public int ColonelID                { get; set; }
        public int CommodityId              { get; set; }
        public string GroupBookingName         { get; set; }
        public string GroupBookingRemark       { get; set; }
        public string GroupBookingUnit         { get; set; }
        public DateTime GroupBookingSdate        { get; set; }
        public string CSTime { get { return GroupBookingSdate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public DateTime GroupBookingZdate        { get; set; }
        public string GZTime { get { return GroupBookingZdate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public int GroupBookingResults      { get; set; }
        public int GroupBookingNumber       { get; set; }
        public int GroupBookingSellLimitNum { get; set; }
        public int GroupBookingSort         { get; set; }
        public int GroupBookingTemplate     { get; set; }
        public int GroupBookingState        { get; set; }
        public decimal GroupBookingPrice        { get; set; }
        public int GroupBookingLimitNum { get; set; }
    }
}
