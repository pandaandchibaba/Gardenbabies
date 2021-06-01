using IOT.Core.IRepository.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// /客服管理
/// </summary>
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseresController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UseresController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [Route("/api/GetUseres")]
        [HttpGet]
        public IActionResult GetUseres(string name = "", int pageindex = 1, int pagesize = 2)
        {
            var list = _usersRepository.GetUsers(name);
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list.Skip((pageindex - 1) * pagesize).Take(pagesize)
            });
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/InsertUseres")]

        public int InsertUseres(Model.Users Model)
        {
            int i = _usersRepository.InsertUsers(Model);
            return i;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptUseres")]

        public int UptUseres(Model.Users a)
        {
            int i = _usersRepository.UptUsers(a);
            return i;
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptUsersStates")]

        public int UptUsersStates(int id)
        {
            int i = _usersRepository.UptUsersState(id);
            return i;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/DelUseres")]

        public int DelUseres(int ids)
        {
            int i = _usersRepository.DelUsers(ids);
            return i;
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetUsersFans")]

        public IActionResult GetUsersFans(int id)
        {
            var list = _usersRepository.GetUsersFan(id);
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_usersRepository.GetAllUsers());
        }
    }
}
