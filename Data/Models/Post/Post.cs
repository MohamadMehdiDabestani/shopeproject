using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Title")]
        [MaxLength(256)]
        public string BrowserTitle { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Description")]
        [MaxLength(300)]
        public string BrowserDescription { get; set; }



        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Post Title")]
        [MaxLength(256)]
        public string PostTitle { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Post Description")]
        [MaxLength(300)]
        public string PostDescription { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Post Title")]
        [MaxLength(150)]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Alt Image")]
        [MaxLength(150)]
        public string AltImage { get; set; }

        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Tags")]
        [MaxLength(400)]
        public string Tags { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        public List<Comment> comment { get; set; }
    }
}