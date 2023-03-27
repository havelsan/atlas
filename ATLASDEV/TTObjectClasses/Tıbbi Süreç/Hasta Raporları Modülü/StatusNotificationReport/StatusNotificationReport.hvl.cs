
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StatusNotificationReport")] 

    /// <summary>
    /// Durum Bildirir Raporu
    /// </summary>
    public  partial class StatusNotificationReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class StatusNotificationReportList : TTObjectCollection<StatusNotificationReport> { }
                    
        public class ChildStatusNotificationReportCollection : TTObject.TTChildObjectCollection<StatusNotificationReport>
        {
            public ChildStatusNotificationReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStatusNotificationReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetStatusNotificationRaportRNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? CopyComplaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COPYCOMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["COPYCOMPLAINT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CopyPatientHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COPYPATIENTHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["COPYPATIENTHISTORY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CopyPhysicalExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COPYPHYSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["COPYPHYSICALEXAMINATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CopyMTSConclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COPYMTSCONCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["COPYMTSCONCLUSION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReportDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REPORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ReportDuration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REPORTDURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PeriodUnitTypeWithUndefiniteEnum? ReportDurationType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDURATIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REPORTDURATIONTYPE"].DataType;
                    return (PeriodUnitTypeWithUndefiniteEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string DiagnosisDetail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISDETAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["DIAGNOSISDETAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ReportDecision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REPORTDECISION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? CommitteeReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMITTEEREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["COMMITTEEREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExaminationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["EXAMINATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Appropriate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROPRIATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["APPROPRIATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? InAppropriate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INAPPROPRIATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["INAPPROPRIATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public StatusNotificationReasonEnum? ReportReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REPORTREASON"].DataType;
                    return (StatusNotificationReasonEnum?)(int)dataType.ConvertValue(val);
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

            public Guid? Parentobjidnotmedula
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTOBJIDNOTMEDULA"]);
                }
            }

            public string Mr
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Isteksebebi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEKSEBEBI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCREQUESTREASON"].AllPropertyDefs["REASONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Raporadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REASONFOREXAMINATIONDEFINITION"].AllPropertyDefs["REASON"].DataType;
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

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetStatusNotificationRaportRNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStatusNotificationRaportRNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStatusNotificationRaportRNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStatusNotificationReportForWL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["EMERGENCY"].DataType;
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

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public GetStatusNotificationReportForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStatusNotificationReportForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStatusNotificationReportForWL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("46146d21-c76a-44b0-bbcf-b6e9986286cc"); } }
            public static Guid Completed { get { return new Guid("64fd7ccd-9edf-407e-983f-70e0ed506966"); } }
            public static Guid Cancelled { get { return new Guid("d8f40d92-831c-45b1-b978-afbaf1f4aee0"); } }
    /// <summary>
    /// Rapor Kaydedildi
    /// </summary>
            public static Guid Saved { get { return new Guid("fd1fd812-d0db-4504-b803-a3f0e115d5ef"); } }
        }

        public static BindingList<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class> GetStatusNotificationRaportRNQL(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].QueryDefs["GetStatusNotificationRaportRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class> GetStatusNotificationRaportRNQL(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].QueryDefs["GetStatusNotificationRaportRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<StatusNotificationReport.GetStatusNotificationRaportRNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StatusNotificationReport.GetStatusNotificationReportForWL_Class> GetStatusNotificationReportForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].QueryDefs["GetStatusNotificationReportForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StatusNotificationReport.GetStatusNotificationReportForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StatusNotificationReport.GetStatusNotificationReportForWL_Class> GetStatusNotificationReportForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STATUSNOTIFICATIONREPORT"].QueryDefs["GetStatusNotificationReportForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StatusNotificationReport.GetStatusNotificationReportForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Şikayet muayeneden kopyalansın mı
    /// </summary>
        public bool? CopyComplaint
        {
            get { return (bool?)this["COPYCOMPLAINT"]; }
            set { this["COPYCOMPLAINT"] = value; }
        }

    /// <summary>
    /// Hasta geçmişini muayeneden kopyalansın mı
    /// </summary>
        public bool? CopyPatientHistory
        {
            get { return (bool?)this["COPYPATIENTHISTORY"]; }
            set { this["COPYPATIENTHISTORY"] = value; }
        }

    /// <summary>
    /// Fiziksel muayene muayeneden kopyalansın mı
    /// </summary>
        public bool? CopyPhysicalExamination
        {
            get { return (bool?)this["COPYPHYSICALEXAMINATION"]; }
            set { this["COPYPHYSICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// MTS  muayeneden kopyalansın mı
    /// </summary>
        public bool? CopyMTSConclusion
        {
            get { return (bool?)this["COPYMTSCONCLUSION"]; }
            set { this["COPYMTSCONCLUSION"] = value; }
        }

    /// <summary>
    /// Rapor Açıklaması
    /// </summary>
        public string ReportDescription
        {
            get { return (string)this["REPORTDESCRIPTION"]; }
            set { this["REPORTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Rapor Süresi
    /// </summary>
        public int? ReportDuration
        {
            get { return (int?)this["REPORTDURATION"]; }
            set { this["REPORTDURATION"] = value; }
        }

    /// <summary>
    /// Rapor Süre Türü
    /// </summary>
        public PeriodUnitTypeWithUndefiniteEnum? ReportDurationType
        {
            get { return (PeriodUnitTypeWithUndefiniteEnum?)(int?)this["REPORTDURATIONTYPE"]; }
            set { this["REPORTDURATIONTYPE"] = value; }
        }

    /// <summary>
    /// Tanı Detayları
    /// </summary>
        public string DiagnosisDetail
        {
            get { return (string)this["DIAGNOSISDETAIL"]; }
            set { this["DIAGNOSISDETAIL"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public object Description
        {
            get { return (object)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Karar
    /// </summary>
        public object ReportDecision
        {
            get { return (object)this["REPORTDECISION"]; }
            set { this["REPORTDECISION"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

    /// <summary>
    /// Heyet Raporu
    /// </summary>
        public bool? CommitteeReport
        {
            get { return (bool?)this["COMMITTEEREPORT"]; }
            set { this["COMMITTEEREPORT"] = value; }
        }

    /// <summary>
    /// Muayene Tarihi
    /// </summary>
        public DateTime? ExaminationDate
        {
            get { return (DateTime?)this["EXAMINATIONDATE"]; }
            set { this["EXAMINATIONDATE"] = value; }
        }

    /// <summary>
    /// Uygundur
    /// </summary>
        public bool? Appropriate
        {
            get { return (bool?)this["APPROPRIATE"]; }
            set { this["APPROPRIATE"] = value; }
        }

    /// <summary>
    /// Uygun Değil
    /// </summary>
        public bool? InAppropriate
        {
            get { return (bool?)this["INAPPROPRIATE"]; }
            set { this["INAPPROPRIATE"] = value; }
        }

    /// <summary>
    /// Durum Bildirir Raporu Veriliş Nedeni
    /// </summary>
        public StatusNotificationReasonEnum? ReportReason
        {
            get { return (StatusNotificationReasonEnum?)(int?)this["REPORTREASON"]; }
            set { this["REPORTREASON"] = value; }
        }

        public HCRequestReason HCRequestReason
        {
            get { return (HCRequestReason)((ITTObject)this).GetParent("HCREQUESTREASON"); }
            set { this["HCREQUESTREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 2.Doktor
    /// </summary>
        public ResUser SecondDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SECONDDOCTOR"); }
            set { this["SECONDDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 3.Doktor
    /// </summary>
        public ResUser ThirdDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("THIRDDOCTOR"); }
            set { this["THIRDDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _StatusNotificationReportHCProcedures = new HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection(_SubactionProcedures, "StatusNotificationReportHCProcedures");
        }

        private HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection _StatusNotificationReportHCProcedures = null;
        public HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection StatusNotificationReportHCProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _StatusNotificationReportHCProcedures;
            }            
        }

        protected StatusNotificationReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StatusNotificationReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StatusNotificationReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StatusNotificationReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StatusNotificationReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STATUSNOTIFICATIONREPORT", dataRow) { }
        protected StatusNotificationReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STATUSNOTIFICATIONREPORT", dataRow, isImported) { }
        public StatusNotificationReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StatusNotificationReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StatusNotificationReport() : base() { }

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