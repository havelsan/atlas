
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HyperbaricOxygenTreatmentOrder")] 

    /// <summary>
    /// Hiperbarik Oksijen Tedavi Emirinin Verildiği Nesnedir
    /// </summary>
    public  partial class HyperbaricOxygenTreatmentOrder : BaseHyperbaricOxygenTreatmentOrder, ICreateSubEpisode, IOldActions, IReasonOfReject, IAppointmentDef, IAllocateSpeciality, IPlanPlannedAction
    {
        public class HyperbaricOxygenTreatmentOrderList : TTObjectCollection<HyperbaricOxygenTreatmentOrder> { }
                    
        public class ChildHyperbaricOxygenTreatmentOrderCollection : TTObject.TTChildObjectCollection<HyperbaricOxygenTreatmentOrder>
        {
            public ChildHyperbaricOxygenTreatmentOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHyperbaricOxygenTreatmentOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class HyperbaricAcceptionReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
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

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Hbarikoxygentreatreqobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HBARIKOXYGENTREATREQOBJECTID"]);
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

            public long? Hbarikoxygentreatreqprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HBARIKOXYGENTREATREQPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARIKOXYGENTREATMENTREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Docdiplomano
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCDIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docemploymentrecordid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCEMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Doctitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Dokrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docmilitaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCMILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Docwork
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCWORK"]);
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

            public string Docspeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HyperbaricAcceptionReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HyperbaricAcceptionReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HyperbaricAcceptionReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class HyperResultReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object DoctorReturnDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORRETURNDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["DOCTORRETURNDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object AbortRequestDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ABORTREQUESTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["ABORTREQUESTDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TreatmentStartDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTSTARTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTSTARTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Duration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["DURATION"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string TreatmentProperties
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTPROPERTIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTPROPERTIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PatientFollowUpForm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFOLLOWUPFORM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["PATIENTFOLLOWUPFORM"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["REPORT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["REPORTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? TreatmentPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? TreatmentDepth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTDEPTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].AllPropertyDefs["TREATMENTDEPTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public HyperResultReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HyperResultReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HyperResultReportQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid Aborted { get { return new Guid("6e64b0ff-432d-4281-b8e8-07b446358c66"); } }
            public static Guid Rejected { get { return new Guid("86b90676-b6a3-4148-bc05-297996b188c9"); } }
            public static Guid Completed { get { return new Guid("262d618a-fddd-42b0-bfb8-f1141b362b84"); } }
            public static Guid Cancelled { get { return new Guid("8a5d88ba-eb43-4268-abe3-69f37d73791b"); } }
            public static Guid Therapy { get { return new Guid("f163ff28-f062-4883-bece-c34d377c2032"); } }
            public static Guid Plan { get { return new Guid("8463f75d-f8a4-4ef4-8250-d78bc57dfc76"); } }
            public static Guid AutomaticPlan { get { return new Guid("dfef7402-6cad-4dff-9a12-e8090bdf537a"); } }
        }

        public static BindingList<HyperbaricOxygenTreatmentOrder> GetMySiblingObjectsForAppointment(TTObjectContext objectContext, string PARAMEPISODE, string PARAMCURRENTOBJECT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].QueryDefs["GetMySiblingObjectsForAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMEPISODE", PARAMEPISODE);
            paramList.Add("PARAMCURRENTOBJECT", PARAMCURRENTOBJECT);

            return ((ITTQuery)objectContext).QueryObjects<HyperbaricOxygenTreatmentOrder>(queryDef, paramList);
        }

        public static BindingList<HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL_Class> HyperbaricAcceptionReportNQL(string HYPERBARICOXYGENTREATMENTORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].QueryDefs["HyperbaricAcceptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HYPERBARICOXYGENTREATMENTORDER", HYPERBARICOXYGENTREATMENTORDER);

            return TTReportNqlObject.QueryObjects<HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL_Class> HyperbaricAcceptionReportNQL(TTObjectContext objectContext, string HYPERBARICOXYGENTREATMENTORDER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].QueryDefs["HyperbaricAcceptionReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HYPERBARICOXYGENTREATMENTORDER", HYPERBARICOXYGENTREATMENTORDER);

            return TTReportNqlObject.QueryObjects<HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HyperbaricOxygenTreatmentOrder.HyperResultReportQuery_Class> HyperResultReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].QueryDefs["HyperResultReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HyperbaricOxygenTreatmentOrder.HyperResultReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HyperbaricOxygenTreatmentOrder.HyperResultReportQuery_Class> HyperResultReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTORDER"].QueryDefs["HyperResultReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HyperbaricOxygenTreatmentOrder.HyperResultReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Süre/dk
    /// </summary>
        public long? Duration
        {
            get { return (long?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Hemşireye Emirler
    /// </summary>
        public string TreatmentProperties
        {
            get { return (string)this["TREATMENTPROPERTIES"]; }
            set { this["TREATMENTPROPERTIES"] = value; }
        }

    /// <summary>
    /// Hasta Takip Formu
    /// </summary>
        public object PatientFollowUpForm
        {
            get { return (object)this["PATIENTFOLLOWUPFORM"]; }
            set { this["PATIENTFOLLOWUPFORM"] = value; }
        }

        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
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
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Tadavi Süresi
    /// </summary>
        public int? TreatmentPeriod
        {
            get { return (int?)this["TREATMENTPERIOD"]; }
            set { this["TREATMENTPERIOD"] = value; }
        }

    /// <summary>
    /// Tedavi Derinliği (m)
    /// </summary>
        public int? TreatmentDepth
        {
            get { return (int?)this["TREATMENTDEPTH"]; }
            set { this["TREATMENTDEPTH"] = value; }
        }

    /// <summary>
    /// Tanı Tedavi Ünitesi
    /// </summary>
        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hiperbarik Oksijen Tedavi Emirleri
    /// </summary>
        public HyperbarikOxygenTreatmentRequest HyperOxygenTreatmentRequest
        {
            get { return (HyperbarikOxygenTreatmentRequest)((ITTObject)this).GetParent("HYPEROXYGENTREATMENTREQUEST"); }
            set { this["HYPEROXYGENTREATMENTREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavi Cihazı
    /// </summary>
        public ResEquipment TreatmentEquipment
        {
            get { return (ResEquipment)((ITTObject)this).GetParent("TREATMENTEQUIPMENT"); }
            set { this["TREATMENTEQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOrderDetailsCollection()
        {
            _OrderDetails = new SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection(this, new Guid("5c5c6442-4bca-495d-a23b-5ee7c2e20d48"));
            CreateOrderDetailsCollectionViews();
            ((ITTChildObjectCollection)_OrderDetails).GetChildren();
        }

        virtual protected void CreateMedulaReportResultsCollection()
        {
            _MedulaReportResults = new MedulaReportResult.ChildMedulaReportResultCollection(this, new Guid("954ab20c-0d09-41f9-ba1e-f8cc32d04bf8"));
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

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _HyperbarikOxygenTreatmentMaterials = new HyperbarikOxygenTreatmentMaterial.ChildHyperbarikOxygenTreatmentMaterialCollection(_TreatmentMaterials, "HyperbarikOxygenTreatmentMaterials");
        }

        private HyperbarikOxygenTreatmentMaterial.ChildHyperbarikOxygenTreatmentMaterialCollection _HyperbarikOxygenTreatmentMaterials = null;
        public HyperbarikOxygenTreatmentMaterial.ChildHyperbarikOxygenTreatmentMaterialCollection HyperbarikOxygenTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _HyperbarikOxygenTreatmentMaterials;
            }            
        }

        protected HyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HYPERBARICOXYGENTREATMENTORDER", dataRow) { }
        protected HyperbaricOxygenTreatmentOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HYPERBARICOXYGENTREATMENTORDER", dataRow, isImported) { }
        public HyperbaricOxygenTreatmentOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HyperbaricOxygenTreatmentOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HyperbaricOxygenTreatmentOrder() : base() { }

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