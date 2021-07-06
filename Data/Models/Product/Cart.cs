using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Cart
    {
        public int Id { get; set; }
        
        public int Count { get; set; }
        
        public int UserId { get; set; }
        
        public int ProductId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}