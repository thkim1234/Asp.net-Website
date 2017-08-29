using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Website.Models
{
    public class WebsiteRepository : IWebsiteRepository
    {
        private WebsiteContext _context;
        private ILogger<WebsiteRepository> _logger;

        public WebsiteRepository(WebsiteContext context, ILogger<WebsiteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Blog GetBlogByTitle(string blogTitle)
        {
            return _context.Blogs
                .Include(b => b.Comments)
                .FirstOrDefault(b => b.Title == blogTitle);
        }

        public void AddBlog(Blog blog)
        {
            _context.Add(blog);
        }

        public void AddComment(string blogTitle, Comment newComment)
        {
            var blog = GetBlogByTitle(blogTitle);

            if (blog != null)
            {
                blog.Comments.Add(newComment);
                _context.Comments.Add(newComment);
            }
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            _logger.LogInformation("Getting All Blogs from the Database");
            return _context.Blogs.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
