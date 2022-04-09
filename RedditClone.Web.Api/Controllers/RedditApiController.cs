using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reddit.Models.Requests;
using Reddit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditClone.Web.Api.Controllers
{
    [Route("api/reddit/")]
    [ApiController]
    public class RedditApiController : ControllerBase
    {
        IRedditService _service = null;

        public RedditApiController(IRedditService service)
        {
            _service = service;
        }

        [HttpPost("addUser")]

        public async Task<IActionResult> AddUser([FromBody] UserAdd user)
        {
            return Ok(await _service.AddUser(user));
        }

    }
}
