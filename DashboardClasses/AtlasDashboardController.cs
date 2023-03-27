using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.ObjectBinding;
using System.Runtime.Serialization;

using System.Reflection.Emit;
using Infrastructure.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

using TTInstanceManagement;
using TTObjectClasses;
using System.Collections.Generic;
using DashboardClasses.Modules.Core_Destek_Modulleri.Dinamik_Rapor_Modulu.DashboardUtils;

namespace DashboardClasses.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public partial class AtlasDashboardController : Controller
    {
        [HvlResult]
        [HttpPost]
        public bool SaveDashboardDataSource(DashboardDataSourceDto dashboardDataSourceDto)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                if (dashboardDataSourceDto.ObjectID == null)
                {
                    var dashboardDataSource = new TTObjectClasses.Dashboard(_context);
                    dashboardDataSource.CreatedDate = Common.RecTime();
                    dashboardDataSource.Enabled = true;
                    dashboardDataSource.Name = dashboardDataSourceDto.Name;
                    dashboardDataSource.DashboardClassName = dashboardDataSourceDto.DashboardClassName;
                    _context.Save();
                    return true;
                }
                else
                {
                    var dashboard = _context.QueryObjects<TTObjectClasses.Dashboard>("ObjectID = '" + dashboardDataSourceDto.ObjectID + "'").FirstOrDefault();
                    dashboard.Name = dashboardDataSourceDto.Name;
                    dashboard.DashboardClassName = dashboardDataSourceDto.DashboardClassName;
                    _context.Save();
                    return true;
                }

            }
        }

        [HvlResult]
        [HttpGet]
        public bool SetEnableDisable(string objectID, bool enable)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dashboard = _context.QueryObjects<TTObjectClasses.Dashboard>("ObjectID = '" + objectID + "'").FirstOrDefault();
                dashboard.Enabled = enable;
                _context.Save();
            }
            return true;
        }

        [HvlResult]
        [HttpGet]
        public List<DashboardDataSourceDto> GetDashboardDataSources(bool getAll)
        {
            string injection = "Enabled = 1";
            if (getAll == true)
            {
                injection = string.Empty;
            }

            using (TTObjectContext _context = new TTObjectContext(false))
            {
                return _context.QueryObjects<TTObjectClasses.Dashboard>(injection).Select(x => new DashboardDataSourceDto() { ObjectID = x.ObjectID, Name = x.Name, DashboardClassName = x.DashboardClassName, Enabled = x.Enabled }).ToList();
            }
        }
    }
}