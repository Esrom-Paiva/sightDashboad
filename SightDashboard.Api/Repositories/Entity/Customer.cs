using System.ComponentModel.DataAnnotations;

namespace Repositories.Entity
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [StringLength(2, MinimumLength = 2)]
        [Required]
        public string state { get; set; }
    }
}
