
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientExamination")] 

    /// <summary>
    /// Hasta Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class PatientExamination : PhysicianApplication, IPatientWorkList, IReasonOfReject, IAppointmentDef, IAllocateSpeciality, ICheckTreatmentMaterialIsEmpty, IOAExamination, IWorkListEpisodeAction, ITreatmentMaterialCollection, INumaratorAppointment
    {
        public class PatientExaminationList : TTObjectCollection<PatientExamination> { }
                    
        public class ChildPatientExaminationCollection : TTObject.TTChildObjectCollection<PatientExamination>
        {
            public ChildPatientExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetPatientExamination_Class : TTReportNqlObject 
        {
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Doctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTOR"]);
                }
            }

            public Guid? Resource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCE"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public Object Paid
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAID"]);
                }
            }

            public Object Reasonforadmission
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADMISSION"]);
                }
            }

            public Object Procedurename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                }
            }

            public Object Subspeciality
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUBSPECIALITY"]);
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

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Homecountry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HOMECOUNTRY"]);
                }
            }

            public Object Countryofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNTRYOFBIRTH"]);
                }
            }

            public Object Returndescription
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RETURNDESCRIPTION"]);
                }
            }

            public OLAP_GetPatientExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPatientExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPatientExamination_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExaminationNQL_Class : TTReportNqlObject 
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

            public string Cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
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

            public string HomeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
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

            public string Ayaktantakipno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AYAKTANTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["ONLINEPROTOKOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSILKODLARI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetPatientExaminationNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExaminationNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExaminationNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledPatientExamination_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetCancelledPatientExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledPatientExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledPatientExamination_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientAbsentNQL_Class : TTReportNqlObject 
        {
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

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientAbsentNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientAbsentNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientAbsentNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExaminationByMasterResource_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["COMPLAINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DECISIONANDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EXAMINATIONSUMMARY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["HABITS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IMAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISTREATMENTMATERIALEMPTY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFOLDER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTSTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["SYSTEMQUERY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsObservationTaken
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOBSERVATIONTAKEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOBSERVATIONTAKEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsReportMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREPORTMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISREPORTMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ReportedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REPORTEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsApproveMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISAPPROVEMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISAPPROVEMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ApprovedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["APPROVEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DischargeTypeEnum? MTSDischargeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETYPE"].DataType;
                    return (DischargeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DishargeToPlaceEnum? MTSDischargeToPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETOPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETOPLACE"].DataType;
                    return (DishargeToPlaceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MedulaESevkNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAESEVKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAESEVKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaMutatDisiAracRaporNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAMUTATDISIARACRAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAMUTATDISIARACRAPORNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracRaporTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBASLANGICTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBitisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBITISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBITISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MutatDisiGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaRefakatciGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaRefakatciDurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIDURUMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MutatDisiAracRaporId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public PatientExaminationEnum? PatientExaminationType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTEXAMINATIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTEXAMINATIONTYPE"].DataType;
                    return (PatientExaminationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPatientExaminationByMasterResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExaminationByMasterResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExaminationByMasterResource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExamiationsForBeatenAndAlcohol_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["COMPLAINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DECISIONANDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EXAMINATIONSUMMARY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["HABITS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IMAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISTREATMENTMATERIALEMPTY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFOLDER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTSTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["SYSTEMQUERY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsObservationTaken
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOBSERVATIONTAKEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOBSERVATIONTAKEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsReportMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREPORTMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISREPORTMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ReportedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REPORTEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsApproveMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISAPPROVEMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISAPPROVEMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ApprovedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["APPROVEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DischargeTypeEnum? MTSDischargeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETYPE"].DataType;
                    return (DischargeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DishargeToPlaceEnum? MTSDischargeToPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETOPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETOPLACE"].DataType;
                    return (DishargeToPlaceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MedulaESevkNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAESEVKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAESEVKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaMutatDisiAracRaporNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAMUTATDISIARACRAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAMUTATDISIARACRAPORNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracRaporTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBASLANGICTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBitisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBITISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBITISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MutatDisiGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaRefakatciGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaRefakatciDurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIDURUMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MutatDisiAracRaporId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public PatientExaminationEnum? PatientExaminationType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTEXAMINATIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTEXAMINATIONTYPE"].DataType;
                    return (PatientExaminationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Objectid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID1"]);
                }
            }

            public GetPatientExamiationsForBeatenAndAlcohol_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExamiationsForBeatenAndAlcohol_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExamiationsForBeatenAndAlcohol_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExaminationByObjectIDs_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["COMPLAINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DECISIONANDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EXAMINATIONSUMMARY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["HABITS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IMAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISTREATMENTMATERIALEMPTY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFOLDER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTSTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["SYSTEMQUERY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsObservationTaken
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOBSERVATIONTAKEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOBSERVATIONTAKEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsReportMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREPORTMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISREPORTMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ReportedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REPORTEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsApproveMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISAPPROVEMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISAPPROVEMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ApprovedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["APPROVEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DischargeTypeEnum? MTSDischargeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETYPE"].DataType;
                    return (DischargeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DishargeToPlaceEnum? MTSDischargeToPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETOPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETOPLACE"].DataType;
                    return (DishargeToPlaceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MedulaESevkNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAESEVKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAESEVKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaMutatDisiAracRaporNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAMUTATDISIARACRAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAMUTATDISIARACRAPORNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracRaporTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBASLANGICTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBitisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBITISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBITISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MutatDisiGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaRefakatciGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaRefakatciDurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIDURUMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MutatDisiAracRaporId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public PatientExaminationEnum? PatientExaminationType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTEXAMINATIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTEXAMINATIONTYPE"].DataType;
                    return (PatientExaminationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPatientExaminationByObjectIDs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExaminationByObjectIDs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExaminationByObjectIDs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPANoDiagnose_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["COMPLAINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DECISIONANDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EXAMINATIONSUMMARY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["HABITS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IMAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISTREATMENTMATERIALEMPTY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFOLDER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTSTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["SYSTEMQUERY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsObservationTaken
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOBSERVATIONTAKEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOBSERVATIONTAKEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsReportMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREPORTMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISREPORTMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ReportedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REPORTEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsApproveMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISAPPROVEMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISAPPROVEMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ApprovedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["APPROVEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DischargeTypeEnum? MTSDischargeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETYPE"].DataType;
                    return (DischargeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DishargeToPlaceEnum? MTSDischargeToPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETOPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETOPLACE"].DataType;
                    return (DishargeToPlaceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MedulaESevkNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAESEVKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAESEVKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaMutatDisiAracRaporNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAMUTATDISIARACRAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAMUTATDISIARACRAPORNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracRaporTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBASLANGICTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBitisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBITISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBITISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MutatDisiGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaRefakatciGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaRefakatciDurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIDURUMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MutatDisiAracRaporId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public PatientExaminationEnum? PatientExaminationType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTEXAMINATIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTEXAMINATIONTYPE"].DataType;
                    return (PatientExaminationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPANoDiagnose_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPANoDiagnose_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPANoDiagnose_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDoctorsWorkListReportNQL_Class : TTReportNqlObject 
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

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
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

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Objectdefid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID1"]);
                }
            }

            public String Objectdefdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetDoctorsWorkListReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDoctorsWorkListReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDoctorsWorkListReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExaminationForWL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public string Triage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRIAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSTRIAJKODU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Examinationprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientadmission
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTADMISSION"]);
                }
            }

            public GetPatientExaminationForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExaminationForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExaminationForWL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExaminationByMasterAction_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["COMPLAINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["DECISIONANDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["EXAMINATIONSUMMARY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["HABITS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["IMAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISTREATMENTMATERIALEMPTY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTFOLDER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTHISTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTSTORY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["SYSTEMQUERY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsObservationTaken
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOBSERVATIONTAKEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISOBSERVATIONTAKEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsReportMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREPORTMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISREPORTMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ReportedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REPORTEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsApproveMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISAPPROVEMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["ISAPPROVEMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ApprovedMHRSGreenList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDMHRSGREENLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["APPROVEDMHRSGREENLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DischargeTypeEnum? MTSDischargeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETYPE"].DataType;
                    return (DischargeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DishargeToPlaceEnum? MTSDischargeToPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSDISCHARGETOPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MTSDISCHARGETOPLACE"].DataType;
                    return (DishargeToPlaceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MedulaESevkNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAESEVKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAESEVKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaMutatDisiAracRaporNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAMUTATDISIARACRAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAMUTATDISIARACRAPORNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracRaporTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBASLANGICTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBitisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBITISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACBITISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MutatDisiGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaRefakatciGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaRefakatciDurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MEDULAREFAKATCIDURUMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MutatDisiAracRaporId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["MUTATDISIARACRAPORID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public PatientExaminationEnum? PatientExaminationType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTEXAMINATIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PATIENTEXAMINATIONTYPE"].DataType;
                    return (PatientExaminationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPatientExaminationByMasterAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExaminationByMasterAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExaminationByMasterAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExaminationDurationByDate_Class : TTReportNqlObject 
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

            public DateTime? Processstartdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcessEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientExaminationDurationByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExaminationDurationByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExaminationDurationByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPolyclinicBookByDate_Class : TTReportNqlObject 
        {
            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
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

            public string Sex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HomeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnosename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Treatmentresult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCIKISSEKLI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public AdmissionStatusEnum? AdmissionStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["ADMISSIONSTATUS"].DataType;
                    return (AdmissionStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPolyclinicBookByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPolyclinicBookByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPolyclinicBookByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExaminationForEmergencyLcd_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetPatientExaminationForEmergencyLcd_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExaminationForEmergencyLcd_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExaminationForEmergencyLcd_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPandemicPatientsData_Class : TTReportNqlObject 
        {
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

            public string Phone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Address
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
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

            public GetPandemicPatientsData_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPandemicPatientsData_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPandemicPatientsData_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientExaminationByPA_Class : TTReportNqlObject 
        {
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetPatientExaminationByPA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientExaminationByPA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientExaminationByPA_Class() : base() { }
        }

        [Serializable] 

        public partial class GetExaminationsQueCount_Class : TTReportNqlObject 
        {
            public Object Toplam
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAM"]);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public GetExaminationsQueCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExaminationsQueCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExaminationsQueCount_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Hasta Gelmedi
    /// </summary>
            public static Guid PatientNoShown { get { return new Guid("29d29b1c-ce13-4e32-a85f-16097a2c14a4"); } }
            public static Guid Cancelled { get { return new Guid("9d8bb3ba-aa2c-415d-ba95-746c42e4f788"); } }
            public static Guid Completed { get { return new Guid("4afe1d14-f57a-4f76-afb1-51d7371876ea"); } }
            public static Guid Examination { get { return new Guid("de3eaf04-75ee-4978-8f85-980be4bfabae"); } }
    /// <summary>
    /// Muayenede tetkik istenmeyip tanı girildiyse bu state e geçer
    /// </summary>
            public static Guid ExaminationCompleted { get { return new Guid("7559956e-aad6-4edb-be05-212dcf46e789"); } }
    /// <summary>
    /// Muayenede tetkik istendi ve sonucu bekleniyorsa bu state e geçer
    /// </summary>
            public static Guid ProcedureRequested { get { return new Guid("168436c3-eb53-4103-b119-7966bf4820b7"); } }
        }

        public static BindingList<PatientExamination.OLAP_GetPatientExamination_Class> OLAP_GetPatientExamination(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["OLAP_GetPatientExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.OLAP_GetPatientExamination_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.OLAP_GetPatientExamination_Class> OLAP_GetPatientExamination(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["OLAP_GetPatientExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.OLAP_GetPatientExamination_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination> GetPatientExaminationByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<PatientExamination>(queryDef, paramList);
        }

        public static BindingList<PatientExamination.GetPatientExaminationNQL_Class> GetPatientExaminationNQL(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationNQL_Class> GetPatientExaminationNQL(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.OLAP_GetCancelledPatientExamination_Class> OLAP_GetCancelledPatientExamination(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["OLAP_GetCancelledPatientExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.OLAP_GetCancelledPatientExamination_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.OLAP_GetCancelledPatientExamination_Class> OLAP_GetCancelledPatientExamination(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["OLAP_GetCancelledPatientExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.OLAP_GetCancelledPatientExamination_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination> GetUnCompletedExaminationForClosedEpisode(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetUnCompletedExaminationForClosedEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PatientExamination>(queryDef, paramList);
        }

        public static BindingList<PatientExamination> GetPatientExaminationByResponsibleDoctor(TTObjectContext objectContext, string PROCEDUREDOCTOR, DateTime CURRENTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByResponsibleDoctor"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREDOCTOR", PROCEDUREDOCTOR);
            paramList.Add("CURRENTDATE", CURRENTDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientExamination>(queryDef, paramList);
        }

        public static BindingList<PatientExamination.GetPatientAbsentNQL_Class> GetPatientAbsentNQL(DateTime TARIH, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientAbsentNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TARIH", TARIH);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientAbsentNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPatientAbsentNQL_Class> GetPatientAbsentNQL(TTObjectContext objectContext, DateTime TARIH, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientAbsentNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TARIH", TARIH);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientAbsentNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationByMasterResource_Class> GetPatientExaminationByMasterResource(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationByMasterResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationByMasterResource_Class> GetPatientExaminationByMasterResource(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationByMasterResource_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination> InactiveExaminationsNQL(TTObjectContext objectContext, DateTime TARIH, Guid STATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["InactiveExaminationsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TARIH", TARIH);
            paramList.Add("STATE", STATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientExamination>(queryDef, paramList);
        }

        public static BindingList<PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class> GetPatientExamiationsForBeatenAndAlcohol(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExamiationsForBeatenAndAlcohol"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class> GetPatientExamiationsForBeatenAndAlcohol(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExamiationsForBeatenAndAlcohol"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination> GetPEByPatientAndAdmissionResource(TTObjectContext objectContext, Guid PATIENT, string ADMISSIONRESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPEByPatientAndAdmissionResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("ADMISSIONRESOURCE", ADMISSIONRESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<PatientExamination>(queryDef, paramList);
        }

        public static BindingList<PatientExamination.GetPatientExaminationByObjectIDs_Class> GetPatientExaminationByObjectIDs(Guid OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByObjectIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationByObjectIDs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationByObjectIDs_Class> GetPatientExaminationByObjectIDs(TTObjectContext objectContext, Guid OBJECTIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByObjectIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationByObjectIDs_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPANoDiagnose_Class> GetPANoDiagnose(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPANoDiagnose"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPANoDiagnose_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPANoDiagnose_Class> GetPANoDiagnose(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPANoDiagnose"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPANoDiagnose_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination> GetPEByPatientAndMainSpecialty(TTObjectContext objectContext, Guid PATIENT, Guid MAINSPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPEByPatientAndMainSpecialty"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("MAINSPECIALITY", MAINSPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<PatientExamination>(queryDef, paramList);
        }

        public static BindingList<PatientExamination> GetDailyOpenPatientExaminations(TTObjectContext objectContext, DateTime DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetDailyOpenPatientExaminations"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientExamination>(queryDef, paramList);
        }

        public static BindingList<PatientExamination.GetDoctorsWorkListReportNQL_Class> GetDoctorsWorkListReportNQL(DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetDoctorsWorkListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetDoctorsWorkListReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientExamination.GetDoctorsWorkListReportNQL_Class> GetDoctorsWorkListReportNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, DateTime MINDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetDoctorsWorkListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MINDATE", MINDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetDoctorsWorkListReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationForWL_Class> GetPatientExaminationForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationForWL_Class> GetPatientExaminationForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationByMasterAction_Class> GetPatientExaminationByMasterAction(Guid MASTERACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTION", MASTERACTION);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationByMasterAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationByMasterAction_Class> GetPatientExaminationByMasterAction(TTObjectContext objectContext, Guid MASTERACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTION", MASTERACTION);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationByMasterAction_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Poliklinik Muayene Süreleri
    /// </summary>
        public static BindingList<PatientExamination.GetPatientExaminationDurationByDate_Class> GetPatientExaminationDurationByDate(DateTime STARTDATE, DateTime ENDDATE, Guid RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationDurationByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationDurationByDate_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Poliklinik Muayene Süreleri
    /// </summary>
        public static BindingList<PatientExamination.GetPatientExaminationDurationByDate_Class> GetPatientExaminationDurationByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid RESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationDurationByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationDurationByDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Poliklinik Defteri
    /// </summary>
        public static BindingList<PatientExamination.GetPolyclinicBookByDate_Class> GetPolyclinicBookByDate(DateTime ENDDATE, Guid RESOURCE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPolyclinicBookByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPolyclinicBookByDate_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Poliklinik Defteri
    /// </summary>
        public static BindingList<PatientExamination.GetPolyclinicBookByDate_Class> GetPolyclinicBookByDate(TTObjectContext objectContext, DateTime ENDDATE, Guid RESOURCE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPolyclinicBookByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPolyclinicBookByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationForEmergencyLcd_Class> GetPatientExaminationForEmergencyLcd(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationForEmergencyLcd"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationForEmergencyLcd_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationForEmergencyLcd_Class> GetPatientExaminationForEmergencyLcd(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationForEmergencyLcd"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationForEmergencyLcd_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Doktorun mevcut gündeki muayeneleri
    /// </summary>
        public static BindingList<PatientExamination> GetDoctorsDailyOpenExamination(TTObjectContext objectContext, Guid PROCEDUREDOCTOR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetDoctorsDailyOpenExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDUREDOCTOR", PROCEDUREDOCTOR);

            return ((ITTQuery)objectContext).QueryObjects<PatientExamination>(queryDef, paramList);
        }

        public static BindingList<PatientExamination.GetPandemicPatientsData_Class> GetPandemicPatientsData(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPandemicPatientsData"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPandemicPatientsData_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientExamination.GetPandemicPatientsData_Class> GetPandemicPatientsData(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPandemicPatientsData"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPandemicPatientsData_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationByPA_Class> GetPatientExaminationByPA(Guid PATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByPA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTADMISSION", PATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationByPA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetPatientExaminationByPA_Class> GetPatientExaminationByPA(TTObjectContext objectContext, Guid PATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetPatientExaminationByPA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTADMISSION", PATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetPatientExaminationByPA_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetExaminationsQueCount_Class> GetExaminationsQueCount(IList<Guid> POLICLINICLIST, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetExaminationsQueCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("POLICLINICLIST", POLICLINICLIST);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetExaminationsQueCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientExamination.GetExaminationsQueCount_Class> GetExaminationsQueCount(TTObjectContext objectContext, IList<Guid> POLICLINICLIST, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].QueryDefs["GetExaminationsQueCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("POLICLINICLIST", POLICLINICLIST);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);

            return TTReportNqlObject.QueryObjects<PatientExamination.GetExaminationsQueCount_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Müşahedeye Alınsın Mı
    /// </summary>
        public bool? IsObservationTaken
        {
            get { return (bool?)this["ISOBSERVATIONTAKEN"]; }
            set { this["ISOBSERVATIONTAKEN"] = value; }
        }

    /// <summary>
    /// MHRS Yeşil Listeye Bildir
    /// </summary>
        public bool? IsReportMHRSGreenList
        {
            get { return (bool?)this["ISREPORTMHRSGREENLIST"]; }
            set { this["ISREPORTMHRSGREENLIST"] = value; }
        }

    /// <summary>
    /// MHRS Yeşil listeye eklendi
    /// </summary>
        public bool? ReportedMHRSGreenList
        {
            get { return (bool?)this["REPORTEDMHRSGREENLIST"]; }
            set { this["REPORTEDMHRSGREENLIST"] = value; }
        }

    /// <summary>
    /// MHRS Yeşil Liste Onayla
    /// </summary>
        public bool? IsApproveMHRSGreenList
        {
            get { return (bool?)this["ISAPPROVEMHRSGREENLIST"]; }
            set { this["ISAPPROVEMHRSGREENLIST"] = value; }
        }

    /// <summary>
    /// Takip Gerektiren Hasta Yapıldı
    /// </summary>
        public bool? ApprovedMHRSGreenList
        {
            get { return (bool?)this["APPROVEDMHRSGREENLIST"]; }
            set { this["APPROVEDMHRSGREENLIST"] = value; }
        }

    /// <summary>
    /// Taburcu Tipi
    /// </summary>
        public DischargeTypeEnum? MTSDischargeType
        {
            get { return (DischargeTypeEnum?)(int?)this["MTSDISCHARGETYPE"]; }
            set { this["MTSDISCHARGETYPE"] = value; }
        }

    /// <summary>
    /// Taburcu Gidiş Yeri
    /// </summary>
        public DishargeToPlaceEnum? MTSDischargeToPlace
        {
            get { return (DishargeToPlaceEnum?)(int?)this["MTSDISCHARGETOPLACE"]; }
            set { this["MTSDISCHARGETOPLACE"] = value; }
        }

    /// <summary>
    /// Medula ESevk No
    /// </summary>
        public string MedulaESevkNo
        {
            get { return (string)this["MEDULAESEVKNO"]; }
            set { this["MEDULAESEVKNO"] = value; }
        }

    /// <summary>
    /// Medula Mutat Dışı Araç Rapor No
    /// </summary>
        public string MedulaMutatDisiAracRaporNo
        {
            get { return (string)this["MEDULAMUTATDISIARACRAPORNO"]; }
            set { this["MEDULAMUTATDISIARACRAPORNO"] = value; }
        }

    /// <summary>
    /// Mutat Dışı Araç Rapor Tarihi
    /// </summary>
        public DateTime? MutatDisiAracRaporTarihi
        {
            get { return (DateTime?)this["MUTATDISIARACRAPORTARIHI"]; }
            set { this["MUTATDISIARACRAPORTARIHI"] = value; }
        }

    /// <summary>
    /// Mutat Dışı Araç Rapor Başlangıç Tarihi
    /// </summary>
        public DateTime? MutatDisiAracBaslangicTarihi
        {
            get { return (DateTime?)this["MUTATDISIARACBASLANGICTARIHI"]; }
            set { this["MUTATDISIARACBASLANGICTARIHI"] = value; }
        }

    /// <summary>
    /// Mutat Dışı Araç Rapor Bitiş Tarihi
    /// </summary>
        public DateTime? MutatDisiAracBitisTarihi
        {
            get { return (DateTime?)this["MUTATDISIARACBITISTARIHI"]; }
            set { this["MUTATDISIARACBITISTARIHI"] = value; }
        }

    /// <summary>
    /// Mutat Dışı Gerekçesi
    /// </summary>
        public string MutatDisiGerekcesi
        {
            get { return (string)this["MUTATDISIGEREKCESI"]; }
            set { this["MUTATDISIGEREKCESI"] = value; }
        }

    /// <summary>
    /// Medula Refakatçi Gerekçesi
    /// </summary>
        public string MedulaRefakatciGerekcesi
        {
            get { return (string)this["MEDULAREFAKATCIGEREKCESI"]; }
            set { this["MEDULAREFAKATCIGEREKCESI"] = value; }
        }

    /// <summary>
    /// Medula Refakatçi Durumu
    /// </summary>
        public bool? MedulaRefakatciDurumu
        {
            get { return (bool?)this["MEDULAREFAKATCIDURUMU"]; }
            set { this["MEDULAREFAKATCIDURUMU"] = value; }
        }

    /// <summary>
    /// XXXXXXde üretilen Mutat Dışı Araç Rapor ID
    /// </summary>
        public TTSequence MutatDisiAracRaporId
        {
            get { return GetSequence("MUTATDISIARACRAPORID"); }
        }

    /// <summary>
    /// Kabul Durum
    /// </summary>
        public PatientExaminationEnum? PatientExaminationType
        {
            get { return (PatientExaminationEnum?)(int?)this["PATIENTEXAMINATIONTYPE"]; }
            set { this["PATIENTEXAMINATIONTYPE"] = value; }
        }

        public SKRSCikisSekli TreatmentResult
        {
            get { return (SKRSCikisSekli)((ITTObject)this).GetParent("TREATMENTRESULT"); }
            set { this["TREATMENTRESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MuayeneGiris MuayeneGiris
        {
            get { return (MuayeneGiris)((ITTObject)this).GetParent("MUAYENEGIRIS"); }
            set { this["MUAYENEGIRIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SevkVasitasi MedulaSevkDonusVasitasi
        {
            get { return (SevkVasitasi)((ITTObject)this).GetParent("MEDULASEVKDONUSVASITASI"); }
            set { this["MEDULASEVKDONUSVASITASI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gönderilen Hastene
    /// </summary>
        public ResSection MTSHospitalSendingTo
        {
            get { return (ResSection)((ITTObject)this).GetParent("MTSHOSPITALSENDINGTO"); }
            set { this["MTSHOSPITALSENDINGTO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition DispatchedSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("DISPATCHEDSPECIALITY"); }
            set { this["DISPATCHEDSPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EmergencyIntervention EmergencyIntervention
        {
            get { return (EmergencyIntervention)((ITTObject)this).GetParent("EMERGENCYINTERVENTION"); }
            set { this["EMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sorumlu/Uzman Doktor
    /// </summary>
        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HCExaminationComponent HCExaminationComponent
        {
            get { return (HCExaminationComponent)((ITTObject)this).GetParent("HCEXAMINATIONCOMPONENT"); }
            set { this["HCEXAMINATIONCOMPONENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommittee HealthCommittee
        {
            get 
            {   
                if (MasterAction is HealthCommittee)
                    return (HealthCommittee)MasterAction; 
                return null;
            }            
            set { MasterAction = value; }
        }

        virtual protected void CreateChildGrowthStandardsCollection()
        {
            _ChildGrowthStandards = new ChildGrowthStandards.ChildChildGrowthStandardsCollection(this, new Guid("04e727c3-7ae7-492d-b2ae-537687c2c2bc"));
            ((ITTChildObjectCollection)_ChildGrowthStandards).GetChildren();
        }

        protected ChildGrowthStandards.ChildChildGrowthStandardsCollection _ChildGrowthStandards = null;
        public ChildGrowthStandards.ChildChildGrowthStandardsCollection ChildGrowthStandards
        {
            get
            {
                if (_ChildGrowthStandards == null)
                    CreateChildGrowthStandardsCollection();
                return _ChildGrowthStandards;
            }
        }

        virtual protected void CreateProcedureOrdersCollection()
        {
            _ProcedureOrders = new ProcedureOrder.ChildProcedureOrderCollection(this, new Guid("67d2217e-1b65-4d2d-b415-7ce413409ca5"));
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

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("8371e3df-4ed8-4d1f-9815-3f5821f30f5a"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
    /// <summary>
    /// Child collection for PatientExamination Çoklu Özel Durum
    /// </summary>
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        virtual protected void CreateDoctorsGridCollection()
        {
            _DoctorsGrid = new DoctorGrid.ChildDoctorGridCollection(this, new Guid("3ee67816-9d3b-45da-a10e-481773f0b7fd"));
            ((ITTChildObjectCollection)_DoctorsGrid).GetChildren();
        }

        protected DoctorGrid.ChildDoctorGridCollection _DoctorsGrid = null;
        public DoctorGrid.ChildDoctorGridCollection DoctorsGrid
        {
            get
            {
                if (_DoctorsGrid == null)
                    CreateDoctorsGridCollection();
                return _DoctorsGrid;
            }
        }

        virtual protected void CreateBaseHCEDynamicsCollection()
        {
            _BaseHCEDynamics = new BaseHCExaminationDynamicObject.ChildBaseHCExaminationDynamicObjectCollection(this, new Guid("7f36f474-ebbb-4a55-b651-c135cd53e0ea"));
            ((ITTChildObjectCollection)_BaseHCEDynamics).GetChildren();
        }

        protected BaseHCExaminationDynamicObject.ChildBaseHCExaminationDynamicObjectCollection _BaseHCEDynamics = null;
        public BaseHCExaminationDynamicObject.ChildBaseHCExaminationDynamicObjectCollection BaseHCEDynamics
        {
            get
            {
                if (_BaseHCEDynamics == null)
                    CreateBaseHCEDynamicsCollection();
                return _BaseHCEDynamics;
            }
        }

        virtual protected void CreatePatientExaminationDoctorInfosCollection()
        {
            _PatientExaminationDoctorInfos = new PatientExaminationDoctorInfo.ChildPatientExaminationDoctorInfoCollection(this, new Guid("72285593-134b-49b1-a49f-8760e89c5974"));
            ((ITTChildObjectCollection)_PatientExaminationDoctorInfos).GetChildren();
        }

        protected PatientExaminationDoctorInfo.ChildPatientExaminationDoctorInfoCollection _PatientExaminationDoctorInfos = null;
        public PatientExaminationDoctorInfo.ChildPatientExaminationDoctorInfoCollection PatientExaminationDoctorInfos
        {
            get
            {
                if (_PatientExaminationDoctorInfos == null)
                    CreatePatientExaminationDoctorInfosCollection();
                return _PatientExaminationDoctorInfos;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _PatientExaminationAdditionalApplications = new PatientExaminationAdditionalApplication.ChildPatientExaminationAdditionalApplicationCollection(_SubactionProcedures, "PatientExaminationAdditionalApplications");
            _PatientExaminationProcedures = new PatientExaminationProcedure.ChildPatientExaminationProcedureCollection(_SubactionProcedures, "PatientExaminationProcedures");
            _HealthCommitteeExaminationProcedure = new HealthCommitteeExaminationProcedure.ChildHealthCommitteeExaminationProcedureCollection(_SubactionProcedures, "HealthCommitteeExaminationProcedure");
            _PatientExaminationForensicProcedure = new PatientExaminationForensicProcedure.ChildPatientExaminationForensicProcedureCollection(_SubactionProcedures, "PatientExaminationForensicProcedure");
        }

        private PatientExaminationAdditionalApplication.ChildPatientExaminationAdditionalApplicationCollection _PatientExaminationAdditionalApplications = null;
        public PatientExaminationAdditionalApplication.ChildPatientExaminationAdditionalApplicationCollection PatientExaminationAdditionalApplications
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PatientExaminationAdditionalApplications;
            }            
        }

        private PatientExaminationProcedure.ChildPatientExaminationProcedureCollection _PatientExaminationProcedures = null;
        public PatientExaminationProcedure.ChildPatientExaminationProcedureCollection PatientExaminationProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PatientExaminationProcedures;
            }            
        }

        private HealthCommitteeExaminationProcedure.ChildHealthCommitteeExaminationProcedureCollection _HealthCommitteeExaminationProcedure = null;
        public HealthCommitteeExaminationProcedure.ChildHealthCommitteeExaminationProcedureCollection HealthCommitteeExaminationProcedure
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _HealthCommitteeExaminationProcedure;
            }            
        }

        private PatientExaminationForensicProcedure.ChildPatientExaminationForensicProcedureCollection _PatientExaminationForensicProcedure = null;
        public PatientExaminationForensicProcedure.ChildPatientExaminationForensicProcedureCollection PatientExaminationForensicProcedure
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PatientExaminationForensicProcedure;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _PatientExaminationTreatmentMaterials = new PatientExaminationTreatmentMaterial.ChildPatientExaminationTreatmentMaterialCollection(_TreatmentMaterials, "PatientExaminationTreatmentMaterials");
        }

        private PatientExaminationTreatmentMaterial.ChildPatientExaminationTreatmentMaterialCollection _PatientExaminationTreatmentMaterials = null;
        public PatientExaminationTreatmentMaterial.ChildPatientExaminationTreatmentMaterialCollection PatientExaminationTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _PatientExaminationTreatmentMaterials;
            }            
        }

        protected PatientExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTEXAMINATION", dataRow) { }
        protected PatientExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTEXAMINATION", dataRow, isImported) { }
        public PatientExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientExamination() : base() { }

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