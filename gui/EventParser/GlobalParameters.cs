namespace EventParser.GUI
{
    public static class Arguments
    {
        public static string connString { get; set; }
        public static string input { get; set; }
        public static string output { get; set; }
    }

    // Necessary for connection string builder window.
    public class ConnectionSettings
    {
        public string ConnectionString { get; set; }
        public int ComandTimeout { get; set; } = 60;
    }
}