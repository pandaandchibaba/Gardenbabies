using IOT.Core.IRepository.Agent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository _agent;
        public AgentController(IAgentRepository agent)
        {
            _agent = agent;
        }

        /// <summary>
        /// 添加 or 修改
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        [HttpPost("/api/CreateAgent")]
        public string CreateAgent(Model.Agent agent)
        {
            return _agent.CreateAgent(agent);
        }

        /// <summary>
        /// 删除代理商
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [HttpPost("/api/DeleteAgent")]
        public int DeleteAgent([FromForm] IOT.Core.Model.Agent agent)
        {
            return _agent.DeleteAgent(agent.AgentId);
        }

        /// <summary>
        /// 分页显示代理商
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="limit">页面大小</param>
        /// <returns></returns>
        [HttpGet("/api/GetAgents")]
        public IActionResult GetAgents(int page, int limit)
        {
            List<Model.Agent> lst = _agent.GetAgents();
            //总记录数
            int count = lst.Count;
            return Ok(new
            {
                code = 0,
                msg = "",
                count = count,
                data = lst.Skip((page - 1) * limit).Take(limit)
            });
        }

        /// <summary>
        /// 通过代理商id获取代理商
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [HttpGet("/api/GetAgentByAId")]
        public IActionResult GetAgentByAId(int aid)
        {
            return Ok(_agent.GetAgentByAId(aid));
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [HttpPost("/api/UpdateState")]
        public int UpdateState([FromForm] IOT.Core.Model.Agent agent)
        {
            return _agent.UpdateState(agent.AgentId);
        }
    }
}
