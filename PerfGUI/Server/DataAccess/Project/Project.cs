using System.Collections.Generic;

namespace PerfGUI.Server.DataAccess
{
    public partial class Project
    {
        public long ProjectId { get; set; }
        public string Name { get; set; }
        public ICollection<Environment> Environments { get; set; }
    }
}