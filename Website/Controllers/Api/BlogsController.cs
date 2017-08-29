using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Website.Models;
using Website.ViewModels;

namespace Website.Controllers.Api
{
    [Authorize]
    [Route("api/blogs")]
    public class BlogsController : Controller
    {
        private IWebsiteRepository _repository;
        private ILogger<BlogsController> _logger;

        public BlogsController(IWebsiteRepository repository, ILogger<BlogsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllBlogs();

                return Ok(Mapper.Map<IEnumerable<BlogViewModel>>(results));
            }
            catch (Exception ex)
            {                
                _logger.LogError($"Failed to get All Blogs: {ex}");
                return BadRequest("Error occurred");
            }
            
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]BlogViewModel theBlog)
        {
            if (ModelState.IsValid)
            {
                var newBlog = Mapper.Map<Blog>(theBlog);
                _repository.AddBlog(newBlog);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/blogs/{theBlog.Title}", Mapper.Map<BlogViewModel>(newBlog));
                }
            }
           
            return BadRequest("Failed to save the blog");
        }
    }
}
