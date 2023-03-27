
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseMedulaWLAction")] 

    /// <summary>
    /// Temel İş Listeli İşlemler
    /// </summary>
    public  abstract  partial class BaseMedulaWLAction : TTObject, IMedulaWorkList
    {
        public class BaseMedulaWLActionList : TTObjectCollection<BaseMedulaWLAction> { }
                    
        public class ChildBaseMedulaWLActionCollection : TTObject.TTChildObjectCollection<BaseMedulaWLAction>
        {
            public ChildBaseMedulaWLActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseMedulaWLActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ISLEMSAYISIDEVAMEDENReportQuery_Class : TTReportNqlObject 
        {
            public int? HealthFacilityID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHFACILITYID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].AllPropertyDefs["HEALTHFACILITYID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Object Islemsayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISLEMSAYISI"]);
                }
            }

            public ISLEMSAYISIDEVAMEDENReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ISLEMSAYISIDEVAMEDENReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ISLEMSAYISIDEVAMEDENReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ISLEMSAYISITAMAMLANMISReportQuery_Class : TTReportNqlObject 
        {
            public int? HealthFacilityID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHFACILITYID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].AllPropertyDefs["HEALTHFACILITYID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Object Islemsayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISLEMSAYISI"]);
                }
            }

            public ISLEMSAYISITAMAMLANMISReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ISLEMSAYISITAMAMLANMISReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ISLEMSAYISITAMAMLANMISReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Object Islemsayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISLEMSAYISI"]);
                }
            }

            public ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid Started { get { return new Guid("dfbfa321-6ccb-4df8-ab31-0e181c9b64ae"); } }
            public static Guid Completed { get { return new Guid("2be650a2-5da9-4caf-b120-1061f9db327d"); } }
            public static Guid Continued { get { return new Guid("19c278cd-b61d-4af1-8a6f-cd4c65961b84"); } }
            public static Guid Cancelled { get { return new Guid("c57166c2-b8e4-4cf8-8bb1-2d5b4f1f9678"); } }
        }

        public static BindingList<BaseMedulaWLAction> BaseMedulaWLActionWorkList(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].QueryDefs["BaseMedulaWLActionWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<BaseMedulaWLAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class> ISLEMSAYISIDEVAMEDENReportQuery(int HEALTHFACILITYID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].QueryDefs["ISLEMSAYISIDEVAMEDENReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class> ISLEMSAYISIDEVAMEDENReportQuery(TTObjectContext objectContext, int HEALTHFACILITYID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].QueryDefs["ISLEMSAYISIDEVAMEDENReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseMedulaWLAction.ISLEMSAYISIDEVAMEDENReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class> ISLEMSAYISITAMAMLANMISReportQuery(int HEALTHFACILITYID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].QueryDefs["ISLEMSAYISITAMAMLANMISReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class> ISLEMSAYISITAMAMLANMISReportQuery(TTObjectContext objectContext, int HEALTHFACILITYID, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].QueryDefs["ISLEMSAYISITAMAMLANMISReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseMedulaWLAction> BaseMedulaWLActionWorkListByMedulaActionID(TTObjectContext objectContext, int MEDULAACTIONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].QueryDefs["BaseMedulaWLActionWorkListByMedulaActionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MEDULAACTIONID", MEDULAACTIONID);

            return ((ITTQuery)objectContext).QueryObjects<BaseMedulaWLAction>(queryDef, paramList);
        }

        public static BindingList<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class> ISLEMSAYISITAMAMLANMISGRUPLUReportQuery(int HEALTHFACILITYID, string OBJECTDEFNAME, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].QueryDefs["ISLEMSAYISITAMAMLANMISGRUPLUReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("OBJECTDEFNAME", OBJECTDEFNAME);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class> ISLEMSAYISITAMAMLANMISGRUPLUReportQuery(TTObjectContext objectContext, int HEALTHFACILITYID, string OBJECTDEFNAME, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEMEDULAWLACTION"].QueryDefs["ISLEMSAYISITAMAMLANMISGRUPLUReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("OBJECTDEFNAME", OBJECTDEFNAME);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İş Listesi Tarihi
    /// </summary>
        public DateTime? WorkListDate
        {
            get { return (DateTime?)this["WORKLISTDATE"]; }
            set { this["WORKLISTDATE"] = value; }
        }

    /// <summary>
    /// İşlem Numarası
    /// </summary>
        public TTSequence MedulaActionID
        {
            get { return GetSequence("MEDULAACTIONID"); }
        }

        public int? HealthFacilityID
        {
            get { return (int?)this["HEALTHFACILITYID"]; }
            set { this["HEALTHFACILITYID"] = value; }
        }

        virtual protected void CreateMedulaErrorLogsCollection()
        {
            _MedulaErrorLogs = new MedulaErrorLog.ChildMedulaErrorLogCollection(this, new Guid("b8dad41b-3534-4052-9aac-32bbd8486a41"));
            ((ITTChildObjectCollection)_MedulaErrorLogs).GetChildren();
        }

        protected MedulaErrorLog.ChildMedulaErrorLogCollection _MedulaErrorLogs = null;
        public MedulaErrorLog.ChildMedulaErrorLogCollection MedulaErrorLogs
        {
            get
            {
                if (_MedulaErrorLogs == null)
                    CreateMedulaErrorLogsCollection();
                return _MedulaErrorLogs;
            }
        }

        protected BaseMedulaWLAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseMedulaWLAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseMedulaWLAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseMedulaWLAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseMedulaWLAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEMEDULAWLACTION", dataRow) { }
        protected BaseMedulaWLAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEMEDULAWLACTION", dataRow, isImported) { }
        public BaseMedulaWLAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseMedulaWLAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseMedulaWLAction() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}