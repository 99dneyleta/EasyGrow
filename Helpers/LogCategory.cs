namespace EasyGrow.Helpers
{
    public class LogCategory
    {
        private LogCategory(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static LogCategory Trace => new LogCategory("Trace");
        public static LogCategory Debug => new LogCategory("Debug");
        public static LogCategory Info => new LogCategory("Info");
        public static LogCategory Warning => new LogCategory("Warning");
        public static LogCategory Error => new LogCategory("Error");
    }
}
