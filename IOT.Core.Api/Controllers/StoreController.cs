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
        private readonly IStoreRepository _storeRepository;


        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        //显示商品
        [Route("/api/GetCommodity")]
        [HttpGet]
        public IActionResult GetCommodity(string ids)
        {
            var list = _storeRepository.GetCommodities();
            if (!string.IsNullOrEmpty(ids))
            {
                list = list.Where(x => x.CommodityId.ToString().Equals(ids) || x.CommodityName.Contains(ids)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }

        //显示订单
        [Route("/api/GetOrder")]
        [HttpGet]
        public IActionResult GetOrder(int id=0,string name="")
        {
            var list = _storeRepository.GetOrder();
            if (id==0&&string.IsNullOrEmpty(name))
            {
                return Ok(new
                {
                    msg = "",
                    code = 0,
                    data = list
                });
            }
            else
            {
                if (id == 1)
                {
                    list = list.Where(x => x.Ordernumber.Equals(name)).ToList();
                }
                if (id == 2)
                {
                    list = list.Where(x => x.UserName.Equals(name)).ToList();
                }
                if (id == 3)
                {
                    list = list.Where(x => x.Phone.Contains(name)).ToList();
                }


                return Ok(new
                {
                    msg = "",
                    code = 0,
                    data = list
                });
            }

           
        }

        //显示门店
        [Route("/api/GetStores")]
        [HttpGet]
        public IActionResult GetStores()
        {
            var list = _storeRepository.GetStores();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
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
        //删除商品
        [HttpDelete]
        [Route("/api/DelCom")]

        public int DelCom(int ids)
        {
            int i = _storeRepository.DelCom(ids);
            return i;
        }
        //删除门店
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

        /// <summary>
        /// 修改商品状态
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptCom")]
        public int UptCom(int cid)
        {
            int i = _storeRepository.UptCom(cid);
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
