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
        public IActionResult colonel(string nickname="",int res=0)
        {
            var ls = _colonelRepository.ShowColonel();
            if (!string.IsNullOrEmpty(nickname))
            {
                ls = ls.Where(x => x.NickName.Contains(nickname)).ToList();
            }
            if (res != 0)
            {
                ls = ls.Where(m => m.DeliveryStatus == res).ToList();
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
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
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
        public IActionResult Users()
        {
            var As = _colonelRepository.GetUsers();
            return Ok(new { data = As });
        }

        //商品修改
        [Route("/api/coloneuptAa")]
        [HttpGet]
        public int coloneuptAa(int CommIds, int ColonelID)
        {
            return _colonelRepository.ColoneluptGoods(CommIds,ColonelID);
        }

        //团员修改
        [Route("/api/UptAa")]
        [HttpGet]
        public int UptAa(int ColonelID, int UserId)
        {
            return _colonelRepository.GetUser(ColonelID, UserId);
        }

        //商品显示
        [Route("/api/cemdisys")]
        [HttpGet]
        public IActionResult cemdisys()
        {
            var As = _colonelRepository.GetCommdit();

            return Ok(new { data = As });
        }

        //修改状态
        [Route("/api/Uptstates")]
        [HttpPost]
        public int Uptstates(int id)
        {
            return _colonelRepository.Updates(id);
        }
   
    }
}
