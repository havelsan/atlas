
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureWorksAcceptNotice")] 

    /// <summary>
    /// Hizmet İşleri Kabul Tutanağı
    /// </summary>
    public  partial class ProcedureWorksAcceptNotice : BasePurchaseAction, IProcedureWorksAcceptNoticeWorkList
    {
        public class ProcedureWorksAcceptNoticeList : TTObjectCollection<ProcedureWorksAcceptNotice> { }
                    
        public class ChildProcedureWorksAcceptNoticeCollection : TTObject.TTChildObjectCollection<ProcedureWorksAcceptNotice>
        {
            public ChildProcedureWorksAcceptNoticeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureWorksAcceptNoticeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class HizmetIsleriKabulTutanagiNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ActualJobEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTUALJOBENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREWORKSACCEPTNOTICE"].AllPropertyDefs["ACTUALJOBENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExtendedEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTENDEDENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREWORKSACCEPTNOTICE"].AllPropertyDefs["EXTENDEDENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ExtendTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREWORKSACCEPTNOTICE"].AllPropertyDefs["EXTENDTIME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREWORKSACCEPTNOTICE"].AllPropertyDefs["REPORTTEXT"].DataType;
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

            public DateTime? JobEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JOBENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["JOBENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ContractDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? TotalContractValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALCONTRACTVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["TOTALCONTRACTVALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? DeliveryTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["DELIVERYTIME"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Supplier
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUPPLIER"]);
                }
            }

            public HizmetIsleriKabulTutanagiNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HizmetIsleriKabulTutanagiNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HizmetIsleriKabulTutanagiNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("8793c527-d22f-47ac-b939-30e9bdf066db"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("903983f0-3213-460f-970d-a847698e107b"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("9e755861-67e4-4535-87f2-ec8edb008b4f"); } }
        }

        public static BindingList<ProcedureWorksAcceptNotice.HizmetIsleriKabulTutanagiNQL_Class> HizmetIsleriKabulTutanagiNQL(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREWORKSACCEPTNOTICE"].QueryDefs["HizmetIsleriKabulTutanagiNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProcedureWorksAcceptNotice.HizmetIsleriKabulTutanagiNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureWorksAcceptNotice.HizmetIsleriKabulTutanagiNQL_Class> HizmetIsleriKabulTutanagiNQL(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREWORKSACCEPTNOTICE"].QueryDefs["HizmetIsleriKabulTutanagiNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProcedureWorksAcceptNotice.HizmetIsleriKabulTutanagiNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureWorksAcceptNotice> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREWORKSACCEPTNOTICE"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureWorksAcceptNotice>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ProcedureWorksAcceptNotice> GetWithActionID(TTObjectContext objectContext, int ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREWORKSACCEPTNOTICE"].QueryDefs["GetWithActionID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureWorksAcceptNotice>(queryDef, paramList);
        }

    /// <summary>
    /// Süre Uzatımlı Bitiş Tarihi
    /// </summary>
        public DateTime? ExtendedEndDate
        {
            get { return (DateTime?)this["EXTENDEDENDDATE"]; }
            set { this["EXTENDEDENDDATE"] = value; }
        }

    /// <summary>
    /// Rapor Açıklaması
    /// </summary>
        public string ReportText
        {
            get { return (string)this["REPORTTEXT"]; }
            set { this["REPORTTEXT"] = value; }
        }

    /// <summary>
    /// İşin Bitirilme Tarihi
    /// </summary>
        public DateTime? ActualJobEndDate
        {
            get { return (DateTime?)this["ACTUALJOBENDDATE"]; }
            set { this["ACTUALJOBENDDATE"] = value; }
        }

    /// <summary>
    /// Süre Uzatımı
    /// </summary>
        public string ExtendTime
        {
            get { return (string)this["EXTENDTIME"]; }
            set { this["EXTENDTIME"] = value; }
        }

        public Contract Contract
        {
            get { return (Contract)((ITTObject)this).GetParent("CONTRACT"); }
            set { this["CONTRACT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProjectContractsCollection()
        {
            _ProjectContracts = new ProjectContract.ChildProjectContractCollection(this, new Guid("be092ed3-6e70-49bb-bdf3-a6a908378137"));
            ((ITTChildObjectCollection)_ProjectContracts).GetChildren();
        }

        protected ProjectContract.ChildProjectContractCollection _ProjectContracts = null;
        public ProjectContract.ChildProjectContractCollection ProjectContracts
        {
            get
            {
                if (_ProjectContracts == null)
                    CreateProjectContractsCollection();
                return _ProjectContracts;
            }
        }

        protected ProcedureWorksAcceptNotice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureWorksAcceptNotice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureWorksAcceptNotice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureWorksAcceptNotice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureWorksAcceptNotice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREWORKSACCEPTNOTICE", dataRow) { }
        protected ProcedureWorksAcceptNotice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREWORKSACCEPTNOTICE", dataRow, isImported) { }
        public ProcedureWorksAcceptNotice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureWorksAcceptNotice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureWorksAcceptNotice() : base() { }

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