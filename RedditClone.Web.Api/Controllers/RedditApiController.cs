using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reddit.Models.Entities;
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

        [HttpPost("AddUser")]

        public async Task<IActionResult> AddUser([FromBody] UserAdd user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                User existingEmail = await _service.GetUserByEmail(user.Email);

                User existingUsername = await _service.GetUserByUsername(user.UserName);

                if (existingEmail != null)
                {
                    return Conflict(new ErrorResponse("Email already exists"));
                }

                if (existingUsername != null)
                {
                    return Conflict(new ErrorResponse("Username already exists"));
                }

                else
                {
                    return Ok(await _service.AddUser(user));
                }
            }

            catch (Exception ex)

            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }


        }

        [HttpPost("UserLogin")]

        public async Task<IActionResult> UserLogin([FromBody] UserLogin user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.UserLogin(user));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpPost("AddComment")]

        public async Task<IActionResult> AddComment([FromBody] CommentAdd comment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.AddComment(comment));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpPost("AddPost")]

        public async Task<IActionResult> AddPost([FromBody] PostAdd post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.AddPost(post));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpGet("SubNames")]

        public async Task<IActionResult> GetSubNames()
        {
            return Ok(await _service.GetSubNames());
        }

        [HttpGet("SubReddit")]

        public async Task<IActionResult> GetSubReddit(string subName)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.GetSubReddit(subName));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpGet("Posts")]

        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _service.GetPosts());
        }


        private IActionResult BadRequestModelState()
        {
            IEnumerable<string> errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));

            return BadRequest(new ErrorResponse(errorMessages));
        }

    }
}
