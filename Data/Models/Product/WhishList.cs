using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class WhishList
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}