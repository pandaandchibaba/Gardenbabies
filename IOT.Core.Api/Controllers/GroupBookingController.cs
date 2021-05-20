using IOT.Core.IRepository.GroupBooking;
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
    public class GroupBookingController : ControllerBase
    {
        private readonly IGroupBookingRepository _groupBookingRepository;

        public GroupBookingController(IGroupBookingRepository groupBookingRepository)
        {
            _groupBookingRepository = groupBookingRepository;
        }

        //添加
        [Route("/api/GroupBookingAdd")]
        [HttpPost]
        public int GroupBookingAdd(IOT.Core.Model.GroupBooking a)
        {
            int i = _groupBookingRepository.AddGroupBooking(a);
            return i;
        }

        //显示
        [Route("/api/GroupBookingShow")]
        [HttpGet]
        public IActionResult GroupBookingShow(int st=0, string nm="")
        {
            //获取全部数据
            var ls = _groupBookingRepository.ShowGroupBooking();
            if (!string.IsNullOrEmpty(nm))
            {
                ls = ls.Where(x => x.GroupBookingName.Contains(nm)).ToList();
            }
            ls = ls.Where(x => x.GroupBookingState.Equals(st)).ToList();
            return Ok(new { msg = "", code = 0, data = ls });
        }


        //删除
        [Route("/api/GroupBookingDel")]
        [HttpDelete]
        public int LiveDel(string id)
        {
            return _groupBookingRepository.DelGroupBooking(id);
        }


        //修改
        [HttpPost]
        [Route("/api/GroupBookingUpt")]
        public int GroupBookingUpt(IOT.Core.Model.GroupBooking a)
        {
            return _groupBookingRepository.UptGroupBooking(a);
        }
        //修改状态
        [Route("/api/UptSt")]
        [HttpGet]
        public int UptSt(int id)
        {
            return _groupBookingRepository.UptSt(id);
        }
    }
}
