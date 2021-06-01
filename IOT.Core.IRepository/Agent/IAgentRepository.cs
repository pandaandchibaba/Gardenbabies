using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Agent
{
    public interface IAgentRepository
    {
        /// <summary>
        /// 添加 or 修改代理商
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        string CreateAgent(IOT.Core.Model.Agent agent);

        /// <summary>
        /// 删除代理商
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        int DeleteAgent(int aid);

        /// <summary>
        /// 分页显示代理商
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.Agent> GetAgents();

        /// <summary>
        /// 通过代理商id获取代理商
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        IOT.Core.Model.Agent GetAgentByAId(int aid);

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        int UpdateState(int aid);
    }
}
