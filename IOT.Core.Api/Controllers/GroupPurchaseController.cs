using IOT.Core.IRepository.GroupPurchase;
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
    public class GroupPurchaseController : ControllerBase
    {
        private readonly IGroupPurchaseRepository _groupPurchaseRepository;
        public GroupPurchaseController(IGroupPurchaseRepository groupPurchaseRepository)
        {
            _groupPurchaseRepository = groupPurchaseRepository;
        }



        //显示
        [Route("/api/Show")]
        [HttpGet]
        public IActionResult Show(int page, int limit)
        {
            var ls = _groupPurchaseRepository.GetModels();
            ls = ls.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { code = 0, msg = "", Count = ls.Count, data = ls });
        }

        [Route("/Api/Add")]
        [HttpPost]
        public int Add([FromForm]IOT.Core.Model.GroupPurchase a)
        {
            int i = _groupPurchaseRepository.insert(a);
            return i;
        }
    }
}
