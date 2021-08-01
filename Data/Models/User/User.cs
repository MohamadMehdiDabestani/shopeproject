using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter {0} .")]
        [MaxLength(250)]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter {0} .")]
        [MaxLength(250)]
        [EmailAddress(ErrorMessage = "Please Enter an Email Valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter {0} .")]
        [MaxLength(250)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter {0} .")]
        [MaxLength(150)]
        public string SecureCode { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره ی همراه")]
        [StringLength(11 , ErrorMessage ="شماره معتبر نیست 1"),RegularExpression(@"^[0-9]{11}$" , ErrorMessage ="شماره معتبر نیست 2")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public DateTime RegisterDate { get; set; }

        [MaxLength(150)]
        public string UserAvatar { get; set; }

        public int? RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public List<Comment> comment { get; set; }

        public List<Factor> Factor { get; set; }

        public List<WhishList> WishList { get; set; }
    }
}