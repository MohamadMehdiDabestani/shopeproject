using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Role
    {
        public int Id { get; set; }
        
        [Display(Name = "Role Title")]
        [Required(ErrorMessage = "Please Enter {0} .")]
        [MaxLength(70)]
        public string RoleTitle { get; set; }

        public List<User> Users { get; set; }


    }
}