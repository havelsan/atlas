
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyIntervention")] 

    /// <summary>
    /// Acil Hasta Müdahale İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
    public  partial class EmergencyIntervention : EpisodeAction, IAllocateSpeciality, IOAExamination, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        public class EmergencyInterventionList : TTObjectCollection<EmergencyIntervention> { }
                    
        public class ChildEmergencyInterventionCollection : TTObject.TTChildObjectCollection<EmergencyIntervention>
        {
            public ChildEmergencyInterventionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyInterventionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetEmergencyObservation_Class : TTReportNqlObject 
        {
            public Object Observationcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OBSERVATIONCOUNT"]);
                }
            }

            public OLAP_GetEmergencyObservation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetEmergencyObservation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetEmergencyObservation_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByEpisodeInfo_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object PatientHistoryDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORYDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PATIENTHISTORYDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string BringerAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRINGERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["BRINGERADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BringerPhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRINGERPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["BRINGERPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object ContinuousDrugs
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTINUOUSDRUGS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Habits
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HABITS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["HABITS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BringerName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRINGERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["BRINGERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Picture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsTraumaticPatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTRAUMATICPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISTRAUMATICPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EnteranceTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTERANCETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ENTERANCETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object InPatientFolder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTFOLDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["INPATIENTFOLDER"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsEmergencyInjured
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYINJURED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISEMERGENCYINJURED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsEmergencyDispatched
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYDISPATCHED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISEMERGENCYDISPATCHED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DischargeTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["DISCHARGETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPatientApprovalFormGiven
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPATIENTAPPROVALFORMGIVEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISPATIENTAPPROVALFORMGIVEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string LastEatingInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTEATINGINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["LASTEATINGINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? AlcoholPromile
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALCOHOLPROMILE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ALCOHOLPROMILE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? TetanusVaccine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETANUSVACCINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["TETANUSVACCINE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["COMPLAINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object ComplaintDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["COMPLAINTDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ComplaintDuration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["COMPLAINTDURATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? InpatientObservationTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTOBSERVATIONTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["INPATIENTOBSERVATIONTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPregnant
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPREGNANT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISPREGNANT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMenstrualPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMENSTRUALPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["LASTMENSTRUALPERIOD"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object AllergyDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLERGYDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ALLERGYDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? InterventionStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERVENTIONSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["INTERVENTIONSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? InterventionEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERVENTIONENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["INTERVENTIONENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetByEpisodeInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByEpisodeInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByEpisodeInfo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeAndPatientInfoAccordingToDiagnosis_Class : TTReportNqlObject 
        {
            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Yabancisicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCISICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? Yabancimi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Diagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEpisodeAndPatientInfoAccordingToDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeAndPatientInfoAccordingToDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeAndPatientInfoAccordingToDiagnosis_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeAndPatientInfo_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EnteranceTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTERANCETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ENTERANCETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DischargeTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["DISCHARGETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Yabancisicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCISICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? Yabancimi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YABANCIMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Sosyalguvenlikkurumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SOSYALGUVENLIKKURUMU"]);
                }
            }

            public GetEpisodeAndPatientInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeAndPatientInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeAndPatientInfo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyInterventionsByDateForReport_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object PatientHistoryDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORYDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PATIENTHISTORYDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string BringerAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRINGERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["BRINGERADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BringerPhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRINGERPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["BRINGERPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object ContinuousDrugs
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTINUOUSDRUGS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Habits
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HABITS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["HABITS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BringerName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRINGERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["BRINGERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Picture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsTraumaticPatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTRAUMATICPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISTRAUMATICPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EnteranceTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTERANCETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ENTERANCETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object InPatientFolder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTFOLDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["INPATIENTFOLDER"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsEmergencyInjured
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYINJURED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISEMERGENCYINJURED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsEmergencyDispatched
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYDISPATCHED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISEMERGENCYDISPATCHED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DischargeTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["DISCHARGETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPatientApprovalFormGiven
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPATIENTAPPROVALFORMGIVEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISPATIENTAPPROVALFORMGIVEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string LastEatingInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTEATINGINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["LASTEATINGINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? AlcoholPromile
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALCOHOLPROMILE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ALCOHOLPROMILE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? TetanusVaccine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TETANUSVACCINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["TETANUSVACCINE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["COMPLAINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object ComplaintDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["COMPLAINTDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ComplaintDuration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["COMPLAINTDURATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? InpatientObservationTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTOBSERVATIONTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["INPATIENTOBSERVATIONTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPregnant
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPREGNANT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ISPREGNANT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMenstrualPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMENSTRUALPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["LASTMENSTRUALPERIOD"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object AllergyDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLERGYDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ALLERGYDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? InterventionStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERVENTIONSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["INTERVENTIONSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? InterventionEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERVENTIONENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["INTERVENTIONENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Objectid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID1"]);
                }
            }

            public GetEmergencyInterventionsByDateForReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyInterventionsByDateForReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyInterventionsByDateForReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergenvyInterventionStatistic_Class : TTReportNqlObject 
        {
            public long? Sirano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIRANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Musahedealinis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUSAHEDEALINIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ENTERANCETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Musahedecikis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUSAHEDECIKIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["DISCHARGETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public DateTime? Kabultarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dogumtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Doktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetEmergenvyInterventionStatistic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergenvyInterventionStatistic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergenvyInterventionStatistic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyInterventionForm_Class : TTReportNqlObject 
        {
            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
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

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ADI
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
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

            public DateTime? EnteranceTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTERANCETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ENTERANCETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public object Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Inpphyappid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INPPHYAPPID"]);
                }
            }

            public Guid? Subepisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public GetEmergencyInterventionForm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyInterventionForm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyInterventionForm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyIntByPA_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Triage
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TRIAGE"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetEmergencyIntByPA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyIntByPA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyIntByPA_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyInterventionForWL_Class : TTReportNqlObject 
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

            public Object Isemergency
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISEMERGENCY"]);
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

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Triage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRIAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTRIAJKODU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Examinationprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetEmergencyInterventionForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyInterventionForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyInterventionForWL_Class() : base() { }
        }

        public static class States
        {
            public static Guid Triage { get { return new Guid("dc998a28-e0ea-4da4-bbe5-2252b3ea1aa1"); } }
            public static Guid Observation { get { return new Guid("3c34be65-a177-4e97-aa17-6db39c457e65"); } }
            public static Guid Completed { get { return new Guid("4275f53b-7be4-46dc-8ab7-8c1350bfe427"); } }
            public static Guid Cancelled { get { return new Guid("b95188ba-5d9e-4013-9946-e86791fcc65c"); } }
    /// <summary>
    /// Hasta Gelmedi
    /// </summary>
            public static Guid Missing { get { return new Guid("76f3d3d4-5b82-4a35-b52a-8e93ffb3092b"); } }
    /// <summary>
    /// Müşahede
    /// </summary>
            public static Guid InpatientObservation { get { return new Guid("a3c8ed2d-b94e-4081-91a9-f60e09668b2c"); } }
        }

        public static BindingList<EmergencyIntervention> GetByEpisode(TTObjectContext objectContext, string PARAMEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISODE", PARAMEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<EmergencyIntervention>(queryDef, paramList);
        }

        public static BindingList<EmergencyIntervention.OLAP_GetEmergencyObservation_Class> OLAP_GetEmergencyObservation(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["OLAP_GetEmergencyObservation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.OLAP_GetEmergencyObservation_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.OLAP_GetEmergencyObservation_Class> OLAP_GetEmergencyObservation(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["OLAP_GetEmergencyObservation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.OLAP_GetEmergencyObservation_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetByEpisodeInfo_Class> GetByEpisodeInfo(string PARAMEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetByEpisodeInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISODE", PARAMEPISODE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetByEpisodeInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetByEpisodeInfo_Class> GetByEpisodeInfo(TTObjectContext objectContext, string PARAMEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetByEpisodeInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISODE", PARAMEPISODE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetByEpisodeInfo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention> GetEmergencyInterventionsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyInterventionsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<EmergencyIntervention>(queryDef, paramList);
        }

        public static BindingList<EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis_Class> GetEpisodeAndPatientInfoAccordingToDiagnosis(DateTime STARTDATE, DateTime ENDDATE, IList<string> DIAGNOSIS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEpisodeAndPatientInfoAccordingToDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DIAGNOSIS", DIAGNOSIS);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis_Class> GetEpisodeAndPatientInfoAccordingToDiagnosis(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> DIAGNOSIS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEpisodeAndPatientInfoAccordingToDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DIAGNOSIS", DIAGNOSIS);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEpisodeAndPatientInfo_Class> GetEpisodeAndPatientInfo(string PARAMEPISPODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEpisodeAndPatientInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISPODE", PARAMEPISPODE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEpisodeAndPatientInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEpisodeAndPatientInfo_Class> GetEpisodeAndPatientInfo(TTObjectContext objectContext, string PARAMEPISPODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEpisodeAndPatientInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISPODE", PARAMEPISPODE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEpisodeAndPatientInfo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class> GetEmergencyInterventionsByDateForReport(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyInterventionsByDateForReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class> GetEmergencyInterventionsByDateForReport(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyInterventionsByDateForReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergenvyInterventionStatistic_Class> GetEmergenvyInterventionStatistic(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergenvyInterventionStatistic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergenvyInterventionStatistic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergenvyInterventionStatistic_Class> GetEmergenvyInterventionStatistic(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergenvyInterventionStatistic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergenvyInterventionStatistic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergencyInterventionForm_Class> GetEmergencyInterventionForm(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyInterventionForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergencyInterventionForm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergencyInterventionForm_Class> GetEmergencyInterventionForm(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyInterventionForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergencyInterventionForm_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergencyIntByPA_Class> GetEmergencyIntByPA(string PATIENTADMISSIN, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyIntByPA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTADMISSIN", PATIENTADMISSIN);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergencyIntByPA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergencyIntByPA_Class> GetEmergencyIntByPA(TTObjectContext objectContext, string PATIENTADMISSIN, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyIntByPA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTADMISSIN", PATIENTADMISSIN);

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergencyIntByPA_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergencyInterventionForWL_Class> GetEmergencyInterventionForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyInterventionForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergencyInterventionForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EmergencyIntervention.GetEmergencyInterventionForWL_Class> GetEmergencyInterventionForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyInterventionForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EmergencyIntervention.GetEmergencyInterventionForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EmergencyIntervention> GetEmergencyIntByObservationTime(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYINTERVENTION"].QueryDefs["GetEmergencyIntByObservationTime"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<EmergencyIntervention>(queryDef, paramList);
        }

    /// <summary>
    /// Hasta Özgeçmiş Açıklaması
    /// </summary>
        public object PatientHistoryDescription
        {
            get { return (object)this["PATIENTHISTORYDESCRIPTION"]; }
            set { this["PATIENTHISTORYDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Getirenin Adresi
    /// </summary>
        public string BringerAddress
        {
            get { return (string)this["BRINGERADDRESS"]; }
            set { this["BRINGERADDRESS"] = value; }
        }

    /// <summary>
    /// Getirenin Telefonu
    /// </summary>
        public string BringerPhone
        {
            get { return (string)this["BRINGERPHONE"]; }
            set { this["BRINGERPHONE"] = value; }
        }

    /// <summary>
    /// Devamlı İlaçlar
    /// </summary>
        public object ContinuousDrugs
        {
            get { return (object)this["CONTINUOUSDRUGS"]; }
            set { this["CONTINUOUSDRUGS"] = value; }
        }

    /// <summary>
    /// Alışkanlıklar
    /// </summary>
        public object Habits
        {
            get { return (object)this["HABITS"]; }
            set { this["HABITS"] = value; }
        }

    /// <summary>
    /// Özgeçmiş / Soygeçmiş
    /// </summary>
        public string PatientHistory
        {
            get { return (string)this["PATIENTHISTORY"]; }
            set { this["PATIENTHISTORY"] = value; }
        }

    /// <summary>
    /// Getirenin Adı
    /// </summary>
        public string BringerName
        {
            get { return (string)this["BRINGERNAME"]; }
            set { this["BRINGERNAME"] = value; }
        }

    /// <summary>
    /// Resim
    /// </summary>
        public object Picture
        {
            get { return (object)this["PICTURE"]; }
            set { this["PICTURE"] = value; }
        }

    /// <summary>
    /// Travma Hastası
    /// </summary>
        public bool? IsTraumaticPatient
        {
            get { return (bool?)this["ISTRAUMATICPATIENT"]; }
            set { this["ISTRAUMATICPATIENT"] = value; }
        }

    /// <summary>
    /// Giriş Tarihi
    /// </summary>
        public DateTime? EnteranceTime
        {
            get { return (DateTime?)this["ENTERANCETIME"]; }
            set { this["ENTERANCETIME"] = value; }
        }

        public object InPatientFolder
        {
            get { return (object)this["INPATIENTFOLDER"]; }
            set { this["INPATIENTFOLDER"] = value; }
        }

    /// <summary>
    /// Acil (Çatışma/Kaza/İntihar) İlk Müdahale
    /// </summary>
        public bool? IsEmergencyInjured
        {
            get { return (bool?)this["ISEMERGENCYINJURED"]; }
            set { this["ISEMERGENCYINJURED"] = value; }
        }

    /// <summary>
    /// Acil (Sevkle Gelen)
    /// </summary>
        public bool? IsEmergencyDispatched
        {
            get { return (bool?)this["ISEMERGENCYDISPATCHED"]; }
            set { this["ISEMERGENCYDISPATCHED"] = value; }
        }

    /// <summary>
    /// Çıkış Tarihi
    /// </summary>
        public DateTime? DischargeTime
        {
            get { return (DateTime?)this["DISCHARGETIME"]; }
            set { this["DISCHARGETIME"] = value; }
        }

    /// <summary>
    /// Aydınlatılmış Onam Formu Verildi
    /// </summary>
        public bool? IsPatientApprovalFormGiven
        {
            get { return (bool?)this["ISPATIENTAPPROVALFORMGIVEN"]; }
            set { this["ISPATIENTAPPROVALFORMGIVEN"] = value; }
        }

        public string LastEatingInfo
        {
            get { return (string)this["LASTEATINGINFO"]; }
            set { this["LASTEATINGINFO"] = value; }
        }

        public int? AlcoholPromile
        {
            get { return (int?)this["ALCOHOLPROMILE"]; }
            set { this["ALCOHOLPROMILE"] = value; }
        }

        public bool? TetanusVaccine
        {
            get { return (bool?)this["TETANUSVACCINE"]; }
            set { this["TETANUSVACCINE"] = value; }
        }

    /// <summary>
    /// Şikayet
    /// </summary>
        public string Complaint
        {
            get { return (string)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Şikayet Açıklama
    /// </summary>
        public object ComplaintDescription
        {
            get { return (object)this["COMPLAINTDESCRIPTION"]; }
            set { this["COMPLAINTDESCRIPTION"] = value; }
        }

        public string ComplaintDuration
        {
            get { return (string)this["COMPLAINTDURATION"]; }
            set { this["COMPLAINTDURATION"] = value; }
        }

    /// <summary>
    /// Müşade Tarihi
    /// </summary>
        public DateTime? InpatientObservationTime
        {
            get { return (DateTime?)this["INPATIENTOBSERVATIONTIME"]; }
            set { this["INPATIENTOBSERVATIONTIME"] = value; }
        }

    /// <summary>
    /// Hamile
    /// </summary>
        public bool? IsPregnant
        {
            get { return (bool?)this["ISPREGNANT"]; }
            set { this["ISPREGNANT"] = value; }
        }

    /// <summary>
    /// Son Adet Tarihi
    /// </summary>
        public DateTime? LastMenstrualPeriod
        {
            get { return (DateTime?)this["LASTMENSTRUALPERIOD"]; }
            set { this["LASTMENSTRUALPERIOD"] = value; }
        }

    /// <summary>
    /// Alerji Açıklaması
    /// </summary>
        public object AllergyDescription
        {
            get { return (object)this["ALLERGYDESCRIPTION"]; }
            set { this["ALLERGYDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Triaj odasına girdiği saat/Entreancetime ile farklı olabilir
    /// </summary>
        public DateTime? InterventionStartTime
        {
            get { return (DateTime?)this["INTERVENTIONSTARTTIME"]; }
            set { this["INTERVENTIONSTARTTIME"] = value; }
        }

    /// <summary>
    /// Triaj odasından çıktığı saat/Dischargetime ile farklı olabilir
    /// </summary>
        public DateTime? InterventionEndTime
        {
            get { return (DateTime?)this["INTERVENTIONENDTIME"]; }
            set { this["INTERVENTIONENDTIME"] = value; }
        }

    /// <summary>
    /// Sorumlu Hemşire
    /// </summary>
        public ResUser ResponsibleNurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLENURSE"); }
            set { this["RESPONSIBLENURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MuayeneGiris MuayeneGiris
        {
            get { return (MuayeneGiris)((ITTObject)this).GetParent("MUAYENEGIRIS"); }
            set { this["MUAYENEGIRIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sorumlu Doktor
    /// </summary>
        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Acil Triaj
    /// </summary>
        public SKRSTRIAJKODU Triage
        {
            get { return (SKRSTRIAJKODU)((ITTObject)this).GetParent("TRIAGE"); }
            set { this["TRIAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ImportantMedicalInformation ImportantMedicalInformation
        {
            get { return (ImportantMedicalInformation)((ITTObject)this).GetParent("IMPORTANTMEDICALINFORMATION"); }
            set { this["IMPORTANTMEDICALINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Eski Acil Triaj bilgisi
    /// </summary>
        public SKRSTRIAJKODU OldTriage
        {
            get { return (SKRSTRIAJKODU)((ITTObject)this).GetParent("OLDTRIAGE"); }
            set { this["OLDTRIAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateConsultationsCollection()
        {
            _Consultations = new Consultation.ChildConsultationCollection(this, new Guid("288ce477-ab06-4145-b018-4ededb2e2cf3"));
            ((ITTChildObjectCollection)_Consultations).GetChildren();
        }

        protected Consultation.ChildConsultationCollection _Consultations = null;
        public Consultation.ChildConsultationCollection Consultations
        {
            get
            {
                if (_Consultations == null)
                    CreateConsultationsCollection();
                return _Consultations;
            }
        }

        virtual protected void CreateProgressCollection()
        {
            _Progress = new EmergencyInterventionProgress.ChildEmergencyInterventionProgressCollection(this, new Guid("9774afed-d564-4472-8fd1-7aa6595fbd45"));
            ((ITTChildObjectCollection)_Progress).GetChildren();
        }

        protected EmergencyInterventionProgress.ChildEmergencyInterventionProgressCollection _Progress = null;
    /// <summary>
    /// Child collection for Müşahade Sekmesi
    /// </summary>
        public EmergencyInterventionProgress.ChildEmergencyInterventionProgressCollection Progress
        {
            get
            {
                if (_Progress == null)
                    CreateProgressCollection();
                return _Progress;
            }
        }

        virtual protected void CreateEmergencyInterventionClinicalDecisionsCollection()
        {
            _EmergencyInterventionClinicalDecisions = new EmergencyInterventionClinicalDecision.ChildEmergencyInterventionClinicalDecisionCollection(this, new Guid("67c36110-c3bd-4aba-8d8a-9b75aad34b91"));
            ((ITTChildObjectCollection)_EmergencyInterventionClinicalDecisions).GetChildren();
        }

        protected EmergencyInterventionClinicalDecision.ChildEmergencyInterventionClinicalDecisionCollection _EmergencyInterventionClinicalDecisions = null;
        public EmergencyInterventionClinicalDecision.ChildEmergencyInterventionClinicalDecisionCollection EmergencyInterventionClinicalDecisions
        {
            get
            {
                if (_EmergencyInterventionClinicalDecisions == null)
                    CreateEmergencyInterventionClinicalDecisionsCollection();
                return _EmergencyInterventionClinicalDecisions;
            }
        }

        virtual protected void CreateNursingApplicationsCollection()
        {
            _NursingApplications = new NursingApplication.ChildNursingApplicationCollection(this, new Guid("54fa47b8-1add-49e7-ae54-97cfeca6bb89"));
            ((ITTChildObjectCollection)_NursingApplications).GetChildren();
        }

        protected NursingApplication.ChildNursingApplicationCollection _NursingApplications = null;
        public NursingApplication.ChildNursingApplicationCollection NursingApplications
        {
            get
            {
                if (_NursingApplications == null)
                    CreateNursingApplicationsCollection();
                return _NursingApplications;
            }
        }

        virtual protected void CreateDoctorGroupsCollection()
        {
            _DoctorGroups = new EmergencyInterventionDoctorGroup.ChildEmergencyInterventionDoctorGroupCollection(this, new Guid("2d5a01b5-7ad5-4f23-b10e-bf71815c82f5"));
            ((ITTChildObjectCollection)_DoctorGroups).GetChildren();
        }

        protected EmergencyInterventionDoctorGroup.ChildEmergencyInterventionDoctorGroupCollection _DoctorGroups = null;
    /// <summary>
    /// Child collection for Doktorlar Sekmesi
    /// </summary>
        public EmergencyInterventionDoctorGroup.ChildEmergencyInterventionDoctorGroupCollection DoctorGroups
        {
            get
            {
                if (_DoctorGroups == null)
                    CreateDoctorGroupsCollection();
                return _DoctorGroups;
            }
        }

        virtual protected void CreateInPatientPhysicianApplicationsCollection()
        {
            _InPatientPhysicianApplications = new InPatientPhysicianApplication.ChildInPatientPhysicianApplicationCollection(this, new Guid("24aaf2d8-b35f-468c-bc64-b4d9afa6c2e2"));
            ((ITTChildObjectCollection)_InPatientPhysicianApplications).GetChildren();
        }

        protected InPatientPhysicianApplication.ChildInPatientPhysicianApplicationCollection _InPatientPhysicianApplications = null;
        public InPatientPhysicianApplication.ChildInPatientPhysicianApplicationCollection InPatientPhysicianApplications
        {
            get
            {
                if (_InPatientPhysicianApplications == null)
                    CreateInPatientPhysicianApplicationsCollection();
                return _InPatientPhysicianApplications;
            }
        }

        virtual protected void CreatePatientExaminationsCollection()
        {
            _PatientExaminations = new PatientExamination.ChildPatientExaminationCollection(this, new Guid("e6f1dc66-66ea-4d2c-9f2d-0df8761fd5ed"));
            ((ITTChildObjectCollection)_PatientExaminations).GetChildren();
        }

        protected PatientExamination.ChildPatientExaminationCollection _PatientExaminations = null;
        public PatientExamination.ChildPatientExaminationCollection PatientExaminations
        {
            get
            {
                if (_PatientExaminations == null)
                    CreatePatientExaminationsCollection();
                return _PatientExaminations;
            }
        }

        virtual protected void CreateEmergencyInterventionNursingDetailsCollection()
        {
            _EmergencyInterventionNursingDetails = new EmergencyInterventionNursingDetail.ChildEmergencyInterventionNursingDetailCollection(this, new Guid("ed927c15-2417-4a12-9d32-515d9f2d2f61"));
            ((ITTChildObjectCollection)_EmergencyInterventionNursingDetails).GetChildren();
        }

        protected EmergencyInterventionNursingDetail.ChildEmergencyInterventionNursingDetailCollection _EmergencyInterventionNursingDetails = null;
        public EmergencyInterventionNursingDetail.ChildEmergencyInterventionNursingDetailCollection EmergencyInterventionNursingDetails
        {
            get
            {
                if (_EmergencyInterventionNursingDetails == null)
                    CreateEmergencyInterventionNursingDetailsCollection();
                return _EmergencyInterventionNursingDetails;
            }
        }

        virtual protected void CreateEmergencyInterventionInjuryLocationCollection()
        {
            _EmergencyInterventionInjuryLocation = new EmergencyInterventionInjuryLocation.ChildEmergencyInterventionInjuryLocationCollection(this, new Guid("7e98ba80-93c5-445d-a24e-670670592996"));
            ((ITTChildObjectCollection)_EmergencyInterventionInjuryLocation).GetChildren();
        }

        protected EmergencyInterventionInjuryLocation.ChildEmergencyInterventionInjuryLocationCollection _EmergencyInterventionInjuryLocation = null;
        public EmergencyInterventionInjuryLocation.ChildEmergencyInterventionInjuryLocationCollection EmergencyInterventionInjuryLocation
        {
            get
            {
                if (_EmergencyInterventionInjuryLocation == null)
                    CreateEmergencyInterventionInjuryLocationCollection();
                return _EmergencyInterventionInjuryLocation;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _EmergencyInterventionProcedures = new EmergencyInterventionProcedure.ChildEmergencyInterventionProcedureCollection(_SubactionProcedures, "EmergencyInterventionProcedures");
            _EmergencyInterventionNutritionDiets = new EmergencyInterventionNutritionDiet.ChildEmergencyInterventionNutritionDietCollection(_SubactionProcedures, "EmergencyInterventionNutritionDiets");
            _EmerInterBedProcedures = new BedProcedureWithoutBed.ChildBedProcedureWithoutBedCollection(_SubactionProcedures, "EmerInterBedProcedures");
        }

        private EmergencyInterventionProcedure.ChildEmergencyInterventionProcedureCollection _EmergencyInterventionProcedures = null;
        public EmergencyInterventionProcedure.ChildEmergencyInterventionProcedureCollection EmergencyInterventionProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _EmergencyInterventionProcedures;
            }            
        }

        private EmergencyInterventionNutritionDiet.ChildEmergencyInterventionNutritionDietCollection _EmergencyInterventionNutritionDiets = null;
        public EmergencyInterventionNutritionDiet.ChildEmergencyInterventionNutritionDietCollection EmergencyInterventionNutritionDiets
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _EmergencyInterventionNutritionDiets;
            }            
        }

        private BedProcedureWithoutBed.ChildBedProcedureWithoutBedCollection _EmerInterBedProcedures = null;
        public BedProcedureWithoutBed.ChildBedProcedureWithoutBedCollection EmerInterBedProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _EmerInterBedProcedures;
            }            
        }

        protected EmergencyIntervention(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyIntervention(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyIntervention(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyIntervention(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyIntervention(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYINTERVENTION", dataRow) { }
        protected EmergencyIntervention(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYINTERVENTION", dataRow, isImported) { }
        public EmergencyIntervention(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyIntervention(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyIntervention() : base() { }

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