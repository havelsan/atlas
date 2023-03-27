
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryRequest")] 

    /// <summary>
    /// Laboratuvar
    /// </summary>
    public  partial class LaboratoryRequest : EpisodeActionWithDiagnosis, ITreatmentMaterialCollection
    {
        public class LaboratoryRequestList : TTObjectCollection<LaboratoryRequest> { }
                    
        public class ChildLaboratoryRequestCollection : TTObject.TTChildObjectCollection<LaboratoryRequest>
        {
            public ChildLaboratoryRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class LaboratoryReportNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Prediagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Urgent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["URGENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["URGENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? PatientSex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PATIENTSEX"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMensturationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMENSTURATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LASTMENSTURATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? BarcodeID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["BARCODEID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string PatientAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PATIENTAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LabRequestAcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABREQUESTACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LABREQUESTACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public LaboratoryPregnancyEnum? Pregnancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PREGNANCY"].DataType;
                    return (LaboratoryPregnancyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MessageID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["MESSAGEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TargetObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TARGETOBJECTID"]);
                }
            }

            public Guid? SourceObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SOURCEOBJECTID"]);
                }
            }

            public bool? IsRequestSent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREQUESTSENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ISREQUESTSENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Binaryscaninfo
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BINARYSCANINFO"]);
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public string Prediagnosis1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reqdoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Labrequestacceptiondate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABREQUESTACCEPTIONDATE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LABREQUESTACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
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

            public Guid? Sex1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX1"]);
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

            public DateTime? Actdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public LaboratoryReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LaboratoryReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LaboratoryReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLastTwoLaboratoryRequests_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetLastTwoLaboratoryRequests_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLastTwoLaboratoryRequests_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLastTwoLaboratoryRequests_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLaboratoryRequestByBarcode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetLaboratoryRequestByBarcode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLaboratoryRequestByBarcode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLaboratoryRequestByBarcode_Class() : base() { }
        }

        [Serializable] 

        public partial class LaboratoryResultsTrackingScreenNQL_Class : TTReportNqlObject 
        {
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public LaboratoryResultsTrackingScreenNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LaboratoryResultsTrackingScreenNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LaboratoryResultsTrackingScreenNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLaboratoryRequestByFilter_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? BarcodeID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["BARCODEID"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetLaboratoryRequestByFilter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLaboratoryRequestByFilter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLaboratoryRequestByFilter_Class() : base() { }
        }

        [Serializable] 

        public partial class LaboratoryTripleTestInfoNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Prediagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Urgent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["URGENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["URGENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? PatientSex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PATIENTSEX"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMensturationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMENSTURATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LASTMENSTURATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? BarcodeID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["BARCODEID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string PatientAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PATIENTAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LabRequestAcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABREQUESTACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LABREQUESTACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public LaboratoryPregnancyEnum? Pregnancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PREGNANCY"].DataType;
                    return (LaboratoryPregnancyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MessageID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["MESSAGEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TargetObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TARGETOBJECTID"]);
                }
            }

            public Guid? SourceObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SOURCEOBJECTID"]);
                }
            }

            public bool? IsRequestSent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREQUESTSENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ISREQUESTSENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Tripletestinfo
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TRIPLETESTINFO"]);
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public string Prediagnosis1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reqdoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Labrequestacceptiondate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABREQUESTACCEPTIONDATE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LABREQUESTACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
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

            public Guid? Sex1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX1"]);
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

            public DateTime? Actdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public LaboratoryTripleTestInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LaboratoryTripleTestInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LaboratoryTripleTestInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class LaboratoryBinaryScanInfoNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Prediagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Urgent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["URGENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["URGENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? PatientSex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PATIENTSEX"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Notes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["NOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMensturationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMENSTURATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LASTMENSTURATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? BarcodeID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["BARCODEID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string PatientAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PATIENTAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LabRequestAcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABREQUESTACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["LABREQUESTACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public LaboratoryPregnancyEnum? Pregnancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["PREGNANCY"].DataType;
                    return (LaboratoryPregnancyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MessageID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["MESSAGEID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? TargetObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TARGETOBJECTID"]);
                }
            }

            public Guid? SourceObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SOURCEOBJECTID"]);
                }
            }

            public bool? IsRequestSent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREQUESTSENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["ISREQUESTSENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Binaryscaninfo
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BINARYSCANINFO"]);
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

            public string Reqdoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Requestdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
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

            public LaboratoryBinaryScanInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public LaboratoryBinaryScanInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected LaboratoryBinaryScanInfoNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İşlemde
    /// </summary>
            public static Guid Procedure { get { return new Guid("28bad858-c7ab-4767-8db1-0bc67695ef07"); } }
            public static Guid New { get { return new Guid("30d50f98-3f54-4a24-8205-bf16f32e8119"); } }
    /// <summary>
    /// Sonuç
    /// </summary>
            public static Guid Completed { get { return new Guid("27c96a7b-b54f-4c54-93eb-7bf4fb04bd5b"); } }
            public static Guid Rejected { get { return new Guid("3c6f90c6-9255-4e1d-a4b7-cab7d6e61bd9"); } }
    /// <summary>
    /// İstek Kabul
    /// </summary>
            public static Guid RequestAcception { get { return new Guid("29bbdcf0-20e7-44d9-99cc-ed387cd01066"); } }
            public static Guid Cancelled { get { return new Guid("be7312b4-2b70-41e7-969d-283af4004ac2"); } }
        }

        public static BindingList<LaboratoryRequest.LaboratoryReportNQL_Class> LaboratoryReportNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["LaboratoryReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.LaboratoryReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryRequest.LaboratoryReportNQL_Class> LaboratoryReportNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["LaboratoryReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.LaboratoryReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryRequest.GetLastTwoLaboratoryRequests_Class> GetLastTwoLaboratoryRequests(Guid PATIENTID, Guid MASTERRESOURCE, DateTime WORKLISTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["GetLastTwoLaboratoryRequests"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("WORKLISTDATE", WORKLISTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.GetLastTwoLaboratoryRequests_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryRequest.GetLastTwoLaboratoryRequests_Class> GetLastTwoLaboratoryRequests(TTObjectContext objectContext, Guid PATIENTID, Guid MASTERRESOURCE, DateTime WORKLISTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["GetLastTwoLaboratoryRequests"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);
            paramList.Add("WORKLISTDATE", WORKLISTDATE);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.GetLastTwoLaboratoryRequests_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryRequest.GetLaboratoryRequestByBarcode_Class> GetLaboratoryRequestByBarcode(long BARCODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["GetLaboratoryRequestByBarcode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARCODEID", BARCODEID);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.GetLaboratoryRequestByBarcode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryRequest.GetLaboratoryRequestByBarcode_Class> GetLaboratoryRequestByBarcode(TTObjectContext objectContext, long BARCODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["GetLaboratoryRequestByBarcode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARCODEID", BARCODEID);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.GetLaboratoryRequestByBarcode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Laboratuvar Sonuç Takip Ekranı NQL
    /// </summary>
        public static BindingList<LaboratoryRequest.LaboratoryResultsTrackingScreenNQL_Class> LaboratoryResultsTrackingScreenNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["LaboratoryResultsTrackingScreenNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.LaboratoryResultsTrackingScreenNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Laboratuvar Sonuç Takip Ekranı NQL
    /// </summary>
        public static BindingList<LaboratoryRequest.LaboratoryResultsTrackingScreenNQL_Class> LaboratoryResultsTrackingScreenNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["LaboratoryResultsTrackingScreenNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.LaboratoryResultsTrackingScreenNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryRequest.GetLaboratoryRequestByFilter_Class> GetLaboratoryRequestByFilter(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["GetLaboratoryRequestByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.GetLaboratoryRequestByFilter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryRequest.GetLaboratoryRequestByFilter_Class> GetLaboratoryRequestByFilter(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["GetLaboratoryRequestByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.GetLaboratoryRequestByFilter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class> LaboratoryTripleTestInfoNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["LaboratoryTripleTestInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class> LaboratoryTripleTestInfoNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["LaboratoryTripleTestInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.LaboratoryTripleTestInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class> LaboratoryBinaryScanInfoNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["LaboratoryBinaryScanInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class> LaboratoryBinaryScanInfoNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYREQUEST"].QueryDefs["LaboratoryBinaryScanInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<LaboratoryRequest.LaboratoryBinaryScanInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kısa Anamnez ve Klinik Bulgular
    /// </summary>
        public string Prediagnosis
        {
            get { return (string)this["PREDIAGNOSIS"]; }
            set { this["PREDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// İşlemin Acil Yapılması İçin İşaret Alanıdır
    /// </summary>
        public bool? Urgent
        {
            get { return (bool?)this["URGENT"]; }
            set { this["URGENT"] = value; }
        }

    /// <summary>
    /// Hasta Cinsiyeti
    /// </summary>
        public SexEnum? PatientSex
        {
            get { return (SexEnum?)(int?)this["PATIENTSEX"]; }
            set { this["PATIENTSEX"] = value; }
        }

    /// <summary>
    /// İşlem Esnasında Girilen Notlar Alanı
    /// </summary>
        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

    /// <summary>
    /// Son Adet Tarihinin Girildiği Alandır
    /// </summary>
        public DateTime? LastMensturationDate
        {
            get { return (DateTime?)this["LASTMENSTURATIONDATE"]; }
            set { this["LASTMENSTURATIONDATE"] = value; }
        }

    /// <summary>
    /// Protokol Numarası
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Barkod Numarası
    /// </summary>
        public int? BarcodeID
        {
            get { return (int?)this["BARCODEID"]; }
            set { this["BARCODEID"] = value; }
        }

    /// <summary>
    /// Hasta Yaşı
    /// </summary>
        public string PatientAge
        {
            get { return (string)this["PATIENTAGE"]; }
            set { this["PATIENTAGE"] = value; }
        }

    /// <summary>
    /// HIS Kabul Tarihi
    /// </summary>
        public DateTime? LabRequestAcceptionDate
        {
            get { return (DateTime?)this["LABREQUESTACCEPTIONDATE"]; }
            set { this["LABREQUESTACCEPTIONDATE"] = value; }
        }

    /// <summary>
    /// Gebelik
    /// </summary>
        public LaboratoryPregnancyEnum? Pregnancy
        {
            get { return (LaboratoryPregnancyEnum?)(int?)this["PREGNANCY"]; }
            set { this["PREGNANCY"] = value; }
        }

    /// <summary>
    /// Lab'a gönderilen mesaj ID'si
    /// </summary>
        public string MessageID
        {
            get { return (string)this["MESSAGEID"]; }
            set { this["MESSAGEID"] = value; }
        }

    /// <summary>
    /// Uzak Yordamlarda Hedef Nesne IDsi
    /// </summary>
        public Guid? TargetObjectID
        {
            get { return (Guid?)this["TARGETOBJECTID"]; }
            set { this["TARGETOBJECTID"] = value; }
        }

    /// <summary>
    /// Uzak Yordamlarda Giden (Kaynak) Nesne IDsi
    /// </summary>
        public Guid? SourceObjectID
        {
            get { return (Guid?)this["SOURCEOBJECTID"]; }
            set { this["SOURCEOBJECTID"] = value; }
        }

    /// <summary>
    /// İstek Başarılı Gönderildi
    /// </summary>
        public bool? IsRequestSent
        {
            get { return (bool?)this["ISREQUESTSENT"]; }
            set { this["ISREQUESTSENT"] = value; }
        }

    /// <summary>
    /// Laboratuvar İstek Şablonu İlişkisi
    /// </summary>
        public ActionTemplate LaboratoryRequestTemplate
        {
            get { return (ActionTemplate)((ITTObject)this).GetParent("LABORATORYREQUESTTEMPLATE"); }
            set { this["LABORATORYREQUESTTEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İsteği Yapan Tabip İlişkisi
    /// </summary>
        public ResUser RequestDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTDOCTOR"); }
            set { this["REQUESTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ana Test İlişkisi
    /// </summary>
        public LaboratoryTestDefinition MasterTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("MASTERTESTDEFINITION"); }
            set { this["MASTERTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Sonucuyla Onaylayan İlişkisi
    /// </summary>
        public ResUser ApprovedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("APPROVEDBY"); }
            set { this["APPROVEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Triple Test İstek Hasta Bilgileri
    /// </summary>
        public LaboratoryTripleTestInfo LaboratoryTripleTestInfo
        {
            get { return (LaboratoryTripleTestInfo)((ITTObject)this).GetParent("LABORATORYTRIPLETESTINFO"); }
            set { this["LABORATORYTRIPLETESTINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İkili Tarama Hasta Bilgileri
    /// </summary>
        public LaboratoryBinaryScanInfo LaboratoryBinaryScanInfo
        {
            get { return (LaboratoryBinaryScanInfo)((ITTObject)this).GetParent("LABORATORYBINARYSCANINFO"); }
            set { this["LABORATORYBINARYSCANINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRequestedProceduresCollection()
        {
            _RequestedProcedures = new LaboratoryRequestProcedure.ChildLaboratoryRequestProcedureCollection(this, new Guid("3b4a50cc-ff05-418f-81d0-f800f624206f"));
            ((ITTChildObjectCollection)_RequestedProcedures).GetChildren();
        }

        protected LaboratoryRequestProcedure.ChildLaboratoryRequestProcedureCollection _RequestedProcedures = null;
        public LaboratoryRequestProcedure.ChildLaboratoryRequestProcedureCollection RequestedProcedures
        {
            get
            {
                if (_RequestedProcedures == null)
                    CreateRequestedProceduresCollection();
                return _RequestedProcedures;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _LaboratoryProcedures = new LaboratoryProcedure.ChildLaboratoryProcedureCollection(_SubactionProcedures, "LaboratoryProcedures");
        }

        private LaboratoryProcedure.ChildLaboratoryProcedureCollection _LaboratoryProcedures = null;
        public LaboratoryProcedure.ChildLaboratoryProcedureCollection LaboratoryProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _LaboratoryProcedures;
            }            
        }

        protected LaboratoryRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYREQUEST", dataRow) { }
        protected LaboratoryRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYREQUEST", dataRow, isImported) { }
        public LaboratoryRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryRequest() : base() { }

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