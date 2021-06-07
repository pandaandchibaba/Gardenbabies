using IOT.Core.IRepository.Menu;
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
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;
        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [HttpGet]
        [Route("/api/GetMenu")]
        public IActionResult GetMenu()
        {
            var result = _menuRepository.GetMenus();
            return Ok(new { msg = "", code = 0, data = result });
        }
    }
}
