using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoBackend.Modules
{
    public class Todos
    {
        public Guid TodoId { get; set; } = Guid.NewGuid();
        public string? TodoContent { get; set; }
        public bool? TodoCompleted { get; set; } = false;
        public DateTime? TodoDateCreated { get; set; } = DateTime.Now;
        public DateTime? TodoDateUpdated { get; set; } = null;
        public DateTime? TodoDateCompleted { get; set; } = null;

    }
}