using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Data.Models
{
    public class Factor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(200)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره ی همراه")]
        [StringLength(11 , ErrorMessage ="شماره معتبر نیست"),RegularExpression(@"^[0-9]{10}")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "آدرس")]
        [MaxLength(600)]
        public string Addres { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "پستال کد")]
        [MaxLength(10)]
        // [Range(1, 10, ErrorMessage = "{0} معتبر نیست")]
        public int PostalCode { get; set; }

        public int Price { get; set; }

        [MaxLength(15)]
        public string Status { get; set; }


        public DateTime CreateDate { get; set; }

        public int Count { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        public ICollection<Product> products { get; set; }
    }
}