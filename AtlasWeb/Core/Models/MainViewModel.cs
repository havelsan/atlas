using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class MainViewModel
    {
        public bool hasRoleStockWorkList { get; set; }
        public bool hasRoleDashboard { get; set; }
        public bool hasRoleMkysIntegration { get; set; }
        public bool hasRoleSupplyRequestManager { get; set; }
        public bool hasRoleLogisticAddAndUpdate { get; set; }
        public bool hasRoleDefinitions { get; set; }
    }

}