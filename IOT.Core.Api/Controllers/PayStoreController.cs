using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.PayStore;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayStoreController : ControllerBase
    {
        private readonly IPayStoreRepository _payStoreRepository;

        public PayStoreController(IPayStoreRepository payStoreRepository)
        {
            _payStoreRepository = payStoreRepository;
        }

        [HttpPut]
        [Route("/api/UptCollection")]
        public int UptCollection(IOT.Core.Model.PayStore payStore)
        {
            int i = _payStoreRepository.UptCollection(payStore);
            return i;
        }

        [HttpPut]
        [Route("/api/UptWhether")]
        public int UptWhether(IOT.Core.Model.PayStore payStore)
        {
            int i = _payStoreRepository.UptWhether(payStore);
            return i;
        }
    }
}
