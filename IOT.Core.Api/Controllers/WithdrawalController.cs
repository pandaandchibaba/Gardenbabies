using IOT.Core.IRepository.Withdrawal;
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
    public class WithdrawalController : ControllerBase
    {
        private readonly IWithdrawalRepository _withdrawalRepository;
        public WithdrawalController(IWithdrawalRepository  withdrawalRepository)
        {
            _withdrawalRepository = withdrawalRepository;
        }
        [HttpPost]
        [Route("/api/Query")]
        public IActionResult GetWithdrawals(string name="",int page=1,int limit=2)
        {
            List<Model.Withdrawal> list = _withdrawalRepository.Query(name);
            return Ok(new
            {
                msg = "",
                code = 0,
                count = list.Count,
                data = list.Skip((page - 1) * limit).Take(limit)
            });
        }
    }
}
