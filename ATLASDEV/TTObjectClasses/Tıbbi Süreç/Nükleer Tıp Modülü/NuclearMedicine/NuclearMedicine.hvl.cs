
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NuclearMedicine")] 

    /// <summary>
    /// Nükleer Tıp
    /// </summary>
    public  partial class NuclearMedicine : EpisodeActionWithDiagnosis, IAppointmentDef, IWorkListNuclear
    {
        public class NuclearMedicineList : TTObjectCollection<NuclearMedicine> { }
                    
        public class ChildNuclearMedicineCollection : TTObject.TTChildObjectCollection<NuclearMedicine>
        {
            public ChildNuclearMedicineCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNuclearMedicineCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class NuclearMedicinePatientInfoNQL_Class : TTReportNqlObject 
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

            public DateTime? Requestdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Requestdoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public NuclearMedicinePatientInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NuclearMedicinePatientInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NuclearMedicinePatientInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class NuclearMedicineReportNQL_Class : TTReportNqlObject 
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

            public long? Patientid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public DateTime? Birthdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE1"]);
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

            public string PreDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["PREDIAGNOSIS"].DataType;
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

            public string Reportedby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTEDBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Approvedby
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public long? Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PharmaceuticalPrepDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHARMACEUTICALPREPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["PHARMACEUTICALPREPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public NuclearMedicineReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NuclearMedicineReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NuclearMedicineReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByNuclearMedicineWorklistDateReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["EMERGENCY"].DataType;
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

            public long? TestSequenceNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTSEQUENCENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["TESTSEQUENCENO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetByNuclearMedicineWorklistDateReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByNuclearMedicineWorklistDateReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByNuclearMedicineWorklistDateReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByWLFilterExpressionReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["EMERGENCY"].DataType;
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

            public long? TestSequenceNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTSEQUENCENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["TESTSEQUENCENO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetByWLFilterExpressionReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByWLFilterExpressionReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByWLFilterExpressionReport_Class() : base() { }
        }

        [Serializable] 

        public partial class NuclearMedicineAppointmentInfoQuery_Class : TTReportNqlObject 
        {
            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Requestdoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public long? Patientid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
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

            public long? Protocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Reasonforadm
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REASONFORADM"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["REQUESTDATE"].DataType;
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

            public long? Actionid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public NuclearMedicineAppointmentInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public NuclearMedicineAppointmentInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected NuclearMedicineAppointmentInfoQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Randevu Bilgileri
    /// </summary>
            public static Guid AppointmentInfo { get { return new Guid("1401d87c-2cbe-4bdf-af05-4c18a372bc54"); } }
    /// <summary>
    /// Onayda
    /// </summary>
            public static Guid Approve { get { return new Guid("552a20d7-a374-4ba6-8b3e-0734cbcb0f18"); } }
    /// <summary>
    /// İstek Kabul
    /// </summary>
            public static Guid RequestAcception { get { return new Guid("1b6ef70b-004d-4bd8-b63f-292417c8a31d"); } }
            public static Guid Preparation { get { return new Guid("934d28ac-446d-4a1e-917c-598fa00435d9"); } }
            public static Guid RadioPharmacy { get { return new Guid("05cfe20a-a4a8-4525-a72a-8bc64bd5ada9"); } }
    /// <summary>
    /// İşlem İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("676bde6d-8727-493a-bc09-a9ed5a19f3e0"); } }
    /// <summary>
    /// Rapor Edildi
    /// </summary>
            public static Guid Reported { get { return new Guid("2617a8b0-dd44-4040-98f4-b7d0c2002c7c"); } }
    /// <summary>
    /// İşlemde
    /// </summary>
            public static Guid Procedure { get { return new Guid("3eb374d0-477e-4084-b7df-b9fb0a6a2cdf"); } }
    /// <summary>
    /// Doktorda
    /// </summary>
            public static Guid Doctor { get { return new Guid("04502d8a-f2ce-4387-9d4f-db2e6d440926"); } }
    /// <summary>
    /// Tetkik İstek
    /// </summary>
            public static Guid Request { get { return new Guid("967ec4b5-098b-43a0-b11b-c9be8b3e1e6c"); } }
            public static Guid AdmissionAppointment { get { return new Guid("b3b6618e-896d-4dcb-a830-dcf3882d717f"); } }
        }

        public static BindingList<NuclearMedicine.NuclearMedicinePatientInfoNQL_Class> NuclearMedicinePatientInfoNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["NuclearMedicinePatientInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<NuclearMedicine.NuclearMedicinePatientInfoNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NuclearMedicine.NuclearMedicinePatientInfoNQL_Class> NuclearMedicinePatientInfoNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["NuclearMedicinePatientInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<NuclearMedicine.NuclearMedicinePatientInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NuclearMedicine.NuclearMedicineReportNQL_Class> NuclearMedicineReportNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["NuclearMedicineReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<NuclearMedicine.NuclearMedicineReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NuclearMedicine.NuclearMedicineReportNQL_Class> NuclearMedicineReportNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["NuclearMedicineReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<NuclearMedicine.NuclearMedicineReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NuclearMedicine> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<NuclearMedicine>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<NuclearMedicine> GetByWLFilterExpression(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["GetByWLFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<NuclearMedicine>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<NuclearMedicine.GetByNuclearMedicineWorklistDateReport_Class> GetByNuclearMedicineWorklistDateReport(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["GetByNuclearMedicineWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NuclearMedicine.GetByNuclearMedicineWorklistDateReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NuclearMedicine.GetByNuclearMedicineWorklistDateReport_Class> GetByNuclearMedicineWorklistDateReport(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["GetByNuclearMedicineWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<NuclearMedicine.GetByNuclearMedicineWorklistDateReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NuclearMedicine.GetByWLFilterExpressionReport_Class> GetByWLFilterExpressionReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["GetByWLFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NuclearMedicine.GetByWLFilterExpressionReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NuclearMedicine.GetByWLFilterExpressionReport_Class> GetByWLFilterExpressionReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["GetByWLFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NuclearMedicine.GetByWLFilterExpressionReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Nükleer Tıp Randevu
    /// </summary>
        public static BindingList<NuclearMedicine.NuclearMedicineAppointmentInfoQuery_Class> NuclearMedicineAppointmentInfoQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["NuclearMedicineAppointmentInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<NuclearMedicine.NuclearMedicineAppointmentInfoQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Nükleer Tıp Randevu
    /// </summary>
        public static BindingList<NuclearMedicine.NuclearMedicineAppointmentInfoQuery_Class> NuclearMedicineAppointmentInfoQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINE"].QueryDefs["NuclearMedicineAppointmentInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<NuclearMedicine.NuclearMedicineAppointmentInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Nükleer Tıp Doktor Notu
    /// </summary>
        public string NucMedDoctorNote
        {
            get { return (string)this["NUCMEDDOCTORNOTE"]; }
            set { this["NUCMEDDOCTORNOTE"] = value; }
        }

    /// <summary>
    /// Rapor Alanı
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Hastanın Yaşı
    /// </summary>
        public int? PatientAge
        {
            get { return (int?)this["PATIENTAGE"]; }
            set { this["PATIENTAGE"] = value; }
        }

    /// <summary>
    /// Radyofarmasi Açıklaması
    /// </summary>
        public string RadioPharmacyDescription
        {
            get { return (string)this["RADIOPHARMACYDESCRIPTION"]; }
            set { this["RADIOPHARMACYDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Madde Adı
    /// </summary>
        public string NuclearMaterialName
        {
            get { return (string)this["NUCLEARMATERIALNAME"]; }
            set { this["NUCLEARMATERIALNAME"] = value; }
        }

    /// <summary>
    /// İşlem Tekrar Nedeni
    /// </summary>
        public string RepeatationReason
        {
            get { return (string)this["REPEATATIONREASON"]; }
            set { this["REPEATATIONREASON"] = value; }
        }

    /// <summary>
    /// Enjeksiyon Tarihi
    /// </summary>
        public DateTime? InjectionDate
        {
            get { return (DateTime?)this["INJECTIONDATE"]; }
            set { this["INJECTIONDATE"] = value; }
        }

    /// <summary>
    /// İstek Düzeltme Nedeni
    /// </summary>
        public string RequestCorrectionReason
        {
            get { return (string)this["REQUESTCORRECTIONREASON"]; }
            set { this["REQUESTCORRECTIONREASON"] = value; }
        }

    /// <summary>
    /// Hasta Ağırlığı
    /// </summary>
        public int? PatientWeight
        {
            get { return (int?)this["PATIENTWEIGHT"]; }
            set { this["PATIENTWEIGHT"] = value; }
        }

    /// <summary>
    /// Protokol Sıra Numarası
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Test Sıra Numarası
    /// </summary>
        public TTSequence TestSequenceNo
        {
            get { return GetSequence("TESTSEQUENCENO"); }
        }

    /// <summary>
    /// Farmasötik Hazırlama Tarihi
    /// </summary>
        public DateTime? PharmaceuticalPrepDate
        {
            get { return (DateTime?)this["PHARMACEUTICALPREPDATE"]; }
            set { this["PHARMACEUTICALPREPDATE"] = value; }
        }

    /// <summary>
    /// Hastanın Telefon Numarası
    /// </summary>
        public string PatientPhoneNumber
        {
            get { return (string)this["PATIENTPHONENUMBER"]; }
            set { this["PATIENTPHONENUMBER"] = value; }
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? IsEmergency
        {
            get { return (bool?)this["ISEMERGENCY"]; }
            set { this["ISEMERGENCY"] = value; }
        }

    /// <summary>
    /// İstek Yapan Tabip Telefon Numarası
    /// </summary>
        public string RequestDoctorPhone
        {
            get { return (string)this["REQUESTDOCTORPHONE"]; }
            set { this["REQUESTDOCTORPHONE"] = value; }
        }

    /// <summary>
    /// Kısa Anamnez ve Klinik Bulgular
    /// </summary>
        public string PreDiagnosis
        {
            get { return (string)this["PREDIAGNOSIS"]; }
            set { this["PREDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ProcedureDate
        {
            get { return (DateTime?)this["PROCEDUREDATE"]; }
            set { this["PROCEDUREDATE"] = value; }
        }

        public string ReportTxt
        {
            get { return (string)this["REPORTTXT"]; }
            set { this["REPORTTXT"] = value; }
        }

        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Medula Kayıt Numarası
    /// </summary>
        public string raporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Hedef Nesne IDsi
    /// </summary>
        public Guid? TargetObjectID
        {
            get { return (Guid?)this["TARGETOBJECTID"]; }
            set { this["TARGETOBJECTID"] = value; }
        }

    /// <summary>
    /// Kaynak Nesne ID'si
    /// </summary>
        public Guid? SourceObjectID
        {
            get { return (Guid?)this["SOURCEOBJECTID"]; }
            set { this["SOURCEOBJECTID"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public string birim
        {
            get { return (string)this["BIRIM"]; }
            set { this["BIRIM"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string MedulaAciklama
        {
            get { return (string)this["MEDULAACIKLAMA"]; }
            set { this["MEDULAACIKLAMA"] = value; }
        }

    /// <summary>
    /// Anestezi yapan doktorun diploma tescil numarası.
    /// </summary>
        public string drAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Bulgular ve Karşılaştırma Bilgisi
    /// </summary>
        public object ResultsAndComparisonInfo
        {
            get { return (object)this["RESULTSANDCOMPARISONINFO"]; }
            set { this["RESULTSANDCOMPARISONINFO"] = value; }
        }

    /// <summary>
    /// Sorumlu Tabip İlişkisi
    /// </summary>
        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Tabip İlişkisi
    /// </summary>
        public ResUser RequestDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTDOCTOR"); }
            set { this["REQUESTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Enjeksiyon Yapan Kullanıcı İlişkisi
    /// </summary>
        public ResUser InjectedBy
        {
            get { return (ResUser)((ITTObject)this).GetParent("INJECTEDBY"); }
            set { this["INJECTEDBY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nükleer Tıp Test Tanım İlişkisi
    /// </summary>
        public NuclearMedicineTestDefinition NuclearMedicineTest
        {
            get { return (NuclearMedicineTestDefinition)((ITTObject)this).GetParent("NUCLEARMEDICINETEST"); }
            set { this["NUCLEARMEDICINETEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sorumlu Akademisyen İlişkisi
    /// </summary>
        public ResUser ResponsibleAcademicStaff
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEACADEMICSTAFF"); }
            set { this["RESPONSIBLEACADEMICSTAFF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// NukleerTip OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Radyoloji SagSol
    /// </summary>
        public SagSol SagSol
        {
            get { return (SagSol)((ITTObject)this).GetParent("SAGSOL"); }
            set { this["SAGSOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser AnesteziDoktor
        {
            get { return (ResUser)((ITTObject)this).GetParent("ANESTEZIDOKTOR"); }
            set { this["ANESTEZIDOKTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// NuclearMedicine AyniFarkliKesi
    /// </summary>
        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("6f4cb5be-9c28-4d46-8286-f0b798488551"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
    /// <summary>
    /// Child collection for NuclearMedicine Çoklu Özel Durum
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

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _NuclearMedicineTests = new NuclearMedicineTest.ChildNuclearMedicineTestCollection(_SubactionProcedures, "NuclearMedicineTests");
        }

        private NuclearMedicineTest.ChildNuclearMedicineTestCollection _NuclearMedicineTests = null;
        public NuclearMedicineTest.ChildNuclearMedicineTestCollection NuclearMedicineTests
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _NuclearMedicineTests;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _RadPharmMaterials = new NucMedRadPharmMatGrid.ChildNucMedRadPharmMatGridCollection(_TreatmentMaterials, "RadPharmMaterials");
            _NucMedTreatmentMats = new NucMedTreatmentMat.ChildNucMedTreatmentMatCollection(_TreatmentMaterials, "NucMedTreatmentMats");
            _NuclearMedicine_SurgeryDirectPurchaseGrids = new SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection(_TreatmentMaterials, "NuclearMedicine_SurgeryDirectPurchaseGrids");
            _NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = new RadyofarmasotikDirectPurchaseGrid.ChildRadyofarmasotikDirectPurchaseGridCollection(_TreatmentMaterials, "NuclearMedicine_RadyofarmasotikDirectPurchaseGrids");
        }

        private NucMedRadPharmMatGrid.ChildNucMedRadPharmMatGridCollection _RadPharmMaterials = null;
        public NucMedRadPharmMatGrid.ChildNucMedRadPharmMatGridCollection RadPharmMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _RadPharmMaterials;
            }            
        }

        private NucMedTreatmentMat.ChildNucMedTreatmentMatCollection _NucMedTreatmentMats = null;
        public NucMedTreatmentMat.ChildNucMedTreatmentMatCollection NucMedTreatmentMats
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _NucMedTreatmentMats;
            }            
        }

        private SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection _NuclearMedicine_SurgeryDirectPurchaseGrids = null;
        public SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection NuclearMedicine_SurgeryDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _NuclearMedicine_SurgeryDirectPurchaseGrids;
            }            
        }

        private RadyofarmasotikDirectPurchaseGrid.ChildRadyofarmasotikDirectPurchaseGridCollection _NuclearMedicine_RadyofarmasotikDirectPurchaseGrids = null;
        public RadyofarmasotikDirectPurchaseGrid.ChildRadyofarmasotikDirectPurchaseGridCollection NuclearMedicine_RadyofarmasotikDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _NuclearMedicine_RadyofarmasotikDirectPurchaseGrids;
            }            
        }

        protected NuclearMedicine(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NuclearMedicine(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NuclearMedicine(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NuclearMedicine(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NuclearMedicine(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCLEARMEDICINE", dataRow) { }
        protected NuclearMedicine(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCLEARMEDICINE", dataRow, isImported) { }
        public NuclearMedicine(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NuclearMedicine(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NuclearMedicine() : base() { }

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