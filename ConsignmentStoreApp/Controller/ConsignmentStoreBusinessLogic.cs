using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace ConsignmentStoreApp.Controller
{
    public static class ConsignmentStoreBusinessLogic
    {
        public static decimal GetConsignorRatio()
        {
            return 1 - decimal.Parse(ConfigurationManager.AppSettings.Get("ConsignmentFee"));
        }
    }
}
