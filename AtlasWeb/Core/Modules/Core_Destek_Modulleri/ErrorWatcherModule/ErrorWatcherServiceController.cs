using System;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Data.Common;
using System.Linq;
using System.Data;
using TTConnectionManager;
using TTStorageManager.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    [AtlasRequiredRoles(TTRoleNames.Hasta_Arama)]
    public partial class ErrorWatcherServiceController : Controller
    {
        [HttpPost]
        public List<ErrorWatcherFormViewModel> LoadTTErrorLogs1()
        {
            List<ErrorWatcherFormViewModel> list = new List<ErrorWatcherFormViewModel>();
            using (var context = new TTObjectContext(false))
            {
                try
                {
                    list.Add(new ErrorWatcherFormViewModel());
                    return list;
                }
                catch (Exception e)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25206", "Ayaktan Hasta Listesi Sorgulamada Hata Oluştu!"), e);
                }
            }
        }
        [HttpPost]
        public IEnumerable<ErrorWatcherFormViewModel> LoadTTErrorLogs()
        {
            DbConnection dbConnection = ConnectionManager.CreateConnection();
            dbConnection.Open();
            var errorLogList = new List<ErrorWatcherFormViewModel>();
            try
            {
                char pc = ConnectionManager.ParameterChar;
                string whereClause = " WHERE ERRORDATE BETWEEN TO_DATE('" + DateTime.Now.AddDays(-7) + "','DD.MM.YYYY:HH24:MI:SS')  AND  TO_DATE('" + DateTime.Now+ "','DD.MM.YYYY:HH24:MI:SS')";
                string sql = "SELECT * FROM TTERRORLOG"+whereClause+" ORDER BY ERRORDATE DESC";// WHERE USERID = '" + TTUser.CurrentUser.TTObjectID.ToString()+"' ORDER BY ERRORDATE DESC"  ;
                using (DbCommand cmd = ConnectionManager.CreateCommand(sql, dbConnection))
                {
                    using (var dataTable = new DataTable())
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                        int i = 0;
                        foreach (var dataRow in dataTable.Rows.OfType<DataRow>())
                        {
                            var errologDetail = new ErrorWatcherFormViewModel()
                            {
                                UserID = Convert.ToString(dataRow["USERID"]),
                                WorkStationName = Convert.ToString(dataRow["WORKSTATIONNAME"]),
                                Description = Convert.ToString(dataRow["DESCRIPTION"]),
                                ErrorDate = Convert.ToDateTime(dataRow["ERRORDATE"]),
                            };
                            i++;
                            
                            if(i < 200)
                                errorLogList.Add(errologDetail);
                        }
                    }
                }
            }
            finally
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }

            return errorLogList;
        }


    }
}