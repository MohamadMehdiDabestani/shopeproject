using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class AddOrUpdateGroupViewModel
    {
        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "Group Title")]
        [MaxLength(256)]
        public string GroupTitle { get; set; }
        
        public int GroupId { get; set; }
        public int? ParentId { get; set; }
    }
}