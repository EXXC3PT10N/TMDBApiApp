using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDBMovieApp
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public string APIPath { get; set; }
        public string APIKey { get; set; }
    }
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }

    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
