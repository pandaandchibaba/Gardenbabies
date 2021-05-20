using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 砍价表
    /// </summary>
    public class Bargain
    {
        public int BargainId      { get; set; }
        public int UserId { get; set; }
        public int CommodityId    { get; set; }
        public int PeopleNum      { get; set; }
        public int KNum           { get; set; }
        public DateTime BeginDate      { get; set; }
        public string BTime { get { return BeginDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public DateTime EndDate        { get; set; }
        public string ETime { get { return EndDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public int Astrict        { get; set; }
        public int ActionState    { get; set; }
        public int PartNum        { get; set; }
        public float MinPrice       { get; set; }
        public int SurplusNum     { get; set; }
        public int SurplusBargain { get; set; }
        public string BargainName    { get; set; }
        public string BargainRemark  { get; set; }
        public int Template       { get; set; }
        public int LimitNum       { get; set; }
        public float BargainSum     { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 商品图
        /// </summary>
        public string CommodityPic { get; set; }
        /// <summary>
        /// 商品售价
        /// </summary>
        public string ShopPrice { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public int ShopNum { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int Repertory { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime OperationDate { get; set; }
        public string OTime { get { return OperationDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        /// <summary>
        /// 商品类别
        /// </summary>
        public int TId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 模板
        /// </summary>
        public int TemplateId { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string CommodityKey { get; set; }
        /// <summary>
        /// 配送地址
        /// </summary>
        public string SendAddress { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public int SId { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 删除状态
        /// </summary>
        public int DeleteState { get; set; }
        /// <summary>
        /// 是否出售
        /// </summary>
        public int IsSell { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public float CostPrice { get; set; }
        /// <summary>
        /// 团长id
        /// </summary>
        public int ColonelID { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public int Mid { get; set; }
    }
}
