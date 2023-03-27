
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalStuffReport")] 

    /// <summary>
    /// Tıbbi Malzeme Raporu.
    /// </summary>
    public  partial class MedicalStuffReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class MedicalStuffReportList : TTObjectCollection<MedicalStuffReport> { }
                    
        public class ChildMedicalStuffReportCollection : TTObject.TTChildObjectCollection<MedicalStuffReport>
        {
            public ChildMedicalStuffReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalStuffReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalStuffReportByID_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? Duration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["DURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PeriodUnitTypeEnum? DurationType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURATIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["DURATIONTYPE"].DataType;
                    return (PeriodUnitTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? CommitteeReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMITTEEREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["COMMITTEEREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["MEDULADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RaporGonderimTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORGONDERIMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["RAPORGONDERIMTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsSendedMedula
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSENDEDMEDULA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ISSENDEDMEDULA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string RaporGelenXML
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORGELENXML"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["RAPORGELENXML"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RaporGidenXML
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORGIDENXML"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["RAPORGIDENXML"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReportDecision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["REPORTDECISION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DiagnosisDetail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSISDETAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["DIAGNOSISDETAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object SignedData
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIGNEDDATA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["SIGNEDDATA"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsSecondDoctorApproved
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSECONDDOCTORAPPROVED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ISSECONDDOCTORAPPROVED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsThirdDoctorApproved
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTHIRDDOCTORAPPROVED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ISTHIRDDOCTORAPPROVED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetMedicalStuffReportByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalStuffReportByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalStuffReportByID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedicalStuffReportListByID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Seconddoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECONDDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Thirddoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["THIRDDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsSendedMedula
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSENDEDMEDULA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ISSENDEDMEDULA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetMedicalStuffReportListByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalStuffReportListByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalStuffReportListByID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReportListByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Seconddoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECONDDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Thirddoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["THIRDDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsSendedMedula
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSENDEDMEDULA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["ISSENDEDMEDULA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetReportListByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReportListByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReportListByPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedicalStuffReportForWL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public GetMedicalStuffReportForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalStuffReportForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalStuffReportForWL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancel { get { return new Guid("26dc81e5-e2ff-4333-a4ef-8c8df1055c55"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("48aeb9bf-72fc-4c93-8110-42c62ec1db57"); } }
    /// <summary>
    /// Medulaya kaydedildi
    /// </summary>
            public static Guid Complete { get { return new Guid("50013305-023e-42f0-8456-31b17986237d"); } }
            public static Guid SecondDoctorApproval { get { return new Guid("7c837b5f-cbdf-47fc-90bd-6db78695fb42"); } }
            public static Guid ThirdDoctorApproval { get { return new Guid("f3fda495-255c-4209-b082-fbc3a19423f8"); } }
            public static Guid HeadDoctorApproval { get { return new Guid("02170102-6367-4b2a-9a3d-e6e597ef95b2"); } }
        }

        public static BindingList<MedicalStuffReport.GetMedicalStuffReportByID_Class> GetMedicalStuffReportByID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].QueryDefs["GetMedicalStuffReportByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MedicalStuffReport.GetMedicalStuffReportByID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedicalStuffReport.GetMedicalStuffReportByID_Class> GetMedicalStuffReportByID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].QueryDefs["GetMedicalStuffReportByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MedicalStuffReport.GetMedicalStuffReportByID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedicalStuffReport.GetMedicalStuffReportListByID_Class> GetMedicalStuffReportListByID(Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].QueryDefs["GetMedicalStuffReportListByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<MedicalStuffReport.GetMedicalStuffReportListByID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedicalStuffReport.GetMedicalStuffReportListByID_Class> GetMedicalStuffReportListByID(TTObjectContext objectContext, Guid SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].QueryDefs["GetMedicalStuffReportListByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<MedicalStuffReport.GetMedicalStuffReportListByID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedicalStuffReport.GetReportListByPatient_Class> GetReportListByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].QueryDefs["GetReportListByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedicalStuffReport.GetReportListByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedicalStuffReport.GetReportListByPatient_Class> GetReportListByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].QueryDefs["GetReportListByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedicalStuffReport.GetReportListByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedicalStuffReport> GetObjectByRaporTakipno(TTObjectContext objectContext, string RAPORTAKIPNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].QueryDefs["GetObjectByRaporTakipno"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RAPORTAKIPNO", RAPORTAKIPNO);

            return ((ITTQuery)objectContext).QueryObjects<MedicalStuffReport>(queryDef, paramList);
        }

        public static BindingList<MedicalStuffReport.GetMedicalStuffReportForWL_Class> GetMedicalStuffReportForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].QueryDefs["GetMedicalStuffReportForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalStuffReport.GetMedicalStuffReportForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalStuffReport.GetMedicalStuffReportForWL_Class> GetMedicalStuffReportForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].QueryDefs["GetMedicalStuffReportForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalStuffReport.GetMedicalStuffReportForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Süre
    /// </summary>
        public int? Duration
        {
            get { return (int?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Süre Türü
    /// </summary>
        public PeriodUnitTypeEnum? DurationType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["DURATIONTYPE"]; }
            set { this["DURATIONTYPE"] = value; }
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
    /// Medula Açıklama
    /// </summary>
        public string MedulaDescription
        {
            get { return (string)this["MEDULADESCRIPTION"]; }
            set { this["MEDULADESCRIPTION"] = value; }
        }

    /// <summary>
    /// Rapor Gönderim Tarihi
    /// </summary>
        public DateTime? RaporGonderimTarihi
        {
            get { return (DateTime?)this["RAPORGONDERIMTARIHI"]; }
            set { this["RAPORGONDERIMTARIHI"] = value; }
        }

    /// <summary>
    /// Medula Rapor Takip No
    /// </summary>
        public string RaporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Medulaya Gönderildi
    /// </summary>
        public bool? IsSendedMedula
        {
            get { return (bool?)this["ISSENDEDMEDULA"]; }
            set { this["ISSENDEDMEDULA"] = value; }
        }

    /// <summary>
    /// Gelen Rapor Bilgileri
    /// </summary>
        public string RaporGelenXML
        {
            get { return (string)this["RAPORGELENXML"]; }
            set { this["RAPORGELENXML"] = value; }
        }

    /// <summary>
    /// Giden Rapor Bilgileri
    /// </summary>
        public string RaporGidenXML
        {
            get { return (string)this["RAPORGIDENXML"]; }
            set { this["RAPORGIDENXML"] = value; }
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
    /// Karar
    /// </summary>
        public object ReportDecision
        {
            get { return (object)this["REPORTDECISION"]; }
            set { this["REPORTDECISION"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
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
    /// İmzalanmış Veri
    /// </summary>
        public object SignedData
        {
            get { return (object)this["SIGNEDDATA"]; }
            set { this["SIGNEDDATA"] = value; }
        }

    /// <summary>
    /// İkinci hekim raporu onayladı ise bu değer true olacaktır.
    /// </summary>
        public bool? IsSecondDoctorApproved
        {
            get { return (bool?)this["ISSECONDDOCTORAPPROVED"]; }
            set { this["ISSECONDDOCTORAPPROVED"] = value; }
        }

    /// <summary>
    /// Üçüncü hekim onayladı ise bu property true olacaktır.
    /// </summary>
        public bool? IsThirdDoctorApproved
        {
            get { return (bool?)this["ISTHIRDDOCTORAPPROVED"]; }
            set { this["ISTHIRDDOCTORAPPROVED"] = value; }
        }

        public MedicalStuffDefinition MedicalStuffDef
        {
            get { return (MedicalStuffDefinition)((ITTObject)this).GetParent("MEDICALSTUFFDEF"); }
            set { this["MEDICALSTUFFDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
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

        virtual protected void CreateMedicalStuffCollection()
        {
            _MedicalStuff = new MedicalStuff.ChildMedicalStuffCollection(this, new Guid("02c8115c-cd3d-475a-a39a-a57b9d38cf99"));
            ((ITTChildObjectCollection)_MedicalStuff).GetChildren();
        }

        protected MedicalStuff.ChildMedicalStuffCollection _MedicalStuff = null;
        public MedicalStuff.ChildMedicalStuffCollection MedicalStuff
        {
            get
            {
                if (_MedicalStuff == null)
                    CreateMedicalStuffCollection();
                return _MedicalStuff;
            }
        }

        virtual protected void CreateMedicalStuffPrescriptionCollection()
        {
            _MedicalStuffPrescription = new MedicalStuffPrescription.ChildMedicalStuffPrescriptionCollection(this, new Guid("87a6d34b-8528-4058-b91c-e0f7621861b5"));
            ((ITTChildObjectCollection)_MedicalStuffPrescription).GetChildren();
        }

        protected MedicalStuffPrescription.ChildMedicalStuffPrescriptionCollection _MedicalStuffPrescription = null;
        public MedicalStuffPrescription.ChildMedicalStuffPrescriptionCollection MedicalStuffPrescription
        {
            get
            {
                if (_MedicalStuffPrescription == null)
                    CreateMedicalStuffPrescriptionCollection();
                return _MedicalStuffPrescription;
            }
        }

        protected MedicalStuffReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalStuffReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalStuffReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalStuffReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalStuffReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALSTUFFREPORT", dataRow) { }
        protected MedicalStuffReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALSTUFFREPORT", dataRow, isImported) { }
        public MedicalStuffReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalStuffReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalStuffReport() : base() { }

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