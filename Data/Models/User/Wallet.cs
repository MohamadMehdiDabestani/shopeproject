using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }

        public int Price { get; set; }

        public int userId { get; set; }

        [ForeignKey("userId")]
        public User user { get; set; }

        public List<Transaction> transaction { get; set; }
    }
}