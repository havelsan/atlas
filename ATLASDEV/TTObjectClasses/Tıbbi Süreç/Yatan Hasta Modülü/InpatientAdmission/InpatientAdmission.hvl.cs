
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientAdmission")] 

    /// <summary>
    /// Hasta Yatış  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class InpatientAdmission : BaseInpatientAdmission, IOAInPatientAdmission
    {
        public class InpatientAdmissionList : TTObjectCollection<InpatientAdmission> { }
                    
        public class ChildInpatientAdmissionCollection : TTObject.TTChildObjectCollection<InpatientAdmission>
        {
            public ChildInpatientAdmissionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientAdmissionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInpatientFolderInfo_Class : TTReportNqlObject 
        {
            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Requestdepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Quarantineinpatientdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Object Patientbirthdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                }
            }

            public Object Patientcityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCITYOFBIRTH"]);
                }
            }

            public Object Patienttownofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTTOWNOFBIRTH"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Address
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADDRESS"]);
                }
            }

            public Object Addresstown
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADDRESSTOWN"]);
                }
            }

            public Object Addresscity
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADDRESSCITY"]);
                }
            }

            public Object Addresscountry
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADDRESSCOUNTRY"]);
                }
            }

            public Object Phone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PHONE"]);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Treatmentclinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTCLINIC"]);
                }
            }

            public GetInpatientFolderInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientFolderInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientFolderInfo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientDischargeInfo_Class : TTReportNqlObject 
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

            public string Townofbirth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNOFBIRTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
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

            public string Treatmentclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? DischargeNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["DISCHARGENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetInpatientDischargeInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientDischargeInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientDischargeInfo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientPrisonerDelivery_Class : TTReportNqlObject 
        {
            public string Treatmentclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public DateTime? Patientbirthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientcityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCITYOFBIRTH"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public DateTime? Quarantineinpatientdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Evraktarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Evraksayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKSAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientPrisonerDelivery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientPrisonerDelivery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientPrisonerDelivery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientAdmissionDeclaration_Class : TTReportNqlObject 
        {
            public string Treatmentclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public DateTime? Patientbirthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientcityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCITYOFBIRTH"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public DateTime? Quarantineinpatientdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetInpatientAdmissionDeclaration_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientAdmissionDeclaration_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientAdmissionDeclaration_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetLastTreatmentClinic_Class : TTReportNqlObject 
        {
            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public OLAP_GetLastTreatmentClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLastTreatmentClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLastTreatmentClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetDischargedInpatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? HospitalInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Gssdischargecode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GSSDISCHARGECODE"]);
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Patientgroup
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTGROUP"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public Object Admissiontype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADMISSIONTYPE"]);
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

            public Guid? RoomGroup
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOMGROUP"]);
                }
            }

            public Guid? Room
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOM"]);
                }
            }

            public OLAP_GetDischargedInpatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDischargedInpatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDischargedInpatient_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetFirstTreatmentClinic_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public OLAP_GetFirstTreatmentClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetFirstTreatmentClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetFirstTreatmentClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDischargeNumberForEtiquetteOffice_Class : TTReportNqlObject 
        {
            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Foreaignno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREAIGNNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public DateTime? Taburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? DischargeNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["DISCHARGENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Klinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDischargeNumberForEtiquetteOffice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDischargeNumberForEtiquetteOffice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDischargeNumberForEtiquetteOffice_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUrgentPatientListByDate_Class : TTReportNqlObject 
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public Object Patientstatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public Object Diagnose
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIAGNOSE"]);
                }
            }

            public string Res
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUrgentPatientListByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUrgentPatientListByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUrgentPatientListByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledDischargedInpatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetCancelledDischargedInpatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledDischargedInpatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledDischargedInpatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDischargedPatientListByDischargeNumber_Class : TTReportNqlObject 
        {
            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public DateTime? Taburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Giristarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIRISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? DischargeNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["DISCHARGENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Klinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDischargedPatientListByDischargeNumber_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDischargedPatientListByDischargeNumber_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDischargedPatientListByDischargeNumber_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDischargedPatientListByDate_Class : TTReportNqlObject 
        {
            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public DateTime? Taburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Giristarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIRISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? DischargeNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["DISCHARGENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Klinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDischargedPatientListByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDischargedPatientListByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDischargedPatientListByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDischargeNumberForEtiquetteUnit_Class : TTReportNqlObject 
        {
            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? Foreaignno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREAIGNNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public DateTime? Taburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public long? DischargeNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["DISCHARGENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Klinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDischargeNumberForEtiquetteUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDischargeNumberForEtiquetteUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDischargeNumberForEtiquetteUnit_Class() : base() { }
        }

        [Serializable] 

        public partial class PlastikCerrahiIstatistik_Class : TTReportNqlObject 
        {
            public long? Tcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Cinsiyet
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CINSIYET"]);
                }
            }

            public DateTime? Dogumtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public DateTime? Taburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Giristarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIRISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReasonForInpatientAdmission
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORINPATIENTADMISSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REASONFORINPATIENTADMISSION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NoCupboard
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOCUPBOARD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["NOCUPBOARD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string GivenAndTakenStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVENANDTAKENSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["GIVENANDTAKENSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RiskWarningLastSeenDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RISKWARNINGLASTSEENDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["RISKWARNINGLASTSEENDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? NeedCompanion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEEDCOMPANION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["NEEDCOMPANION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasTightContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTIGHTCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASTIGHTCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? EstimatedInpatientDateCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDINPATIENTDATECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ESTIMATEDINPATIENTDATECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EstimatedDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ESTIMATEDDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EstimatedInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ESTIMATEDINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFallingRisk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFALLINGRISK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASFALLINGRISK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasDropletIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASDROPLETISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASDROPLETISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasAirborneContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASAIRBORNECONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASAIRBORNECONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? DischargeNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["DISCHARGENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReturnToClinicReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNTOCLINICREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["RETURNTOCLINICREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object ReturnToQuarantineReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNTOQUARANTINEREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["RETURNTOQUARANTINEREASON"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ReturnToRequestReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNTOREQUESTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["RETURNTOREQUESTREASON"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NumberOfEmptyBeds
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFEMPTYBEDS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["NUMBEROFEMPTYBEDS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ISPATIENTAPPROVALFORMGIVEN"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIARACRAPORID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracRaporTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIARACRAPORTARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIGEREKCESI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MEDULAREFAKATCIDURUMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaRefakatciGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MEDULAREFAKATCIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaESevkNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAESEVKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MEDULAESEVKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MEDULAMUTATDISIARACRAPORNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIARACBASLANGICTARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIARACBITISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Klinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PlastikCerrahiIstatistik_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PlastikCerrahiIstatistik_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PlastikCerrahiIstatistik_Class() : base() { }
        }

        [Serializable] 

        public partial class SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetForeignInpatientsNQL_Class : TTReportNqlObject 
        {
            public string Isim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyisim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? YUPASSNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YUPASSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["YUPASSNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public DateTime? Tarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Hprotno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPROTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetForeignInpatientsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetForeignInpatientsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetForeignInpatientsNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInPatientEtiquette_Class : TTReportNqlObject 
        {
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

            public long? Tc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Protokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dogumtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOGUMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Dogumyeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERI"]);
                }
            }

            public string Klinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tibbikayitprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIBBIKAYITPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Yatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetInPatientEtiquette_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInPatientEtiquette_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInPatientEtiquette_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDoctorFaultAmount_Class : TTReportNqlObject 
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

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetDoctorFaultAmount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDoctorFaultAmount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDoctorFaultAmount_Class() : base() { }
        }

        [Serializable] 

        public partial class complex_Class : TTReportNqlObject 
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

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public DateTime? BranchDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANCHDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Boolean? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public complex_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public complex_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected complex_Class() : base() { }
        }

        [Serializable] 

        public partial class simple_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReasonForInpatientAdmission
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORINPATIENTADMISSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REASONFORINPATIENTADMISSION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NoCupboard
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOCUPBOARD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["NOCUPBOARD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string GivenAndTakenStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVENANDTAKENSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["GIVENANDTAKENSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RiskWarningLastSeenDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RISKWARNINGLASTSEENDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["RISKWARNINGLASTSEENDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? NeedCompanion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEEDCOMPANION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["NEEDCOMPANION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasTightContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTIGHTCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASTIGHTCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? EstimatedInpatientDateCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDINPATIENTDATECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ESTIMATEDINPATIENTDATECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EstimatedDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ESTIMATEDDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EstimatedInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ESTIMATEDINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFallingRisk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFALLINGRISK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASFALLINGRISK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasDropletIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASDROPLETISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASDROPLETISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasAirborneContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASAIRBORNECONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HASAIRBORNECONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? HospitalInPatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? DischargeNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["DISCHARGENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReturnToClinicReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNTOCLINICREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["RETURNTOCLINICREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object ReturnToQuarantineReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNTOQUARANTINEREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["RETURNTOQUARANTINEREASON"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ReturnToRequestReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNTOREQUESTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["RETURNTOREQUESTREASON"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? NumberOfEmptyBeds
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFEMPTYBEDS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["NUMBEROFEMPTYBEDS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["ISPATIENTAPPROVALFORMGIVEN"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIARACRAPORID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracRaporTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACRAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIARACRAPORTARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIGEREKCESI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MEDULAREFAKATCIDURUMU"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaRefakatciGerekcesi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREFAKATCIGEREKCESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MEDULAREFAKATCIGEREKCESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedulaESevkNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAESEVKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MEDULAESEVKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MEDULAMUTATDISIARACRAPORNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MutatDisiAracBaslangicTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUTATDISIARACBASLANGICTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIARACBASLANGICTARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["MUTATDISIARACBITISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public simple_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public simple_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected simple_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_TaburcuSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_TaburcuSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_TaburcuSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_TaburcuSayisi_Class() : base() { }
        }

        public static class States
        {
            public static Guid Discharged { get { return new Guid("dae55d66-29b2-4cee-a3fa-0c9e44242eb6"); } }
            public static Guid ClinicProcedure { get { return new Guid("4d853a03-2c7f-4299-80e7-7de44c49b505"); } }
            public static Guid Request { get { return new Guid("2109ec1e-3448-4ae7-a6a2-08c45f4bcfb4"); } }
            public static Guid Cancelled { get { return new Guid("306ba7c8-535a-43f1-839b-abac39c0e23b"); } }
        }

        public static BindingList<InpatientAdmission.GetInpatientFolderInfo_Class> GetInpatientFolderInfo(string INPATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInpatientFolderInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTADMISSION", INPATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInpatientFolderInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetInpatientFolderInfo_Class> GetInpatientFolderInfo(TTObjectContext objectContext, string INPATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInpatientFolderInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTADMISSION", INPATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInpatientFolderInfo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetInpatientDischargeInfo_Class> GetInpatientDischargeInfo(string INPATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInpatientDischargeInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTADMISSION", INPATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInpatientDischargeInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetInpatientDischargeInfo_Class> GetInpatientDischargeInfo(TTObjectContext objectContext, string INPATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInpatientDischargeInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTADMISSION", INPATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInpatientDischargeInfo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetInpatientPrisonerDelivery_Class> GetInpatientPrisonerDelivery(string INPATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInpatientPrisonerDelivery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTADMISSION", INPATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInpatientPrisonerDelivery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetInpatientPrisonerDelivery_Class> GetInpatientPrisonerDelivery(TTObjectContext objectContext, string INPATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInpatientPrisonerDelivery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTADMISSION", INPATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInpatientPrisonerDelivery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetInpatientAdmissionDeclaration_Class> GetInpatientAdmissionDeclaration(string INPATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInpatientAdmissionDeclaration"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTADMISSION", INPATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInpatientAdmissionDeclaration_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetInpatientAdmissionDeclaration_Class> GetInpatientAdmissionDeclaration(TTObjectContext objectContext, string INPATIENTADMISSION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInpatientAdmissionDeclaration"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTADMISSION", INPATIENTADMISSION);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInpatientAdmissionDeclaration_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.OLAP_GetLastTreatmentClinic_Class> OLAP_GetLastTreatmentClinic(string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["OLAP_GetLastTreatmentClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.OLAP_GetLastTreatmentClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.OLAP_GetLastTreatmentClinic_Class> OLAP_GetLastTreatmentClinic(TTObjectContext objectContext, string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["OLAP_GetLastTreatmentClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.OLAP_GetLastTreatmentClinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.OLAP_GetDischargedInpatient_Class> OLAP_GetDischargedInpatient(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["OLAP_GetDischargedInpatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.OLAP_GetDischargedInpatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.OLAP_GetDischargedInpatient_Class> OLAP_GetDischargedInpatient(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["OLAP_GetDischargedInpatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.OLAP_GetDischargedInpatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.OLAP_GetFirstTreatmentClinic_Class> OLAP_GetFirstTreatmentClinic(string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["OLAP_GetFirstTreatmentClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.OLAP_GetFirstTreatmentClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.OLAP_GetFirstTreatmentClinic_Class> OLAP_GetFirstTreatmentClinic(TTObjectContext objectContext, string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["OLAP_GetFirstTreatmentClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.OLAP_GetFirstTreatmentClinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission> GetUnacceptedInLimitedTime(TTObjectContext objectContext, DateTime LIMITREQUESTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetUnacceptedInLimitedTime"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LIMITREQUESTDATE", LIMITREQUESTDATE);

            return ((ITTQuery)objectContext).QueryObjects<InpatientAdmission>(queryDef, paramList);
        }

        public static BindingList<InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class> GetDischargeNumberForEtiquetteOffice(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDischargeNumberForEtiquetteOffice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class> GetDischargeNumberForEtiquetteOffice(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDischargeNumberForEtiquetteOffice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetUrgentPatientListByDate_Class> GetUrgentPatientListByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetUrgentPatientListByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetUrgentPatientListByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetUrgentPatientListByDate_Class> GetUrgentPatientListByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetUrgentPatientListByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetUrgentPatientListByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.OLAP_GetCancelledDischargedInpatient_Class> OLAP_GetCancelledDischargedInpatient(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["OLAP_GetCancelledDischargedInpatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.OLAP_GetCancelledDischargedInpatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.OLAP_GetCancelledDischargedInpatient_Class> OLAP_GetCancelledDischargedInpatient(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["OLAP_GetCancelledDischargedInpatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.OLAP_GetCancelledDischargedInpatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Taburcu Hasta Listesi(Taburcu numarasına göre)
    /// </summary>
        public static BindingList<InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class> GetDischargedPatientListByDischargeNumber(long DISCHARGESTARTNO, long DISCHARGEENDNO, int FILTER, string CLINIC, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDischargedPatientListByDischargeNumber"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DISCHARGESTARTNO", DISCHARGESTARTNO);
            paramList.Add("DISCHARGEENDNO", DISCHARGEENDNO);
            paramList.Add("FILTER", FILTER);
            paramList.Add("CLINIC", CLINIC);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Taburcu Hasta Listesi(Taburcu numarasına göre)
    /// </summary>
        public static BindingList<InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class> GetDischargedPatientListByDischargeNumber(TTObjectContext objectContext, long DISCHARGESTARTNO, long DISCHARGEENDNO, int FILTER, string CLINIC, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDischargedPatientListByDischargeNumber"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DISCHARGESTARTNO", DISCHARGESTARTNO);
            paramList.Add("DISCHARGEENDNO", DISCHARGEENDNO);
            paramList.Add("FILTER", FILTER);
            paramList.Add("CLINIC", CLINIC);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Taburcu Hasta Listesi
    /// </summary>
        public static BindingList<InpatientAdmission.GetDischargedPatientListByDate_Class> GetDischargedPatientListByDate(DateTime STARTDATE, DateTime ENDDATE, string CLINIC, int FILTER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDischargedPatientListByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CLINIC", CLINIC);
            paramList.Add("FILTER", FILTER);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDischargedPatientListByDate_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Taburcu Hasta Listesi
    /// </summary>
        public static BindingList<InpatientAdmission.GetDischargedPatientListByDate_Class> GetDischargedPatientListByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string CLINIC, int FILTER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDischargedPatientListByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CLINIC", CLINIC);
            paramList.Add("FILTER", FILTER);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDischargedPatientListByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetDischargeNumberForEtiquetteUnit_Class> GetDischargeNumberForEtiquetteUnit(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDischargeNumberForEtiquetteUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDischargeNumberForEtiquetteUnit_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetDischargeNumberForEtiquetteUnit_Class> GetDischargeNumberForEtiquetteUnit(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDischargeNumberForEtiquetteUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDischargeNumberForEtiquetteUnit_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission> GetDischargedInPatientAdmissions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDischargedInPatientAdmissions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<InpatientAdmission>(queryDef, paramList);
        }

        public static BindingList<InpatientAdmission.PlastikCerrahiIstatistik_Class> PlastikCerrahiIstatistik(DateTime STARTDATE, DateTime ENDDATE, string CLINIC, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["PlastikCerrahiIstatistik"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CLINIC", CLINIC);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.PlastikCerrahiIstatistik_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.PlastikCerrahiIstatistik_Class> PlastikCerrahiIstatistik(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string CLINIC, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["PlastikCerrahiIstatistik"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("CLINIC", CLINIC);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.PlastikCerrahiIstatistik_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class> SelectActiveInpatientAdmissionCollectedInvoiceRQ(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["SelectActiveInpatientAdmissionCollectedInvoiceRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class> SelectActiveInpatientAdmissionCollectedInvoiceRQ(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["SelectActiveInpatientAdmissionCollectedInvoiceRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetForeignInpatientsNQL_Class> GetForeignInpatientsNQL(DateTime ACTIONENDDATE, DateTime ACTIONSTARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetForeignInpatientsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONENDDATE", ACTIONENDDATE);
            paramList.Add("ACTIONSTARTDATE", ACTIONSTARTDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetForeignInpatientsNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetForeignInpatientsNQL_Class> GetForeignInpatientsNQL(TTObjectContext objectContext, DateTime ACTIONENDDATE, DateTime ACTIONSTARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetForeignInpatientsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONENDDATE", ACTIONENDDATE);
            paramList.Add("ACTIONSTARTDATE", ACTIONSTARTDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetForeignInpatientsNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetInPatientEtiquette_Class> GetInPatientEtiquette(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInPatientEtiquette"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInPatientEtiquette_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GetInPatientEtiquette_Class> GetInPatientEtiquette(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInPatientEtiquette"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetInPatientEtiquette_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Doktor Hata Oranı
    /// </summary>
        public static BindingList<InpatientAdmission.GetDoctorFaultAmount_Class> GetDoctorFaultAmount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDoctorFaultAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDoctorFaultAmount_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Doktor Hata Oranı
    /// </summary>
        public static BindingList<InpatientAdmission.GetDoctorFaultAmount_Class> GetDoctorFaultAmount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetDoctorFaultAmount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GetDoctorFaultAmount_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yatan Hasta Listesi(Episode a göre)
    /// </summary>
        public static BindingList<InpatientAdmission> GetInpatientAdmissionByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GetInpatientAdmissionByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<InpatientAdmission>(queryDef, paramList);
        }

        public static BindingList<InpatientAdmission.complex_Class> complex(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["complex"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientAdmission.complex_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.complex_Class> complex(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["complex"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientAdmission.complex_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.simple_Class> simple(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["simple"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientAdmission.simple_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.simple_Class> simple(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["simple"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientAdmission.simple_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GunSonu_TaburcuSayisi_Class> GunSonu_TaburcuSayisi(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GunSonu_TaburcuSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GunSonu_TaburcuSayisi_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmission.GunSonu_TaburcuSayisi_Class> GunSonu_TaburcuSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].QueryDefs["GunSonu_TaburcuSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InpatientAdmission.GunSonu_TaburcuSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Taburcu Numarası
    /// </summary>
        public TTSequence DischargeNumber
        {
            get { return GetSequence("DISCHARGENUMBER"); }
        }

    /// <summary>
    /// Karantina Protokol No
    /// </summary>
        public TTSequence QuarantineProtocolNo
        {
            get { return GetSequence("QUARANTINEPROTOCOLNO"); }
        }

    /// <summary>
    /// Kliniğe İade Sebebi
    /// </summary>
        public string ReturnToClinicReason
        {
            get { return (string)this["RETURNTOCLINICREASON"]; }
            set { this["RETURNTOCLINICREASON"] = value; }
        }

    /// <summary>
    /// Tıbbi Kayıta İade Sebebi
    /// </summary>
        public object ReturnToQuarantineReason
        {
            get { return (object)this["RETURNTOQUARANTINEREASON"]; }
            set { this["RETURNTOQUARANTINEREASON"] = value; }
        }

    /// <summary>
    /// Hekime İade Sebebi
    /// </summary>
        public object ReturnToRequestReason
        {
            get { return (object)this["RETURNTOREQUESTREASON"]; }
            set { this["RETURNTOREQUESTREASON"] = value; }
        }

    /// <summary>
    /// Rapor No
    /// </summary>
        public TTSequence ReportNo
        {
            get { return GetSequence("REPORTNO"); }
        }

    /// <summary>
    /// Boş Yatak Sayısı
    /// </summary>
        public long? NumberOfEmptyBeds
        {
            get { return (long?)this["NUMBEROFEMPTYBEDS"]; }
            set { this["NUMBEROFEMPTYBEDS"] = value; }
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
    /// XXXXXXde üretilen Mutat Dışı Araç Rapor ID
    /// </summary>
        public TTSequence MutatDisiAracRaporId
        {
            get { return GetSequence("MUTATDISIARACRAPORID"); }
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
    /// Mutat Dışı Gerekçesi
    /// </summary>
        public string MutatDisiGerekcesi
        {
            get { return (string)this["MUTATDISIGEREKCESI"]; }
            set { this["MUTATDISIGEREKCESI"] = value; }
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
    /// Medula Refakatçi Gerekçesi
    /// </summary>
        public string MedulaRefakatciGerekcesi
        {
            get { return (string)this["MEDULAREFAKATCIGEREKCESI"]; }
            set { this["MEDULAREFAKATCIGEREKCESI"] = value; }
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

        public InPatientTreatmentClinicApplication ActiveInPatientTrtmentClcApp
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("ACTIVEINPATIENTTRTMENTCLCAPP"); }
            set { this["ACTIVEINPATIENTTRTMENTCLCAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SevkVasitasi MedulaSevkDonusVasitasi
        {
            get { return (SevkVasitasi)((ITTObject)this).GetParent("MEDULASEVKDONUSVASITASI"); }
            set { this["MEDULASEVKDONUSVASITASI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubEpisodesCollection()
        {
            _SubEpisodes = new SubEpisode.ChildSubEpisodeCollection(this, new Guid("5fc40597-e2c6-4d70-a70a-6f69f59a93e1"));
            ((ITTChildObjectCollection)_SubEpisodes).GetChildren();
        }

        protected SubEpisode.ChildSubEpisodeCollection _SubEpisodes = null;
        public SubEpisode.ChildSubEpisodeCollection SubEpisodes
        {
            get
            {
                if (_SubEpisodes == null)
                    CreateSubEpisodesCollection();
                return _SubEpisodes;
            }
        }

        virtual protected void CreateAdvanceDocumentsCollection()
        {
            _AdvanceDocuments = new AdvanceDocument.ChildAdvanceDocumentCollection(this, new Guid("79c6f7c9-2413-4b73-b711-4d26b4f911ca"));
            ((ITTChildObjectCollection)_AdvanceDocuments).GetChildren();
        }

        protected AdvanceDocument.ChildAdvanceDocumentCollection _AdvanceDocuments = null;
    /// <summary>
    /// Child collection for Yatış işlemiyle ilişkisi
    /// </summary>
        public AdvanceDocument.ChildAdvanceDocumentCollection AdvanceDocuments
        {
            get
            {
                if (_AdvanceDocuments == null)
                    CreateAdvanceDocumentsCollection();
                return _AdvanceDocuments;
            }
        }

        virtual protected void CreateAccountTransactionsCollection()
        {
            _AccountTransactions = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("09341e70-3fbc-424f-ad5b-7e292ffa9817"));
            ((ITTChildObjectCollection)_AccountTransactions).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransactions = null;
    /// <summary>
    /// Child collection for Yatış action ında Ödendi durumuna alınanlar için
    /// </summary>
        public AccountTransaction.ChildAccountTransactionCollection AccountTransactions
        {
            get
            {
                if (_AccountTransactions == null)
                    CreateAccountTransactionsCollection();
                return _AccountTransactions;
            }
        }

        virtual protected void CreateDoctorsGridCollection()
        {
            _DoctorsGrid = new DoctorGrid.ChildDoctorGridCollection(this, new Guid("f9a13486-dcc1-4046-931f-035fb08b6916"));
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

        virtual protected void CreateCompanionApplicationsCollection()
        {
            _CompanionApplications = new CompanionApplication.ChildCompanionApplicationCollection(this, new Guid("1c327fb7-91a9-41df-a97e-e5479510d518"));
            ((ITTChildObjectCollection)_CompanionApplications).GetChildren();
        }

        protected CompanionApplication.ChildCompanionApplicationCollection _CompanionApplications = null;
    /// <summary>
    /// Child collection for Hasta Yatış
    /// </summary>
        public CompanionApplication.ChildCompanionApplicationCollection CompanionApplications
        {
            get
            {
                if (_CompanionApplications == null)
                    CreateCompanionApplicationsCollection();
                return _CompanionApplications;
            }
        }

        protected InpatientAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientAdmission(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTADMISSION", dataRow) { }
        protected InpatientAdmission(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTADMISSION", dataRow, isImported) { }
        public InpatientAdmission(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientAdmission(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientAdmission() : base() { }

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