using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Path
{
   public interface IPathRepository
    {/// <summary>
    /// 显示
    /// </summary>
    /// <returns></returns>
        List<IOT.Core.Model.Path> GthXS();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int Add(IOT.Core.Model.Path a);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int delete(string id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int Edit(IOT.Core.Model.Path a);
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        int Update(int cid);


    }
}
