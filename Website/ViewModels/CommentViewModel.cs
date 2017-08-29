using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Body { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;
    }
}
