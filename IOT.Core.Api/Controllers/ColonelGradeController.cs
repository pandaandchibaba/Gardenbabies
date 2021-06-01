using IOT.Core.IRepository.ColonelGrade;
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
    public class ColonelGradeController : ControllerBase
    {
        private readonly IColonelGradeRepository _colonelGradeRepository;
        public ColonelGradeController(IColonelGradeRepository colonelGradeRepository)
        {
            _colonelGradeRepository = colonelGradeRepository;
        }

        [Route("/Api/colonelGrade")]
        [HttpGet]
        public IActionResult colonelGrade(string sname="")
        {
            var ls = _colonelGradeRepository.GetColonels();
            if (!string.IsNullOrEmpty(sname))
            {
                ls = ls.Where(x => x.CGradeName.Contains(sname)).ToList();
            }
            return Ok( new{data = ls });
        }
        [Route("/Api/delte")]
        [HttpGet]
        public int  delte(string id)
        {
            int i = _colonelGradeRepository.Edit(id);
            return i;
        }
        [Route("/Api/Uptdate")]
        [HttpPost]
        public int Uptdate([FromForm]Model.ColonelGrade a)
        {
            int i = _colonelGradeRepository.Upt(a);
            return i;
        }
        [Route("/api/Uptdatas")]
        [HttpGet]
        public int Uptdatas(int id)
        {
            int i = _colonelGradeRepository.UptState(id);
            return i;


        }

        [Route("/api/FTS")]
        [HttpGet]
        public IActionResult FTS(int id)
        {
            return Ok(_colonelGradeRepository.ft2(id));
        }



    }
}
