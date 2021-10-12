using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be more than 50 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Description cannot be more than 50 characters")]
        public string Description { get; set; }
        [Required]
        public decimal Rating { get; set; }
    }
}
