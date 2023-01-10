namespace StarWars.Domain
{
    public static class Logs
    {
        private static void LogMessage(string type, string message)
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var fileName = Path.Combine(path, "log.txt");

            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"[{type}] {DateTime.UtcNow} {message}");
            }
        }

        public static void INFO(string message)
        {
            LogMessage("INFO", message);
        }
        public static void ERROR(string message)
        {
            LogMessage("ERROR", message);
        }

        public static void WARNING(string message)
        {
            LogMessage("WARNING", message);
        }
    }
}
