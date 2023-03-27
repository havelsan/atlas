
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManipulationRequest")] 

    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İstek Yapılan Nesnedir 
    /// </summary>
    public  partial class ManipulationRequest : EpisodeActionWithDiagnosis, IAllocateSpeciality, IWorkListEpisodeAction
    {
        public class ManipulationRequestList : TTObjectCollection<ManipulationRequest> { }
                    
        public class ChildManipulationRequestCollection : TTObject.TTChildObjectCollection<ManipulationRequest>
        {
            public ChildManipulationRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManipulationRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetManipulationRequestQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPatientApprovalFormGiven
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPATIENTAPPROVALFORMGIVEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["ISPATIENTAPPROVALFORMGIVEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object PreInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["PREINFORMATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["REPORTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MedulaRaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["MEDULARAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TestTubeBabyType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTTUBEBABYTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["TESTTUBEBABYTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ButKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUTKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].AllPropertyDefs["BUTKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetManipulationRequestQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetManipulationRequestQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetManipulationRequestQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid Completed { get { return new Guid("45746d79-48dd-490a-9201-a2ff71348695"); } }
            public static Guid Request { get { return new Guid("55a6468f-5bec-47a2-8617-e59e04a03b15"); } }
            public static Guid Cancelled { get { return new Guid("0440165a-fabe-48d5-86a9-56c11a5a2d19"); } }
        }

        public static BindingList<ManipulationRequest.GetManipulationRequestQuery_Class> GetManipulationRequestQuery(string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].QueryDefs["GetManipulationRequestQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<ManipulationRequest.GetManipulationRequestQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ManipulationRequest.GetManipulationRequestQuery_Class> GetManipulationRequestQuery(TTObjectContext objectContext, string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATIONREQUEST"].QueryDefs["GetManipulationRequestQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<ManipulationRequest.GetManipulationRequestQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public long? ProtocolNo
        {
            get { return (long?)this["PROTOCOLNO"]; }
            set { this["PROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Aydınlatılmış Onam Formu Verildi
    /// </summary>
        public bool? IsPatientApprovalFormGiven
        {
            get { return (bool?)this["ISPATIENTAPPROVALFORMGIVEN"]; }
            set { this["ISPATIENTAPPROVALFORMGIVEN"] = value; }
        }

    /// <summary>
    /// Ön Bilgi
    /// </summary>
        public object PreInformation
        {
            get { return (object)this["PREINFORMATION"]; }
            set { this["PREINFORMATION"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public string ReportNo
        {
            get { return (string)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
        }

    /// <summary>
    /// Medula Rapor Başlangıç Tarihi
    /// </summary>
        public DateTime? ReportStartDate
        {
            get { return (DateTime?)this["REPORTSTARTDATE"]; }
            set { this["REPORTSTARTDATE"] = value; }
        }

    /// <summary>
    /// Medula Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? ReportEndDate
        {
            get { return (DateTime?)this["REPORTENDDATE"]; }
            set { this["REPORTENDDATE"] = value; }
        }

    /// <summary>
    /// Medula Rapor Takip Numarası
    /// </summary>
        public string MedulaRaporTakipNo
        {
            get { return (string)this["MEDULARAPORTAKIPNO"]; }
            set { this["MEDULARAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Tüp Bebek Türü
    /// </summary>
        public string TestTubeBabyType
        {
            get { return (string)this["TESTTUBEBABYTYPE"]; }
            set { this["TESTTUBEBABYTYPE"] = value; }
        }

    /// <summary>
    /// But Kodu
    /// </summary>
        public string ButKodu
        {
            get { return (string)this["BUTKODU"]; }
            set { this["BUTKODU"] = value; }
        }

        virtual protected void CreateManipulationsCollection()
        {
            _Manipulations = new Manipulation.ChildManipulationCollection(this, new Guid("fbfe3ecd-4a42-444d-bdd7-1c8dfc1e71b6"));
            ((ITTChildObjectCollection)_Manipulations).GetChildren();
        }

        protected Manipulation.ChildManipulationCollection _Manipulations = null;
        public Manipulation.ChildManipulationCollection Manipulations
        {
            get
            {
                if (_Manipulations == null)
                    CreateManipulationsCollection();
                return _Manipulations;
            }
        }

        virtual protected void CreateManipulationProceduresCollection()
        {
            _ManipulationProcedures = new ManipulationProcedure.ChildManipulationProcedureCollection(this, new Guid("da9fe4a7-8485-4bde-b4f3-ad7c861ede49"));
            ((ITTChildObjectCollection)_ManipulationProcedures).GetChildren();
        }

        protected ManipulationProcedure.ChildManipulationProcedureCollection _ManipulationProcedures = null;
        public ManipulationProcedure.ChildManipulationProcedureCollection ManipulationProcedures
        {
            get
            {
                if (_ManipulationProcedures == null)
                    CreateManipulationProceduresCollection();
                return _ManipulationProcedures;
            }
        }

        protected ManipulationRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManipulationRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManipulationRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManipulationRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManipulationRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANIPULATIONREQUEST", dataRow) { }
        protected ManipulationRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANIPULATIONREQUEST", dataRow, isImported) { }
        public ManipulationRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManipulationRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManipulationRequest() : base() { }

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