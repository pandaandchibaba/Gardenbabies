using IOT.Core.IRepository.SVIP;
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
    public class SVIPController : ControllerBase
    {
        /// <summary>
        /// 注入
        /// </summary>
        private readonly ISVIPRepository _iSVIP;
        public SVIPController(ISVIPRepository iSVIP)
        {
            _iSVIP = iSVIP;
        }

        /// <summary>
        /// 添加超级会员
        /// </summary>
        /// <param name="sVIP"></param>
        /// <returns></returns>
        [HttpPost("/api/CreateSVIP")]
        public string CreateSVIP([FromForm]IOT.Core.Model.SVIP sVIP)
        {
            return _iSVIP.CreateSVIP(sVIP);
        }
    }
}
