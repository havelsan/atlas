
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrthesisProsthesisRequest")] 

    /// <summary>
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class OrthesisProsthesisRequest : EpisodeActionWithDiagnosis, IAppointmentDef, ICreateSubEpisode
    {
        public class OrthesisProsthesisRequestList : TTObjectCollection<OrthesisProsthesisRequest> { }
                    
        public class ChildOrthesisProsthesisRequestCollection : TTObject.TTChildObjectCollection<OrthesisProsthesisRequest>
        {
            public ChildOrthesisProsthesisRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrthesisProsthesisRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOrthesisProsthesisRequest_Class : TTReportNqlObject 
        {
            public Guid? Ortezid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORTEZID"]);
                }
            }

            public Guid? Pid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PID"]);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public Guid? Eid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EID"]);
                }
            }

            public DateTime? Islemtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tckimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetOrthesisProsthesisRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrthesisProsthesisRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrthesisProsthesisRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrthesisRceptionReportInfo_Class : TTReportNqlObject 
        {
            public Guid? Ortezid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORTEZID"]);
                }
            }

            public Guid? Pid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PID"]);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string HomeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
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

            public string BirthPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? Eid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EID"]);
                }
            }

            public DateTime? Islemtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tckimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Payerid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYERID"]);
                }
            }

            public string Kabul
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABUL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string WarrantyNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARRANTYNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].AllPropertyDefs["WARRANTYNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOrthesisRceptionReportInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrthesisRceptionReportInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrthesisRceptionReportInfo_Class() : base() { }
        }

        public static class States
        {
            public static Guid HealthCommittee { get { return new Guid("de957f3f-5cd9-4e53-919f-06a55985936e"); } }
            public static Guid FinancialDepartmentControl { get { return new Guid("c3d4702c-d330-4338-8906-06ba7ecf16cf"); } }
    /// <summary>
    /// İstek İade
    /// </summary>
            public static Guid RequestReturn { get { return new Guid("8db8cdfb-c09e-4289-a27a-547b37711fd5"); } }
            public static Guid HealthCommitteeWithThreeSpecialistApproval { get { return new Guid("6f0d84c3-0587-49e4-b62e-8814cfae0564"); } }
            public static Guid HealthCommitteeWithThreeSpecialist { get { return new Guid("d2430dba-e979-419e-b7fb-763fc290f9f8"); } }
            public static Guid RequestAcception { get { return new Guid("0ebfe392-237c-452d-99c8-77aeb2314197"); } }
            public static Guid Procedure { get { return new Guid("f78ff8a2-b19d-4879-ba7a-61a3729677db"); } }
            public static Guid FinancialDepartmentRejected { get { return new Guid("42ab7e3b-9be7-4aa3-86ef-63f1483bea66"); } }
            public static Guid DoctorApproval { get { return new Guid("873d64eb-9a0a-4457-b13b-508301644700"); } }
            public static Guid Rejected { get { return new Guid("aed8afd7-1560-4649-ade0-8f1f7a77f262"); } }
            public static Guid Request { get { return new Guid("a5c6ccd3-41ca-4f1f-a12d-a818c0733665"); } }
            public static Guid HealthCommitteeApproval { get { return new Guid("23178232-c3be-48a6-9de7-8e4f541e7c54"); } }
            public static Guid Completed { get { return new Guid("f956ed62-df8b-403b-9b54-7c3e80a2a8e7"); } }
            public static Guid Pricing { get { return new Guid("1c48eb98-f5ef-4e2d-a9cb-f29c980e4f86"); } }
    /// <summary>
    /// Teknisyen Seçimi
    /// </summary>
            public static Guid TechnicianSelection { get { return new Guid("ca25550e-5025-4a6f-ad8f-ac1a2c54e4e3"); } }
            public static Guid ControlApproval { get { return new Guid("ca11a88d-e90c-4336-9ebb-c6f321454e94"); } }
            public static Guid Appointment { get { return new Guid("0ef07ba0-f417-4044-8622-fdf2a21c8695"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f98500a9-0e65-40a4-b0d8-fe8fa5976c19"); } }
        }

    /// <summary>
    /// Süreç içinden OrthesisProsthesisRequest get eder
    /// </summary>
        public static BindingList<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class> GetOrthesisProsthesisRequest(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].QueryDefs["GetOrthesisProsthesisRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Süreç içinden OrthesisProsthesisRequest get eder
    /// </summary>
        public static BindingList<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class> GetOrthesisProsthesisRequest(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].QueryDefs["GetOrthesisProsthesisRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OrthesisProsthesisRequest> GetLastActiveOrthesisProthesisRequest(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].QueryDefs["GetLastActiveOrthesisProthesisRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<OrthesisProsthesisRequest>(queryDef, paramList);
        }

        public static BindingList<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class> GetOrthesisRceptionReportInfo(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].QueryDefs["GetOrthesisRceptionReportInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class> GetOrthesisRceptionReportInfo(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].QueryDefs["GetOrthesisRceptionReportInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisRequest.GetOrthesisRceptionReportInfo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Şema
    /// </summary>
        public object Image
        {
            get { return (object)this["IMAGE"]; }
            set { this["IMAGE"] = value; }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public object TotalDescription
        {
            get { return (object)this["TOTALDESCRIPTION"]; }
            set { this["TOTALDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Döner Sermaye Notu
    /// </summary>
        public string FinancialDepartmentNot
        {
            get { return (string)this["FINANCIALDEPARTMENTNOT"]; }
            set { this["FINANCIALDEPARTMENTNOT"] = value; }
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
    /// Baş Teknisyen Notu
    /// </summary>
        public string ChiefTechnicianNote
        {
            get { return (string)this["CHIEFTECHNICIANNOTE"]; }
            set { this["CHIEFTECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Teknisyen Notu
    /// </summary>
        public string TechnicianNote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// İstek state inden create edilip edilmediği kontrolü için
    /// </summary>
        public bool? IsInRequest
        {
            get { return (bool?)this["ISINREQUEST"]; }
            set { this["ISINREQUEST"] = value; }
        }

    /// <summary>
    /// İstek Sebebi
    /// </summary>
        public object RequestReason
        {
            get { return (object)this["REQUESTREASON"]; }
            set { this["REQUESTREASON"] = value; }
        }

    /// <summary>
    /// Garanti Notu Açıklaması
    /// </summary>
        public string WarrantyNote
        {
            get { return (string)this["WARRANTYNOTE"]; }
            set { this["WARRANTYNOTE"] = value; }
        }

    /// <summary>
    /// İstemi Yapan Kullanıcı
    /// </summary>
        public Guid? RequesterUsr
        {
            get { return (Guid?)this["REQUESTERUSR"]; }
            set { this["REQUESTERUSR"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHospitalsUnitsCollection()
        {
            _HospitalsUnits = new OrthesisProsthesisHospitalsUnitsGrid.ChildOrthesisProsthesisHospitalsUnitsGridCollection(this, new Guid("82e83d82-ce26-4edf-9187-4df864020d6d"));
            ((ITTChildObjectCollection)_HospitalsUnits).GetChildren();
        }

        protected OrthesisProsthesisHospitalsUnitsGrid.ChildOrthesisProsthesisHospitalsUnitsGridCollection _HospitalsUnits = null;
    /// <summary>
    /// Child collection for Birimler/XXXXXXler
    /// </summary>
        public OrthesisProsthesisHospitalsUnitsGrid.ChildOrthesisProsthesisHospitalsUnitsGridCollection HospitalsUnits
        {
            get
            {
                if (_HospitalsUnits == null)
                    CreateHospitalsUnitsCollection();
                return _HospitalsUnits;
            }
        }

        virtual protected void CreateHealthComiteeMaterialsCollection()
        {
            _HealthComiteeMaterials = new OrthesisProsthesisHealthComiteeMaterial.ChildOrthesisProsthesisHealthComiteeMaterialCollection(this, new Guid("354ad832-0c2c-4397-9d7a-45b52226d6b1"));
            ((ITTChildObjectCollection)_HealthComiteeMaterials).GetChildren();
        }

        protected OrthesisProsthesisHealthComiteeMaterial.ChildOrthesisProsthesisHealthComiteeMaterialCollection _HealthComiteeMaterials = null;
    /// <summary>
    /// Child collection for Sağlık Kurulu Malzemeleri
    /// </summary>
        public OrthesisProsthesisHealthComiteeMaterial.ChildOrthesisProsthesisHealthComiteeMaterialCollection HealthComiteeMaterials
        {
            get
            {
                if (_HealthComiteeMaterials == null)
                    CreateHealthComiteeMaterialsCollection();
                return _HealthComiteeMaterials;
            }
        }

        virtual protected void CreateReturnDescriptionsCollection()
        {
            _ReturnDescriptions = new OrthesisProsthesis_ReturnDescriptionsGrid.ChildOrthesisProsthesis_ReturnDescriptionsGridCollection(this, new Guid("b1592f91-ceb0-465c-b629-e2005a0de3fd"));
            ((ITTChildObjectCollection)_ReturnDescriptions).GetChildren();
        }

        protected OrthesisProsthesis_ReturnDescriptionsGrid.ChildOrthesisProsthesis_ReturnDescriptionsGridCollection _ReturnDescriptions = null;
    /// <summary>
    /// Child collection for Ortez Protez İade Sebepleri
    /// </summary>
        public OrthesisProsthesis_ReturnDescriptionsGrid.ChildOrthesisProsthesis_ReturnDescriptionsGridCollection ReturnDescriptions
        {
            get
            {
                if (_ReturnDescriptions == null)
                    CreateReturnDescriptionsCollection();
                return _ReturnDescriptions;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _OrthesisProsthesisProcedures = new OrthesisProsthesisProcedure.ChildOrthesisProsthesisProcedureCollection(_SubactionProcedures, "OrthesisProsthesisProcedures");
        }

        private OrthesisProsthesisProcedure.ChildOrthesisProsthesisProcedureCollection _OrthesisProsthesisProcedures = null;
        public OrthesisProsthesisProcedure.ChildOrthesisProsthesisProcedureCollection OrthesisProsthesisProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _OrthesisProsthesisProcedures;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _OrthesisProthesisReqTreatmentMaterials = new OrthesisProthesisRequestTreatmentMaterial.ChildOrthesisProthesisRequestTreatmentMaterialCollection(_TreatmentMaterials, "OrthesisProthesisReqTreatmentMaterials");
            _OrthesisProsthesisRequest_OPDirectPurchaseGrids = new SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection(_TreatmentMaterials, "OrthesisProsthesisRequest_OPDirectPurchaseGrids");
            _OPRequest_CodelessMaterialDirectPurchaseGrids = new CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection(_TreatmentMaterials, "OPRequest_CodelessMaterialDirectPurchaseGrids");
        }

        private OrthesisProthesisRequestTreatmentMaterial.ChildOrthesisProthesisRequestTreatmentMaterialCollection _OrthesisProthesisReqTreatmentMaterials = null;
        public OrthesisProthesisRequestTreatmentMaterial.ChildOrthesisProthesisRequestTreatmentMaterialCollection OrthesisProthesisReqTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _OrthesisProthesisReqTreatmentMaterials;
            }            
        }

        private SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection _OrthesisProsthesisRequest_OPDirectPurchaseGrids = null;
        public SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection OrthesisProsthesisRequest_OPDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _OrthesisProsthesisRequest_OPDirectPurchaseGrids;
            }            
        }

        private CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection _OPRequest_CodelessMaterialDirectPurchaseGrids = null;
        public CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection OPRequest_CodelessMaterialDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _OPRequest_CodelessMaterialDirectPurchaseGrids;
            }            
        }

        protected OrthesisProsthesisRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrthesisProsthesisRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrthesisProsthesisRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrthesisProsthesisRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrthesisProsthesisRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTHESISPROSTHESISREQUEST", dataRow) { }
        protected OrthesisProsthesisRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTHESISPROSTHESISREQUEST", dataRow, isImported) { }
        public OrthesisProsthesisRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrthesisProsthesisRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrthesisProsthesisRequest() : base() { }

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