using IOT.Core.IRepository.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Security.Claims;

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
        Logger logger = NLog.LogManager.GetCurrentClassLogger();//实例化
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
       // [HttpGet("Get"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetLogin(string loginname, string loginpwd)
        {
            int i = _usersRepository.Login(loginname,loginpwd);
            StringBuilder builder = new StringBuilder();
            builder.Append("登录名："+loginname+"\n");
            builder.Append("时间：" + DateTime.Now + "\n");
            if (i>0)
            {
                builder.Append("登录成功");
            }
            else
            {
                builder.Append("登录失败");
            }
            logger.Debug(builder.ToString());

            return Ok(new { Token = BuildToken(loginname), Id = i }) ;
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

        public int UptUsers(Model.Users a)
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

        [HttpGet("GetToken")]
        public IActionResult GetToken()
        {
            return Ok(new { Token = BuildToken("admin") });
        }


        private string BuildToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Security:Tokens:Key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "Security:Tokens:Issuer",
                Audience = "Security:Tokens:Audience",
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userId) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
