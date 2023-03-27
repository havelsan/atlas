using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using TTConnectionManager;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class AuditQueryController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public AuditQueryFormViewModel AuditFormOpen([FromQuery] AuditQueryFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                viewModel = new AuditQueryFormViewModel();
                List<TTUser> lstUser = TTUser.GetAllUsers();
                foreach (var item in lstUser)
                {
                    Users us = new Users();
                    us.Name = item.FullName;
                    us.UserID = item.UserID;
                    viewModel.users.Add(us);
                }
                foreach (TTObjectDef objectDef in TTObjectDefManager.Instance.ObjectDefs.Values)
                {
                    ObjectDef obj = new ObjectDef();
                    obj.ObjectName = objectDef.ApplicationName + " ( " + objectDef.Name + " )";
                    obj.ObjectDefId = objectDef.ID;
                    viewModel._object.Add(obj);
                }

                foreach (TTReportDef reportDef in TTObjectDefManager.Instance.ReportDefs.Values)
                {
                    ObjectDef obj = new ObjectDef();
                    obj.ObjectName = reportDef.ApplicationName + " ( " + reportDef.Name + " )";
                    obj.ObjectDefId = reportDef.ID;
                    viewModel._object.Add(obj);
                }

                return viewModel;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public AuditQueryFormViewModel AuditQuery(AuditQueryFilter param)
        {
            AuditQueryFormViewModel viewModel = new AuditQueryFormViewModel();
            DataTable _allDataDataTable = TTAuditRecord.GetAuditRecords(param.ObjectID, param.ObjectDefID, param.UserID, param.StartDate, param.EndDate, false, false, null, null);
            for (int i = 0; i < _allDataDataTable.Rows.Count; i++)
            {
                TTAuditRecord audit = new TTAuditRecord(_allDataDataTable.Rows[i]);
                LogDataSource arr = LogDataSource.CreateFromAudit(audit);
                viewModel.LogDataSource.Add(arr);
            }

            return viewModel;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<LogDataSourceDetails> AuditQueryDetail([FromQuery]Guid auditId)
        {
            List<LogDataSourceDetails> ldsd = new List<LogDataSourceDetails>();
            DataTable _allDataDataTable = TTAuditRecord.GetAuditRecords(null, null, null, null, null, true, false, null, null, auditId);
            TTAuditRecord audit = new TTAuditRecord(_allDataDataTable.Rows[0]);
            if (audit.DetailData == null)
            {
                return ldsd;
            }
            for (int k = 0; k < audit.DetailData.Count; k++)
            {
                LogDataSourceDetails arr = LogDataSourceDetails.CreateFromAudit(audit.DetailData[k]);
                ldsd.Add(arr);
            }
            return ldsd;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ShowAuditFormViewModel ShowAuditsFormOpen(ShowAuditFormViewModel viewModel)
        {
            using (TTObjectContext context = new TTObjectContext(true))
            {
                foreach (AuditObject auditObject in viewModel.auditObjectIDs)
                {
                    TTObject obj = context.GetObject(auditObject.AuditObjectID, auditObject.AuditObjectDefID);
                    if (obj.ObjectDef.DisplayText != null)
                    {
                        AuditObjectList auditObjectList = new AuditObjectList();
                        auditObjectList.objectID = auditObject.AuditObjectID;
                        auditObjectList.objectName = obj.ObjectDef.DisplayText;
                        viewModel.auditObjectList.Add(auditObjectList);
                    }
                    else
                    {
                        AuditObjectList auditObjectList = new AuditObjectList();
                        auditObjectList.objectID = auditObject.AuditObjectID;
                        auditObjectList.objectName = obj.ObjectDef.Name;
                        viewModel.auditObjectList.Add(auditObjectList);
                    }

                }
                return viewModel;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<LogDataSource> GetObjectAuditRecords([FromQuery]Guid auditObjectID)
        {
            List<LogDataSource> arr = new List<LogDataSource>();
            DataTable _allDataDataTable = TTAuditRecord.GetObjectAuditRecords(auditObjectID, null, null, false);
            for (int i = 0; i < _allDataDataTable.Rows.Count; i++)
            {
                TTAuditRecord audit = new TTAuditRecord(_allDataDataTable.Rows[i]);
                arr.Add(LogDataSource.CreateFromAudit(audit));
            }
            return arr;
        }

        public LogDataSource GetAudit(Guid auditID)
        {
            LogDataSource retval = null;
            TTAuditRecord audit = TTAuditRecord.GetObjectAuditRecord(auditID);
            if (audit != null)
                retval = LogDataSource.CreateFromAudit(audit);
            return retval;
        }
    }

    public class AuditQueryFormViewModel
    {
        public List<Users> users = new List<Users>();


        public List<ObjectDef> _object = new List<ObjectDef>();
        public List<LogDataSource> LogDataSource = new List<LogDataSource>();
        public List<LogDataSourceDetails> LogDataSourceDetails = new List<LogDataSourceDetails>();
    }

    public class Users
    {
        public string Name
        {
            get;
            set;
        }
        public Guid UserID
        {
            get;
            set;
        }
    }

    public class ShowAuditFormViewModel
    {
        public Guid objectID
        {
            get;
            set;
        }

        public List<LogDataSource> LogDataSource = new List<LogDataSource>();
        public List<LogDataSourceDetails> LogDataSourceDetails = new List<LogDataSourceDetails>();
        public List<AuditObject> auditObjectIDs = new List<AuditObject>();
        public List<AuditObjectList> auditObjectList = new List<AuditObjectList>();
        public AuditObject selectedAuditObject { get; set; }
    }

    public class ObjectDef
    {
        public string ObjectName
        {
            get;
            set;
        }

        public Guid ObjectDefId
        {
            get;
            set;
        }
    }

    public class AuditQueryFilter
    {
        public Guid? ObjectID
        {
            get;
            set;
        }

        public Guid? UserID
        {
            get;
            set;
        }

        public Guid? ObjectDefID
        {
            get;
            set;
        }

        public DateTime? StartDate
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get;
            set;
        }
    }

    public class LogDataSource
    {
        public static LogDataSource CreateFromAudit(TTAuditRecord audit)
        {
            LogDataSource lds = new LogDataSource();
            lds.ObjectID = audit.ObjectID;
            lds.Date = audit.OperationDate;
            lds.PcIp = audit.WorkStation;
            lds.OperationName = audit.OperationTypeName;
            lds.AccountName = audit.UserName;
            lds.AuditId = audit.AuditID;

            return lds;
        }

        public Guid? ObjectID
        {
            get;
            set;
        }

        public string OperationName
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string PcIp
        {
            get;
            set;
        }

        public string AccountName
        {
            get;
            set;
        }

        public Guid? AuditId
        {
            get;
            set;
        }
    }
    public class LogDataSourceDetails
    {
        public static LogDataSourceDetails CreateFromAudit(TTAuditRecord.Detail detail)
        {
            LogDataSourceDetails ldsd = new LogDataSourceDetails();
            ldsd.Caption = detail.Caption;
            ldsd.Value = detail.Value;
            ldsd.Value2 = detail.Value2;
            return ldsd;
        }

        public string Caption
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
        public string Value2
        {
            get;
            set;
        }


    }

    public class AuditObjectList
    {
        public Guid objectID { get; set; }
        public string objectName { get; set; }
    }

    public class AuditObject
    {
        public Guid AuditObjectID { get; set; }
        public Guid AuditObjectDefID { get; set; }
    }
}