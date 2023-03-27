
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CheckingExternalHospitalHealthCommitteeReports")] 

    /// <summary>
    /// Dış XXXXXX Sağlık Kurulu Raporları Kontrol
    /// </summary>
    public  partial class CheckingExternalHospitalHealthCommitteeReports : EpisodeActionWithDiagnosis
    {
        public class CheckingExternalHospitalHealthCommitteeReportsList : TTObjectCollection<CheckingExternalHospitalHealthCommitteeReports> { }
                    
        public class ChildCheckingExternalHospitalHealthCommitteeReportsCollection : TTObject.TTChildObjectCollection<CheckingExternalHospitalHealthCommitteeReports>
        {
            public ChildCheckingExternalHospitalHealthCommitteeReportsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCheckingExternalHospitalHealthCommitteeReportsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCheckingExternalHospitalHCReportsUnCompleted_Class : TTReportNqlObject 
        {
            public Guid? Currentojectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTOJECTID"]);
                }
            }

            public long? Eid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public long? Islemno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Islemtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetCheckingExternalHospitalHCReportsUnCompleted_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCheckingExternalHospitalHCReportsUnCompleted_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCheckingExternalHospitalHCReportsUnCompleted_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCheckingExternalHospitalHCReportsCompleted_Class : TTReportNqlObject 
        {
            public Guid? Currentojectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTOJECTID"]);
                }
            }

            public long? Eid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public long? Islemno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Islemtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetCheckingExternalHospitalHCReportsCompleted_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCheckingExternalHospitalHCReportsCompleted_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCheckingExternalHospitalHCReportsCompleted_Class() : base() { }
        }

        public static class States
        {
            public static Guid SelectionofController { get { return new Guid("8f8f2aeb-1fc6-46b7-a90e-07f8b798674e"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("d37c1b1d-a5e4-424e-84b4-6d12dfbfb45c"); } }
            public static Guid Request { get { return new Guid("6986ae3f-ab78-46a8-8ead-4334d3383f61"); } }
            public static Guid DetailedControl { get { return new Guid("ff4bbdca-f203-4b5e-849b-889b64bafd29"); } }
            public static Guid LastControl { get { return new Guid("71553459-d91a-44c1-9847-82cf99582f61"); } }
            public static Guid Control { get { return new Guid("99a763fa-eb10-44b8-977a-85ca075301ad"); } }
            public static Guid Acceptance { get { return new Guid("3be54f8d-1af1-425d-a82b-d0666cbd20a0"); } }
            public static Guid Completed { get { return new Guid("640a2048-3419-4d10-9ff7-fae032ee115a"); } }
        }

    /// <summary>
    /// Tamamlanmamış CheckingExternalHospitalHealthCommitteeReports ları get eder
    /// </summary>
        public static BindingList<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsUnCompleted_Class> GetCheckingExternalHospitalHCReportsUnCompleted(string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS"].QueryDefs["GetCheckingExternalHospitalHCReportsUnCompleted"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsUnCompleted_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Tamamlanmamış CheckingExternalHospitalHealthCommitteeReports ları get eder
    /// </summary>
        public static BindingList<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsUnCompleted_Class> GetCheckingExternalHospitalHCReportsUnCompleted(TTObjectContext objectContext, string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS"].QueryDefs["GetCheckingExternalHospitalHCReportsUnCompleted"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsUnCompleted_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tamamlanmış CheckingExternalHospitalHealthCommitteeReports ları get eder
    /// </summary>
        public static BindingList<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsCompleted_Class> GetCheckingExternalHospitalHCReportsCompleted(string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS"].QueryDefs["GetCheckingExternalHospitalHCReportsCompleted"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsCompleted_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Tamamlanmış CheckingExternalHospitalHealthCommitteeReports ları get eder
    /// </summary>
        public static BindingList<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsCompleted_Class> GetCheckingExternalHospitalHCReportsCompleted(TTObjectContext objectContext, string PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS"].QueryDefs["GetCheckingExternalHospitalHCReportsCompleted"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<CheckingExternalHospitalHealthCommitteeReports.GetCheckingExternalHospitalHCReportsCompleted_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Ön Tanı
    /// </summary>
        public string PreDiagnosis
        {
            get { return (string)this["PREDIAGNOSIS"]; }
            set { this["PREDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public string Report
        {
            get { return (string)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Gönderme Tarihi
    /// </summary>
        public DateTime? SendingDate
        {
            get { return (DateTime?)this["SENDINGDATE"]; }
            set { this["SENDINGDATE"] = value; }
        }

    /// <summary>
    /// Karar
    /// </summary>
        public string Decision
        {
            get { return (string)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// İstek Sebebi
    /// </summary>
        public string ReasonForRequest
        {
            get { return (string)this["REASONFORREQUEST"]; }
            set { this["REASONFORREQUEST"] = value; }
        }

    /// <summary>
    /// Gönderi Notu
    /// </summary>
        public string ConsignmentNote
        {
            get { return (string)this["CONSIGNMENTNOTE"]; }
            set { this["CONSIGNMENTNOTE"] = value; }
        }

    /// <summary>
    /// Gönderen  Makam
    /// </summary>
        public ConfirmationUnitDefinition ChairSendFrom
        {
            get { return (ConfirmationUnitDefinition)((ITTObject)this).GetParent("CHAIRSENDFROM"); }
            set { this["CHAIRSENDFROM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public HealthCommitteControlResultDefinition Result
        {
            get { return (HealthCommitteControlResultDefinition)((ITTObject)this).GetParent("RESULT"); }
            set { this["RESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMatterSliceAnecdoteCollection()
        {
            _MatterSliceAnecdote = new CEHHCRMatterSliceAnecdoteGrid.ChildCEHHCRMatterSliceAnecdoteGridCollection(this, new Guid("2273efa0-5ba0-4128-aa23-dcfe8372fe9d"));
            ((ITTChildObjectCollection)_MatterSliceAnecdote).GetChildren();
        }

        protected CEHHCRMatterSliceAnecdoteGrid.ChildCEHHCRMatterSliceAnecdoteGridCollection _MatterSliceAnecdote = null;
    /// <summary>
    /// Child collection for Madde/Dilim/Fıkra
    /// </summary>
        public CEHHCRMatterSliceAnecdoteGrid.ChildCEHHCRMatterSliceAnecdoteGridCollection MatterSliceAnecdote
        {
            get
            {
                if (_MatterSliceAnecdote == null)
                    CreateMatterSliceAnecdoteCollection();
                return _MatterSliceAnecdote;
            }
        }

        protected CheckingExternalHospitalHealthCommitteeReports(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CheckingExternalHospitalHealthCommitteeReports(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CheckingExternalHospitalHealthCommitteeReports(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CheckingExternalHospitalHealthCommitteeReports(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CheckingExternalHospitalHealthCommitteeReports(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS", dataRow) { }
        protected CheckingExternalHospitalHealthCommitteeReports(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHECKINGEXTERNALHOSPITALHEALTHCOMMITTEEREPORTS", dataRow, isImported) { }
        public CheckingExternalHospitalHealthCommitteeReports(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CheckingExternalHospitalHealthCommitteeReports(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CheckingExternalHospitalHealthCommitteeReports() : base() { }

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