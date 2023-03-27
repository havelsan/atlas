using DashboardClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu.DashboardUtils;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ObjectBinding;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TTInstanceManagement;
using TTObjectClasses;

namespace DashboardClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu
{
    public class AtlasDataSourceStorage : DevExpress.DashboardWeb.IDataSourceStorage
    {
        public XDocument GetDataSource(string dataSourceID)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dashboardData = _context.QueryObjects<TTObjectClasses.Dashboard>("ObjectID = '" + dataSourceID + "'").FirstOrDefault();

                var targetType = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies().Where(x => x.Name.Contains("AtlasDataSource")).Select(System.Reflection.Assembly.Load).SelectMany(x => x.DefinedTypes).Where(p => p.Name == dashboardData.DashboardClassName).FirstOrDefault();

                return DashboardUtils.DashboardUtils.GetDataSource(dashboardData.Name, targetType);
            }
        }

        public IEnumerable<string> GetDataSourcesID()
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                return _context.QueryObjects<TTObjectClasses.Dashboard>("Enabled = 1").Select(x => x.ObjectID.ToString()).ToList();
            }
        }
    }
    public class AtlasDashboardStorage : IDashboardStorage, IEditableDashboardStorage
    {
        public string AddDashboard(XDocument dashboard, string dashboardName)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                DashboardData dashboardData = new DashboardData(_context);
                dashboardData.CreatedDate = Common.RecTime();
                dashboardData.Name = dashboardName;
                dashboardData.XML = dashboard.ToString();
                dashboardData.CreatedBy = Common.CurrentResource;

                var dashboardItem = new DevExpress.DashboardCommon.Dashboard();
                dashboardItem.LoadFromXDocument(dashboard);

                var dataSourceName = dashboardItem.DataSources.FirstOrDefault().Name;
                var dashboardFK = _context.QueryObjects<TTObjectClasses.Dashboard>("Name = '" + dataSourceName + "'").FirstOrDefault();
                dashboardData.Dashboard = dashboardFK;
                _context.Save();
                return dashboardData.ObjectID.ToString(); ;
            }
        }

        public IEnumerable<DashboardInfo> GetAvailableDashboardsInfo()
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                return _context.QueryObjects<DashboardData>().Select(x => new DashboardInfo() { ID = x.ObjectID.ToString(), Name = x.Name }).ToList();
            }
        }

        public XDocument LoadDashboard(string dashboardID)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dashboardData = _context.QueryObjects<DashboardData>("ObjectID = '" + dashboardID + "'").FirstOrDefault();
                return XDocument.Parse(dashboardData.XML.ToString());
            }
        }

        public void SaveDashboard(string dashboardID, XDocument dashboard)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dashboardData = _context.QueryObjects<DashboardData>("ObjectID = '" + dashboardID + "'").FirstOrDefault();
                dashboardData.XML = dashboard.ToString();
                _context.Save();

            }
        }
    }
}
