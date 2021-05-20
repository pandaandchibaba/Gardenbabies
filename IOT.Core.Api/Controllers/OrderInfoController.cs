using IOT.Core.IRepository.OrderInfo;
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

        [HttpGet]
        [Route("/api/GetListOrderInfo")]
        public IActionResult GetListOrderInfo(string name = "", string state = "", string end = "", int tui = 0, int dingt = 0, int uid = 0, string cname = "", string ziti = "", int pageindex = 1, int pagesize = 2)
        {
            List<IOT.Core.Model.OrderInfo> list = _orderInfoRepository.GetOrderInfos(name, state, end, tui, dingt, uid, cname, ziti);
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.CommodityName.Contains(name) || x.Phone.Contains(name)).ToList();
            }
            if (!string.IsNullOrEmpty(state))
            {
                list = list.Where(x => x.StartTime < Convert.ToDateTime(state)).ToList();
            }
            if (!string.IsNullOrEmpty(end))
            {
                list = list.Where(x => x.StartTime < Convert.ToDateTime(state)).ToList();
            }
            if (tui != 0)
            {
                list = list.Where(x => x.OrderState == tui).ToList();
            }
            if (dingt != 0)
            {
                list = list.Where(x => x.OrderState == tui).ToList();
            }
            if (uid != 0)
            {
                list = list.Where(x => x.UserId == tui).ToList();
            }
            if (!string.IsNullOrEmpty(cname))
            {
                list = list.Where(x => x.CommodityName.Contains(cname)).ToList();
            }
            if (!string.IsNullOrEmpty(ziti))
            {
                list = list.Where(x => x.Address.Contains(ziti)).ToList();
            }

            return Ok(new
            {
                msg = "",
                code = 0,
                data = list.Skip((pageindex - 1) * pagesize).Take(pagesize)
            }
                );
        }
        [HttpGet]
        [Route("/api/GetOrderInfo")]
        
        public IActionResult GetOrderInfo()
        {
            List<Model.OrderInfo> list = _orderInfoRepository.Query();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }
        [HttpPost]
        [Route("/api/UptOrderInfoRemark")]
        
        public int UptRemark(Model.OrderInfo Model)
        {
            int i = _orderInfoRepository.UptRemark(Model);
            return i;
        }
        [HttpPost]
        [Route("/api/UptOrderInfoSendWay")]
        
        public int UptSendWay(Model.OrderInfo Model)
        {
            int i = _orderInfoRepository.UptSendWay(Model);
            return i;
        }
        [HttpPost]
        [Route("/api/UptOrderInfoOrderState")]
        
        public int UptOrderState(Model.OrderInfo Model)
        {
            int i = _orderInfoRepository.UptOrderState(Model);
            return i;
        }
    }
}
