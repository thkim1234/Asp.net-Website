using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
