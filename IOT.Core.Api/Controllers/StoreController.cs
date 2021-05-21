using IOT.Core.IRepository.Store;
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
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository  _storeRepository;

        public StoreController(IStoreRepository  storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [Route("/api/GetStores")]
        [HttpGet]
        public IActionResult GetStores( int pageindex = 1, int pagesize = 2)
        {
            var list = _storeRepository.GetStores();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list.Skip((pageindex - 1) * pagesize).Take(pagesize)
            });
        }
        [Route("/api/GetStoresFan")]
        [HttpGet]
        public IActionResult GetStoresFan(int id)
        {
            var list = _storeRepository.GetStoresFan(id);
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }
        [HttpDelete]
        [Route("/api/DelStore")]

        public int DelStore(int ids)
        {
            int i = _storeRepository.DelStore(ids);
            return i;
        }
        [HttpPost]
        [Route("/api/InsertStore")]

        public int InsertStore(Model.Store Model)
        {
            int i = _storeRepository.InsertStore(Model);
            return i;
        }
        [HttpPost]
        [Route("/api/UptStore")]

        public int UptStore(Model.Store Model)
        {
            int i = _storeRepository.UptStore(Model);
            return i;
        }
        [HttpPost]
        [Route("/api/UptStoreState")]

        public int UptStoreState(int id)
        {
            int i = _storeRepository.UptStoreState(id);
            return i;
        }
    }
}
