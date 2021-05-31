using IOT.Core.IRepository.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// 员工管理
/// </summary>
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository  _usersRepository;

        public UsersController(IUsersRepository  usersRepository)
        {
            _usersRepository = usersRepository;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginname"></param>
        /// <param name="loginpwd"></param>
        /// <returns></returns>
        [Route("/api/GetLogin")]
        [HttpGet]
        public int GetLogin(string loginname, string loginpwd)
        {
            int i = _usersRepository.Login(loginname,loginpwd);
            return i;
        }


        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>

        [Route("/api/GetUsers")]
        [HttpGet]
        public IActionResult GetUsers(string name="",int pageindex=1,int pagesize=2)
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
        [Route("/api/InsertUsers")]

        public int InsertUsers(Model.Users Model)
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
        [Route("/api/UptUsers")]

        public int UptUsers(Model.Users Model)
        {
            int i = _usersRepository.UptUsers(Model);
            return i;
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptUsersState")]

        public int UptUsersState(int id)
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
        [Route("/api/DelUsers")]

        public int DelUsers(int ids)
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
        [Route("/api/GetUsersFan")]
        
        public IActionResult GetUsersFan(int id)
        {
            var list = _usersRepository.GetUsersFan(id);
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }
    }
}
