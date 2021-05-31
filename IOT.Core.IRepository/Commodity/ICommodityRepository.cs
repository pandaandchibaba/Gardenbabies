using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Commodity
{
    public interface ICommodityRepository
    {
        /// <summary>
        /// 获取商品
        /// </summary>
        /// <param name="code">怎样显示 1、出售中，2、仓库中，3、已出售，4、回收站</param>
        /// <param name="tid">类别</param>
        /// <param name="key">查询关键词</param>
        /// <returns></returns>
        List<IOT.Core.Model.V_Commodity> GetCommodities(int code=1,int tid=0,string key="");
        
        /// <summary>
        /// 修改删除状态
        /// </summary>
        /// <param name="CId"></param>
        /// <returns></returns>
        int UpdateDeleteState(int CId);

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="CId"></param>
        /// <returns></returns>
        int UpdateState(int CId);

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        int CreateCommodity(IOT.Core.Model.Commodity commodity);

        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.Commodity> GetAllCommodities();
    }
}
