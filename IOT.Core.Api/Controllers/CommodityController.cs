﻿using IOT.Core.IRepository.Commodity;
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
    public class CommodityController : ControllerBase
    {
        /// <summary>
        /// 注入
        /// </summary>
        private readonly ICommodityRepository _commodity;
        public CommodityController(ICommodityRepository commodity)
        {
            _commodity = commodity;
        }

        /// <summary>
        /// 获取商品
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="limit">页面大小</param>
        /// <param name="code">怎样显示 1、出售中，2、仓库中，3、已出售，4、回收站</param>
        /// <param name="tid">类别</param>
        /// <param name="key">查询关键词</param>
        /// <returns></returns>
        [HttpGet("/Commodity/GetCommodities")]
        public IActionResult GetCommodities(int page, int limit, int code = 1, int tid = 0, string key = "")
        {
            List<IOT.Core.Model.V_Commodity> lst = _commodity.GetCommodities(code, tid, key);
            int count = lst.Count;
            return Ok(new
            {
                msg = "",
                code = 0,
                count = count,
                data = lst.Skip((page - 1) * limit).Take(limit)
            });
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        [HttpGet("/Commodity/UpdateState")]
        public int UpdateState(int cid)
        {
            return _commodity.UpdateState(cid);
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        [HttpGet("/Commodity/UpdateDeleteState")]
        public int UpdateDeleteState(int cid)
        {
            return _commodity.UpdateDeleteState(cid);
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="commodity"></param>
        /// <returns></returns>
        [HttpPost("/Commodity/CreateCommodity")]
        public int CreateCommodity(Model.Commodity commodity)
        {
            return _commodity.CreateCommodity(commodity);
        }
    }
}