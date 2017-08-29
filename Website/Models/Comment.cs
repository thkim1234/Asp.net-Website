using System;

namespace Website.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime DatePosted { get; set; }
    }
}