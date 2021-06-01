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
        public readonly IOutLibraryRepository _outLibraryRepository;
        public OutLibraryController(IOutLibraryRepository outLibraryRepository)
        {
            _outLibraryRepository = outLibraryRepository;
        }

        //显示

        [HttpGet]
        [Route("/api/ShowOutLibrary")]
        public IActionResult ShowOutLibrary(string warehousename, string putno, string sdate = "", string zdate = "")
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
            if (!string.IsNullOrEmpty(sdate))
            {
                lp = lp.Where(x => x.OutDate >= Convert.ToDateTime(sdate)).ToList();
            }
            if (!string.IsNullOrEmpty(zdate))
            {
                lp = lp.Where(x => x.OutDate <= Convert.ToDateTime(zdate)).ToList();
            }

            return Ok(new
            {
                msg = "",
                code = 0,
                data = lp
            });
        }
        //添加
        [HttpPost]
        [Route("/api/AddOutLibrary")]
        public int AddOutLibrary([FromForm]IOT.Core.Model.OutLibrary outLibrary)
        {
            int i = _outLibraryRepository.Insert(outLibrary);
            return i;
        }
        //删除
        [HttpDelete]
        [Route("/api/DelOutLibrary")]
        public int DelOutLibrary(string ids)
        {
            int i = _outLibraryRepository.Delete(ids);
            return i;

        }

        [HttpPut]
        [Route("/api/UptOutLibrary")]
        public int UptOutLibrary([FromForm]IOT.Core.Model.OutLibrary outLibrary)
        {
            int i = _outLibraryRepository.Update(outLibrary);
            return i;
        }

        [HttpGet]
        [Route("/api/FtOutLibrary")]
        public IActionResult FtOutLibrary(int id)
        {
            List<IOT.Core.Model.OutLibrary> lp = _outLibraryRepository.Query();
            IOT.Core.Model.OutLibrary outLibrary = lp.FirstOrDefault(x => x.PutLibraryId.Equals(id));
            return Ok(new
            {
                msg = "",
                code = 0,
                data = outLibrary
            });
        }

    }
}
