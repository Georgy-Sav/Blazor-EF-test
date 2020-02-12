namespace PerfGUI.Server.DataAccess
{
    public partial class Environment
    {
        public long EnvironmentId { get; set; }
        public string Name { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}