//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Storage;
//using Microsoft.Extensions.Logging;
//using Website.Models;
//using Website.ViewModels;

//namespace Website.Controllers.Api
//{
//    [Route("api/readerBlogs")]
//    public class ReaderBlogsController : Controller
//    {
//        private IWebsiteRepository _repository;
//        private ILogger<ReaderBlogsController> _logger;

//        public ReaderBlogsController(IWebsiteRepository repository, ILogger<ReaderBlogsController> logger)
//        {
//            _repository = repository;
//            _logger = logger;
//        }

//        [HttpGet("")]
//        public IActionResult Get()
//        {
//            try
//            {
//                var results = _repository.GetAllBlogs();

//                return Ok(Mapper.Map<IEnumerable<ReaderBlogViewModel>>(results));
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Failed to get All Blogs: {ex}");
//                return BadRequest("Error occurred");
//            }

//        }
//    }
//}
