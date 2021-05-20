using IOT.Core.IRepository.Brokerage;
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
    public class BrokerageController : ControllerBase
    {
        private readonly IBrokerageRepository _brokerageRepository;
        public BrokerageController(IBrokerageRepository brokerageRepository)
        {
            _brokerageRepository = brokerageRepository;
        }
        [Route("/Api/BrokergeShow")]
        [HttpGet]
        public IActionResult BrokergeShow()
        {
            var ls = _brokerageRepository.GetBrokerages();
            return Ok(new { data = ls });
        }
    }
}
