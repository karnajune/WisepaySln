using System;
using NLog;
namespace Logging.NLog
{

  public class NLogLogger: Logging.ILogger
  {
    private readonly Logger logger;

    public NLogLogger()
    {
      this.logger = LogManager.GetLogger("SMILE");
    }

    public void Info(String message)
    {
      this.logger.Info(message);
    }

    public void Warn(String message)
    {
      this.logger.Warn(message);
    }

    public void Debug(String message)
    {
      this.logger.Debug(message);
    }

    public void Error(Exception exception)
    {
      this.logger.Error(exception);
    }

    public void Error(String message)
    {
      this.logger.Error(message);
    }

    public void Error(String message, Exception ex)
    {
      this.logger.Log(LogLevel.Error, message, ex);
    }

    public void Error(Exception x, String path, String url)
    {
      this.logger.Error(x.BuildExceptionMessage(path, url));
    }

    public void Fatal(String message)
    {
      this.logger.Fatal(message);
    }

    public void Fatal(String message, Exception ex)
    {
      this.logger.Fatal(message, ex);
    }

    public void Fatal(Exception ex, String path, String url)
    {
      this.Fatal(ex.BuildExceptionMessage(path, url));
    }
  }
}
