using IOT.Core.Repository.MiniProgram;
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
    public class MiniProgramController : ControllerBase
    {
        private readonly IMiniProgramRepository _miniProgramRepository;

        public MiniProgramController(IMiniProgramRepository  miniProgramRepository)
        {
            _miniProgramRepository = miniProgramRepository;
        }

        [HttpPost]
        [Route("/api/InsertMiniProgram")]

        public int InsertMiniProgram(Model.MiniProgram Model)
        {
            int i = _miniProgramRepository.Insert(Model);
            return i;
        }
    }
}
