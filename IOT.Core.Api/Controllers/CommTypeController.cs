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
        [HttpGet("/api/GetOneType")]
        public IActionResult GetOneType()
        {
            return Ok(_commType.GetOneType());
        }

        /// <summary>
        /// 添加 or 修改
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        [HttpPost("/api/CreateType")]
        public string CreateType([FromForm]IOT.Core.Model.CommType comm)
        {
            return _commType.CreateType(comm);
        }

        /// <summary>
        /// 显示所有分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/GetCommTypes")]
        public IActionResult GetCommTypes(string st="",string key="")
        {
            return Ok(_commType.GetCommTypes(st,key));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpGet("/api/DeleteType")]
        public int DeleteType(int tid)
        {
            return _commType.DeleteType(tid);
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpGet("/api/UpdateTypeState")]
        public int UpdateState(int tid)
        {
            return _commType.UpdateState(tid);
        }

        /// <summary>
        /// 通过类别id获取类别
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        [HttpGet("/api/GetCommTypeByTid")]
        public IActionResult GetCommTypeByTid(int tid)
        {
            IOT.Core.Model.V_CommType comm = _commType.GetCommTypeByTid(tid);
            return Ok(comm);
        }

        /// <summary>
        /// 绑定类别下拉
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet("/api/BindType")]
        public IActionResult BindType()
        {
            return Ok(_commType.BindType());
        }
    }
}
