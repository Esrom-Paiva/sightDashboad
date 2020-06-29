using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        [Display(Name = "Placed")]
        [DataType(DataType.Date)]
        public DateTime Placed { get; set; }

        [Display(Name = "Completed")]
        [DataType(DataType.Date)]
        public DateTime? Completed { get; set; }
    }
}
