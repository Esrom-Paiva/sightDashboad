using System.ComponentModel.DataAnnotations;

namespace Repositories.Entity
{
    public class Server
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsOnline { get; set; }
    }
}
