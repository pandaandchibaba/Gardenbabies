using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.PutLibrary;
using IOT.Core.Repository.PutLibrary;
using IOT.Core.Model;
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PutLibraryController : ControllerBase
    {
        private readonly IPutLibraryRepository _putLibraryRepository;

        public PutLibraryController(IPutLibraryRepository putLibraryRepository)
        {
            _putLibraryRepository = putLibraryRepository;
        }

        [HttpGet]
        [Route("/api/ShowPutLibrary")]
        public IActionResult ShowPutLibrary()
        {
            List<IOT.Core.Model.PutLibrary> lp = _putLibraryRepository.Query();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = lp
            });
        }
        [HttpPost]
        [Route("/api/AddPutLibrary")]
        public int AddPutLibrary(IOT.Core.Model.PutLibrary putLibrary)
        {
            int i = _putLibraryRepository.Insert(putLibrary);
            return i;
        }

        [HttpDelete]
        [Route("/api/DelPutLibrary")]
        public int DelPutLibrary(string ids)
        {
            int i = _putLibraryRepository.Delete(ids);
            return i;
        }
        [HttpPut]
        [Route("/api/UptPutLibrary")]
        public int UptPutLibrary(IOT.Core.Model.PutLibrary putLibrary)
        {
            int i = _putLibraryRepository.Update(putLibrary);
            return i;
        }


    }
}
