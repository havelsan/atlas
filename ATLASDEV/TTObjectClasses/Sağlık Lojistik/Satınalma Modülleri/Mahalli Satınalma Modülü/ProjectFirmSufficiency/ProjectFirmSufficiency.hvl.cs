
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectFirmSufficiency")] 

    /// <summary>
    /// Satınalma Projesinde Firmaların Yeterlilik Bilgisini Barındıran Sınıftır.
    /// </summary>
    public  partial class ProjectFirmSufficiency : TTObject
    {
        public class ProjectFirmSufficiencyList : TTObjectCollection<ProjectFirmSufficiency> { }
                    
        public class ChildProjectFirmSufficiencyCollection : TTObject.TTChildObjectCollection<ProjectFirmSufficiency>
        {
            public ChildProjectFirmSufficiencyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectFirmSufficiencyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUnSufficientFirmsByProjectObjectID_Class : TTReportNqlObject 
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Sufficient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].AllPropertyDefs["SUFFICIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].AllPropertyDefs["ORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TenderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SufficiencyDueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENCYDUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["SUFFICIENCYDUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Responsibleprocurementunitdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEPROCUREMENTUNITDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KIKTenderRegisterNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKTENDERREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIKTENDERREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ActDefine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDEFINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTDEFINE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplieraddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUnSufficientFirmsByProjectObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnSufficientFirmsByProjectObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnSufficientFirmsByProjectObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllFirmsByProjectObjectID_Class : TTReportNqlObject 
        {
            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TenderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SufficiencyDueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENCYDUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["SUFFICIENCYDUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Responsibleprocurementunitdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEPROCUREMENTUNITDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KIKTenderRegisterNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKTENDERREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIKTENDERREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ActDefine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDEFINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTDEFINE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Sufficient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].AllPropertyDefs["SUFFICIENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllFirmsByProjectObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllFirmsByProjectObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllFirmsByProjectObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSufficientFirmsByProjectObjectID_Class : TTReportNqlObject 
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Sufficient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].AllPropertyDefs["SUFFICIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].AllPropertyDefs["ORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplieraddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TenderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SufficiencyDueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENCYDUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["SUFFICIENCYDUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Responsibleprocurementunitdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEPROCUREMENTUNITDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KIKTenderRegisterNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKTENDERREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIKTENDERREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ActDefine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDEFINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTDEFINE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSufficientFirmsByProjectObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSufficientFirmsByProjectObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSufficientFirmsByProjectObjectID_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("2431c191-da0b-4719-8198-af3fded67c94"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("0625dd30-822f-4780-a344-92f8875e093d"); } }
        }

        public static BindingList<ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID_Class> GetUnSufficientFirmsByProjectObjectID(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].QueryDefs["GetUnSufficientFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID_Class> GetUnSufficientFirmsByProjectObjectID(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].QueryDefs["GetUnSufficientFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProjectFirmSufficiency.GetUnSufficientFirmsByProjectObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class> GetAllFirmsByProjectObjectID(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].QueryDefs["GetAllFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class> GetAllFirmsByProjectObjectID(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].QueryDefs["GetAllFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProjectFirmSufficiency.GetAllFirmsByProjectObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID_Class> GetSufficientFirmsByProjectObjectID(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].QueryDefs["GetSufficientFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID_Class> GetSufficientFirmsByProjectObjectID(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROJECTFIRMSUFFICIENCY"].QueryDefs["GetSufficientFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Yeterli
    /// </summary>
        public bool? Sufficient
        {
            get { return (bool?)this["SUFFICIENT"]; }
            set { this["SUFFICIENT"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public long? OrderNo
        {
            get { return (long?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProjectFirmSufficiency(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectFirmSufficiency(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectFirmSufficiency(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectFirmSufficiency(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectFirmSufficiency(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTFIRMSUFFICIENCY", dataRow) { }
        protected ProjectFirmSufficiency(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTFIRMSUFFICIENCY", dataRow, isImported) { }
        public ProjectFirmSufficiency(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectFirmSufficiency(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectFirmSufficiency() : base() { }

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