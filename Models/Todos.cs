using System.ComponentModel.DataAnnotations;

namespace todoBackend.Models
{
    public class Todos
    {
        [Key]
        public Guid TodoId { get; set; } = Guid.NewGuid();
        public string? TodoContent { get; set; }
        public bool? TodoCompleted { get; set; } = false;
        public DateTime? TodoDateCreated { get; set; } = DateTime.Now.ToUniversalTime();
        public DateTime? TodoDateUpdated { get; set; } = null;
        public DateTime? TodoDateCompleted { get; set; } = null;
    }
}