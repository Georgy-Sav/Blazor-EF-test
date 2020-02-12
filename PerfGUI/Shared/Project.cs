using System.ComponentModel.DataAnnotations;

namespace PerfGUI.Shared.Models
{
    public partial class Project
    {
        public long ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}