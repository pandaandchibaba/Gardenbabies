using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 规格表
    /// </summary>
    public class Specification
    {
        /// <summary>
        /// 规格id
        /// </summary>
        public int SId { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecificationName { get; set; }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string CommSpec { get; set; }
        /// <summary>
        /// 商品属性
        /// </summary>
        public string CommProp { get; set; }
        /// <summary>
        /// 规格值
        /// </summary>
        public int SpecificationValue { get; set; }
    }
}
