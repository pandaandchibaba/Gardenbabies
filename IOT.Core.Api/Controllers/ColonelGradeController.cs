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
        public IActionResult colonelGrade(int page,int limit)
        {
            var ls = _colonelGradeRepository.GetColonels();
            ls = ls.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new {code=0,msg="",count=ls.Count, data = ls });
        }
        [Route("/Api/delte")]
        [HttpPost]
        public int  delte(string id)
        {
            int i = _colonelGradeRepository.Edit(id);
            return i;
        }
        [Route("/Api/Uptdate")]
        [HttpPost]
        public int Uptdate(Model.ColonelGrade a)
        {
            int i = _colonelGradeRepository.Upt(a);
            return i;
        }



    }
}
