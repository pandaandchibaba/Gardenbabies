using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.OutLibrary;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutLibraryController : ControllerBase
    {
        //注入
        public readonly IOutLibraryRepository  _outLibraryRepository;
        public OutLibraryController(IOutLibraryRepository outLibraryRepository)
        {
            _outLibraryRepository = outLibraryRepository;
        }

        //显示

        [HttpGet]
        [Route("/api/ShowOutLibrary")]
        public IActionResult ShowOutLibrary(string warehousename, string putno, string sdate = "", string zdate = "", int page = 1, int limit = 4)
        {
            List<IOT.Core.Model.OutLibrary> lp = _outLibraryRepository.Query();
            if (!string.IsNullOrEmpty(warehousename))
            {
                lp = lp.Where(x => x.WarehouseName.Contains(warehousename)).ToList();
            }
            if (!string.IsNullOrEmpty(putno))
            {
                lp = lp.Where(x => x.OutNO.Contains(putno)).ToList();
            }
            if (!string.IsNullOrEmpty(sdate) && !string.IsNullOrEmpty(zdate))
            {
                lp = lp.Where(x => x.OutDate >= Convert.ToDateTime(sdate) & x.OutDate <= Convert.ToDateTime(zdate)).ToList();
            }

            return Ok(new
            {
                msg = "",
                code = 0,
                count = lp.Count,
                data = lp.Skip((page - 1) * limit).Take(limit)
            });
        }

        [HttpPost]
        [Route("/api/AddOutLibrary")]
        public int AddOutLibrary(IOT.Core.Model.OutLibrary outLibrary)
        {
            int i = _outLibraryRepository.Insert(outLibrary);
            return i;
        }

        [HttpDelete]
        [Route("/api/DelOutLibrary")]
        public int DelOutLibrary(string ids)
        {
            int i = _outLibraryRepository.Delete(ids);
            return i;

        }
        [HttpPut]
        [Route("/api/UptOutLibrary")]
        public int UptOutLibrary(IOT.Core.Model.OutLibrary outLibrary)
        {
            int i = _outLibraryRepository.Update(outLibrary);
            return i;
        }

    }
}
