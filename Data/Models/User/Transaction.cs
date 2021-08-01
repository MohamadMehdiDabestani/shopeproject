using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public int Price { get; set; }
        
        public bool Status { get; set; }
        
        public DateTime CreateDate { get; set; }

        public int? WalletId { get; set; }

        [ForeignKey("WalletId")]
        public Wallet wallet { get; set; }
    }
}