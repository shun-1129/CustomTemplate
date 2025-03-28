namespace WorkerServiceTemplate.Models.Data
{
    public class Appsettings
    {
        public string ConnectionStrings { get; set; } = string.Empty;

        public string User { get; set; } = string.Empty;

        public string Program { get; set; } = string.Empty;

        public int DelayTimeMs { get; set; }
    }
}
