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
        public int BargainAdd(IOT.Core.Model.Bargain a)
        { 
            int i = _bargainRepository.AddBargain(a); 
            return i;
        }

        //显示砍价商品
        [Route("/api/BargainShows")]
        [HttpGet]
        public IActionResult BargainShows(string nm,int st)
        {
            //获取全部数据
            var ls = _bargainRepository.ShowBargain();
            if (!string.IsNullOrEmpty(nm))
            {
                ls = ls.Where(x => x.CommodityName.Contains(nm)).ToList();
            }
            ls = ls.Where(x => x.State.Equals(st)).ToList();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //显示砍价列表
        [Route("/api/ShowBargains")]
        [HttpGet]
        public IActionResult ShowBargains()
        {
            //获取全部数据
            var ls = _bargainRepository.BargainShow();
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
        [HttpDelete]
        public int BargainDel(string id)
        {
            return _bargainRepository.DelBargain(id);
        }


        //修改
        [HttpPost]
        [Route("/api/BargainUpt")]
        public int BargainUpt(IOT.Core.Model.Bargain a)
        {
            return _bargainRepository.UptBargain(a);
        }

        //修改状态
        [Route("/api/UpdateState")]
        [HttpGet]
        public int UptSt(int id)
        {
            return _bargainRepository.UptSt(id);
        }
    }
}
