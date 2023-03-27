
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DialysisOrder")] 

    /// <summary>
    /// Diyaliz Emrinin Verildiği Nesnedir.
    /// </summary>
    public  partial class DialysisOrder : BaseDialysisOrder, IReasonOfReject, IAllocateSpeciality, IPlanPlannedAction, ICreateSubEpisode, IOldActions
    {
        public class DialysisOrderList : TTObjectCollection<DialysisOrder> { }
                    
        public class ChildDialysisOrderCollection : TTObject.TTChildObjectCollection<DialysisOrder>
        {
            public ChildDialysisOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDialysisOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DialysisAcceptionReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Dialysisrequestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIALYSISREQUESTOBJECTID"]);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISREQUEST"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Dialysisrequestprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIALYSISREQUESTPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIALYSISREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Docdiplomano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCDIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docemploymentrecordid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCEMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Doctitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Dokrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docmilitaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCMILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docwork
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCWORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docspeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DialysisAcceptionReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DialysisAcceptionReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DialysisAcceptionReportNQL_Class() : base() { }
        }

        public static class States
        {
            public static Guid Therapy { get { return new Guid("c233488f-9ef7-4cf0-98ea-252e7234c3d5"); } }
    /// <summary>
    /// Hekime İade
    /// </summary>
            public static Guid ApprovalForAbort { get { return new Guid("9e097679-aaf6-4220-8486-a065fb40c28e"); } }
            public static Guid RequestAcception { get { return new Guid("6d1f328b-ee7e-4306-8459-612679944a97"); } }
            public static Guid Cancelled { get { return new Guid("21b262b8-7fa8-4379-a940-3ec3e55f4aee"); } }
            public static Guid Completed { get { return new Guid("dee7f2ce-b21f-4c2e-918b-80a6ae136c83"); } }
            public static Guid Aborted { get { return new Guid("34f13297-520e-463b-bdc9-9b0a8faf9b7e"); } }
            public static Guid Rejected { get { return new Guid("c5b0cac2-8081-4373-822e-6be8155a41d1"); } }
            public static Guid Plan { get { return new Guid("272b57ee-f03f-42f8-b620-d9cf06f7fa60"); } }
        }

        public static BindingList<DialysisOrder.DialysisAcceptionReportNQL_Class> DialysisAcceptionReportNQL(string DIALYSISORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].QueryDefs["DialysisAcceptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIALYSISORDER", DIALYSISORDER);

            return TTReportNqlObject.QueryObjects<DialysisOrder.DialysisAcceptionReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DialysisOrder.DialysisAcceptionReportNQL_Class> DialysisAcceptionReportNQL(TTObjectContext objectContext, string DIALYSISORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].QueryDefs["DialysisAcceptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIALYSISORDER", DIALYSISORDER);

            return TTReportNqlObject.QueryObjects<DialysisOrder.DialysisAcceptionReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DialysisOrder> GetMySiblingObjectsForAppointment(TTObjectContext objectContext, string PARAMEPISODE, string PARAMCURRENTOBJECT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIALYSISORDER"].QueryDefs["GetMySiblingObjectsForAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PARAMCURRENTOBJECT", PARAMCURRENTOBJECT);

            return ((ITTQuery)objectContext).QueryObjects<DialysisOrder>(queryDef, paramList);
        }

    /// <summary>
    /// Sure/dk
    /// </summary>
        public long? Duration
        {
            get { return (long?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Doktor Diyaliz Takip Formu
    /// </summary>
        public object DoctorFollowUpForm
        {
            get { return (object)this["DOCTORFOLLOWUPFORM"]; }
            set { this["DOCTORFOLLOWUPFORM"] = value; }
        }

        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Hemşire Diyaliz Takip Formu
    /// </summary>
        public object NurseFollowUpForm
        {
            get { return (object)this["NURSEFOLLOWUPFORM"]; }
            set { this["NURSEFOLLOWUPFORM"] = value; }
        }

    /// <summary>
    /// Hemşireye Emirler
    /// </summary>
        public string OrderNote
        {
            get { return (string)this["ORDERNOTE"]; }
            set { this["ORDERNOTE"] = value; }
        }

    /// <summary>
    /// Tanı Tedavi Ünitesi
    /// </summary>
        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diyaliz Emirleri 
    /// </summary>
        public DialysisRequest DialysisRequest
        {
            get { return (DialysisRequest)((ITTObject)this).GetParent("DIALYSISREQUEST"); }
            set { this["DIALYSISREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavi Cihazı
    /// </summary>
        public ResEquipment TreatmentEquipment
        {
            get { return (ResEquipment)((ITTObject)this).GetParent("TREATMENTEQUIPMENT"); }
            set { this["TREATMENTEQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOrderDetailsCollection()
        {
            _OrderDetails = new SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection(this, new Guid("74ad2dbd-8b5c-4781-8226-21f427df90f0"));
            CreateOrderDetailsCollectionViews();
            ((ITTChildObjectCollection)_OrderDetails).GetChildren();
        }

        virtual protected void CreateMedulaReportResultsCollection()
        {
            _MedulaReportResults = new MedulaReportResult.ChildMedulaReportResultCollection(this, new Guid("b9999cc1-ccff-43bd-8b21-9336553a9184"));
            ((ITTChildObjectCollection)_MedulaReportResults).GetChildren();
        }

        protected MedulaReportResult.ChildMedulaReportResultCollection _MedulaReportResults = null;
        public MedulaReportResult.ChildMedulaReportResultCollection MedulaReportResults
        {
            get
            {
                if (_MedulaReportResults == null)
                    CreateMedulaReportResultsCollection();
                return _MedulaReportResults;
            }
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _DialysisTreatmentMaterials = new DialysisTreatmentMaterial.ChildDialysisTreatmentMaterialCollection(_TreatmentMaterials, "DialysisTreatmentMaterials");
        }

        private DialysisTreatmentMaterial.ChildDialysisTreatmentMaterialCollection _DialysisTreatmentMaterials = null;
        public DialysisTreatmentMaterial.ChildDialysisTreatmentMaterialCollection DialysisTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _DialysisTreatmentMaterials;
            }            
        }

        protected DialysisOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DialysisOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DialysisOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DialysisOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DialysisOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIALYSISORDER", dataRow) { }
        protected DialysisOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIALYSISORDER", dataRow, isImported) { }
        public DialysisOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DialysisOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DialysisOrder() : base() { }

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