using IOT.Core.IRepository.Path;
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
    public class pathController : ControllerBase
    {
        private readonly IPathRepository _pathRepository;
        public pathController(IPathRepository pathRepository)
        {
            _pathRepository = pathRepository;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>

        [Route("/Api/TOShow")]
        [HttpGet]
        public IActionResult TOShow(int page,int limit)
        {
            var ls = _pathRepository.GthXS();
            ls = ls.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new {code=0,msg="",count=ls.Count, data = ls });
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [Route("/Api/AddData")]
        [HttpPost]
        public int AddData(IOT.Core.Model.Path a)
        {
            int i = _pathRepository.Add(a);
            return i;
        }/// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("/Api/Delete")]
        [HttpDelete]
        public int Delete(string id)
        {
            int i = _pathRepository.delete(id);
            return i;
        }
        [Route("/Api/Upts")]
        [HttpPost]
        public int Upts(IOT.Core.Model.Path a)
        {
            int i = _pathRepository.Edit(a);
            return i;
        }
        [Route("/api/Uptdates")]
        [HttpPost]
        public int Uptdates(int id)
        {
            return _pathRepository.Update(id);
        }

        [Route("/api/FTES")]
        [HttpGet]
        public IActionResult FTES(int id)
        {
            return Ok(_pathRepository.Ft(id));
        }


    }
}
