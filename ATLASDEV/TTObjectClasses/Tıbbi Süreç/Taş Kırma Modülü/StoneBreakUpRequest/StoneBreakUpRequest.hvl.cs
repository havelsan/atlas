
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StoneBreakUpRequest")] 

    /// <summary>
    /// Taş Kırma
    /// </summary>
    public  partial class StoneBreakUpRequest : EpisodeActionWithDiagnosis, IAppointmentDef
    {
        public class StoneBreakUpRequestList : TTObjectCollection<StoneBreakUpRequest> { }
                    
        public class ChildStoneBreakUpRequestCollection : TTObject.TTChildObjectCollection<StoneBreakUpRequest>
        {
            public ChildStoneBreakUpRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStoneBreakUpRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class StoneBreakUpReportNQL_Class : TTReportNqlObject 
        {
            public long? Refno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
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

            public string DiplomaNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EmploymentRecordID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
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

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REPORT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public StoneBreakUpReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StoneBreakUpReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StoneBreakUpReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStoneBreakUpQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Symptom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYMPTOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["SYMPTOM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfReturn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFRETURN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REASONOFRETURN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REPORT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Image
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["IMAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["ISPATIENTAPPROVALFORMGIVEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaRaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["MEDULARAPORTAKIPNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["REPORTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object RadiologyInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOLOGYINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["RADIOLOGYINFORMATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string RaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DrAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetStoneBreakUpQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStoneBreakUpQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStoneBreakUpQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid ReturnedToRequester { get { return new Guid("cf12a208-15e9-4ad5-8800-054d16b736f2"); } }
            public static Guid ResultedUnsuccessfully { get { return new Guid("6f5b64b3-80cd-46d2-8823-a3efc77f77e6"); } }
            public static Guid ResultedSuccessfully { get { return new Guid("1069f4a0-0893-48c5-b799-a70222b37875"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("2b555589-b9db-40b7-99fe-a7289ecff6b7"); } }
            public static Guid Appointment { get { return new Guid("f246928b-c1bf-44d4-ad24-5834aeb0a056"); } }
            public static Guid RequestAcception { get { return new Guid("f7f870d6-00b0-40dc-90bc-91ea679b4a57"); } }
            public static Guid Procedure { get { return new Guid("cec1a9ce-038c-48ff-b615-b09b30c7aa8e"); } }
            public static Guid Request { get { return new Guid("48b0a959-afac-4a5a-b8c6-dc60c321f63c"); } }
            public static Guid ResultEntry { get { return new Guid("2fb10408-8e66-4dd6-be4f-f7ac613e3bb6"); } }
        }

        public static BindingList<StoneBreakUpRequest.StoneBreakUpReportNQL_Class> StoneBreakUpReportNQL(string STONEBREAKUP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].QueryDefs["StoneBreakUpReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STONEBREAKUP", STONEBREAKUP);

            return TTReportNqlObject.QueryObjects<StoneBreakUpRequest.StoneBreakUpReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StoneBreakUpRequest.StoneBreakUpReportNQL_Class> StoneBreakUpReportNQL(TTObjectContext objectContext, string STONEBREAKUP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].QueryDefs["StoneBreakUpReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STONEBREAKUP", STONEBREAKUP);

            return TTReportNqlObject.QueryObjects<StoneBreakUpRequest.StoneBreakUpReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<StoneBreakUpRequest> GetByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<StoneBreakUpRequest>(queryDef, paramList);
        }

        public static BindingList<StoneBreakUpRequest.GetStoneBreakUpQuery_Class> GetStoneBreakUpQuery(string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].QueryDefs["GetStoneBreakUpQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<StoneBreakUpRequest.GetStoneBreakUpQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StoneBreakUpRequest.GetStoneBreakUpQuery_Class> GetStoneBreakUpQuery(TTObjectContext objectContext, string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPREQUEST"].QueryDefs["GetStoneBreakUpQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<StoneBreakUpRequest.GetStoneBreakUpQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Anamnez ve Bulgular
    /// </summary>
        public string Symptom
        {
            get { return (string)this["SYMPTOM"]; }
            set { this["SYMPTOM"] = value; }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Red Rebebi
    /// </summary>
        public string ReasonOfReturn
        {
            get { return (string)this["REASONOFRETURN"]; }
            set { this["REASONOFRETURN"] = value; }
        }

    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
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
    /// Prosedür Tarihi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Şema
    /// </summary>
        public bool? Image
        {
            get { return (bool?)this["IMAGE"]; }
            set { this["IMAGE"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
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
    /// Medula Rapor Takip Numarası
    /// </summary>
        public string MedulaRaporTakipNo
        {
            get { return (string)this["MEDULARAPORTAKIPNO"]; }
            set { this["MEDULARAPORTAKIPNO"] = value; }
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
    /// Radyoloji Bilgileri
    /// </summary>
        public object RadiologyInformation
        {
            get { return (object)this["RADIOLOGYINFORMATION"]; }
            set { this["RADIOLOGYINFORMATION"] = value; }
        }

    /// <summary>
    /// Rapor Takip Numarası
    /// </summary>
        public string RaporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Anestezi Doktor Tescil No
    /// </summary>
        public string DrAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

        public ResEquipment Equipment
        {
            get { return (ResEquipment)((ITTObject)this).GetParent("EQUIPMENT"); }
            set { this["EQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedulaReportResultsCollection()
        {
            _MedulaReportResults = new MedulaReportResult.ChildMedulaReportResultCollection(this, new Guid("eb0962a9-c2f2-48bc-9ce4-f12a4da88073"));
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

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("c00c2c0a-36d1-4449-83ed-5d3e5971f7e9"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _StoneBreakUpProcedures = new StoneBreakUpProcedure.ChildStoneBreakUpProcedureCollection(_SubactionProcedures, "StoneBreakUpProcedures");
            _StoneBreakUpPackageProcedures = new StoneBreakUpPackageProcedure.ChildStoneBreakUpPackageProcedureCollection(_SubactionProcedures, "StoneBreakUpPackageProcedures");
        }

        private StoneBreakUpProcedure.ChildStoneBreakUpProcedureCollection _StoneBreakUpProcedures = null;
        public StoneBreakUpProcedure.ChildStoneBreakUpProcedureCollection StoneBreakUpProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _StoneBreakUpProcedures;
            }            
        }

        private StoneBreakUpPackageProcedure.ChildStoneBreakUpPackageProcedureCollection _StoneBreakUpPackageProcedures = null;
        public StoneBreakUpPackageProcedure.ChildStoneBreakUpPackageProcedureCollection StoneBreakUpPackageProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _StoneBreakUpPackageProcedures;
            }            
        }

        protected StoneBreakUpRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StoneBreakUpRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StoneBreakUpRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StoneBreakUpRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StoneBreakUpRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STONEBREAKUPREQUEST", dataRow) { }
        protected StoneBreakUpRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STONEBREAKUPREQUEST", dataRow, isImported) { }
        public StoneBreakUpRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StoneBreakUpRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StoneBreakUpRequest() : base() { }

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