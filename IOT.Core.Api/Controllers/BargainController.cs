using IOT.Core.IRepository.Bargain;
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
    public class BargainController : ControllerBase
    {
        private readonly IBargainRepository _bargainRepository;

        public BargainController(IBargainRepository bargainRepository)
        {
            _bargainRepository = bargainRepository;
        }

        //添加
        [Route("/api/BargainAdd")]
        [HttpPost]
        public int BargainAdd([FromForm]IOT.Core.Model.Bargain a)
        {
            int i = _bargainRepository.AddBargain(a);
            return i;
        }

        //显示砍价商品
        [Route("/api/BargainShows")]
        [HttpGet]
        public IActionResult BargainShows(string nm = "", int st = -1)
        {
            //获取全部数据
            var ls = _bargainRepository.ShowBargain();
            if (!string.IsNullOrEmpty(nm))
            {
                ls = ls.Where(x => x.BargainName.Contains(nm)).ToList();
            }
            if (st != -1)
            {
                ls = ls.Where(x => x.State.Equals(st)).ToList();
            }
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //显示砍价列表
        [Route("/api/ShowBargains")]
        [HttpGet]
        public IActionResult ShowBargains(string nmid="", int st=-1,int days=0)
        {
            //获取全部数据
            var ls = _bargainRepository.BargainShow(days);
            if (!string.IsNullOrEmpty(nmid))
            {
                ls = ls.Where(x => x.CommodityName.Contains(nmid) || x.BargainId.Equals(nmid)).ToList();
            }
            if (st != -1)
            {
                ls = ls.Where(x => x.ActionState.Equals(st)).ToList();
            }
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //反填
        [Route("/api/FT")]
        [HttpGet]
        public IActionResult FT(int id)
        {
            return Ok(_bargainRepository.FT(id));
        }

        //删除
        [Route("/api/BargainDel")]
        [HttpGet]
        public int BargainDel(string id)
        {
            return _bargainRepository.DelBargain(id);
        }


        //修改
        [HttpPost]
        [Route("/api/BargainUpt")]
        public int BargainUpt([FromForm]IOT.Core.Model.Bargain a)
        {
            return _bargainRepository.UptBargain(a);
        }

        //修改状态
        [Route("/api/UpdateBargainState")]
        [HttpGet]
        public int UpdateBargainState(int id)
        {
            return _bargainRepository.UptSt(id);
        }
    }
}
