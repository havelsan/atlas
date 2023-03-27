
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HyperbarikOxygenTreatmentRequest")] 

    /// <summary>
    /// Hiperbarik Oksijen Tedavisi İstek
    /// </summary>
    public  partial class HyperbarikOxygenTreatmentRequest : EpisodeActionWithDiagnosis, IReasonOfReject, IAllocateSpeciality, ICreateSubEpisode, IDiagnosisOzelDurum
    {
        public class HyperbarikOxygenTreatmentRequestList : TTObjectCollection<HyperbarikOxygenTreatmentRequest> { }
                    
        public class ChildHyperbarikOxygenTreatmentRequestCollection : TTObject.TTChildObjectCollection<HyperbarikOxygenTreatmentRequest>
        {
            public ChildHyperbarikOxygenTreatmentRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHyperbarikOxygenTreatmentRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class HOTReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REPORTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public HOTReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HOTReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HOTReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class HyperReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REPORTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public HyperReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HyperReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HyperReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHOTRequestQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsForensic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISFORENSIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["ISFORENSIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string CameHospital
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAMEHOSPITAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["CAMEHOSPITAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Decision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["DECISION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["COMPLAINT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string History
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["HISTORY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PyhsicalExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PYHSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["PYHSICALEXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaRaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULARAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["MEDULARAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REPORTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["REPORTSTARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? CreateSubEpisode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATESUBEPISODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["CREATESUBEPISODE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetHOTRequestQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHOTRequestQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHOTRequestQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("82314b2e-8417-43d1-865a-9bbfb41b4e1e"); } }
            public static Guid Request { get { return new Guid("8204261d-ec6d-4fbc-960c-7cc05d221d99"); } }
            public static Guid Completed { get { return new Guid("84cc8e4c-dc56-488d-9090-8ea58df751dc"); } }
        }

        public static BindingList<HyperbarikOxygenTreatmentRequest.HOTReportQuery_Class> HOTReportQuery(string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].QueryDefs["HOTReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentRequest.HOTReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentRequest.HOTReportQuery_Class> HOTReportQuery(TTObjectContext objectContext, string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].QueryDefs["HOTReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentRequest.HOTReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentRequest.HyperReportQuery_Class> HyperReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].QueryDefs["HyperReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentRequest.HyperReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentRequest.HyperReportQuery_Class> HyperReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].QueryDefs["HyperReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentRequest.HyperReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentRequest.GetHOTRequestQuery_Class> GetHOTRequestQuery(string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].QueryDefs["GetHOTRequestQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentRequest.GetHOTRequestQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HyperbarikOxygenTreatmentRequest.GetHOTRequestQuery_Class> GetHOTRequestQuery(TTObjectContext objectContext, string REPORTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].QueryDefs["GetHOTRequestQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTNO", REPORTNO);

            return TTReportNqlObject.QueryObjects<HyperbarikOxygenTreatmentRequest.GetHOTRequestQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Adli Vaka
    /// </summary>
        public bool? IsForensic
        {
            get { return (bool?)this["ISFORENSIC"]; }
            set { this["ISFORENSIC"] = value; }
        }

    /// <summary>
    /// Geldiği XXXXXX
    /// </summary>
        public string CameHospital
        {
            get { return (string)this["CAMEHOSPITAL"]; }
            set { this["CAMEHOSPITAL"] = value; }
        }

    /// <summary>
    /// KARAR
    /// </summary>
        public string Decision
        {
            get { return (string)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// Şikayet
    /// </summary>
        public object Complaint
        {
            get { return (object)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

    /// <summary>
    /// Hikaye
    /// </summary>
        public string History
        {
            get { return (string)this["HISTORY"]; }
            set { this["HISTORY"] = value; }
        }

    /// <summary>
    /// Fiziki Muayene
    /// </summary>
        public object PyhsicalExamination
        {
            get { return (object)this["PYHSICALEXAMINATION"]; }
            set { this["PYHSICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public string ReportNo
        {
            get { return (string)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
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
    /// Medula Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? ReportEndDate
        {
            get { return (DateTime?)this["REPORTENDDATE"]; }
            set { this["REPORTENDDATE"] = value; }
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
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Altvaka oluşsun mu
    /// </summary>
        public bool? CreateSubEpisode
        {
            get { return (bool?)this["CREATESUBEPISODE"]; }
            set { this["CREATESUBEPISODE"] = value; }
        }

        public ResUser ApprovedDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("APPROVEDDOCTOR"); }
            set { this["APPROVEDDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// HyperbarikOxygenTreatmentRequest OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHyperbaricOxygenTreatmentOrdersCollection()
        {
            _HyperbaricOxygenTreatmentOrders = new HyperbaricOxygenTreatmentOrder.ChildHyperbaricOxygenTreatmentOrderCollection(this, new Guid("92d6e895-1f5f-414b-9537-b2cec18e3993"));
            ((ITTChildObjectCollection)_HyperbaricOxygenTreatmentOrders).GetChildren();
        }

        protected HyperbaricOxygenTreatmentOrder.ChildHyperbaricOxygenTreatmentOrderCollection _HyperbaricOxygenTreatmentOrders = null;
    /// <summary>
    /// Child collection for Hiperbarik Oksijen Tedavi Emirleri
    /// </summary>
        public HyperbaricOxygenTreatmentOrder.ChildHyperbaricOxygenTreatmentOrderCollection HyperbaricOxygenTreatmentOrders
        {
            get
            {
                if (_HyperbaricOxygenTreatmentOrders == null)
                    CreateHyperbaricOxygenTreatmentOrdersCollection();
                return _HyperbaricOxygenTreatmentOrders;
            }
        }

        protected HyperbarikOxygenTreatmentRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HyperbarikOxygenTreatmentRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HyperbarikOxygenTreatmentRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HyperbarikOxygenTreatmentRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HyperbarikOxygenTreatmentRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HYPERBARIKOXYGENTREATMENTREQUEST", dataRow) { }
        protected HyperbarikOxygenTreatmentRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HYPERBARIKOXYGENTREATMENTREQUEST", dataRow, isImported) { }
        public HyperbarikOxygenTreatmentRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HyperbarikOxygenTreatmentRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HyperbarikOxygenTreatmentRequest() : base() { }

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