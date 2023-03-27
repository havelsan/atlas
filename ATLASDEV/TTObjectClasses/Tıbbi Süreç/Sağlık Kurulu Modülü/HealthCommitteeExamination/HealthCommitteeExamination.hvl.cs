
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeExamination")] 

    /// <summary>
    /// Sağlık Kurulu Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class HealthCommitteeExamination : PatientExamination, IPatientWorkList, IAppointmentDef, IAllocateSpeciality, IOAHealthCommitteeExaminatios, IOAHealthCommittee, INumaratorAppointment
    {
        public class HealthCommitteeExaminationList : TTObjectCollection<HealthCommitteeExamination> { }
                    
        public class ChildHealthCommitteeExaminationCollection : TTObject.TTChildObjectCollection<HealthCommitteeExamination>
        {
            public ChildHealthCommitteeExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCurrentHCExamination_Class : TTReportNqlObject 
        {
            public object Rapor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Raportarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public string Bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Usersicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERSICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Userunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Usersinif
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERSINIF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Userrutbe
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERRUTBE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Usergorev
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERGOREV"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Karar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["OFFEROFDECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Bolumid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BOLUMID"]);
                }
            }

            public Object Dogumyeriil
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIIL"]);
                }
            }

            public Object Dogumyeriilce
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIILCE"]);
                }
            }

            public Object Dogumyeriulke
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIULKE"]);
                }
            }

            public GetCurrentHCExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCurrentHCExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCurrentHCExamination_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCExamsByMResource_Class : TTReportNqlObject 
        {
            public Guid? Object_id
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECT_ID"]);
                }
            }

            public Guid? Healthcomitteeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEALTHCOMITTEEOBJECTID"]);
                }
            }

            public object Rapor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Raportarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public string Bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Usersicilno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERSICILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Userunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Usersinif
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERSINIF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Userrutbe
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERRUTBE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Usergorev
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERGOREV"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Karar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KARAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["OFFEROFDECISION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Bolumid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BOLUMID"]);
                }
            }

            public int? Kilo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KILO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["WEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? Boy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["HEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetHCExamsByMResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCExamsByMResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCExamsByMResource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCExaminationByMasterAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public object Rapor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? Raportarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Raporno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Bolum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BOLUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doktoradi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doktorsinifi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTORSINIFI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doktorrutbe
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTORRUTBE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Doktorunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTORUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Doktorsicil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTORSICIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHCExaminationByMasterAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCExaminationByMasterAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCExaminationByMasterAction_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHealthCommitteeDetails_Class : TTReportNqlObject 
        {
            public Guid? Examinationobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXAMINATIONOBJECTID"]);
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

            public OLAP_GetHealthCommitteeDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHealthCommitteeDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHealthCommitteeDetails_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHealthCommitteeExamination_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
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

            public OLAP_GetHealthCommitteeExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHealthCommitteeExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHealthCommitteeExamination_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledHealthCommitteeExamination_Class : TTReportNqlObject 
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

            public OLAP_GetCancelledHealthCommitteeExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledHealthCommitteeExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledHealthCommitteeExamination_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBackHCExaminationByDate_Class : TTReportNqlObject 
        {
            public long? Kimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Poliklinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLIKLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBackHCExaminationByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBackHCExaminationByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBackHCExaminationByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHCExaminationForWL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public GetHCExaminationForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCExaminationForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCExaminationForWL_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Examination { get { return new Guid("84ef7887-0ff5-4d4c-9bfe-59a56d65b588"); } }
            public static Guid New { get { return new Guid("672e9a1a-e7d6-48de-a7ff-b2a9c12cace4"); } }
    /// <summary>
    /// İptal State i
    /// </summary>
            public static Guid Cancelled { get { return new Guid("7bb71f1f-1932-49f5-bb69-a093e806ddcb"); } }
            public static Guid Completed { get { return new Guid("30c3e5a0-81c3-4f86-834e-b955b7239326"); } }
            public static Guid PatientNoShown { get { return new Guid("8280acbe-9741-4862-a72c-d23e427d535b"); } }
    /// <summary>
    /// Sıraya Eklendi
    /// </summary>
            public static Guid InsertedIntoQueue { get { return new Guid("0cefeb03-c747-482a-863f-0e5b083d9c5a"); } }
        }

    /// <summary>
    /// Süreçte iken o andaki Sağlık Kurulu Muayenesi ni getirir.
    /// </summary>
        public static BindingList<HealthCommitteeExamination.GetCurrentHCExamination_Class> GetCurrentHCExamination(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetCurrentHCExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetCurrentHCExamination_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Süreçte iken o andaki Sağlık Kurulu Muayenesi ni getirir.
    /// </summary>
        public static BindingList<HealthCommitteeExamination.GetCurrentHCExamination_Class> GetCurrentHCExamination(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetCurrentHCExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetCurrentHCExamination_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.GetHCExamsByMResource_Class> GetHCExamsByMResource(IList<string> MRESOURCE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetHCExamsByMResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MRESOURCE", MRESOURCE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetHCExamsByMResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.GetHCExamsByMResource_Class> GetHCExamsByMResource(TTObjectContext objectContext, IList<string> MRESOURCE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetHCExamsByMResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MRESOURCE", MRESOURCE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetHCExamsByMResource_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sağlık Kurulu Muayenesini MasterAction ile get eder
    /// </summary>
        public static BindingList<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class> GetHCExaminationByMasterAction(string MASTERACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetHCExaminationByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONID", MASTERACTIONID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Sağlık Kurulu Muayenesini MasterAction ile get eder
    /// </summary>
        public static BindingList<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class> GetHCExaminationByMasterAction(TTObjectContext objectContext, string MASTERACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetHCExaminationByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONID", MASTERACTIONID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.OLAP_GetHealthCommitteeDetails_Class> OLAP_GetHealthCommitteeDetails(string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["OLAP_GetHealthCommitteeDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.OLAP_GetHealthCommitteeDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.OLAP_GetHealthCommitteeDetails_Class> OLAP_GetHealthCommitteeDetails(TTObjectContext objectContext, string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["OLAP_GetHealthCommitteeDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.OLAP_GetHealthCommitteeDetails_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.OLAP_GetHealthCommitteeExamination_Class> OLAP_GetHealthCommitteeExamination(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["OLAP_GetHealthCommitteeExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.OLAP_GetHealthCommitteeExamination_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.OLAP_GetHealthCommitteeExamination_Class> OLAP_GetHealthCommitteeExamination(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["OLAP_GetHealthCommitteeExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.OLAP_GetHealthCommitteeExamination_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.OLAP_GetCancelledHealthCommitteeExamination_Class> OLAP_GetCancelledHealthCommitteeExamination(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["OLAP_GetCancelledHealthCommitteeExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.OLAP_GetCancelledHealthCommitteeExamination_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.OLAP_GetCancelledHealthCommitteeExamination_Class> OLAP_GetCancelledHealthCommitteeExamination(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["OLAP_GetCancelledHealthCommitteeExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.OLAP_GetCancelledHealthCommitteeExamination_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.GetBackHCExaminationByDate_Class> GetBackHCExaminationByDate(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetBackHCExaminationByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetBackHCExaminationByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination.GetBackHCExaminationByDate_Class> GetBackHCExaminationByDate(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetBackHCExaminationByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetBackHCExaminationByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<HealthCommitteeExamination> GetHCEByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetHCEByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommitteeExamination>(queryDef, paramList);
        }

        public static BindingList<HealthCommitteeExamination.GetHCExaminationForWL_Class> GetHCExaminationForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetHCExaminationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetHCExaminationForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HealthCommitteeExamination.GetHCExaminationForWL_Class> GetHCExaminationForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEEEXAMINATION"].QueryDefs["GetHCExaminationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommitteeExamination.GetHCExaminationForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Muamele Sayısı
    /// </summary>
        public int? NumberOfProcess
        {
            get { return (int?)this["NUMBEROFPROCESS"]; }
            set { this["NUMBEROFPROCESS"] = value; }
        }

    /// <summary>
    /// Karar Teklifi
    /// </summary>
        public string OfferOfDecision
        {
            get { return (string)this["OFFEROFDECISION"]; }
            set { this["OFFEROFDECISION"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public int? Weight
        {
            get { return (int?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Height
        {
            get { return (double?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// Başlama Tarihi
    /// </summary>
        public DateTime? HealthCommitteeStartDate
        {
            get { return (DateTime?)this["HEALTHCOMMITTEESTARTDATE"]; }
            set { this["HEALTHCOMMITTEESTARTDATE"] = value; }
        }

    /// <summary>
    /// Sağlam
    /// </summary>
        public bool? IsHealthy
        {
            get { return (bool?)this["ISHEALTHY"]; }
            set { this["ISHEALTHY"] = value; }
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
    /// Randevu Bilgisi
    /// </summary>
        public string AppointmentInfo
        {
            get { return (string)this["APPOINTMENTINFO"]; }
            set { this["APPOINTMENTINFO"] = value; }
        }

    /// <summary>
    /// Engel Oarnı
    /// </summary>
        public double? DisabledRatio
        {
            get { return (double?)this["DISABLEDRATIO"]; }
            set { this["DISABLEDRATIO"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diğer Birimlerden Sağlık Kurulu Muayenesi
    /// </summary>
        public HealthCommitteeExaminationFromOtherDepartments HCEFromOtherDepartments
        {
            get { return (HealthCommitteeExaminationFromOtherDepartments)((ITTObject)this).GetParent("HCEFROMOTHERDEPARTMENTS"); }
            set { this["HCEFROMOTHERDEPARTMENTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMatterSliceAnectodesCollection()
        {
            _MatterSliceAnectodes = new HealthCommitteeExamination_MatterSliceAnectodeGrid.ChildHealthCommitteeExamination_MatterSliceAnectodeGridCollection(this, new Guid("3d312dad-db28-4d1e-ae52-89e85d854860"));
            ((ITTChildObjectCollection)_MatterSliceAnectodes).GetChildren();
        }

        protected HealthCommitteeExamination_MatterSliceAnectodeGrid.ChildHealthCommitteeExamination_MatterSliceAnectodeGridCollection _MatterSliceAnectodes = null;
    /// <summary>
    /// Child collection for Madde Dilim Fıkra
    /// </summary>
        public HealthCommitteeExamination_MatterSliceAnectodeGrid.ChildHealthCommitteeExamination_MatterSliceAnectodeGridCollection MatterSliceAnectodes
        {
            get
            {
                if (_MatterSliceAnectodes == null)
                    CreateMatterSliceAnectodesCollection();
                return _MatterSliceAnectodes;
            }
        }

        virtual protected void CreateHCEMatterSliceAnectodesCollection()
        {
            _HCEMatterSliceAnectodes = new HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection(this, new Guid("8236bfc1-f743-445c-b719-94c59ab1e508"));
            ((ITTChildObjectCollection)_HCEMatterSliceAnectodes).GetChildren();
        }

        protected HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection _HCEMatterSliceAnectodes = null;
        public HCMatterSliceAnectodeDefinitionGrid.ChildHCMatterSliceAnectodeDefinitionGridCollection HCEMatterSliceAnectodes
        {
            get
            {
                if (_HCEMatterSliceAnectodes == null)
                    CreateHCEMatterSliceAnectodesCollection();
                return _HCEMatterSliceAnectodes;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _HealthCommitteeExaminationProcedures = new HealthCommitteeExaminationProcedure.ChildHealthCommitteeExaminationProcedureCollection(_SubactionProcedures, "HealthCommitteeExaminationProcedures");
        }

        private HealthCommitteeExaminationProcedure.ChildHealthCommitteeExaminationProcedureCollection _HealthCommitteeExaminationProcedures = null;
        public HealthCommitteeExaminationProcedure.ChildHealthCommitteeExaminationProcedureCollection HealthCommitteeExaminationProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _HealthCommitteeExaminationProcedures;
            }            
        }

        protected HealthCommitteeExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEEXAMINATION", dataRow) { }
        protected HealthCommitteeExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEEXAMINATION", dataRow, isImported) { }
        public HealthCommitteeExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeExamination() : base() { }

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