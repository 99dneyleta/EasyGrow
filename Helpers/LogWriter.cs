using System.IO;

namespace EasyGrow.Helpers
{
    public class LogWriter
    {
        public static bool WriteLog(string strMessage, string strFileName = "ConsoleLog")
        {
            try
            {
                FileStream objFileStream = new FileStream(string.Format("{0}\\{1}", Path.GetTempPath(), strFileName), FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFileStream);
                objStreamWriter.WriteLine(strMessage);
                objStreamWriter.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string CreateLog(int logEvent, LogCategory category, string message)
        {
            return "(" + logEvent.ToString() + ") " + category.Value + ": " + message;
        }
    }
}
