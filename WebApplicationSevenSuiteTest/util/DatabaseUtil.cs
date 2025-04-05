using System;
using System.Web.Configuration;

namespace WebApplicationSevenSuiteTest.util
{
    public class DatabaseUtil
    {
        static public String ConnectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["sevensuiteDbCS"].ConnectionString;
            }
        }
    }
}