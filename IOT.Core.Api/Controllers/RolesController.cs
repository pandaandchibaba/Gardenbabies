using IOT.Core.IRepository.Roles;
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
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [Route("/Api/RolesShow")]
        [HttpGet]
        public IActionResult RolesShow()
        {
            var ls = _rolesRepository.GetRoles();
            return Ok(new { data = ls });
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [Route("/Api/Addshow")]
        [HttpPost]
        public int  Addshow(Model.Roles a)
        {
           int  i = _rolesRepository.AddRoles(a);
            return i;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("/Api/deleteshow")]
        [HttpPost]
        public int deleteshow(string id)
        {
            return _rolesRepository.DeleteRoles(id);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [Route("/Api/EditRoles")]
        [HttpPost]
        public int EditRoles(Model.Roles a)
        {
            return _rolesRepository.UptRoles(a);
        }
        [Route("/Api/FTRoles")]
        [HttpGet]
        public IActionResult FTRoles(int id)
        {
            return Ok(_rolesRepository.FT(id));
        }

    }
}
