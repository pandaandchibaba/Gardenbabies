﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 订单评论
    /// </summary>
    public class OrderComment
    {
        public int Commentid     { get; set; }
        public int State         { get; set; }
        public int Com_CommentId { get; set; }



        ///////////////////////////////////
        ///

        public int CommodityId       { get; set; }
        public int UserId            { get; set; }
        public int CommGrade         { get; set; }
        public int SeverGrade        { get; set; }
        public string CommentContent    { get; set; }
        public string RevertContent     { get; set; }
        public string CommentPic        { get; set; }
        public string CommentTime       { get; set; }

    }
}
