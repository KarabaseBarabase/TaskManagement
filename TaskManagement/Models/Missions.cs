using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Mission
    {
        [Key]
        public long TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AssignedTo { get; set; } 
        public int Duration { get; set; }
    }
}
