using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.NowRep;
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NowRepController : ControllerBase
    {
        private readonly INowRepRepository _nowRepRepository;
        public NowRepController(INowRepRepository nowRepRepository)
        {
            _nowRepRepository = nowRepRepository;
        }

        [HttpGet]
        [Route("/api/ShowNowRep")]
        public IActionResult ShowNowRep(string commodityname,string warehousename, int page = 1, int limit = 4)
        {
            List<IOT.Core.Model.NowRep> ln = _nowRepRepository.Query();
            if (!string.IsNullOrEmpty(commodityname))
            {
                ln = ln.Where(x => x.CommodityName.Contains(commodityname)).ToList();
            }
            if (!string.IsNullOrEmpty(warehousename))
            {
                ln = ln.Where(x => x.WarehouseName.Contains(warehousename)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                count = ln.Count,
                data = ln.Skip((page - 1) * limit).Take(limit)
            });
        }

        [HttpDelete]
        [Route("/api/DelNowRep")]
        public int DelNowRep(string ids)
        {
            int i = _nowRepRepository.Delete(ids);
            return i;
        }
    }
}
