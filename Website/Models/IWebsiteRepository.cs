using System.Collections.Generic;
using System.Threading.Tasks;

namespace Website.Models
{
    public interface IWebsiteRepository
    {
        IEnumerable<Blog> GetAllBlogs();
        Blog GetBlogByTitle(string blogTitle);

        void AddBlog(Blog blog);
        void AddComment(string blogTitle, Comment newComment);

        Task<bool> SaveChangesAsync();
    }
}