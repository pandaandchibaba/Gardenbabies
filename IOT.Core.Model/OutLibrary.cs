﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 出库
    /// </summary>
    public class OutLibrary
    {
        public int PutLibraryId { get; set; }
        public int WarehouseId  { get; set; }
        public int CommodityId  { get; set; }
        public int GoodNum      { get; set; }
        public DateTime OutDate      { get; set; }
        public string OTime { get { return OutDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public string OutNO        { get; set; }
    }
}
