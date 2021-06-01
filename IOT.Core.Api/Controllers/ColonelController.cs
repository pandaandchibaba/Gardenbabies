using IOT.Core.IRepository.Colonel;
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
    public class ColonelController : ControllerBase
    {

        private readonly IColonelRepository _colonelRepository;
        public ColonelController(IColonelRepository colonelRepository)
        {
            _colonelRepository = colonelRepository;
        }



        //显示
        [Route("/api/colonel")]
        [HttpGet]
        public IActionResult colonel(string nickname = "")
        {
            var ls = _colonelRepository.ShowColonel();
            if (!string.IsNullOrEmpty(nickname))
            {
                ls = ls.Where(x => x.NickName.Contains(nickname)).ToList();
            }
            
            return Ok(new {data = ls });
        }

        /// <summary>
        /// 显示查询
        /// </summary>
        /// <param name="address"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("/api/GetColonel")]
        public IActionResult GetColonel(string address="",string key="")
        {
            return Ok(_colonelRepository.GetColonel(address, key));
        }

        [Route("/api/Colonelupt")]
        [HttpPost]
        public int Colonelupt([FromForm]Model.Colonel a)
        {
            int i = _colonelRepository.UptColonel(a);
            return i;
        }

        [Route("/api/FT")]
        [HttpPost]
        public IActionResult FT (int id)
        {
            return Ok(_colonelRepository.FT1(id));
        }


        //用户显示
        [Route("/api/Users")]
        [HttpGet]
        public IActionResult Users(int page, int limit)
        {
            var As = _colonelRepository.GetUsers();
            As = As.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { code = 0, msg = "", Count = As.Count, data = As });
        }
        //商品显示
        [Route("/api/Commoditys")]
        [HttpGet]
        public IActionResult Commoditys(int page, int limit)
        {
            var As = _colonelRepository.GetCommodities();
            As = As.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { code = 0, msg = "", Count = As.Count, data = As });
        }

    }
}
