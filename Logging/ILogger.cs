using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public interface ILogger
    {
    void Info(String message);

    void Warn(String message);

    void Debug(String message);

    void Error(Exception exception);

    void Error(String message);

    void Error(String message, Exception ex);

    void Error(Exception x, String path, String url);

    void Fatal(String message);

    void Fatal(String message, Exception ex);

    void Fatal(Exception ex, String path, String url);
  }
}
