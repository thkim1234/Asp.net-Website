using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Website.Models
{
    public class WebsiteContextSeedData
    {
        private WebsiteContext _context;
        private UserManager<WebsiteUser> _userManager;

        public WebsiteContextSeedData(WebsiteContext context, UserManager<WebsiteUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("tedkim1234@gmail.com") == null)
            {
                var user = new WebsiteUser
                {
                    UserName = "taekim",
                    Email = "tedkim1234@gmail.com"
                };

                await _userManager.CreateAsync(user, "12251225Aa!");
            }

            //if (!_context.Blogs.Any())
            //{
            //    var firstBlog = new Blog
            //    {
            //        DatePosted = DateTime.UtcNow,
            //        Title = "My First Blog",
            //        Body = "I'm so exited to make this website.",
            //        Comments = new List<Comment>
            //        {
            //            new Comment
            //            {
            //                Name = "Tae",
            //                Body = "What up",
            //                DatePosted = DateTime.UtcNow
            //            }
            //        }
            //    };

            //    _context.Blogs.Add(firstBlog);

            //    _context.Comments.AddRange(firstBlog.Comments);

            //    var secondBlog = new Blog
            //    {
            //        DatePosted = DateTime.UtcNow,
            //        Title = "My Second Blog",
            //        Body = "Ezpz.",
            //        Comments = new List<Comment>
            //        {
            //            new Comment
            //            {
            //                Name = "Tae",
            //                Body = "What up",
            //                DatePosted = DateTime.UtcNow
            //            }
            //        }
            //    };

            //    _context.Blogs.Add(secondBlog);

            //    _context.Comments.AddRange(secondBlog.Comments);

            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
