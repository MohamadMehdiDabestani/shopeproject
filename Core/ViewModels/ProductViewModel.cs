using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Core.ViewModels
{
    public class GetAllAdminProductViewModel
    {
        public string ProductName { get; set; }

        public string ImageName { get; set; }

        public string AltImage { get; set; }

        public int ProductId { get; set; }
    }
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Product Name")]
        [MaxLength(256)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Description")]
        [MaxLength(350)]
        public string ProductBrowserDescription { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Title")]
        [MaxLength(256)]
        public string ProductBrowserTitle { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Product Text")]
        public string ProductText { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Price")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Tags")]
        [MaxLength(300)]
        public string Tags { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Alt Image")]
        [MaxLength(200)]
        public string AltImage { get; set; }

        [Required(ErrorMessage = "Please Select {0}")]
        [Display(Name = "Group")]
        public int GroupId { get; set; }

        public int? SubGroupId { get; set; }
    }
    public class EditeProductViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Product Name")]
        [MaxLength(256)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Description")]
        [MaxLength(350)]
        public string ProductBrowserDescription { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Browser Title")]
        [MaxLength(256)]
        public string ProductBrowserTitle { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Product Text")]
        public string ProductText { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Price")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Tags")]
        [MaxLength(300)]
        public string Tags { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Alt Image")]
        [MaxLength(200)]
        public string AltImage { get; set; }

        [Required(ErrorMessage = "Please Select {0}")]
        [Display(Name = "Group")]
        public int GroupId { get; set; }

        public int? SubGroupId { get; set; }
    }
    public class PropertiyViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Title")]
        [MaxLength(256)]
        public string ProductPropertyTitle { get; set; }
    }
    public class ProductPropertiyViewModel
    {
        public int PP_ID { get; set; }


        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Title")]
        [MaxLength(256)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Title")]
        [MaxLength(256)]
        public string Value { get; set; }

        [Required]
        public int PropertiyId { get; set; }
    }
    public class AddPropertiyToProductViewModel
    {
        [Required]
        public int PropertiyId { get; set; }
        [Required]
        public int ProducId { get; set; }
        [Required]
        public string PropertiyValue { get; set; }
    }
    public class GetGalleryViewModel
    {
        [Required]
        public int GalleryId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        [Required]
        [MaxLength(256)]
        public string AltImage { get; set; }
    }
    public class AddGalleryViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(256)]
        public string AltImage { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
    public class GetAllProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Price { get; set; }

        public string GroupTitle { get; set; }

        public string ImageName { get; set; }

        public string AltImage { get; set; }


    }
    public class GetProductViewModel
    {
        public GetProductViewModel()
        {
            Gallery = new List<GetGalleryProductViewModel>();
            Propertiy = new List<GetPropertiyProductViewModel>();
            Review = new List<GetReview>();
        }
        #nullable enable
        public List<GetGalleryProductViewModel>? Gallery { get; set; }

        #nullable enable
        public List<GetPropertiyProductViewModel>? Propertiy { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Price { get; set; }

        public string GroupTitle { get; set; }

        public string ImageName { get; set; }

        public string AltImage { get; set; }

        #nullable enable
        public string? SubGroupTitle { get; set; }

        public int GroupId { get; set; }

        #nullable enable
        public int? SunGroupId { get; set; }

        public string BTitle { get; set; }

        public string BDescription { get; set; }

        #nullable enable
        public List<GetReview>? Review { get; set; }

        public int Count { get; set; }
    }
    public class GetGalleryProductViewModel
    {
#nullable enable
        public string? ImageName { get; set; }

#nullable enable
        public string? AltImage { get; set; }
    }
    public class GetPropertiyProductViewModel
    {
#nullable enable
        public string? Title { get; set; }

#nullable enable
        public string? Value { get; set; }
    }
    public class GetReview
    {
        public string UserName { get; set; }

        public string CreateDate { get; set; }

        public string Text { get; set; }

    }
    public class AddReviewViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "متن نظر")]
        [MaxLength(256)]
        public string Text { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
    public class AddCartViewModel 
    {
        [Required]
        public int Count { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}