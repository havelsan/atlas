
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Manipulation")] 

    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class Manipulation : EpisodeActionWithDiagnosis, IReasonOfReject, IAppointmentDef, IWorkListEpisodeAction, ICreateSubEpisode, IDiagnosisOzelDurum
    {
        public class ManipulationList : TTObjectCollection<Manipulation> { }
                    
        public class ChildManipulationCollection : TTObject.TTChildObjectCollection<Manipulation>
        {
            public ChildManipulationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManipulationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAllManiplationOfPatient_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReturnReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["RETURNREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PreInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PREINFORMATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ProcedureReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PROCEDUREREPORT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReasonToContinue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONTOCONTINUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REASONTOCONTINUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsPatientApprovalFormGiven
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPATIENTAPPROVALFORMGIVEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ISPATIENTAPPROVALFORMGIVEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsGunubirlikTakip
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGUNUBIRLIKTAKIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ISGUNUBIRLIKTAKIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object ReportPDF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTPDF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REPORTPDF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetAllManiplationOfPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllManiplationOfPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllManiplationOfPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetManiplationbyEpisode_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReturnReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["RETURNREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PreInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PREINFORMATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ProcedureReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PROCEDUREREPORT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReasonToContinue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONTOCONTINUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REASONTOCONTINUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsPatientApprovalFormGiven
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPATIENTAPPROVALFORMGIVEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ISPATIENTAPPROVALFORMGIVEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsGunubirlikTakip
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGUNUBIRLIKTAKIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ISGUNUBIRLIKTAKIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object ReportPDF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTPDF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REPORTPDF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetManiplationbyEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetManiplationbyEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetManiplationbyEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetManipulationsbyRequest_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReturnReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["RETURNREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PreInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PREINFORMATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ProcedureReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PROCEDUREREPORT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReasonToContinue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONTOCONTINUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REASONTOCONTINUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsPatientApprovalFormGiven
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPATIENTAPPROVALFORMGIVEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ISPATIENTAPPROVALFORMGIVEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsGunubirlikTakip
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISGUNUBIRLIKTAKIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["ISGUNUBIRLIKTAKIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object ReportPDF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTPDF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REPORTPDF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetManipulationsbyRequest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetManipulationsbyRequest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetManipulationsbyRequest_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetManipulation22_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
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

            public string ReturnReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["RETURNREASON"].DataType;
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

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public Guid? FromResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FROMRESOURCE"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public OLAP_GetManipulation22_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetManipulation22_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetManipulation22_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForManipulation_Class : TTReportNqlObject 
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

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public GetOldInfoForManipulation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForManipulation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForManipulation_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("36f93e17-bb1b-463d-91cf-4f1509301402"); } }
            public static Guid RequestingDoctorFromTechnicianProcedure { get { return new Guid("fc28e20f-1268-44b5-a381-01af49b88b7a"); } }
            public static Guid RequestAcception { get { return new Guid("c81c378c-a99d-4c1f-bba1-06cf1325960e"); } }
            public static Guid Completed { get { return new Guid("be64830f-6ee8-46ba-8876-5745ddfff6b7"); } }
            public static Guid RequestingDoctorFromAcception { get { return new Guid("4270e9b0-a661-4e30-8619-5b1af46b5b9a"); } }
            public static Guid DoctorProcedure { get { return new Guid("8f7eaca9-238e-432f-beef-d491799399cd"); } }
            public static Guid Appointment { get { return new Guid("0e0777b1-85c3-4851-a8f9-d7258a2fdad3"); } }
            public static Guid ResultEntry { get { return new Guid("7f6cdc1c-1ba0-4037-9e09-6bb5944fa69a"); } }
            public static Guid TechnicianProcedure { get { return new Guid("5d7531fb-bac5-4603-8ed3-fb9800cc0e75"); } }
            public static Guid RequestingDoctorFromDoctorProcedure { get { return new Guid("771b2966-d4a7-40d5-b6fe-d53e3f70c1bf"); } }
            public static Guid NursingProcedure { get { return new Guid("c94e9826-b21d-4a1d-87ba-9785c27682d5"); } }
        }

        public static BindingList<Manipulation.GetAllManiplationOfPatient_Class> GetAllManiplationOfPatient(Guid PATIENTOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["GetAllManiplationOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJID", PATIENTOBJID);

            return TTReportNqlObject.QueryObjects<Manipulation.GetAllManiplationOfPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Manipulation.GetAllManiplationOfPatient_Class> GetAllManiplationOfPatient(TTObjectContext objectContext, Guid PATIENTOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["GetAllManiplationOfPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTOBJID", PATIENTOBJID);

            return TTReportNqlObject.QueryObjects<Manipulation.GetAllManiplationOfPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Manipulation.GetManiplationbyEpisode_Class> GetManiplationbyEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["GetManiplationbyEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<Manipulation.GetManiplationbyEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Manipulation.GetManiplationbyEpisode_Class> GetManiplationbyEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["GetManiplationbyEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<Manipulation.GetManiplationbyEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Manipulation.GetManipulationsbyRequest_Class> GetManipulationsbyRequest(Guid MANIPULATIONREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["GetManipulationsbyRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MANIPULATIONREQUEST", MANIPULATIONREQUEST);

            return TTReportNqlObject.QueryObjects<Manipulation.GetManipulationsbyRequest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Manipulation.GetManipulationsbyRequest_Class> GetManipulationsbyRequest(TTObjectContext objectContext, Guid MANIPULATIONREQUEST, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["GetManipulationsbyRequest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MANIPULATIONREQUEST", MANIPULATIONREQUEST);

            return TTReportNqlObject.QueryObjects<Manipulation.GetManipulationsbyRequest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Manipulation.OLAP_GetManipulation22_Class> OLAP_GetManipulation22(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["OLAP_GetManipulation22"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Manipulation.OLAP_GetManipulation22_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Manipulation.OLAP_GetManipulation22_Class> OLAP_GetManipulation22(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["OLAP_GetManipulation22"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Manipulation.OLAP_GetManipulation22_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Manipulation.GetOldInfoForManipulation_Class> GetOldInfoForManipulation(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["GetOldInfoForManipulation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Manipulation.GetOldInfoForManipulation_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Manipulation.GetOldInfoForManipulation_Class> GetOldInfoForManipulation(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANIPULATION"].QueryDefs["GetOldInfoForManipulation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Manipulation.GetOldInfoForManipulation_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Doktor İade Sebebi
    /// </summary>
        public string ReturnReason
        {
            get { return (string)this["RETURNREASON"]; }
            set { this["RETURNREASON"] = value; }
        }

    /// <summary>
    /// Teknisyen Notu
    /// </summary>
        public object TechnicianNote
        {
            get { return (object)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Ön Bilgi
    /// </summary>
        public object PreInformation
        {
            get { return (object)this["PREINFORMATION"]; }
            set { this["PREINFORMATION"] = value; }
        }

    /// <summary>
    /// Prosedür Raporu
    /// </summary>
        public object ProcedureReport
        {
            get { return (object)this["PROCEDUREREPORT"]; }
            set { this["PROCEDUREREPORT"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// İşleme Devam Etme Sebebi
    /// </summary>
        public string ReasonToContinue
        {
            get { return (string)this["REASONTOCONTINUE"]; }
            set { this["REASONTOCONTINUE"] = value; }
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
    /// Günübirlik Takip Al
    /// </summary>
        public bool? IsGunubirlikTakip
        {
            get { return (bool?)this["ISGUNUBIRLIKTAKIP"]; }
            set { this["ISGUNUBIRLIKTAKIP"] = value; }
        }

    /// <summary>
    /// PDF
    /// </summary>
        public object ReportPDF
        {
            get { return (object)this["REPORTPDF"]; }
            set { this["REPORTPDF"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

        public ManipulationRequest ManipulationRequest
        {
            get { return (ManipulationRequest)((ITTObject)this).GetParent("MANIPULATIONREQUEST"); }
            set { this["MANIPULATIONREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Technician
    /// </summary>
        public ResUser Technician
        {
            get { return (ResUser)((ITTObject)this).GetParent("TECHNICIAN"); }
            set { this["TECHNICIAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser SorumluDoktor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SORUMLUDOKTOR"); }
            set { this["SORUMLUDOKTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Manipulation OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Psikolog manipulasyon yapabilsin ve rapora çıksın diye eklendi
    /// </summary>
        public ResUser ResponsiblePersonnel
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEPERSONNEL"); }
            set { this["RESPONSIBLEPERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Manipulasyon İstemini Yapan Kullanıcı bilgisini tutar.
    /// </summary>
        public ResUser RequestedByUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTEDBYUSER"); }
            set { this["REQUESTEDBYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateManipulationPersonnelCollection()
        {
            _ManipulationPersonnel = new ManipulationPersonnel.ChildManipulationPersonnelCollection(this, new Guid("b5615e2c-e079-4eca-89f7-ad9b88e555bd"));
            ((ITTChildObjectCollection)_ManipulationPersonnel).GetChildren();
        }

        protected ManipulationPersonnel.ChildManipulationPersonnelCollection _ManipulationPersonnel = null;
        public ManipulationPersonnel.ChildManipulationPersonnelCollection ManipulationPersonnel
        {
            get
            {
                if (_ManipulationPersonnel == null)
                    CreateManipulationPersonnelCollection();
                return _ManipulationPersonnel;
            }
        }

        virtual protected void CreateManipulationReturnReasonsCollection()
        {
            _ManipulationReturnReasons = new ManipulationReturnReasonsGrid.ChildManipulationReturnReasonsGridCollection(this, new Guid("3dff5a50-674e-43ac-90a7-dc146a8054cf"));
            ((ITTChildObjectCollection)_ManipulationReturnReasons).GetChildren();
        }

        protected ManipulationReturnReasonsGrid.ChildManipulationReturnReasonsGridCollection _ManipulationReturnReasons = null;
    /// <summary>
    /// Child collection for Manipulation_ManipulationReturnReasonsGrid
    /// </summary>
        public ManipulationReturnReasonsGrid.ChildManipulationReturnReasonsGridCollection ManipulationReturnReasons
        {
            get
            {
                if (_ManipulationReturnReasons == null)
                    CreateManipulationReturnReasonsCollection();
                return _ManipulationReturnReasons;
            }
        }

        virtual protected void CreateMedulaReportResultsCollection()
        {
            _MedulaReportResults = new MedulaReportResult.ChildMedulaReportResultCollection(this, new Guid("f91ab9d5-3af3-4402-a138-cea52b1d3b06"));
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

        virtual protected void CreateManipulationFormBaseObjectCollection()
        {
            _ManipulationFormBaseObject = new ManipulationFormBaseObject.ChildManipulationFormBaseObjectCollection(this, new Guid("d6450bec-f000-4e63-a176-1f947118c0dd"));
            ((ITTChildObjectCollection)_ManipulationFormBaseObject).GetChildren();
        }

        protected ManipulationFormBaseObject.ChildManipulationFormBaseObjectCollection _ManipulationFormBaseObject = null;
        public ManipulationFormBaseObject.ChildManipulationFormBaseObjectCollection ManipulationFormBaseObject
        {
            get
            {
                if (_ManipulationFormBaseObject == null)
                    CreateManipulationFormBaseObjectCollection();
                return _ManipulationFormBaseObject;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _ManipulationProcedures = new ManipulationProcedure.ChildManipulationProcedureCollection(_SubactionProcedures, "ManipulationProcedures");
            _ManipulationAdditionalApplications = new ManipulationAdditionalApplication.ChildManipulationAdditionalApplicationCollection(_SubactionProcedures, "ManipulationAdditionalApplications");
        }

        private ManipulationProcedure.ChildManipulationProcedureCollection _ManipulationProcedures = null;
        public ManipulationProcedure.ChildManipulationProcedureCollection ManipulationProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _ManipulationProcedures;
            }            
        }

        private ManipulationAdditionalApplication.ChildManipulationAdditionalApplicationCollection _ManipulationAdditionalApplications = null;
        public ManipulationAdditionalApplication.ChildManipulationAdditionalApplicationCollection ManipulationAdditionalApplications
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _ManipulationAdditionalApplications;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _ManipulationTreatmentMaterials = new ManipulationTreatmentMaterial.ChildManipulationTreatmentMaterialCollection(_TreatmentMaterials, "ManipulationTreatmentMaterials");
            _Manipulation_SurgeryDirectPurchaseGrids = new SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection(_TreatmentMaterials, "Manipulation_SurgeryDirectPurchaseGrids");
            _Manipulation_CodelessMaterialDirectPurchaseGrids = new CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection(_TreatmentMaterials, "Manipulation_CodelessMaterialDirectPurchaseGrids");
        }

        private ManipulationTreatmentMaterial.ChildManipulationTreatmentMaterialCollection _ManipulationTreatmentMaterials = null;
        public ManipulationTreatmentMaterial.ChildManipulationTreatmentMaterialCollection ManipulationTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _ManipulationTreatmentMaterials;
            }            
        }

        private SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection _Manipulation_SurgeryDirectPurchaseGrids = null;
        public SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection Manipulation_SurgeryDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _Manipulation_SurgeryDirectPurchaseGrids;
            }            
        }

        private CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection _Manipulation_CodelessMaterialDirectPurchaseGrids = null;
        public CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection Manipulation_CodelessMaterialDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _Manipulation_CodelessMaterialDirectPurchaseGrids;
            }            
        }

        protected Manipulation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Manipulation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Manipulation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Manipulation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Manipulation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANIPULATION", dataRow) { }
        protected Manipulation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANIPULATION", dataRow, isImported) { }
        public Manipulation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Manipulation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Manipulation() : base() { }

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