using IOT.Core.IRepository.Group_Comm;
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
    public class Group_CommController : ControllerBase
    {
        private readonly IGroup_CommRepository  _group_CommRepository;

        public Group_CommController(IGroup_CommRepository group_CommRepository)
        {
            _group_CommRepository = group_CommRepository;
        }

        //添加
        [Route("/api/Group_CommAdd")]
        [HttpPost]
        public int Group_CommAdd(IOT.Core.Model.Group_Comm a)
        {
            int i = _group_CommRepository.AddGroup_Comm(a);
            return i;
        }

        //显示
        [Route("/api/Group_CommShow")]
        [HttpGet]
        public IActionResult Group_CommShow(int st = -1, string nm="")
        {
            //获取全部数据
            var ls = _group_CommRepository.ShowGroup_Comm();
            if (st != -1)
            {
                ls = ls.Where(x => x.Group_State.Equals(st)).ToList();
            }
            if (!string.IsNullOrEmpty(nm))
            {
                ls = ls.Where(x => x.NickName.Contains(nm)).ToList();
            }
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //反填
        [Route("/api/Group_CommFT")]
        [HttpGet]
        public IActionResult Group_CommFT(int id)
        {
            return Ok(_group_CommRepository.FT(id));
        }

        //删除
        [Route("/api/Group_CommDel")]
        [HttpGet]
        public int Group_CommDel(string id)
        {
            return _group_CommRepository.DelGroup_Comm(id);
        }

        //修改状态
        [Route("/api/UptGroup_CommSt")]
        [HttpGet]
        public int UptGroup_CommSt(int id)
        {
            return _group_CommRepository.UptSt(id);
        }
    }
}
