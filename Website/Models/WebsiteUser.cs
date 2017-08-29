using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Website.Models
{
    public class WebsiteUser : IdentityUser
    {
        public DateTime FirstBlog { get; set; }
    }
}
