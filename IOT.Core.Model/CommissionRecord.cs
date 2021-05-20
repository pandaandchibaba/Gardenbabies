﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 会员佣金
    /// </summary>
    public class CommissionRecord
    {
        public int CommissionRecordId { get; set; }
        public int SId                { get; set; }
        public float Money              { get; set; }
        public DateTime CreateDate { get; set; }
        public string CTime { get { return CreateDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
    }
}
