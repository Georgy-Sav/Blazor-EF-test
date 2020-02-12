using System.ComponentModel.DataAnnotations;

namespace PerfGUI.Shared.Models
{
    public partial class Environment
    {
        public long EnvironmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, long.MaxValue)]
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}