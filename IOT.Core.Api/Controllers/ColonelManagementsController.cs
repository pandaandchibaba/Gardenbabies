using IOT.Core.IRepository.ColonelManagement;
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
    public class ColonelManagementsController : ControllerBase
    {
        private readonly IColonelManagementRepository _colonelManagementRepository;
        public ColonelManagementsController(IColonelManagementRepository colonelManagementRepository)
        {
            _colonelManagementRepository = colonelManagementRepository;
        }


        [Route("/api/colonelManagements")]
        [HttpGet]
        public IActionResult colonelManagements(int page,int limit,string checkname="")
        {
            var ls = _colonelManagementRepository.GetColonelManagements();
            if (!string.IsNullOrEmpty(checkname))
            {
                ls = ls.Where(x => x.CheckName.Contains(checkname)).ToList();
            }
            ls = ls.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new {code=0,msg="",Count=ls.Count(), data = ls });
        }

    }
}
