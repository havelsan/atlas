using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu.DashboardUtils
{
    public class DashboardDataSourceDto
    {
        public string Name { get; set; }
        public string DashboardClassName { get; set; }
        public Guid? ObjectID { get; set; }
        public bool? Enabled { get; set; }
    }
}
