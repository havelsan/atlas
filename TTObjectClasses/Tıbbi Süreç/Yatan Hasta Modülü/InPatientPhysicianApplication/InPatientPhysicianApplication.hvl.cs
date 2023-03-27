
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InPatientPhysicianApplication")] 

    public  partial class InPatientPhysicianApplication : PhysicianApplication, IWorkListInpatient, IOAInPatientApplication, IWorkListEpisodeAction, IAllocateSpeciality
    {
        public class InPatientPhysicianApplicationList : TTObjectCollection<InPatientPhysicianApplication> { }
                    
        public class ChildInPatientPhysicianApplicationCollection : TTObject.TTChildObjectCollection<InPatientPhysicianApplication>
        {
            public ChildInPatientPhysicianApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInPatientPhysicianApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOldInfoForClinic_Class : TTReportNqlObject 
        {
            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public String Defname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? Requestdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dischargedate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Guid? Masterresourceid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCEID"]);
                }
            }

            public string Uzmanlik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UZMANLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetOldInfoForClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInPatientPhysicianApplicationForWL_Class : TTReportNqlObject 
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

            public string Oncelikdurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONCELIKDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Inpatientdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetInPatientPhysicianApplicationForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInPatientPhysicianApplicationForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInPatientPhysicianApplicationForWL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpPhysicianForEmergencyForm_Class : TTReportNqlObject 
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

            public GetInpPhysicianForEmergencyForm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpPhysicianForEmergencyForm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpPhysicianForEmergencyForm_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyInterventionByPatient_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcessEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PROCESSENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public object ContinuousDrugs
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTINUOUSDRUGS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object DecisionAndAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECISIONANDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["DECISIONANDACTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ExaminationSummary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONSUMMARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["EXAMINATIONSUMMARY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["HABITS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Image
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["IMAGE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsTreatmentMaterialEmpty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTREATMENTMATERIALEMPTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["ISTREATMENTMATERIALEMPTY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object PatientFamilyHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFAMILYHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PatientFolder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFOLDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PATIENTFOLDER"].DataType;
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

            public object PatientStory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PATIENTSTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PhysicalExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object SystemQuery
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYSTEMQUERY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["SYSTEMQUERY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object MTSConclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSCONCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object InPatientFolder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTFOLDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["INPATIENTFOLDER"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? IsPandemic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPANDEMIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["ISPANDEMIC"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? PandemicChangeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANDEMICCHANGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].AllPropertyDefs["PANDEMICCHANGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetEmergencyInterventionByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyInterventionByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyInterventionByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientsByClinic_Class : TTReportNqlObject 
        {
            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
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

            public DateTime? ClinicInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Subepisodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEID"]);
                }
            }

            public Guid? Episodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEID"]);
                }
            }

            public InpatientStatusEnum? InpatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["INPATIENTSTATUS"].DataType;
                    return (InpatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsDailyOperation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDAILYOPERATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ISDAILYOPERATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetInpatientsByClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientsByClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientsByClinic_Class() : base() { }
        }

        public static class States
        {
            public static Guid PreDischarged { get { return new Guid("cab7db30-2645-4567-9d1b-8b6782fce9e1"); } }
            public static Guid Discharged { get { return new Guid("8318fb32-f0a0-4cde-baff-7080414d6fec"); } }
            public static Guid Application { get { return new Guid("73698603-b1f2-4691-968d-fe4e0cab1d03"); } }
            public static Guid Cancelled { get { return new Guid("fd0175ba-4b66-4d0b-add1-065ec3330532"); } }
        }

        public static BindingList<InPatientPhysicianApplication> GetUnCompletedEmergencyPhyAppForClosedEpisodes(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetUnCompletedEmergencyPhyAppForClosedEpisodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<InPatientPhysicianApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientPhysicianApplication.GetOldInfoForClinic_Class> GetOldInfoForClinic(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetOldInfoForClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetOldInfoForClinic_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientPhysicianApplication.GetOldInfoForClinic_Class> GetOldInfoForClinic(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetOldInfoForClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetOldInfoForClinic_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientPhysicianApplication> GetActiveInpatientPhAppByEpisode(TTObjectContext objectContext, Guid EPISODEPARAM)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetActiveInpatientPhAppByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEPARAM", EPISODEPARAM);

            return ((ITTQuery)objectContext).QueryObjects<InPatientPhysicianApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientPhysicianApplication.GetInPatientPhysicianApplicationForWL_Class> GetInPatientPhysicianApplicationForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetInPatientPhysicianApplicationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetInPatientPhysicianApplicationForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientPhysicianApplication.GetInPatientPhysicianApplicationForWL_Class> GetInPatientPhysicianApplicationForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetInPatientPhysicianApplicationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetInPatientPhysicianApplicationForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientPhysicianApplication.GetInpPhysicianForEmergencyForm_Class> GetInpPhysicianForEmergencyForm(Guid EMERGENCYINTERVETION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetInpPhysicianForEmergencyForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EMERGENCYINTERVETION", EMERGENCYINTERVETION);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetInpPhysicianForEmergencyForm_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientPhysicianApplication.GetInpPhysicianForEmergencyForm_Class> GetInpPhysicianForEmergencyForm(TTObjectContext objectContext, Guid EMERGENCYINTERVETION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetInpPhysicianForEmergencyForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EMERGENCYINTERVETION", EMERGENCYINTERVETION);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetInpPhysicianForEmergencyForm_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Bu hastada aynı gün Acil müşahede bilgisi var mı
    /// </summary>
        public static BindingList<InPatientPhysicianApplication.GetEmergencyInterventionByPatient_Class> GetEmergencyInterventionByPatient(Guid PATIENTID, DateTime DATETIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetEmergencyInterventionByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("DATETIME", DATETIME);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetEmergencyInterventionByPatient_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Bu hastada aynı gün Acil müşahede bilgisi var mı
    /// </summary>
        public static BindingList<InPatientPhysicianApplication.GetEmergencyInterventionByPatient_Class> GetEmergencyInterventionByPatient(TTObjectContext objectContext, Guid PATIENTID, DateTime DATETIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetEmergencyInterventionByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("DATETIME", DATETIME);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetEmergencyInterventionByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientPhysicianApplication.GetInpatientsByClinic_Class> GetInpatientsByClinic(IList<Guid> MASTERRESOURCEID, IList<Guid> DIAGNOSISID, IList<Guid> SPROCEDUREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetInpatientsByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("DIAGNOSISID", DIAGNOSISID);
            paramList.Add("SPROCEDUREID", SPROCEDUREID);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetInpatientsByClinic_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientPhysicianApplication.GetInpatientsByClinic_Class> GetInpatientsByClinic(TTObjectContext objectContext, IList<Guid> MASTERRESOURCEID, IList<Guid> DIAGNOSISID, IList<Guid> SPROCEDUREID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTPHYSICIANAPPLICATION"].QueryDefs["GetInpatientsByClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("DIAGNOSISID", DIAGNOSISID);
            paramList.Add("SPROCEDUREID", SPROCEDUREID);

            return TTReportNqlObject.QueryObjects<InPatientPhysicianApplication.GetInpatientsByClinic_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Dosyası
    /// </summary>
        public object InPatientFolder
        {
            get { return (object)this["INPATIENTFOLDER"]; }
            set { this["INPATIENTFOLDER"] = value; }
        }

    /// <summary>
    /// Pandemi olgusu var mı?
    /// </summary>
        public YesNoEnum? IsPandemic
        {
            get { return (YesNoEnum?)(int?)this["ISPANDEMIC"]; }
            set { this["ISPANDEMIC"] = value; }
        }

    /// <summary>
    /// Pandemi olgusu evet yapılma tarihi
    /// </summary>
        public DateTime? PandemicChangeDate
        {
            get { return (DateTime?)this["PANDEMICCHANGEDATE"]; }
            set { this["PANDEMICCHANGEDATE"] = value; }
        }

        public EmergencyIntervention EmergencyIntervention
        {
            get { return (EmergencyIntervention)((ITTObject)this).GetParent("EMERGENCYINTERVENTION"); }
            set { this["EMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication InPatientTreatmentClinicApp
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("INPATIENTTREATMENTCLINICAPP"); }
            set { this["INPATIENTTREATMENTCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ventilatör Kullanım Durumu
    /// </summary>
        public SKRSDurum VentilatorStatus
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("VENTILATORSTATUS"); }
            set { this["VENTILATORSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNursingOrdersCollection()
        {
            _NursingOrders = new NursingOrder.ChildNursingOrderCollection(this, new Guid("4a33d805-6f20-418f-9099-a294249cb8dc"));
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

        virtual protected void CreateDrugOrdersCollection()
        {
            _DrugOrders = new DrugOrder.ChildDrugOrderCollection(this, new Guid("07e39817-81ba-4025-a9d1-a52470843803"));
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

        virtual protected void CreateProcedureOrdersCollection()
        {
            _ProcedureOrders = new ProcedureOrder.ChildProcedureOrderCollection(this, new Guid("a543a91d-05a3-47db-8a32-437334974347"));
            ((ITTChildObjectCollection)_ProcedureOrders).GetChildren();
        }

        protected ProcedureOrder.ChildProcedureOrderCollection _ProcedureOrders = null;
        public ProcedureOrder.ChildProcedureOrderCollection ProcedureOrders
        {
            get
            {
                if (_ProcedureOrders == null)
                    CreateProcedureOrdersCollection();
                return _ProcedureOrders;
            }
        }

        virtual protected void CreateNutritionDietsCollection()
        {
            _NutritionDiets = new NutritionDietOrder.ChildNutritionDietOrderCollection(this, new Guid("0ec4f7f9-9d19-439b-9bdf-f313d31a0c00"));
            ((ITTChildObjectCollection)_NutritionDiets).GetChildren();
        }

        protected NutritionDietOrder.ChildNutritionDietOrderCollection _NutritionDiets = null;
        public NutritionDietOrder.ChildNutritionDietOrderCollection NutritionDiets
        {
            get
            {
                if (_NutritionDiets == null)
                    CreateNutritionDietsCollection();
                return _NutritionDiets;
            }
        }

        virtual protected void CreateDietOrdersCollection()
        {
            _DietOrders = new DietOrder.ChildDietOrderCollection(this, new Guid("ec9fe663-312b-4c74-8b70-85ee09a76c12"));
            ((ITTChildObjectCollection)_DietOrders).GetChildren();
        }

        protected DietOrder.ChildDietOrderCollection _DietOrders = null;
        public DietOrder.ChildDietOrderCollection DietOrders
        {
            get
            {
                if (_DietOrders == null)
                    CreateDietOrdersCollection();
                return _DietOrders;
            }
        }

        virtual protected void CreatePatientvacationsCollection()
        {
            _Patientvacations = new PatientOnVacation.ChildPatientOnVacationCollection(this, new Guid("a2a168ec-12ac-46d7-8714-5a5a8e7985c0"));
            ((ITTChildObjectCollection)_Patientvacations).GetChildren();
        }

        protected PatientOnVacation.ChildPatientOnVacationCollection _Patientvacations = null;
        public PatientOnVacation.ChildPatientOnVacationCollection Patientvacations
        {
            get
            {
                if (_Patientvacations == null)
                    CreatePatientvacationsCollection();
                return _Patientvacations;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _PhysicianApplicationDietOrderDetails = new DietOrderDetail.ChildDietOrderDetailCollection(_SubactionProcedures, "PhysicianApplicationDietOrderDetails");
            _InpatientPhysicianAppAdditionalApplications = new InpatientPhysicianApplicationAdditionalApplication.ChildInpatientPhysicianApplicationAdditionalApplicationCollection(_SubactionProcedures, "InpatientPhysicianAppAdditionalApplications");
        }

        private DietOrderDetail.ChildDietOrderDetailCollection _PhysicianApplicationDietOrderDetails = null;
        public DietOrderDetail.ChildDietOrderDetailCollection PhysicianApplicationDietOrderDetails
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PhysicianApplicationDietOrderDetails;
            }            
        }

        private InpatientPhysicianApplicationAdditionalApplication.ChildInpatientPhysicianApplicationAdditionalApplicationCollection _InpatientPhysicianAppAdditionalApplications = null;
        public InpatientPhysicianApplicationAdditionalApplication.ChildInpatientPhysicianApplicationAdditionalApplicationCollection InpatientPhysicianAppAdditionalApplications
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _InpatientPhysicianAppAdditionalApplications;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _InPatientPhysicianTreatmentMaterials = new InPatientPhysicianMaterial.ChildInPatientPhysicianMaterialCollection(_TreatmentMaterials, "InPatientPhysicianTreatmentMaterials");
        }

        private InPatientPhysicianMaterial.ChildInPatientPhysicianMaterialCollection _InPatientPhysicianTreatmentMaterials = null;
        public InPatientPhysicianMaterial.ChildInPatientPhysicianMaterialCollection InPatientPhysicianTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _InPatientPhysicianTreatmentMaterials;
            }            
        }

        protected InPatientPhysicianApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InPatientPhysicianApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InPatientPhysicianApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InPatientPhysicianApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InPatientPhysicianApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTPHYSICIANAPPLICATION", dataRow) { }
        protected InPatientPhysicianApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTPHYSICIANAPPLICATION", dataRow, isImported) { }
        public InPatientPhysicianApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InPatientPhysicianApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InPatientPhysicianApplication() : base() { }

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