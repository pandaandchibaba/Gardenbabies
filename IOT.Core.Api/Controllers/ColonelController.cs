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
        public IActionResult colonel(int page, int limit, string nickname = "")
        {
            var ls = _colonelRepository.ShowColonel();
            if (!string.IsNullOrEmpty(nickname))
            {
                ls = ls.Where(x => x.NickName.Contains(nickname)).ToList();
            }
            ls = ls.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { code = 0, msg = "", Count = ls.Count, data = ls });
        }

        [Route("/api/Colonelupt")]
        [HttpPost]
        public int Colonelupt(Model.Colonel a)
        {
            int i = _colonelRepository.UptColonel(a);
            return i;
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
