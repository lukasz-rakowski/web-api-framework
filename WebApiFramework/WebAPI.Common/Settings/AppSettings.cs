using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Common.Settings
{
    public sealed class AppSettings
    {
        public string SecretKey { get; set; }
        public byte TokenExpireMonths { get; set; }
        public string HistoryTablesEnableQueryTemplate { get; set; }
    }
}
