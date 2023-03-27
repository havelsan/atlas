using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ObjectBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DashboardClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu.DashboardUtils
{
    public class DashboardUtils
    {
        public static XDocument GetDataSource(string dashboardName, Type type)
        {
          
            DashboardObjectDataSource dashboardObjectDataSource = new DashboardObjectDataSource(dashboardName);
            dashboardObjectDataSource.DataSource = type;
            dashboardObjectDataSource.DataMember = "GetReportData";
     
            dashboardObjectDataSource.Constructor = ObjectConstructorInfo.Default;
            return XDocument.Parse(dashboardObjectDataSource.SaveToXml().ToString());
        }
    }
}
