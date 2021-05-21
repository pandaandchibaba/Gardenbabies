using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Brokerage
{
   public interface IBrokerageRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.Brokerage> GetBrokerages();
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Updatestate(int id);

       
    }
}
