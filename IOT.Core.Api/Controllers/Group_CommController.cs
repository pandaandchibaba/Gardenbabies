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
        [Route("/Group_Comm/Group_CommAdd")]
        [HttpPost]
        public int Group_CommAdd(IOT.Core.Model.Group_Comm a)
        {
            int i = _group_CommRepository.AddGroup_Comm(a);
            return i;
        }

        //显示
        [Route("/Group_Comm/Group_CommShow")]
        [HttpGet]
        public IActionResult Group_CommShow(int st=0)
        {
            //获取全部数据
            var ls = _group_CommRepository.ShowGroup_Comm();

            ls = ls.Where(x => x.Group_State.Equals(st)).ToList();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //反填
        [Route("/Group_Comm/FT")]
        [HttpGet]
        public IActionResult FT(int id)
        {
            return Ok(_group_CommRepository.FT(id));
        }

        //删除
        [Route("/Group_Comm/BargainDel")]
        [HttpDelete]
        public int Group_CommDel(string id)
        {
            return _group_CommRepository.DelGroup_Comm(id);
        }

        //修改状态
        [Route("/Group_Comm/UptSt")]
        [HttpGet]
        public int UptSt(int id)
        {
            return _group_CommRepository.UptSt(id);
        }
    }
}
