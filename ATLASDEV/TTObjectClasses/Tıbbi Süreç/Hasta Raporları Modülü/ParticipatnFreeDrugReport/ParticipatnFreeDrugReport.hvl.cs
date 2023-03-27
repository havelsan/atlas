
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ParticipatnFreeDrugReport")] 

    /// <summary>
    /// Hasta Katılım Payından Muaf İlaç Raporu
    /// </summary>
    public  partial class ParticipatnFreeDrugReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public class ParticipatnFreeDrugReportList : TTObjectCollection<ParticipatnFreeDrugReport> { }
                    
        public class ChildParticipatnFreeDrugReportCollection : TTObject.TTChildObjectCollection<ParticipatnFreeDrugReport>
        {
            public ChildParticipatnFreeDrugReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildParticipatnFreeDrugReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetParticipatnFreeDrugReportRNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string itno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ITNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientApprovalFormNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTAPPROVALFORMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["PATIENTAPPROVALFORMNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? HeadDoctorApproval
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADDOCTORAPPROVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["HEADDOCTORAPPROVAL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MedulaPassword
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAPASSWORD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["MEDULAPASSWORD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsRepeated
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREPEATED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ISREPEATED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? SecondDoctorApproval
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECONDDOCTORAPPROVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["SECONDDOCTORAPPROVAL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ThirdDoctorApproval
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["THIRDDOCTORAPPROVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["THIRDDOCTORAPPROVAL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public ReportApproveTypeEnum? ReportApprovalType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTAPPROVALTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REPORTAPPROVALTYPE"].DataType;
                    return (ReportApproveTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? CommitteeReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMITTEEREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["COMMITTEEREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExaminationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["EXAMINATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ExamptionProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMPTIONPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["EXAMPTIONPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string SocialInsurance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOCIALINSURANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["SOCIALINSURANCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Disease
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISEASE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["DISEASE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientEnterprise
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTENTERPRISE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["PATIENTENTERPRISE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Duration1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURATION1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["DURATION1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object TestsAndSigns
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTSANDSIGNS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["TESTSANDSIGNS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REPORTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ProtocolNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["PROTOCOLNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REPORTDURATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REPORTDURATIONTYPE"].DataType;
                    return (PeriodUnitTypeWithUndefiniteEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsSendedMedula
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSENDEDMEDULA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ISSENDEDMEDULA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DrugReportReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGREPORTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["DRUGREPORTREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? HemoglobinA1c
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEMOGLOBINA1C"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["HEMOGLOBINA1C"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IsSecondDoctorApproved
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSECONDDOCTORAPPROVED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ISSECONDDOCTORAPPROVED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ISTHIRDDOCTORAPPROVED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? AclikKanSekeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACLIKKANSEKERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["ACLIKKANSEKERI"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["KILO"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public string ReportChasingNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTCHASINGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULAREPORTRESULT"].AllPropertyDefs["REPORTCHASINGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetParticipatnFreeDrugReportRNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetParticipatnFreeDrugReportRNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetParticipatnFreeDrugReportRNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetParticipatnFreeDrugReportForWL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public GetParticipatnFreeDrugReportForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetParticipatnFreeDrugReportForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetParticipatnFreeDrugReportForWL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetParticipatnFreeDrugReports_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Hastaadi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAADI"]);
                }
            }

            public long? Tck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
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

            public string Servis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetParticipatnFreeDrugReports_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetParticipatnFreeDrugReports_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetParticipatnFreeDrugReports_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("04200b26-1590-4f3d-abed-dda38b822304"); } }
            public static Guid Approval { get { return new Guid("208fa2d4-98cf-421b-a744-a9e00789da73"); } }
            public static Guid Report { get { return new Guid("c5111942-bbf0-4eb5-8d70-b5e29c3c8fa1"); } }
            public static Guid Completed { get { return new Guid("c0b8367b-22cd-491d-a0c9-251ccbfacc15"); } }
            public static Guid Cancelled { get { return new Guid("a8befca2-9c71-4755-a157-379ab60f9667"); } }
            public static Guid SecondDoctorApproval { get { return new Guid("46d77051-ac33-4e73-a525-963ed5ac1fd4"); } }
            public static Guid ThirdDoctorApproval { get { return new Guid("dffc0056-c70f-44bd-816e-0f60c6ae623a"); } }
            public static Guid ReportCompleted { get { return new Guid("3e73586c-dbad-45d5-9ec1-c5b4aaad177a"); } }
        }

        public static BindingList<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class> GetParticipatnFreeDrugReportRNQL(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].QueryDefs["GetParticipatnFreeDrugReportRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class> GetParticipatnFreeDrugReportRNQL(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].QueryDefs["GetParticipatnFreeDrugReportRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportRNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ParticipatnFreeDrugReport> GetCompletedBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].QueryDefs["GetCompletedBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<ParticipatnFreeDrugReport>(queryDef, paramList);
        }

        public static BindingList<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportForWL_Class> GetParticipatnFreeDrugReportForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].QueryDefs["GetParticipatnFreeDrugReportForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportForWL_Class> GetParticipatnFreeDrugReportForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].QueryDefs["GetParticipatnFreeDrugReportForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReportForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReports_Class> GetParticipatnFreeDrugReports(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].QueryDefs["GetParticipatnFreeDrugReports"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReports_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReports_Class> GetParticipatnFreeDrugReports(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATNFREEDRUGREPORT"].QueryDefs["GetParticipatnFreeDrugReports"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReports_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Bilgi İşlem Numarası
    /// </summary>
        public string itno
        {
            get { return (string)this["ITNO"]; }
            set { this["ITNO"] = value; }
        }

        public string PatientApprovalFormNo
        {
            get { return (string)this["PATIENTAPPROVALFORMNO"]; }
            set { this["PATIENTAPPROVALFORMNO"] = value; }
        }

    /// <summary>
    /// Başhekim Onay Durumu
    /// </summary>
        public int? HeadDoctorApproval
        {
            get { return (int?)this["HEADDOCTORAPPROVAL"]; }
            set { this["HEADDOCTORAPPROVAL"] = value; }
        }

        public string MedulaPassword
        {
            get { return (string)this["MEDULAPASSWORD"]; }
            set { this["MEDULAPASSWORD"] = value; }
        }

    /// <summary>
    /// Bir Daha Sorma Kullanıcı Bilgilerine Kaydet
    /// </summary>
        public bool? IsRepeated
        {
            get { return (bool?)this["ISREPEATED"]; }
            set { this["ISREPEATED"] = value; }
        }

    /// <summary>
    /// 2.Tabip Onay Durumu
    /// </summary>
        public int? SecondDoctorApproval
        {
            get { return (int?)this["SECONDDOCTORAPPROVAL"]; }
            set { this["SECONDDOCTORAPPROVAL"] = value; }
        }

    /// <summary>
    /// 3.Tabip Onay Durumu
    /// </summary>
        public int? ThirdDoctorApproval
        {
            get { return (int?)this["THIRDDOCTORAPPROVAL"]; }
            set { this["THIRDDOCTORAPPROVAL"] = value; }
        }

    /// <summary>
    /// Doktor Onay Tipi
    /// </summary>
        public ReportApproveTypeEnum? ReportApprovalType
        {
            get { return (ReportApproveTypeEnum?)(int?)this["REPORTAPPROVALTYPE"]; }
            set { this["REPORTAPPROVALTYPE"] = value; }
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
    /// Heyet Raporu
    /// </summary>
        public bool? CommitteeReport
        {
            get { return (bool?)this["COMMITTEEREPORT"]; }
            set { this["COMMITTEEREPORT"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
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
    /// Muayene Tarihi
    /// </summary>
        public DateTime? ExaminationDate
        {
            get { return (DateTime?)this["EXAMINATIONDATE"]; }
            set { this["EXAMINATIONDATE"] = value; }
        }

    /// <summary>
    /// Muafiyet Protokol No
    /// </summary>
        public TTSequence ExamptionProtocolNo
        {
            get { return GetSequence("EXAMPTIONPROTOCOLNO"); }
        }

    /// <summary>
    /// Sosyal Güvence
    /// </summary>
        public string SocialInsurance
        {
            get { return (string)this["SOCIALINSURANCE"]; }
            set { this["SOCIALINSURANCE"] = value; }
        }

    /// <summary>
    /// Hastalık
    /// </summary>
        public string Disease
        {
            get { return (string)this["DISEASE"]; }
            set { this["DISEASE"] = value; }
        }

    /// <summary>
    /// Çalıştığı Kurum
    /// </summary>
        public string PatientEnterprise
        {
            get { return (string)this["PATIENTENTERPRISE"]; }
            set { this["PATIENTENTERPRISE"] = value; }
        }

    /// <summary>
    /// Süre
    /// </summary>
        public string Duration1
        {
            get { return (string)this["DURATION1"]; }
            set { this["DURATION1"] = value; }
        }

    /// <summary>
    /// Bulgular ve Tetkikler
    /// </summary>
        public object TestsAndSigns
        {
            get { return (object)this["TESTSANDSIGNS"]; }
            set { this["TESTSANDSIGNS"] = value; }
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
    /// Protokol Defter No
    /// </summary>
        public string ProtocolNumber
        {
            get { return (string)this["PROTOCOLNUMBER"]; }
            set { this["PROTOCOLNUMBER"] = value; }
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
    /// Medulaya Gönderildi
    /// </summary>
        public bool? IsSendedMedula
        {
            get { return (bool?)this["ISSENDEDMEDULA"]; }
            set { this["ISSENDEDMEDULA"] = value; }
        }

    /// <summary>
    /// Rapor Düzenleme Türü
    /// </summary>
        public string DrugReportReason
        {
            get { return (string)this["DRUGREPORTREASON"]; }
            set { this["DRUGREPORTREASON"] = value; }
        }

    /// <summary>
    /// Hemoglobin A1 c
    /// </summary>
        public double? HemoglobinA1c
        {
            get { return (double?)this["HEMOGLOBINA1C"]; }
            set { this["HEMOGLOBINA1C"] = value; }
        }

    /// <summary>
    /// İkinci Doktor Onayı Kontrol
    /// </summary>
        public bool? IsSecondDoctorApproved
        {
            get { return (bool?)this["ISSECONDDOCTORAPPROVED"]; }
            set { this["ISSECONDDOCTORAPPROVED"] = value; }
        }

    /// <summary>
    /// Üçüncü Doktor Onayı Kontrol
    /// </summary>
        public bool? IsThirdDoctorApproved
        {
            get { return (bool?)this["ISTHIRDDOCTORAPPROVED"]; }
            set { this["ISTHIRDDOCTORAPPROVED"] = value; }
        }

    /// <summary>
    /// Açlık Kan Şekeri
    /// </summary>
        public double? AclikKanSekeri
        {
            get { return (double?)this["ACLIKKANSEKERI"]; }
            set { this["ACLIKKANSEKERI"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public double? Kilo
        {
            get { return (double?)this["KILO"]; }
            set { this["KILO"] = value; }
        }

    /// <summary>
    /// 2.Tabip
    /// </summary>
        public ResUser SecondDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SECONDDOCTOR"); }
            set { this["SECONDDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// 3.Tabip
    /// </summary>
        public ResUser ThirdDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("THIRDDOCTOR"); }
            set { this["THIRDDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ParticipantFreeDrugReportTemplate ParticipntFreeDrugReportTmplt
        {
            get { return (ParticipantFreeDrugReportTemplate)((ITTObject)this).GetParent("PARTICIPNTFREEDRUGREPORTTMPLT"); }
            set { this["PARTICIPNTFREEDRUGREPORTTMPLT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateParticipationFreeDrugsCollection()
        {
            _ParticipationFreeDrugs = new ParticipationFreeDrgGrid.ChildParticipationFreeDrgGridCollection(this, new Guid("1d5aa8f5-f88a-4ef7-96ba-52ccec6822bd"));
            ((ITTChildObjectCollection)_ParticipationFreeDrugs).GetChildren();
        }

        protected ParticipationFreeDrgGrid.ChildParticipationFreeDrgGridCollection _ParticipationFreeDrugs = null;
        public ParticipationFreeDrgGrid.ChildParticipationFreeDrgGridCollection ParticipationFreeDrugs
        {
            get
            {
                if (_ParticipationFreeDrugs == null)
                    CreateParticipationFreeDrugsCollection();
                return _ParticipationFreeDrugs;
            }
        }

        virtual protected void CreateMedulaReportResultsCollection()
        {
            _MedulaReportResults = new MedulaReportResult.ChildMedulaReportResultCollection(this, new Guid("51888f50-c6d5-44a6-8891-4319f5747e89"));
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

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _ParticipationFreeDrugReportHCProcedures = new HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection(_SubactionProcedures, "ParticipationFreeDrugReportHCProcedures");
        }

        private HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection _ParticipationFreeDrugReportHCProcedures = null;
        public HealthCommitteeProcedure.ChildHealthCommitteeProcedureCollection ParticipationFreeDrugReportHCProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _ParticipationFreeDrugReportHCProcedures;
            }            
        }

        protected ParticipatnFreeDrugReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ParticipatnFreeDrugReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ParticipatnFreeDrugReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ParticipatnFreeDrugReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ParticipatnFreeDrugReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PARTICIPATNFREEDRUGREPORT", dataRow) { }
        protected ParticipatnFreeDrugReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PARTICIPATNFREEDRUGREPORT", dataRow, isImported) { }
        public ParticipatnFreeDrugReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ParticipatnFreeDrugReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ParticipatnFreeDrugReport() : base() { }

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