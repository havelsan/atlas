
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingApplication")] 

    /// <summary>
    /// Hemşirelik Hizmetlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class NursingApplication : EpisodeAction, IWorkListInpatient, IOAInPatientApplication, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        public class NursingApplicationList : TTObjectCollection<NursingApplication> { }
                    
        public class ChildNursingApplicationCollection : TTObject.TTChildObjectCollection<NursingApplication>
        {
            public ChildNursingApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingApplicationForWL_Class : TTReportNqlObject 
        {
            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public bool? Isemergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Prioritystatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? HasTightContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTIGHTCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASTIGHTCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFallingRisk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFALLINGRISK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASFALLINGRISK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasDropletIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASDROPLETISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASDROPLETISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasAirborneContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASAIRBORNECONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASAIRBORNECONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Date
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DATE"]);
                }
            }

            public Object Patientnamesurname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAMESURNAME"]);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Episodeactionname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODEACTIONNAME"]);
                }
            }

            public String Statename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Roombed
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ROOMBED"]);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Nursename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NURSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissiontype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Telno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Inppappfwl
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INPPAPPFWL"]);
                }
            }

            public PatientClassTypeEnum? Hastaturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PATIENTCLASSGROUP"].DataType;
                    return (PatientClassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ApplicationReasonEnum? Basvuruturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASVURUTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["APPLICATIONREASON"].DataType;
                    return (ApplicationReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetNursingApplicationForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingApplicationForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingApplicationForWL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyNursingAppForWL_Class : TTReportNqlObject 
        {
            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Prioritystatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Date
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DATE"]);
                }
            }

            public Object Patientnamesurname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAMESURNAME"]);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Episodeactionname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODEACTIONNAME"]);
                }
            }

            public String Statename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissiontype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Telno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientClassTypeEnum? Hastaturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PATIENTCLASSGROUP"].DataType;
                    return (PatientClassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ApplicationReasonEnum? Basvuruturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASVURUTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["APPLICATIONREASON"].DataType;
                    return (ApplicationReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetEmergencyNursingAppForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyNursingAppForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyNursingAppForWL_Class() : base() { }
        }

        public static class States
        {
            public static Guid Discharged { get { return new Guid("99744311-4e61-497a-8218-24217a4bb6e9"); } }
            public static Guid PreDischarged { get { return new Guid("218e7b51-a99e-4706-8cbf-3d2eab933aa1"); } }
            public static Guid Application { get { return new Guid("9431b925-023e-41cf-8681-e558c8e337ef"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("e7c44e36-442e-418a-8524-50e228fbf76f"); } }
        }

        public static BindingList<NursingApplication.GetNursingApplicationForWL_Class> GetNursingApplicationForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLICATION"].QueryDefs["GetNursingApplicationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingApplication.GetNursingApplicationForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingApplication.GetNursingApplicationForWL_Class> GetNursingApplicationForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLICATION"].QueryDefs["GetNursingApplicationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingApplication.GetNursingApplicationForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingApplication.GetEmergencyNursingAppForWL_Class> GetEmergencyNursingAppForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLICATION"].QueryDefs["GetEmergencyNursingAppForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingApplication.GetEmergencyNursingAppForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NursingApplication.GetEmergencyNursingAppForWL_Class> GetEmergencyNursingAppForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLICATION"].QueryDefs["GetEmergencyNursingAppForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NursingApplication.GetEmergencyNursingAppForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public InPatientTreatmentClinicApplication InPatientTreatmentClinicApp
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("INPATIENTTREATMENTCLINICAPP"); }
            set { this["INPATIENTTREATMENTCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EmergencyIntervention EmergencyIntervention
        {
            get { return (EmergencyIntervention)((ITTObject)this).GetParent("EMERGENCYINTERVENTION"); }
            set { this["EMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNursingOrdersCollection()
        {
            _NursingOrders = new NursingOrder.ChildNursingOrderCollection(this, new Guid("18fdbe7b-b9b4-4108-a46e-2b53dd36e9b8"));
            ((ITTChildObjectCollection)_NursingOrders).GetChildren();
        }

        protected NursingOrder.ChildNursingOrderCollection _NursingOrders = null;
        public NursingOrder.ChildNursingOrderCollection NursingOrders
        {
            get
            {
                if (_NursingOrders == null)
                    CreateNursingOrdersCollection();
                return _NursingOrders;
            }
        }

        virtual protected void CreateDayToDayInvestigationsCollection()
        {
            _DayToDayInvestigations = new NursingDayToDayInvestigation.ChildNursingDayToDayInvestigationCollection(this, new Guid("c12cb480-6649-40b9-a540-3faa73810dee"));
            ((ITTChildObjectCollection)_DayToDayInvestigations).GetChildren();
        }

        protected NursingDayToDayInvestigation.ChildNursingDayToDayInvestigationCollection _DayToDayInvestigations = null;
    /// <summary>
    /// Child collection for Günlük Gözlem
    /// </summary>
        public NursingDayToDayInvestigation.ChildNursingDayToDayInvestigationCollection DayToDayInvestigations
        {
            get
            {
                if (_DayToDayInvestigations == null)
                    CreateDayToDayInvestigationsCollection();
                return _DayToDayInvestigations;
            }
        }

        virtual protected void CreateDrugOrdersCollection()
        {
            _DrugOrders = new DrugOrder.ChildDrugOrderCollection(this, new Guid("36b6e3df-f4c4-4de3-a570-42af25e6433d"));
            ((ITTChildObjectCollection)_DrugOrders).GetChildren();
        }

        protected DrugOrder.ChildDrugOrderCollection _DrugOrders = null;
        public DrugOrder.ChildDrugOrderCollection DrugOrders
        {
            get
            {
                if (_DrugOrders == null)
                    CreateDrugOrdersCollection();
                return _DrugOrders;
            }
        }

        virtual protected void CreateWaterlowRisksCollection()
        {
            _WaterlowRisks = new NursingWaterlowRisk.ChildNursingWaterlowRiskCollection(this, new Guid("5e23a4df-07ba-4ebd-a04a-b7a3805913fc"));
            ((ITTChildObjectCollection)_WaterlowRisks).GetChildren();
        }

        protected NursingWaterlowRisk.ChildNursingWaterlowRiskCollection _WaterlowRisks = null;
    /// <summary>
    /// Child collection for Waterlow Bası Riski
    /// </summary>
        public NursingWaterlowRisk.ChildNursingWaterlowRiskCollection WaterlowRisks
        {
            get
            {
                if (_WaterlowRisks == null)
                    CreateWaterlowRisksCollection();
                return _WaterlowRisks;
            }
        }

        virtual protected void CreateDrugOrderDetailsCollection()
        {
            _DrugOrderDetails = new DrugOrderDetail.ChildDrugOrderDetailCollection(this, new Guid("e9b8031b-c6fd-4393-b1fa-c0cc9fb8898e"));
            ((ITTChildObjectCollection)_DrugOrderDetails).GetChildren();
        }

        protected DrugOrderDetail.ChildDrugOrderDetailCollection _DrugOrderDetails = null;
        public DrugOrderDetail.ChildDrugOrderDetailCollection DrugOrderDetails
        {
            get
            {
                if (_DrugOrderDetails == null)
                    CreateDrugOrderDetailsCollection();
                return _DrugOrderDetails;
            }
        }

        virtual protected void CreatePatientBruiseAssessmentTracingsCollection()
        {
            _PatientBruiseAssessmentTracings = new NursingPatientBruiseAssessmentTracing.ChildNursingPatientBruiseAssessmentTracingCollection(this, new Guid("313e3a06-fd6b-4ff4-b519-d2cec6d6f7cf"));
            ((ITTChildObjectCollection)_PatientBruiseAssessmentTracings).GetChildren();
        }

        protected NursingPatientBruiseAssessmentTracing.ChildNursingPatientBruiseAssessmentTracingCollection _PatientBruiseAssessmentTracings = null;
    /// <summary>
    /// Child collection for Hasta Yara Değerlendirme Takipi
    /// </summary>
        public NursingPatientBruiseAssessmentTracing.ChildNursingPatientBruiseAssessmentTracingCollection PatientBruiseAssessmentTracings
        {
            get
            {
                if (_PatientBruiseAssessmentTracings == null)
                    CreatePatientBruiseAssessmentTracingsCollection();
                return _PatientBruiseAssessmentTracings;
            }
        }

        virtual protected void CreateTakeInTakeOutsCollection()
        {
            _TakeInTakeOuts = new NursingTakeInTakeOut.ChildNursingTakeInTakeOutCollection(this, new Guid("aac3b8c4-55a7-4505-ac13-9b01939b8764"));
            ((ITTChildObjectCollection)_TakeInTakeOuts).GetChildren();
        }

        protected NursingTakeInTakeOut.ChildNursingTakeInTakeOutCollection _TakeInTakeOuts = null;
    /// <summary>
    /// Child collection for Aldığı Çıkardığı
    /// </summary>
        public NursingTakeInTakeOut.ChildNursingTakeInTakeOutCollection TakeInTakeOuts
        {
            get
            {
                if (_TakeInTakeOuts == null)
                    CreateTakeInTakeOutsCollection();
                return _TakeInTakeOuts;
            }
        }

        virtual protected void CreateBaseNursingDataEntriesCollectionViews()
        {
            _NursingNutritionalRiskAssessments = new NursingNutritionalRiskAssessment.ChildNursingNutritionalRiskAssessmentCollection(_BaseNursingDataEntries, "NursingNutritionalRiskAssessments");
            _BodilyFluidIntakeOutputs = new NursingBodilyFluidIntakeOutput.ChildNursingBodilyFluidIntakeOutputCollection(_BaseNursingDataEntries, "BodilyFluidIntakeOutputs");
            _GlaskowComaScales = new NursingGlaskowComaScale.ChildNursingGlaskowComaScaleCollection(_BaseNursingDataEntries, "GlaskowComaScales");
            _Progresses = new NursingAppliProgress.ChildNursingAppliProgressCollection(_BaseNursingDataEntries, "Progresses");
            _PupilSymptoms = new NursingPupilSymptoms.ChildNursingPupilSymptomsCollection(_BaseNursingDataEntries, "PupilSymptoms");
            _DailyLifeActivities = new NursingDailyLifeActivity.ChildNursingDailyLifeActivityCollection(_BaseNursingDataEntries, "DailyLifeActivities");
            _BaseNursingPatientAndFamilyInstructions = new BaseNursingPatientAndFamilyInstruction.ChildBaseNursingPatientAndFamilyInstructionCollection(_BaseNursingDataEntries, "BaseNursingPatientAndFamilyInstructions");
            _BaseNursingSystemInterrogations = new BaseNursingSystemInterrogation.ChildBaseNursingSystemInterrogationCollection(_BaseNursingDataEntries, "BaseNursingSystemInterrogations");
            _BaseNursingDischargingInstructionPlans = new BaseNursingDischargingInstructionPlan.ChildBaseNursingDischargingInstructionPlanCollection(_BaseNursingDataEntries, "BaseNursingDischargingInstructionPlans");
            _BaseNursingFallingDownRisks = new BaseNursingFallingDownRisk.ChildBaseNursingFallingDownRiskCollection(_BaseNursingDataEntries, "BaseNursingFallingDownRisks");
            _WoundAssessmentScales = new NursingWoundAssessmentScale.ChildNursingWoundAssessmentScaleCollection(_BaseNursingDataEntries, "WoundAssessmentScales");
            _LegMeasurements = new NursingLegMeasurement.ChildNursingLegMeasurementCollection(_BaseNursingDataEntries, "LegMeasurements");
            _NursingBodyFluidAnalysis = new NursingBodyFluidAnalysis.ChildNursingBodyFluidAnalysisCollection(_BaseNursingDataEntries, "NursingBodyFluidAnalysis");
            _PatientPreAssessments = new NursingPatientPreAssessment.ChildNursingPatientPreAssessmentCollection(_BaseNursingDataEntries, "PatientPreAssessments");
            _PainScales = new NursingPainScale.ChildNursingPainScaleCollection(_BaseNursingDataEntries, "PainScales");
            _SpiritualEvaluations = new NursingSpiritualEvaluation.ChildNursingSpiritualEvaluationCollection(_BaseNursingDataEntries, "SpiritualEvaluations");
            _NutritionAssessments = new NursingNutritionAssessment.ChildNursingNutritionAssessmentCollection(_BaseNursingDataEntries, "NutritionAssessments");
            _NursingCares = new NursingCare.ChildNursingCareCollection(_BaseNursingDataEntries, "NursingCares");
            _WoundAssesments = new NursingWoundedAssesment.ChildNursingWoundedAssesmentCollection(_BaseNursingDataEntries, "WoundAssesments");
        }

        virtual protected void CreateBaseNursingDataEntriesCollection()
        {
            _BaseNursingDataEntries = new BaseNursingDataEntry.ChildBaseNursingDataEntryCollection(this, new Guid("be7b8deb-e3ae-4730-bc06-026cecf53c59"));
            CreateBaseNursingDataEntriesCollectionViews();
            ((ITTChildObjectCollection)_BaseNursingDataEntries).GetChildren();
        }

        protected BaseNursingDataEntry.ChildBaseNursingDataEntryCollection _BaseNursingDataEntries = null;
        public BaseNursingDataEntry.ChildBaseNursingDataEntryCollection BaseNursingDataEntries
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _BaseNursingDataEntries;
            }
        }

        private NursingNutritionalRiskAssessment.ChildNursingNutritionalRiskAssessmentCollection _NursingNutritionalRiskAssessments = null;
        public NursingNutritionalRiskAssessment.ChildNursingNutritionalRiskAssessmentCollection NursingNutritionalRiskAssessments
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _NursingNutritionalRiskAssessments;
            }            
        }

        private NursingBodilyFluidIntakeOutput.ChildNursingBodilyFluidIntakeOutputCollection _BodilyFluidIntakeOutputs = null;
        public NursingBodilyFluidIntakeOutput.ChildNursingBodilyFluidIntakeOutputCollection BodilyFluidIntakeOutputs
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _BodilyFluidIntakeOutputs;
            }            
        }

        private NursingGlaskowComaScale.ChildNursingGlaskowComaScaleCollection _GlaskowComaScales = null;
        public NursingGlaskowComaScale.ChildNursingGlaskowComaScaleCollection GlaskowComaScales
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _GlaskowComaScales;
            }            
        }

        private NursingAppliProgress.ChildNursingAppliProgressCollection _Progresses = null;
        public NursingAppliProgress.ChildNursingAppliProgressCollection Progresses
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _Progresses;
            }            
        }

        private NursingPupilSymptoms.ChildNursingPupilSymptomsCollection _PupilSymptoms = null;
        public NursingPupilSymptoms.ChildNursingPupilSymptomsCollection PupilSymptoms
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _PupilSymptoms;
            }            
        }

        private NursingDailyLifeActivity.ChildNursingDailyLifeActivityCollection _DailyLifeActivities = null;
        public NursingDailyLifeActivity.ChildNursingDailyLifeActivityCollection DailyLifeActivities
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _DailyLifeActivities;
            }            
        }

        private BaseNursingPatientAndFamilyInstruction.ChildBaseNursingPatientAndFamilyInstructionCollection _BaseNursingPatientAndFamilyInstructions = null;
        public BaseNursingPatientAndFamilyInstruction.ChildBaseNursingPatientAndFamilyInstructionCollection BaseNursingPatientAndFamilyInstructions
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _BaseNursingPatientAndFamilyInstructions;
            }            
        }

        private BaseNursingSystemInterrogation.ChildBaseNursingSystemInterrogationCollection _BaseNursingSystemInterrogations = null;
        public BaseNursingSystemInterrogation.ChildBaseNursingSystemInterrogationCollection BaseNursingSystemInterrogations
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _BaseNursingSystemInterrogations;
            }            
        }

        private BaseNursingDischargingInstructionPlan.ChildBaseNursingDischargingInstructionPlanCollection _BaseNursingDischargingInstructionPlans = null;
        public BaseNursingDischargingInstructionPlan.ChildBaseNursingDischargingInstructionPlanCollection BaseNursingDischargingInstructionPlans
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _BaseNursingDischargingInstructionPlans;
            }            
        }

        private BaseNursingFallingDownRisk.ChildBaseNursingFallingDownRiskCollection _BaseNursingFallingDownRisks = null;
        public BaseNursingFallingDownRisk.ChildBaseNursingFallingDownRiskCollection BaseNursingFallingDownRisks
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _BaseNursingFallingDownRisks;
            }            
        }

        private NursingWoundAssessmentScale.ChildNursingWoundAssessmentScaleCollection _WoundAssessmentScales = null;
        public NursingWoundAssessmentScale.ChildNursingWoundAssessmentScaleCollection WoundAssessmentScales
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _WoundAssessmentScales;
            }            
        }

        private NursingLegMeasurement.ChildNursingLegMeasurementCollection _LegMeasurements = null;
        public NursingLegMeasurement.ChildNursingLegMeasurementCollection LegMeasurements
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _LegMeasurements;
            }            
        }

        private NursingBodyFluidAnalysis.ChildNursingBodyFluidAnalysisCollection _NursingBodyFluidAnalysis = null;
        public NursingBodyFluidAnalysis.ChildNursingBodyFluidAnalysisCollection NursingBodyFluidAnalysis
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _NursingBodyFluidAnalysis;
            }            
        }

        private NursingPatientPreAssessment.ChildNursingPatientPreAssessmentCollection _PatientPreAssessments = null;
        public NursingPatientPreAssessment.ChildNursingPatientPreAssessmentCollection PatientPreAssessments
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _PatientPreAssessments;
            }            
        }

        private NursingPainScale.ChildNursingPainScaleCollection _PainScales = null;
        public NursingPainScale.ChildNursingPainScaleCollection PainScales
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _PainScales;
            }            
        }

        private NursingSpiritualEvaluation.ChildNursingSpiritualEvaluationCollection _SpiritualEvaluations = null;
        public NursingSpiritualEvaluation.ChildNursingSpiritualEvaluationCollection SpiritualEvaluations
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _SpiritualEvaluations;
            }            
        }

        private NursingNutritionAssessment.ChildNursingNutritionAssessmentCollection _NutritionAssessments = null;
        public NursingNutritionAssessment.ChildNursingNutritionAssessmentCollection NutritionAssessments
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _NutritionAssessments;
            }            
        }

        private NursingCare.ChildNursingCareCollection _NursingCares = null;
        public NursingCare.ChildNursingCareCollection NursingCares
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _NursingCares;
            }            
        }

        private NursingWoundedAssesment.ChildNursingWoundedAssesmentCollection _WoundAssesments = null;
        public NursingWoundedAssesment.ChildNursingWoundedAssesmentCollection WoundAssesments
        {
            get
            {
                if (_BaseNursingDataEntries == null)
                    CreateBaseNursingDataEntriesCollection();
                return _WoundAssesments;
            }            
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _NursingAdditionalApps = new NursingAdditionalApp.ChildNursingAdditionalAppCollection(_SubactionProcedures, "NursingAdditionalApps");
            _NursingProcedures = new NursingApplicationNursingProcedure.ChildNursingApplicationNursingProcedureCollection(_SubactionProcedures, "NursingProcedures");
            _NursingApplicationNursingOrderDetails = new NursingOrderDetail.ChildNursingOrderDetailCollection(_SubactionProcedures, "NursingApplicationNursingOrderDetails");
        }

        private NursingAdditionalApp.ChildNursingAdditionalAppCollection _NursingAdditionalApps = null;
        public NursingAdditionalApp.ChildNursingAdditionalAppCollection NursingAdditionalApps
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _NursingAdditionalApps;
            }            
        }

        private NursingApplicationNursingProcedure.ChildNursingApplicationNursingProcedureCollection _NursingProcedures = null;
        public NursingApplicationNursingProcedure.ChildNursingApplicationNursingProcedureCollection NursingProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _NursingProcedures;
            }            
        }

        private NursingOrderDetail.ChildNursingOrderDetailCollection _NursingApplicationNursingOrderDetails = null;
        public NursingOrderDetail.ChildNursingOrderDetailCollection NursingApplicationNursingOrderDetails
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _NursingApplicationNursingOrderDetails;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _NursingApplicationTreatmentMaterials = new NursingApplicationTreatmentMaterial.ChildNursingApplicationTreatmentMaterialCollection(_TreatmentMaterials, "NursingApplicationTreatmentMaterials");
        }

        private NursingApplicationTreatmentMaterial.ChildNursingApplicationTreatmentMaterialCollection _NursingApplicationTreatmentMaterials = null;
        public NursingApplicationTreatmentMaterial.ChildNursingApplicationTreatmentMaterialCollection NursingApplicationTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _NursingApplicationTreatmentMaterials;
            }            
        }

        protected NursingApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGAPPLICATION", dataRow) { }
        protected NursingApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGAPPLICATION", dataRow, isImported) { }
        public NursingApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingApplication() : base() { }

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