using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace Core.ViewModels
{
    public class GetAllPostAdminViewModel
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string ImageName { get; set; }
        public string AltImage { get; set; }
    }
    public class AddPostViewModel
    {
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
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Tags")]
        [MaxLength(400)]
        public string Tags { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Title")]
        [MaxLength(256)]
        public string BrowserTitle { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Description")]
        [MaxLength(300)]
        public string BrowserDescription { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Alt Image")]
        [MaxLength(150)]
        public string AltImage { get; set; }
    }
    public class EditePostViewModel
    {
        [Display(Name = "Post Id")]
        [Required(ErrorMessage = "Please do not edite {0}")]
        public int PostId { get; set; }


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


        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Tags")]
        [MaxLength(400)]
        public string Tags { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Title")]
        [MaxLength(256)]
        public string BrowserTitle { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Description")]
        [MaxLength(300)]
        public string BrowserDescription { get; set; }


        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Alt Image")]
        [MaxLength(150)]
        public string AltImage { get; set; }
    }
    public class GetPostViewModel
    {
        public GetPostViewModel()
        {
            Comments = new List<GetCommentViewModel>();
        }
        public int PostId { get; set; }

        public string AltImage { get; set; }
        public string Title { get; set; }

        public string ImageName { get; set; }

        public string Text { get; set; }

        public string Tags { get; set; }

        public string CreateDate { get; set; }
        
        public List<GetCommentViewModel> Comments { get; set; }
        
        public int CommentCount { get; set; }
    }
    public class GetAllPostViewModel
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string ImageName { get; set; }
        public string AltImage { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public int CommentCount { get; set; }
    }
    public class AddCommentViewModel
    {
        [Required]
        public int PostId { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Alt Image")]
        [MaxLength(150)]
        public string Text { get; set; }

        public int ParentId { get; set; }

    }
    public class GetCommentViewModel
    {
        public string Text { get; set; }

        public string UserName { get; set; }

        public string CreateDate { get; set; }

        public string Avatar { get; set; }

        public int CommentId { get; set; }

        public int? ParentId { get; set; }
    }
}