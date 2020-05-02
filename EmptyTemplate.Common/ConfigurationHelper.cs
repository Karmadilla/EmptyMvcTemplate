using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyTemplate.Common
{
    public class ConfigurationHelper
    {
        public static string GetSqlConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["EmptyTemplate"].ConnectionString;
        }
    }
}