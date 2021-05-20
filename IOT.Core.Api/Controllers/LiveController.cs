using IOT.Core.IRepository.Live;
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
    public class LiveController : ControllerBase
    {
        private readonly ILiveRepository _liveRepository;

        public LiveController(ILiveRepository liveRepository)
        {
            _liveRepository = liveRepository;
        }

        //添加
        [Route("/api/LiveAdd")]
        [HttpPost]
        public int LiveAdd(IOT.Core.Model.Live a)
        {
            int i = _liveRepository.AddLive(a);
            return i;
        }

        //显示
        [Route("/api/LiveShow")]
        [HttpGet]
        public IActionResult LiveShow(int st, string nm)
        {
            //获取全部数据
            var ls = _liveRepository.ShowLive();
            if (!string.IsNullOrEmpty(nm))
            {
                ls = ls.Where(x => x.LiveId.Equals(nm)).ToList();
            }
            ls = ls.Where(x => x.IsEnable.Equals(st)).ToList();
            return Ok(new { msg = "", code = 0, data = ls });
        }


        //删除
        [Route("/api/LiveDel")]
        [HttpDelete]
        public int LiveDel(string id)
        {
            return _liveRepository.DelLive(id);
        }


        //修改
        [HttpPost]
        [Route("/api/LiveUpt")]
        public int LiveUpt(IOT.Core.Model.Live a)
        {
            return _liveRepository.UptLive(a);
        }
    }
}
