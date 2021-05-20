using IOT.Core.IRepository.CommType;
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
    public class CommTypeController : ControllerBase
    {
        /// <summary>
        /// 注入
        /// </summary>
        private readonly ICommTypeRepository _commType;
        public CommTypeController(ICommTypeRepository commType)
        {
            _commType = commType;
        }

        /// <summary>
        /// 获取所有一级分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("/CommType/GetOneType")]
        public IActionResult GetOneType()
        {
            return Ok(_commType.GetOneType());
        }

        /// <summary>
        /// 添加 or 修改
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        [HttpPost("/CommType/CreateType")]
        public string CreateType(IOT.Core.Model.CommType comm)
        {
            return _commType.CreateType(comm);
        }

        /// <summary>
        /// 显示所有分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("/CommType/GetCommodities")]
        public IActionResult GetCommodities()
        {
            return Ok(_commType.GetCommodities());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpPost("/CommType/DeleteType")]
        public int DeleteType([FromForm]int tid)
        {
            return _commType.DeleteType(tid);
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpPost("/CommType/UpdateState")]
        public int UpdateState([FromForm]int tid)
        {
            return _commType.UpdateState(tid);
        }

        /// <summary>
        /// 通过类别id获取类别
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpGet("/CommType/GetCommTypeByTid")]
        public IActionResult GetCommTypeByTid(int tid)
        {
            return Ok(_commType.GetCommTypeByTid(tid));
        }

        /// <summary>
        /// 绑定类别下拉
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet("/CommType/BindType")]
        public IActionResult BindType(int pid=0)
        {
            return Ok(_commType.BindType(pid));
        }
    }
}
