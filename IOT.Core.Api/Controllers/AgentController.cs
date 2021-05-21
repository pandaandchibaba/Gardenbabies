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
        [HttpPost("/Agent/CreateAgent")]
        public string CreateAgent(Model.Agent agent)
        {
            return _agent.CreateAgent(agent);
        }

        /// <summary>
        /// 删除代理商
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [HttpPost("/Agent/DeleteAgent")]
        public int DeleteAgent([FromForm]string aid)
        {
            return _agent.DeleteAgent(aid);
        }

        /// <summary>
        /// 分页显示代理商
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet("/Agent/GetAgents")]
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
        [HttpGet("/Agent/GetAgentByAId")]
        public IActionResult GetAgentByAId(int aid)
        {
            return Ok(_agent.GetAgentByAId(aid));
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        [HttpPost("/Agent/UpdateState")]
        public int UpdateState([FromForm] int aid)
        {
            return _agent.UpdateState(aid);
        }
    }
}
