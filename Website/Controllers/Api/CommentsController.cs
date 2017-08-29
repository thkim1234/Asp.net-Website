using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Website.Models;
using Website.ViewModels;

namespace Website.Controllers.Api
{
    [Route("/api/blogs/{blogTitle}/comments")]
    public class CommentsController : Controller
    {
        private ILogger<CommentsController> _logger;
        private IWebsiteRepository _repository;

        public CommentsController(IWebsiteRepository repository, ILogger<CommentsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get(string blogTitle)
        {
            try
            {
                var blog = _repository.GetBlogByTitle(blogTitle);

                return Ok(Mapper.Map<IEnumerable<CommentViewModel>>(blog.Comments.OrderBy(c => c.DatePosted).ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get comments: {0}", ex);
            }

            return BadRequest("Failed to get comments");
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(string blogTitle, [FromBody] CommentViewModel vm)
        {
            try
            {
                // If the VM is valid
                if (ModelState.IsValid)
                {
                    var newComment = Mapper.Map<Comment>(vm);
                    // Lookup

                    _repository.AddComment(blogTitle, newComment);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created($"/api/blogs/{blogTitle}/comments/{newComment.Name}",
                            Mapper.Map<CommentViewModel>(newComment));
                    }                 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new Comment: {0}", ex);
            }

            return BadRequest("Failed to save new comment");
        }
    }
}
