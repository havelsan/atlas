
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientInterviewForm")] 

    public  partial class PatientInterviewForm : EpisodeAction, IWorkListEpisodeAction
    {
        public class PatientInterviewFormList : TTObjectCollection<PatientInterviewForm> { }
                    
        public class ChildPatientInterviewFormCollection : TTObject.TTChildObjectCollection<PatientInterviewForm>
        {
            public ChildPatientInterviewFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientInterviewFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SocialServicesUnitRegistryReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public DateTime? ExaminationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["EXAMINATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Homeaddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PATIENTADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mobilephone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PATIENTPHONENUM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissionphoneno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONPHONENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissionaddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientTypeEnum? PatientType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PATIENTTYPE"].DataType;
                    return (PatientTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Procedurebyuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREBYUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? C0
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C0"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PSYCHOSOCIALSTUDYWITHPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PSYCHOSOCIALSTUDYPATFAMILY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["SOCIALREVIEWANDEVOLUTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["HOMEORORGANIZATIONVISIT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C4
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C4"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["WORKPLACEVISIT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C5
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C5"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["SCHOOLVISIT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C6
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C6"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["INSTUTIONALCAREPLACEMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C7
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C7"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PLACEMENTINTEMPORARYSHELTERS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C8
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C8"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["GOODSANDMONEYHELP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C9
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C9"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["TREATMENTEXPENSERESOURCEROUTE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C10
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C10"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PATIENTSGROUPSTUDY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C11
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C11"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["GROUPSTUDYWITHPATIENTFAMILY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C12
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C12"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PATIENTEDUCATIONANDWORKSTUDY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C13
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C13"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PATIENTTRANSFERERVICE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C14
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C14"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PSYCHOSOCIALEDUPATIENTFAMILY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C15
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C15"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["SOCIALACTIVITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? C16
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["C16"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["OTHERVOCATIONALINTERVENTIONS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SocialServicesUnitRegistryReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SocialServicesUnitRegistryReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SocialServicesUnitRegistryReport_Class() : base() { }
        }

        [Serializable] 

        public partial class SocialServicesUnitActivityReport_Class : TTReportNqlObject 
        {
            public Object C0
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C0"]);
                }
            }

            public Object C1
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C1"]);
                }
            }

            public Object C2
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C2"]);
                }
            }

            public Object C3
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C3"]);
                }
            }

            public Object C4
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C4"]);
                }
            }

            public Object C5
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C5"]);
                }
            }

            public Object C6
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C6"]);
                }
            }

            public Object C7
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C7"]);
                }
            }

            public Object C8
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C8"]);
                }
            }

            public Object C9
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C9"]);
                }
            }

            public Object C10
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C10"]);
                }
            }

            public Object C11
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C11"]);
                }
            }

            public Object C12
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C12"]);
                }
            }

            public Object C13
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C13"]);
                }
            }

            public Object C14
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C14"]);
                }
            }

            public Object C15
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C15"]);
                }
            }

            public Object C16
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["C16"]);
                }
            }

            public PatientTypeEnum? PatientType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PATIENTTYPE"].DataType;
                    return (PatientTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SocialServicesUnitActivityReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SocialServicesUnitActivityReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SocialServicesUnitActivityReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientInterviewFormsWL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public String Currentstatetext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATETEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

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

            public long? Patientuniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public string Roomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bedname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BEDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurebyuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREBYUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Requestedby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Subepisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetPatientInterviewFormsWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientInterviewFormsWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientInterviewFormsWL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İşlemde
    /// </summary>
            public static Guid Procedure { get { return new Guid("cf1c45ad-8a29-4137-8f88-35433be4d7eb"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("1feb0ae5-1530-44a4-9b85-b3009488c04a"); } }
    /// <summary>
    /// İşlem İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("082b2115-464a-4a49-b144-a9c22c8368c2"); } }
        }

        public static BindingList<PatientInterviewForm> GetAllPatientInterviewForms(TTObjectContext objectContext, string PATIENTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].QueryDefs["GetAllPatientInterviewForms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJECTID", PATIENTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<PatientInterviewForm>(queryDef, paramList);
        }

    /// <summary>
    /// Sosyal Hizmet Birimi Kayıt Defteri
    /// </summary>
        public static BindingList<PatientInterviewForm.SocialServicesUnitRegistryReport_Class> SocialServicesUnitRegistryReport(DateTime ENDDATE, DateTime STARTDATE, string PROCEDUREBYUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].QueryDefs["SocialServicesUnitRegistryReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("PROCEDUREBYUSER", PROCEDUREBYUSER);

            return TTReportNqlObject.QueryObjects<PatientInterviewForm.SocialServicesUnitRegistryReport_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Sosyal Hizmet Birimi Kayıt Defteri
    /// </summary>
        public static BindingList<PatientInterviewForm.SocialServicesUnitRegistryReport_Class> SocialServicesUnitRegistryReport(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, string PROCEDUREBYUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].QueryDefs["SocialServicesUnitRegistryReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("PROCEDUREBYUSER", PROCEDUREBYUSER);

            return TTReportNqlObject.QueryObjects<PatientInterviewForm.SocialServicesUnitRegistryReport_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sosyal Hizmet Birimi Faaliyet Raporu
    /// </summary>
        public static BindingList<PatientInterviewForm.SocialServicesUnitActivityReport_Class> SocialServicesUnitActivityReport(DateTime STARTDATE, DateTime ENDDATE, string PROCEDUREBYUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].QueryDefs["SocialServicesUnitActivityReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PROCEDUREBYUSER", PROCEDUREBYUSER);

            return TTReportNqlObject.QueryObjects<PatientInterviewForm.SocialServicesUnitActivityReport_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Sosyal Hizmet Birimi Faaliyet Raporu
    /// </summary>
        public static BindingList<PatientInterviewForm.SocialServicesUnitActivityReport_Class> SocialServicesUnitActivityReport(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string PROCEDUREBYUSER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].QueryDefs["SocialServicesUnitActivityReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PROCEDUREBYUSER", PROCEDUREBYUSER);

            return TTReportNqlObject.QueryObjects<PatientInterviewForm.SocialServicesUnitActivityReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientInterviewForm.GetPatientInterviewFormsWL_Class> GetPatientInterviewFormsWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].QueryDefs["GetPatientInterviewFormsWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientInterviewForm.GetPatientInterviewFormsWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientInterviewForm.GetPatientInterviewFormsWL_Class> GetPatientInterviewFormsWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].QueryDefs["GetPatientInterviewFormsWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientInterviewForm.GetPatientInterviewFormsWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Görüşme Yaplıan Yer
    /// </summary>
        public string InterviewPlace
        {
            get { return (string)this["INTERVIEWPLACE"]; }
            set { this["INTERVIEWPLACE"] = value; }
        }

    /// <summary>
    /// Görüşme Yapılan Kişiler
    /// </summary>
        public string InterviewedContacts
        {
            get { return (string)this["INTERVIEWEDCONTACTS"]; }
            set { this["INTERVIEWEDCONTACTS"] = value; }
        }

    /// <summary>
    /// Sorun Tanımı
    /// </summary>
        public string ProblemDefinition
        {
            get { return (string)this["PROBLEMDEFINITION"]; }
            set { this["PROBLEMDEFINITION"] = value; }
        }

    /// <summary>
    /// Başvuru/Havale/Görüşme Nedeni
    /// </summary>
        public string MeetingReason
        {
            get { return (string)this["MEETINGREASON"]; }
            set { this["MEETINGREASON"] = value; }
        }

    /// <summary>
    /// Hastanın Sağlık ve Fiziksel Durumu
    /// </summary>
        public string PatientHealthPhysicalCond
        {
            get { return (string)this["PATIENTHEALTHPHYSICALCOND"]; }
            set { this["PATIENTHEALTHPHYSICALCOND"] = value; }
        }

    /// <summary>
    /// Hasta Telefon Numarası
    /// </summary>
        public string PatientPhoneNum
        {
            get { return (string)this["PATIENTPHONENUM"]; }
            set { this["PATIENTPHONENUM"] = value; }
        }

    /// <summary>
    /// Hasta Adresi
    /// </summary>
        public string PatientAddress
        {
            get { return (string)this["PATIENTADDRESS"]; }
            set { this["PATIENTADDRESS"] = value; }
        }

    /// <summary>
    /// Hastanın Psikososyal ve Ailevi Durumu
    /// </summary>
        public string PatientPsychosocialFamilyCond
        {
            get { return (string)this["PATIENTPSYCHOSOCIALFAMILYCOND"]; }
            set { this["PATIENTPSYCHOSOCIALFAMILYCOND"] = value; }
        }

    /// <summary>
    /// Hastanın Barınma ve Ekonomik Durumu
    /// </summary>
        public string PatientAccomodationEcoCon
        {
            get { return (string)this["PATIENTACCOMODATIONECOCON"]; }
            set { this["PATIENTACCOMODATIONECOCON"] = value; }
        }

    /// <summary>
    /// Değerlendirme
    /// </summary>
        public string Evaluation
        {
            get { return (string)this["EVALUATION"]; }
            set { this["EVALUATION"] = value; }
        }

    /// <summary>
    /// Sonuç ve Öneriler
    /// </summary>
        public string ResultsAndRecommendations
        {
            get { return (string)this["RESULTSANDRECOMMENDATIONS"]; }
            set { this["RESULTSANDRECOMMENDATIONS"] = value; }
        }

    /// <summary>
    /// Hizmet Türü
    /// </summary>
        public TypeOfServicesEnum? TypeOfService
        {
            get { return (TypeOfServicesEnum?)(int?)this["TYPEOFSERVICE"]; }
            set { this["TYPEOFSERVICE"] = value; }
        }

        public DateTime? ExaminationDate
        {
            get { return (DateTime?)this["EXAMINATIONDATE"]; }
            set { this["EXAMINATIONDATE"] = value; }
        }

    /// <summary>
    /// Hasta Türü
    /// </summary>
        public PatientTypeEnum? PatientType
        {
            get { return (PatientTypeEnum?)(int?)this["PATIENTTYPE"]; }
            set { this["PATIENTTYPE"] = value; }
        }

    /// <summary>
    /// Hastayla Psikososyal Çalışma
    /// </summary>
        public bool? PsychosocialStudyWithPatient
        {
            get { return (bool?)this["PSYCHOSOCIALSTUDYWITHPATIENT"]; }
            set { this["PSYCHOSOCIALSTUDYWITHPATIENT"] = value; }
        }

    /// <summary>
    /// Hasta Ailesiyle Psikososyal Çalışma
    /// </summary>
        public bool? PsychosocialStudyPatFamily
        {
            get { return (bool?)this["PSYCHOSOCIALSTUDYPATFAMILY"]; }
            set { this["PSYCHOSOCIALSTUDYPATFAMILY"] = value; }
        }

    /// <summary>
    /// Sosyal İnceleme ve Değerlendirme
    /// </summary>
        public bool? SocialReviewAndEvolution
        {
            get { return (bool?)this["SOCIALREVIEWANDEVOLUTION"]; }
            set { this["SOCIALREVIEWANDEVOLUTION"] = value; }
        }

    /// <summary>
    /// Ev veya Kuruluş Ziyareti
    /// </summary>
        public bool? HomeOrOrganizationVisit
        {
            get { return (bool?)this["HOMEORORGANIZATIONVISIT"]; }
            set { this["HOMEORORGANIZATIONVISIT"] = value; }
        }

    /// <summary>
    /// İşyeri Ziyareti
    /// </summary>
        public bool? WorkplaceVisit
        {
            get { return (bool?)this["WORKPLACEVISIT"]; }
            set { this["WORKPLACEVISIT"] = value; }
        }

    /// <summary>
    /// Okul Ziyareti
    /// </summary>
        public bool? SchoolVisit
        {
            get { return (bool?)this["SCHOOLVISIT"]; }
            set { this["SCHOOLVISIT"] = value; }
        }

    /// <summary>
    /// Kurum Bakımına Yerleştirme
    /// </summary>
        public bool? InstutionalCarePlacement
        {
            get { return (bool?)this["INSTUTIONALCAREPLACEMENT"]; }
            set { this["INSTUTIONALCAREPLACEMENT"] = value; }
        }

    /// <summary>
    /// Geçici Barınma Merkezlerine Yerleştirme
    /// </summary>
        public bool? PlacementInTemporaryShelters
        {
            get { return (bool?)this["PLACEMENTINTEMPORARYSHELTERS"]; }
            set { this["PLACEMENTINTEMPORARYSHELTERS"] = value; }
        }

    /// <summary>
    /// Ayni ve Nakdi Yardım
    /// </summary>
        public bool? GoodsAndMoneyHelp
        {
            get { return (bool?)this["GOODSANDMONEYHELP"]; }
            set { this["GOODSANDMONEYHELP"] = value; }
        }

    /// <summary>
    /// Tedavi Giderleri için Kaynak Bulma ve Yönlendirme
    /// </summary>
        public bool? TreatmentExpenseResourceRoute
        {
            get { return (bool?)this["TREATMENTEXPENSERESOURCEROUTE"]; }
            set { this["TREATMENTEXPENSERESOURCEROUTE"] = value; }
        }

    /// <summary>
    /// Hastalara Grup Çalışması
    /// </summary>
        public bool? PatientsGroupStudy
        {
            get { return (bool?)this["PATIENTSGROUPSTUDY"]; }
            set { this["PATIENTSGROUPSTUDY"] = value; }
        }

    /// <summary>
    /// Hasta Ailesi ile Grup Çalışması
    /// </summary>
        public bool? GroupStudyWithPatientFamily
        {
            get { return (bool?)this["GROUPSTUDYWITHPATIENTFAMILY"]; }
            set { this["GROUPSTUDYWITHPATIENTFAMILY"] = value; }
        }

    /// <summary>
    /// Hasta Eğitimi ve Uğraşı Çalışması
    /// </summary>
        public bool? PatientEducationAndWorkStudy
        {
            get { return (bool?)this["PATIENTEDUCATIONANDWORKSTUDY"]; }
            set { this["PATIENTEDUCATIONANDWORKSTUDY"] = value; }
        }

    /// <summary>
    /// Hasta Nakil Hizmeti
    /// </summary>
        public bool? PatientTransferervice
        {
            get { return (bool?)this["PATIENTTRANSFERERVICE"]; }
            set { this["PATIENTTRANSFERERVICE"] = value; }
        }

    /// <summary>
    /// Hasta Ailesinin Psikososyal Eğitimi
    /// </summary>
        public bool? PsychosocialEduPatientFamily
        {
            get { return (bool?)this["PSYCHOSOCIALEDUPATIENTFAMILY"]; }
            set { this["PSYCHOSOCIALEDUPATIENTFAMILY"] = value; }
        }

    /// <summary>
    /// Sosyal Etkinlik
    /// </summary>
        public bool? SocialActivity
        {
            get { return (bool?)this["SOCIALACTIVITY"]; }
            set { this["SOCIALACTIVITY"] = value; }
        }

    /// <summary>
    /// Diğer Mesleki Müdahaleler
    /// </summary>
        public bool? OtherVocationalInterventions
        {
            get { return (bool?)this["OTHERVOCATIONALINTERVENTIONS"]; }
            set { this["OTHERVOCATIONALINTERVENTIONS"] = value; }
        }

    /// <summary>
    /// Hasta-Aile Bilgi Formu Hastanın Medeni Hali
    /// </summary>
        public MaritalStatusEnum? MaritalStatus
        {
            get { return (MaritalStatusEnum?)(int?)this["MARITALSTATUS"]; }
            set { this["MARITALSTATUS"] = value; }
        }

        public SocServPatientFamilyInfo SocServPatientFamilyInfo
        {
            get { return (SocServPatientFamilyInfo)((ITTObject)this).GetParent("SOCSERVPATIENTFAMILYINFO"); }
            set { this["SOCSERVPATIENTFAMILYINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Öğrenim Durumu
    /// </summary>
        public SKRSOgrenimDurumu EducationStatus
        {
            get { return (SKRSOgrenimDurumu)((ITTObject)this).GetParent("EDUCATIONSTATUS"); }
            set { this["EDUCATIONSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Mesleği
    /// </summary>
        public SKRSMeslekler PatientJob
        {
            get { return (SKRSMeslekler)((ITTObject)this).GetParent("PATIENTJOB"); }
            set { this["PATIENTJOB"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PhysicianApplication PhysicianApplication
        {
            get { return (PhysicianApplication)((ITTObject)this).GetParent("PHYSICIANAPPLICATION"); }
            set { this["PHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SocServAppliedProcedures SocServAppliedProcedures
        {
            get { return (SocServAppliedProcedures)((ITTObject)this).GetParent("SOCSERVAPPLIEDPROCEDURES"); }
            set { this["SOCSERVAPPLIEDPROCEDURES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser RequestedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTEDBY"); }
            set { this["REQUESTEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientInterviewForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientInterviewForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientInterviewForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientInterviewForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientInterviewForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTINTERVIEWFORM", dataRow) { }
        protected PatientInterviewForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTINTERVIEWFORM", dataRow, isImported) { }
        public PatientInterviewForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientInterviewForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientInterviewForm() : base() { }

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