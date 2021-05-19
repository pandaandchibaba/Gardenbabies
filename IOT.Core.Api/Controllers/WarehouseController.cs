﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Warehouse;
using IOT.Core.Model;
namespace IOT.Core.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        [HttpGet]
        [Route("/api/ShowWarehouse")]
        public IActionResult ShowWarehouse()
        {
            List<Model.Warehouse> lw = _warehouseRepository.Query();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = lw
            });
        }

        [HttpPost]
        [Route("/api/AddWarehouse")]
        public int AddWarehouse(IOT.Core.Model.Warehouse warehouse)
        {
            int i = _warehouseRepository.Insert(warehouse);
            return i;
        }
        [HttpDelete]
        [Route("/api/DelWarehouse")]
        public int DelWarehouse(string ids)
        {
            int i = _warehouseRepository.Delete(ids);
            return i;
        }
        [HttpPut]
        [Route("/api/UptWarehouse")]
        public int UptWarehouse(IOT.Core.Model.Warehouse warehouse)
        {
            int i = _warehouseRepository.Update(warehouse);
            return i;
        }
    }
}