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
        public int LiveAdd([FromForm]IOT.Core.Model.Live a)
        {
            int i = _liveRepository.AddLive(a);
            return i;
        }

        //显示
        [Route("/api/LiveShow")]
        [HttpGet]
        public IActionResult LiveShow(int st=-1, string nm="")
        {
            //获取全部数据
            var ls = _liveRepository.ShowLive();
            if (!string.IsNullOrEmpty(nm))
            {
                ls = ls.Where(x => x.LiveId.Equals(nm) || x.AnchorName.Contains(nm)).ToList();
            }
            if (st != -1)
            {
                ls = ls.Where(x => x.IsEnable.Equals(st)).ToList();
            }
           
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //反填
        [Route("/api/LiveFT")]
        [HttpGet]
        public IActionResult LiveFT(int id)
        {
            return Ok(_liveRepository.FT(id));
        }

        //删除
        [Route("/api/LiveDel")]
        [HttpGet]
        public int LiveDel(int id)
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

        //修改状态
        [HttpGet]
        [Route("/api/LiveUptst")]
        public int LiveUptst(int id)
        {
            return _liveRepository.UptSt(id);
        }
    }
}
