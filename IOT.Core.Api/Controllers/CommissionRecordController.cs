using IOT.Core.IRepository.CommissionRecord;
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
    public class CommissionRecordController : ControllerBase
    {
        /// <summary>
        /// 注入
        /// </summary>
        private readonly ICommissionRecordRepository _commissionRecord;
        public CommissionRecordController(ICommissionRecordRepository commissionRecord)
        {
            _commissionRecord = commissionRecord;
        }

        /// <summary>
        /// 显示 查询流水佣金
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("/CommissionRecord/GetCommissionRecords")]
        public IActionResult GetCommissionRecords(int page,int limit,string key="")
        {
            List<IOT.Core.Model.V_CommissionRecord> lst = _commissionRecord.GetCommissionRecords(key);
            int count = lst.Count;
            return Ok(new
            {
                msg = "",
                code = 0,
                count = count,
                data = lst.Skip((page - 1) * limit).Take(limit)
            });
        }
    }
}
