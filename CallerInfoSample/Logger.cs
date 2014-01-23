using System;
using System.Runtime.CompilerServices;
using log4net;

namespace CallerInfoSample
{
    public class Logger
    {
        private static Logger _logger;
        private ILog _log;
        public static Logger Instance
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                }
                return _logger;
            }
        }

        private Logger()
        {
        }

        private void Initialize()
        {
            _log = LogManager.GetLogger(typeof(Logger));
            log4net.Config.XmlConfigurator.Configure();
        }

        public void Error(Exception ex, 
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (_log == null)
            {
                Initialize();
            }
            _log.Error(string.Format(
                "Error Logged From method {0} in file {1} at line {2}",
                memberName, sourceFilePath, sourceLineNumber), ex);
        }

        public void Warning(Exception ex,                    
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (_log == null)
            {
                Initialize();
            }
            _log.Warn(string.Format("Warning from method {0} in file {1} at line {2}", 
                memberName, sourceFilePath, sourceLineNumber), ex);
        }

        public void Debug(Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (_log == null)
            {
                Initialize();
            }
            _log.Debug(string.Format(
                "Debug entry from method {0} in file {1} at line {2}",
                memberName, sourceFilePath, sourceLineNumber), ex);
        }
    }
}
