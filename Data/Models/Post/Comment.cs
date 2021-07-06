using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Display(Name = "Comment Text")]
        [Required(ErrorMessage = "Please Enter {0} .")]
        [MaxLength(300)]
        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public List<Comment> SubComment { get; set; }

        public int? UserId { get; set; }

        public int PostId { get; set; }


        [ForeignKey("PostId")]
        public Post post { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
    }
}