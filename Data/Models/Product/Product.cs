using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Product Name")]
        [MaxLength(256)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Product Browser Description")]
        [MaxLength(350)]
        public string ProductBrowserDescription { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Product Browser Title")]
        [MaxLength(256)]
        public string ProductBrowserTitle { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Product Text")]
        public string ProductText { get; set; }

        [MaxLength(150)]
        public string ProductImageName { get; set; }
        
        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Alt Image")]
        [MaxLength(200)]
        public string AltImage { get; set; }
        
        

        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Tags")]
        [MaxLength(300)]
        public string Tags { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public int Quantity { get; set; }
        
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public int Price { get; set; }

        public DateTime CreateDate { get; set; }
        
        
        // Relations
        [Required]
        public int GroupId { get; set; }

        public int? SubGroupId { get; set; }


        public ICollection<ProductPropertyRelation> ProductPropertyRelation { get; set; }

        [ForeignKey("GroupId")]
        public Group GroupProduct { get; set; }

        [ForeignKey("SubGroupId")]
        public Group SubGroupProduct { get; set; }

        public List<Gallery> Gallery { get; set; }
        
        #nullable enable
        public List<Reviews>? Review { get; set; }
        
        #nullable enable
        public List<Cart>? CartId { get; set; }
    }
}