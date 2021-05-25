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
        public IActionResult colonelManagements(string checkname="")
        {
            var ls = _colonelManagementRepository.GetColonelManagements();
            if (!string.IsNullOrEmpty(checkname))
            {
                ls = ls.Where(x => x.CheckName.Contains(checkname)).ToList();
            }
          
            return Ok(new {data = ls });
        }
        [Route("/api/Uptdata")]
        [HttpPost]
        public int Uptdata(int  id)
        {
            return _colonelManagementRepository.Uptdata(id);
        }

    }
}
