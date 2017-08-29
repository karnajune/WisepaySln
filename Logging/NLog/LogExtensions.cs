using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.NLog
{
public  static class LogExtensions
  {
    public static String BuildExceptionMessage(this Exception exception, String path, String url)
    {
      String errorMessage = "Error in Path :" + path;
      errorMessage += Environment.NewLine + "Raw Url :" + url;

      Exception logException = exception;

      while (logException != null)
      {
        errorMessage += Environment.NewLine + "Message :" + logException.Message;
        errorMessage += Environment.NewLine + "Source :" + logException.Source;
        errorMessage += Environment.NewLine + "Stack Trace :" + logException.StackTrace;
        errorMessage += Environment.NewLine + "TargetSite :" + logException.TargetSite;

        logException = logException.InnerException;
        if (logException != null)
        {
          errorMessage += Environment.NewLine + Environment.NewLine + "   ====== Inner Exception" + Environment.NewLine;
        }
      }

      return errorMessage;
    }
  }
}
