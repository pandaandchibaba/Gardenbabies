using IOT.Core.IRepository.Users;
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
    public class UseresController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UseresController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        [Route("/api/GetUseres")]
        [HttpGet]
        public IActionResult GetUseres(string name = "", int pageindex = 1, int pagesize = 2)
        {
            var list = _usersRepository.GetUsers(name);
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list.Skip((pageindex - 1) * pagesize).Take(pagesize)
            });
        }
        [HttpPost]
        [Route("/api/InsertUseres")]

        public int InsertUseres(Model.Users Model)
        {
            int i = _usersRepository.InsertUsers(Model);
            return i;
        }
        [HttpPost]
        [Route("/api/UptUseres")]

        public int UptUseres(Model.Users Model)
        {
            int i = _usersRepository.UptUsers(Model);
            return i;
        }
        [HttpPost]
        [Route("/api/UptUsersStates")]

        public int UptUsersStates(int id)
        {
            int i = _usersRepository.UptUsersState(id);
            return i;
        }
        [HttpDelete]
        [Route("/api/DelUseres")]

        public int DelUseres(int ids)
        {
            int i = _usersRepository.DelUsers(ids);
            return i;
        }
        [HttpGet]
        [Route("/api/GetUsersFans")]

        public IActionResult GetUsersFans(int id)
        {
            var list = _usersRepository.GetUsersFan(id);
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }


    }
}
