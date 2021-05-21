using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Store
{
    public interface IStoreRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.Store> GetStores();
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<IOT.Core.Model.Store> GetStoresFan(int id);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int InsertStore(Model.Store Model);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptStore(Model.Store Model);
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UptStoreState(int id);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        int DelStore(int ids);
    }
}
