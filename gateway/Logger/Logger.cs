
namespace Logger;

public class Logger
{
    private static readonly Logger instance = new Logger();
    private readonly string logFilePath;

    private Logger()
    {
        logFilePath = "../../../log.txt";
    }

    public static Logger Instance
    {
        get { return instance; }
    }

    public void Log(string message)
    {
        string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";

        Console.WriteLine(log);

        WriteToFile(log);
    }

    private void WriteToFile(string log)
    {
        try
        {
            File.AppendAllText(logFilePath, log + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to log file: {ex.Message}");
        }
    }
}