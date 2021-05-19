using IOT.Core.IRepository.IOrderInfo;
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
    public class OrderInfoController : ControllerBase
    {
        private readonly IOrderInfoRepository _orderInfoRepository;

        public OrderInfoController(IOrderInfoRepository orderInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
        }
        [Route("api/GetOrderInfo")]
        [HttpGet]
        public IActionResult GetOrderInfo(string name="", string state="", string end="", string tui="", string dingt="", string uid="", string cname="", string ziti="")
        {
            var list = _orderInfoRepository.GetList(name, state, end, tui, dingt, uid, cname, ziti);
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.UserName.Contains(name)).ToList();
            }

            
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }
    }
}
