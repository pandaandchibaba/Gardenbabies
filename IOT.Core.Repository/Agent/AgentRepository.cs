using IOT.Core.Common;
using IOT.Core.IRepository.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Agent
{
    public class AgentRepository : IAgentRepository
    {
        /// <summary>
        /// 添加 or 修改代理商
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public string CreateAgent(Model.Agent agent)
        {
            //添加
            if (agent.AgentId==0)
            {
                try
                {
                    //添加的SQL语句
                    string sql = $"insert into Agent values(null,'{agent.AgentName}','{agent.BackgroudColor}','{agent.Icon}','{agent.BCImg}','{agent.Fans}',{agent.Consume},{agent.Money},'{agent.NFans}',{agent.Two},{agent.Three},{agent.One},'{agent.Explaina}',{agent.AgentState})";
                    int i = DapperHelper.Execute(sql);
                    if (i > 0)
                    {
                        return "添加成功";
                    }
                    else
                    {
                        return "添加失败";
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else  //修改
            {
                try
                {
                    //修改SQL语句
                    string sql = $"update Agent set AgentName='{agent.AgentName}',BackgroudColor='{agent.BackgroudColor}',Icon='{agent.Icon}',BCImg='{agent.BCImg}',Fans='{agent.Fans}',Consume={agent.Consume},Money={agent.Money},NFans='{agent.NFans}',Two={agent.Two},Three={agent.Three},One={agent.One},Explaina='{agent.Explaina}',AgentState={agent.AgentState} where AgentId={agent.AgentId}";
                    int i = DapperHelper.Execute(sql);
                    if (i > 0)
                    {
                        return "修改成功";
                    }
                    else
                    {
                        return "修改失败";
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// 删除代理商
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public int DeleteAgent(string aid)
        {
            string sql = $"delete from Agent where AgentId ={aid}";
            return DapperHelper.Execute(sql);
        }

        /// <summary>
        /// 通过代理商id获取代理商
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public Model.Agent GetAgentByAId(int aid)
        {
            return DapperHelper.GetList<IOT.Core.Model.Agent>($"select * from Agent where AgentId={aid}").FirstOrDefault();
        }

        /// <summary>
        /// 分页 显示代理商
        /// </summary>
        /// <returns></returns>
        public List<Model.Agent> GetAgents()
        {
            return DapperHelper.GetList<IOT.Core.Model.Agent>("select * from Agent");
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public int UpdateState(int aid)
        {
            try
            {
                Model.Agent agent = DapperHelper.GetList<IOT.Core.Model.Agent>($"select * from Agent where AgentId={aid}").FirstOrDefault();
                if (agent.AgentState == 1)
                {
                    agent.AgentState = 0;
                }
                else
                {
                    agent.AgentState = 1;
                }
                string sql = $"update Agent set AgentState={agent.AgentState} where AgentId={agent.AgentId} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
