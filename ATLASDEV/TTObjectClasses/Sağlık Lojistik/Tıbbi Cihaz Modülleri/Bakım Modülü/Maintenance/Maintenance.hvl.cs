
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Maintenance")] 

    /// <summary>
    /// Bakım
    /// </summary>
    public  partial class Maintenance : CMRAction
    {
        public class MaintenanceList : TTObjectCollection<Maintenance> { }
                    
        public class ChildMaintenanceCollection : TTObject.TTChildObjectCollection<Maintenance>
        {
            public ChildMaintenanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMaintenanceCheckListQuery_Class : TTReportNqlObject 
        {
            public Guid? MaintenanceParameterDef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MAINTENANCEPARAMETERDEF"]);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCECHECKLIST"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCECHECKLIST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? SenderSection
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SENDERSECTION"]);
                }
            }

            public GetMaintenanceCheckListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaintenanceCheckListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaintenanceCheckListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDeviceCheckListQuery_Class : TTReportNqlObject 
        {
            public Guid? MaintenanceParameterDef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MAINTENANCEPARAMETERDEF"]);
                }
            }

            public bool? Check
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEVICECHECKLIST"].AllPropertyDefs["CHECK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEVICECHECKLIST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? SenderSection
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SENDERSECTION"]);
                }
            }

            public GetDeviceCheckListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDeviceCheckListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDeviceCheckListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class MaintenanceReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? RequestNoSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["REQUESTNOSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public MaintenanceParameterPeriodEnum? MaintenanceType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTENANCETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].AllPropertyDefs["MAINTENANCETYPE"].DataType;
                    return (MaintenanceParameterPeriodEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MaintenanceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaintenanceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaintenanceReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("cbd9d0ad-c9b9-4dc6-ad03-a0f034b98622"); } }
    /// <summary>
    /// Bakım
    /// </summary>
            public static Guid Maintenance { get { return new Guid("4c530280-c6f2-4261-a6b6-a2bb2d5e5968"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("16eed1de-6b76-4a71-a482-db711b56eee2"); } }
    /// <summary>
    /// Onarım
    /// </summary>
            public static Guid Repair { get { return new Guid("3a27063e-8c50-4b8e-86fd-f70a71b0452c"); } }
    /// <summary>
    /// Kalibrasyon
    /// </summary>
            public static Guid Calibration { get { return new Guid("85f03e0e-ee7c-442a-9baa-7474cbdf290d"); } }
    /// <summary>
    /// İstek Onay
    /// </summary>
            public static Guid ForkNew { get { return new Guid("4d626080-7c18-4a7e-9ef6-9666eb52d11d"); } }
        }

        public static BindingList<Maintenance.GetMaintenanceCheckListQuery_Class> GetMaintenanceCheckListQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].QueryDefs["GetMaintenanceCheckListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Maintenance.GetMaintenanceCheckListQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Maintenance.GetMaintenanceCheckListQuery_Class> GetMaintenanceCheckListQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].QueryDefs["GetMaintenanceCheckListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Maintenance.GetMaintenanceCheckListQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Maintenance.GetDeviceCheckListQuery_Class> GetDeviceCheckListQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].QueryDefs["GetDeviceCheckListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Maintenance.GetDeviceCheckListQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Maintenance.GetDeviceCheckListQuery_Class> GetDeviceCheckListQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].QueryDefs["GetDeviceCheckListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Maintenance.GetDeviceCheckListQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Maintenance.MaintenanceReportQuery_Class> MaintenanceReportQuery(int DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].QueryDefs["MaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<Maintenance.MaintenanceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Maintenance.MaintenanceReportQuery_Class> MaintenanceReportQuery(TTObjectContext objectContext, int DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE"].QueryDefs["MaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<Maintenance.MaintenanceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// Bakım Peryodu
    /// </summary>
        public MaintenanceParameterPeriodEnum? MaintenanceType
        {
            get { return (MaintenanceParameterPeriodEnum?)(int?)this["MAINTENANCETYPE"]; }
            set { this["MAINTENANCETYPE"] = value; }
        }

        virtual protected void CreateMaintenanceParametersCollection()
        {
            _MaintenanceParameters = new MaintenanceParameter.ChildMaintenanceParameterCollection(this, new Guid("8bf9ff4a-c279-411c-9ce7-f92c865ce1de"));
            ((ITTChildObjectCollection)_MaintenanceParameters).GetChildren();
        }

        protected MaintenanceParameter.ChildMaintenanceParameterCollection _MaintenanceParameters = null;
        public MaintenanceParameter.ChildMaintenanceParameterCollection MaintenanceParameters
        {
            get
            {
                if (_MaintenanceParameters == null)
                    CreateMaintenanceParametersCollection();
                return _MaintenanceParameters;
            }
        }

        virtual protected void CreateMaintenanceCheckListsCollection()
        {
            _MaintenanceCheckLists = new MaintenanceCheckList.ChildMaintenanceCheckListCollection(this, new Guid("a8fa8984-02a5-4e4d-991f-a3484b24c41f"));
            ((ITTChildObjectCollection)_MaintenanceCheckLists).GetChildren();
        }

        protected MaintenanceCheckList.ChildMaintenanceCheckListCollection _MaintenanceCheckLists = null;
        public MaintenanceCheckList.ChildMaintenanceCheckListCollection MaintenanceCheckLists
        {
            get
            {
                if (_MaintenanceCheckLists == null)
                    CreateMaintenanceCheckListsCollection();
                return _MaintenanceCheckLists;
            }
        }

        virtual protected void CreateDeviceCheckListsCollection()
        {
            _DeviceCheckLists = new DeviceCheckList.ChildDeviceCheckListCollection(this, new Guid("1532dd49-bde3-4621-be41-823a0d326d80"));
            ((ITTChildObjectCollection)_DeviceCheckLists).GetChildren();
        }

        protected DeviceCheckList.ChildDeviceCheckListCollection _DeviceCheckLists = null;
        public DeviceCheckList.ChildDeviceCheckListCollection DeviceCheckLists
        {
            get
            {
                if (_DeviceCheckLists == null)
                    CreateDeviceCheckListsCollection();
                return _DeviceCheckLists;
            }
        }

        protected Maintenance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Maintenance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Maintenance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Maintenance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Maintenance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCE", dataRow) { }
        protected Maintenance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCE", dataRow, isImported) { }
        public Maintenance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Maintenance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Maintenance() : base() { }

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