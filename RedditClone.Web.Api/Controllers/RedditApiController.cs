using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reddit.Models.Entities;
using Reddit.Models.Requests;
using Reddit.Services.CommonMethods;
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

        //POSTS

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

        [HttpPost("AddSub")]

        public async Task<IActionResult> AddSub([FromBody] SubRedditAdd sub)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                SubReddit existingName = await _service.GetSubByName(sub.SubName);

                if (existingName != null)
                {
                    return Conflict(new ErrorResponse("Subreddit name already exists"));
                }

                else
                {
                    return Ok(await _service.AddSub(sub));
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
                    return BadRequest(new ErrorResponse("Username or password don't match"));
                }

                User existingUsername = await _service.GetUserByUsername(user.Username);


                if (existingUsername == null)
                {
                    return Unauthorized(new ErrorResponse("Username wasn't found"));
                }

                var LoginUser = await _service.UserLogin(user);

                if (LoginUser == null)
                {
                    return BadRequest(new ErrorResponse("Username or password don't match"));
                }

          
                return Ok(await _service.UserLogin(user));

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

        [HttpPost("LikePost")]

        public async Task<IActionResult> PostLike([FromBody] PostLiked post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.PostLike(post));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpPost("LikeComment")]

        public async Task<IActionResult> CommentLike([FromBody] CommentLiked comment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.CommentLike(comment));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpPost("AddRule")]

        public async Task<IActionResult> AddRule([FromBody] SubRuleAdd rule)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.AddRule(rule));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        //GETS

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

        [HttpGet("UserLikedComments")]

        public async Task<IActionResult> GetUserCommentLikes(int postId, int userId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.GetUserCommentLikes(postId, userId));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpGet("Posts")]

        public async Task<IActionResult> GetPosts(int pageNumber, int pageSize)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.GetPosts(pageNumber, pageSize));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpGet("CurrentPost")]

        public async Task<IActionResult> GetCurrentPost(int postId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.GetCurrentPost(postId));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        [HttpGet("RandomSubs")]

        public async Task<IActionResult> GetRandomSubs()
        {
            return Ok(await _service.GetRandomSubs());
        }

        [HttpGet("TrendingPosts")]

        public async Task<IActionResult> GetTrendingPosts()
        {
            return Ok(await _service.GetTrendingPosts());
        }

        [HttpGet("SubPosts")]

        public async Task<IActionResult> GetSubPosts(int subId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.GetSubPosts(subId));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
           
        }

        [HttpGet("SearchPosts")]

        public async Task<IActionResult> SearchPosts(string query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.SearchPosts(query));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }

        }

        [HttpGet("SearchSubNames")]

        public async Task<IActionResult> SearchSubNames(string query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.SearchSubNames(query));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }

        }

        [HttpGet("Comments")]

        public async Task<IActionResult> GetComments(int postId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestModelState();
                }

                else
                {
                    return Ok(await _service.GetComments(postId));
                }
            }

            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse($"Error: ${ex.Message}");

                return StatusCode(500, response);
            }
        }

        private IActionResult BadRequestModelState()
        {
            IEnumerable<string> errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));

            return BadRequest(new ErrorResponse(errorMessages));
        }

    }
}
