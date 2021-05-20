﻿using IOT.Core.IRepository.SeckillCom;
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
    public class SeckillComController : ControllerBase
    {
        private readonly ISeckillComRepository _seckillComRepository;

        public SeckillComController(ISeckillComRepository seckillComRepository)
        {
            _seckillComRepository = seckillComRepository;
        }

        //添加
        [Route("/api/SeckillComAdd")]
        [HttpPost]
        public int SeckillComAdd(IOT.Core.Model.SeckillCom a)
        {
            int i = _seckillComRepository.AddSeckillCom(a);
            return i;
        }

        //显示
        [Route("/api/SeckillComShow")]
        [HttpGet]
        public IActionResult SeckillComShow(string nmid, int st)
        {
            var ls = _seckillComRepository.ShowSeckillCom();
            //根据姓名id查询
            if (!string.IsNullOrEmpty(nmid))
            {
                ls = ls.Where(x => x.CommodityId.Equals(nmid) || x.SeckillTitle.Contains(nmid)).ToList();
            }
            //根据状态查询
            ls = ls.Where(x => x.State.Equals(st)).ToList();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = ls
            });
        }


        //删除
        [Route("/api/SeckillComDel")]
        [HttpDelete]
        public int SeckillComDel(string id)
        {
            return _seckillComRepository.DelSeckillCom(id);
        }


        //修改
        [HttpPost]
        [Route("/api/SeckillComUpt")]
        public int SeckillComUpt(IOT.Core.Model.SeckillCom a)
        {
            return _seckillComRepository.UptSeckillCom(a);
        }
    }
}
