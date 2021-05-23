using IOT.Core.IRepository.Activity;
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
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        //添加
        [Route("/api/ActivityAdd")]
        [HttpPost]
        public int ActivityAdd(IOT.Core.Model.Activity a)
        {
            int i = _activityRepository.AddActivity(a);
            return i;
        }

        //显示
        [Route("/api/ActivityShow")]
        [HttpGet]
        public IActionResult ActivityShow(string nm = "", int st = -1)
        {
            //获取全部数据
            var ls = _activityRepository.ShowActivity();
            if (!string.IsNullOrEmpty(nm))
            {
                ls = ls.Where(x => x.ActivityName.Contains(nm)).ToList();
            }
            if (st!=-1)
            {
                ls = ls.Where(x => x.State.Equals(st)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = ls
            });
        }

        //删除
        [Route("/api/ActivityDel")]
        [HttpDelete]
        public int ActivityDel(string id)
        {
            return _activityRepository.DelActivity(id);
        }


        //修改
        [HttpPost]
        [Route("/api/ActivityUpt")]
        public int ActivityUpt(IOT.Core.Model.Activity a)
        {
            return _activityRepository.UptActivity(a);
        }

        //修改状态
        [HttpPost]
        [Route("/api/ActivityUptst")]
        public int ActivityUptst(int id)
        {
            return _activityRepository.Uptst(id);
        }
    }
}
