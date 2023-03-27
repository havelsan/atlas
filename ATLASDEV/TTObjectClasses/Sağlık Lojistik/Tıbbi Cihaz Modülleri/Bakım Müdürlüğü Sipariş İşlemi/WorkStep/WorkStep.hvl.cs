
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WorkStep")] 

    /// <summary>
    /// Yardımcı Atölye İş İstek
    /// </summary>
    public  partial class WorkStep : CMRAction
    {
        public class WorkStepList : TTObjectCollection<WorkStep> { }
                    
        public class ChildWorkStepCollection : TTObject.TTChildObjectCollection<WorkStep>
        {
            public ChildWorkStepCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWorkStepCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWorkCardByObjectIDReportQuery_Class : TTReportNqlObject 
        {
            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKSTEP"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKSTEP"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Accountancymilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Senderresdivision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERRESDIVISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sendersection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Receiversection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVERSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Receiverresdivision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVERRESDIVISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWorkCardByObjectIDReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkCardByObjectIDReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkCardByObjectIDReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWorkCardReportQuery_Class : TTReportNqlObject 
        {
            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKSTEP"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKSTEP"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Accountancymilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Senderresdivision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERRESDIVISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sendersection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Receiversection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVERSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWorkCardReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkCardReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkCardReportQuery_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("04180973-53e0-422f-88e1-9a3348dc1544"); } }
    /// <summary>
    /// Malzeme Temin
    /// </summary>
            public static Guid SupplyOfMaterial { get { return new Guid("91d058da-5e97-417e-ae81-38f450ab957d"); } }
    /// <summary>
    /// Bölüm Amiri Onay
    /// </summary>
            public static Guid New { get { return new Guid("cc57ee53-884d-4546-8aad-ac2c91102ed2"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("3073aa87-2e6b-4fd7-9bcf-66c6493c5acd"); } }
    /// <summary>
    /// Yardımcı Atölye Onay
    /// </summary>
            public static Guid WorkshopApproval { get { return new Guid("cfef9d77-f314-44fc-ae5b-afd224177ca7"); } }
    /// <summary>
    /// Yardımcı Atölye
    /// </summary>
            public static Guid WorkStepRepair { get { return new Guid("6a848d5b-e04c-4b2a-b405-185cdc1c7343"); } }
        }

        public static BindingList<WorkStep.GetWorkCardByObjectIDReportQuery_Class> GetWorkCardByObjectIDReportQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKSTEP"].QueryDefs["GetWorkCardByObjectIDReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<WorkStep.GetWorkCardByObjectIDReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<WorkStep.GetWorkCardByObjectIDReportQuery_Class> GetWorkCardByObjectIDReportQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKSTEP"].QueryDefs["GetWorkCardByObjectIDReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<WorkStep.GetWorkCardByObjectIDReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<WorkStep.GetWorkCardReportQuery_Class> GetWorkCardReportQuery(string ORDERNO, string RESDIVISION, string SENDERSECTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKSTEP"].QueryDefs["GetWorkCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERNO", ORDERNO);
            paramList.Add("RESDIVISION", RESDIVISION);
            paramList.Add("SENDERSECTION", SENDERSECTION);

            return TTReportNqlObject.QueryObjects<WorkStep.GetWorkCardReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<WorkStep.GetWorkCardReportQuery_Class> GetWorkCardReportQuery(TTObjectContext objectContext, string ORDERNO, string RESDIVISION, string SENDERSECTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKSTEP"].QueryDefs["GetWorkCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERNO", ORDERNO);
            paramList.Add("RESDIVISION", RESDIVISION);
            paramList.Add("SENDERSECTION", SENDERSECTION);

            return TTReportNqlObject.QueryObjects<WorkStep.GetWorkCardReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İş Yükü
    /// </summary>
        public long? Workload
        {
            get { return (long?)this["WORKLOAD"]; }
            set { this["WORKLOAD"] = value; }
        }

    /// <summary>
    /// Düşünceler
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateUsedConsumedMaterailsCollection()
        {
            _UsedConsumedMaterails = new UsedConsumedMaterail.ChildUsedConsumedMaterailCollection(this, new Guid("07c0dbf6-742c-4f6e-9bc9-c3acd24a1e1c"));
            ((ITTChildObjectCollection)_UsedConsumedMaterails).GetChildren();
        }

        protected UsedConsumedMaterail.ChildUsedConsumedMaterailCollection _UsedConsumedMaterails = null;
        public UsedConsumedMaterail.ChildUsedConsumedMaterailCollection UsedConsumedMaterails
        {
            get
            {
                if (_UsedConsumedMaterails == null)
                    CreateUsedConsumedMaterailsCollection();
                return _UsedConsumedMaterails;
            }
        }

        virtual protected void CreateWorkStepConsumedMaterialsCollection()
        {
            _WorkStepConsumedMaterials = new WorkStepConsumedMaterial.ChildWorkStepConsumedMaterialCollection(this, new Guid("c2038057-12f2-46ee-b7db-2fc34f3503b0"));
            ((ITTChildObjectCollection)_WorkStepConsumedMaterials).GetChildren();
        }

        protected WorkStepConsumedMaterial.ChildWorkStepConsumedMaterialCollection _WorkStepConsumedMaterials = null;
        public WorkStepConsumedMaterial.ChildWorkStepConsumedMaterialCollection WorkStepConsumedMaterials
        {
            get
            {
                if (_WorkStepConsumedMaterials == null)
                    CreateWorkStepConsumedMaterialsCollection();
                return _WorkStepConsumedMaterials;
            }
        }

        protected WorkStep(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WorkStep(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WorkStep(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WorkStep(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WorkStep(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WORKSTEP", dataRow) { }
        protected WorkStep(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WORKSTEP", dataRow, isImported) { }
        public WorkStep(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WorkStep(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WorkStep() : base() { }

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