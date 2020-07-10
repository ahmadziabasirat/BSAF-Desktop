using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Helper
{
    public class Variables
    {
        public static string baseUrl = ConfigurationManager.AppSettings["baseUrl"].ToString();
        public static string loginUrl = ConfigurationManager.AppSettings["loginUrl"].ToString();
        public static string beneficiaryUrl = ConfigurationManager.AppSettings["beneficiaryUrl"].ToString();
    }
}
