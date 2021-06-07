using IOT.Core.IRepository.Specification;
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
    public class SpecificationController : ControllerBase
    {
        /// <summary>
        /// 注入
        /// </summary>
        private readonly ISpecificationRepository _specification;
        public SpecificationController(ISpecificationRepository specification)
        {
            _specification = specification;
        }

        /// <summary>
        /// 添加 or 修改
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        [HttpPost("/api/CreateSpecification")]
        public string CreateSpecification([FromForm]IOT.Core.Model.Specification specification)
        {
            return _specification.CreateSpecification(specification);
        }

        /// <summary>
        /// 删除规格
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet("/api/DeleteSpecification")]
        public int DeleteSpecification(string ids)
        {
            return _specification.DeleteSpecification(ids);
        }

        /// <summary>
        /// 获取规格通过规格id
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        [HttpGet("/api/GetSpecificationBySId")]
        public IActionResult GetSpecificationBySId(int sid)
        {
            return Ok(_specification.GetSpecificationBySId(sid));
        }

        /// <summary>
        /// 显示 查询所有规格
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("/api/GetSpecifications")]
        public IActionResult GetSpecifications(int page, int limit, string key = "")
        {
            //获取全部数据
            List<IOT.Core.Model.Specification> lst = _specification.GetSpecifications(key);
            //记录数
            int count = lst.Count;
            return Ok(new
            {
                msg = "",
                code = 0,
                count = count,
                data = lst.Skip((page - 1) * limit).Take(limit)
            });
        }
    }
}
