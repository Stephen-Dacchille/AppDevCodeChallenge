using AppDevCodeChallange1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDevCodeChallange1.Helpers
{
    public class AppSettings : IAppSettings
    {
        public string DbConnectionString { get; private set; }

        public AppSettings()
        {
            DbConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        }
    }
}
