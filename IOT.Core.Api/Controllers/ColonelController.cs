using IOT.Core.IRepository.Colonel;
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
    public class ColonelController : ControllerBase
    {
        public readonly IColonelRepository _colonelRepository;
        public ColonelController(IColonelRepository colonelRepository)
        {
            _colonelRepository = colonelRepository;
        }



        //显示
        [Route("/api/colonel")]
        [HttpGet]
        public IActionResult colonel()
        {
            var ls = _colonelRepository.ShowColonel();
            return Ok(new { code = 0, msg = "", data = ls });
        }



        [Route("/api/ ColonelAdd")]
        [HttpPost]
        public int ColonelAdd(Model.Colonel a)
        {
            int i= _colonelRepository.AddColonel(a);
            return i;
        }


        [Route("/api/Colonelupt")]
        [HttpPost]
        public int Colonelupt(Model.Colonel a)
        {
            int i = _colonelRepository.UptColonel(a);
            return i;
        }


    }
}
