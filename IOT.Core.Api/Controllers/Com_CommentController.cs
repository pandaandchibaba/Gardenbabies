using IOT.Core.IRepository.Com_Comment;
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
    public class Com_CommentController : ControllerBase
    {
        /// <summary>
        /// 注入
        /// </summary>
        private readonly ICom_CommentRepository _com_Comment;
        public Com_CommentController(ICom_CommentRepository com_Comment)
        {
            _com_Comment = com_Comment;
        }

        /// <summary>
        /// 查询 显示评论
        /// </summary>
        /// <param name="cname"></param>
        /// <param name="uname"></param>
        /// <returns></returns>
        [HttpGet("/api/GetComments")]
        public IActionResult GetComments(int page, int limit,int days=0,string st="", string cname = "", string uname = "")
        {
            //获取全部数据
            List<IOT.Core.Model.V_Com_Comment> lst = _com_Comment.GetComments(days, st, cname, uname);
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
        /// 添加评论
        /// </summary>
        /// <param name="com_Comment"></param>
        /// <returns></returns>
        [HttpPost("/api/CreateCom_Comment")]
        public string CreateCom_Comment(IOT.Core.Model.Com_Comment com_Comment)
        {
            return _com_Comment.CreateCom_Comment(com_Comment);
        }

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        [HttpPost("/api/DeleteCom_Comment")]
        public int DeleteCom_Comment([FromForm] int cid)
        {
            return _com_Comment.DeleteCom_Comment(cid);
        }

        /// <summary>
        /// 回复评论
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        [HttpPost("/api/ReplyComment")]
        public int ReplyComment([FromForm]IOT.Core.Model.Com_Comment com)
        {
            return _com_Comment.ReplyComment(com);
        }
    }
}
