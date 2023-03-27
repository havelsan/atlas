
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Episode")] 

    /// <summary>
    /// Hastanın bir gelişine ait işlemlerin tutulduğu Vaka
    /// </summary>
    public  partial class Episode : TTObject, ISUTEpisode, IOldActions
    {
        public class EpisodeList : TTObjectCollection<Episode> { }
                    
        public class ChildEpisodeCollection : TTObject.TTChildObjectCollection<Episode>
        {
            public ChildEpisodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetEpisodeInformation_Class : TTReportNqlObject 
        {
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

            public OLAP_GetEpisodeInformation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetEpisodeInformation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetEpisodeInformation_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetEpisodeDiagnosis_Class : TTReportNqlObject 
        {
            public Guid? Diagnose
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSE"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public OLAP_GetEpisodeDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetEpisodeDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetEpisodeDiagnosis_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetLastDiagnosis_Class : TTReportNqlObject 
        {
            public Guid? Diagnose
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIAGNOSE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public OLAP_GetLastDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLastDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLastDiagnosis_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetEmergencyAdmission_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetEmergencyAdmission_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetEmergencyAdmission_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetEmergencyAdmission_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetEpisodeResourceByStatus_Class : TTReportNqlObject 
        {
            public Object Resource
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RESOURCE"]);
                }
            }

            public OLAP_GetEpisodeResourceByStatus_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetEpisodeResourceByStatus_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetEpisodeResourceByStatus_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDischargedPatientCount_Class : TTReportNqlObject 
        {
            public bool? IsQuotaUsed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISQUOTAUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ISQUOTAUSED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetDischargedPatientCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDischargedPatientCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDischargedPatientCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByPatientAndDayLimitNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Guid? MainSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MAINSPECIALITY"]);
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

            public GetByPatientAndDayLimitNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByPatientAndDayLimitNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByPatientAndDayLimitNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetForCashOfficeSearch_Class : TTReportNqlObject 
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetForCashOfficeSearch_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetForCashOfficeSearch_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetForCashOfficeSearch_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNotDiagnosisExistsByDateInterval_Class : TTReportNqlObject 
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

            public string AdmissionResource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ADMISSIONRESOURCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNotDiagnosisExistsByDateInterval_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNotDiagnosisExistsByDateInterval_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNotDiagnosisExistsByDateInterval_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledEmergencyAdmission_Class : TTReportNqlObject 
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

            public OLAP_GetCancelledEmergencyAdmission_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledEmergencyAdmission_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledEmergencyAdmission_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodeInformation_RQ_Class : TTReportNqlObject 
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

            public Object Cinsiyet
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CINSIYET"]);
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

            public Object Dogumyeriulke
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERIULKE"]);
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

            public string Babaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Anneadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Maritalstatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARITALSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSMEDENIHALI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Kangrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KANGRUBU"]);
                }
            }

            public Object Evadresi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVADRESI"]);
                }
            }

            public Object Evpostakodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVPOSTAKODU"]);
                }
            }

            public Object Evtelefonu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVTELEFONU"]);
                }
            }

            public Object Evil
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVIL"]);
                }
            }

            public Object Evilce
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EVILCE"]);
                }
            }

            public Object Kuvveti
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KUVVETI"]);
                }
            }

            public Object Birligi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BIRLIGI"]);
                }
            }

            public Object Rutbesi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RUTBESI"]);
                }
            }

            public DateTime? Acilistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACILISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Kabulyapanbirim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULYAPANBIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ADMISSIONRESOURCE"].DataType;
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

            public Object Hastadurumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTADURUMU"]);
                }
            }

            public GetEpisodeInformation_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodeInformation_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodeInformation_RQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEpisodesToSendEHRs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetEpisodesToSendEHRs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEpisodesToSendEHRs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEpisodesToSendEHRs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDiagnosisByPatientExamination_Class : TTReportNqlObject 
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

            public object DentalExaminationFile
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DENTALEXAMINATIONFILE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DENTALEXAMINATIONFILE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object PatientFolder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFOLDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTFOLDER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["CONTINUOUSDRUGS"].DataType;
                    return (object)dataType.ConvertValue(val);
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

            public double? Heigth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HEIGTH"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public object Complaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["COMPLAINT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? ClosedByMorgue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOSEDBYMORGUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["CLOSEDBYMORGUE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClosingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLOSINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["CLOSINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object PatientFamilyHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFAMILYHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTFAMILYHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public int? Priority
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PRIORITY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public object Habits
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HABITS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HABITS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTHISTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
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

            public DateTime? HealthCommitteeStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHCOMMITTEESTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HEALTHCOMMITTEESTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Guid? sourceDispatchObjID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SOURCEDISPATCHOBJID"]);
                }
            }

            public object SystemQuery
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYSTEMQUERY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["SYSTEMQUERY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ImportantPatientInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMPORTANTPATIENTINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["IMPORTANTPATIENTINFO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["EXAMINATIONSUMMARY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string AdmissionResource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ADMISSIONRESOURCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsQuotaUsed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISQUOTAUSED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ISQUOTAUSED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object DecisionAndAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECISIONANDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DECISIONANDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? IsNewBorn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNEWBORN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ISNEWBORN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object MTSConclusion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MTSCONCLUSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["MTSCONCLUSION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetDiagnosisByPatientExamination_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnosisByPatientExamination_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnosisByPatientExamination_Class() : base() { }
        }

        [Serializable] 

        public partial class GetVeteransOfEpisodesByDate_Class : TTReportNqlObject 
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

            public Guid? MainSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MAINSPECIALITY"]);
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

            public GetVeteransOfEpisodesByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVeteransOfEpisodesByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVeteransOfEpisodesByDate_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("58b46f1f-8298-4f55-8926-b0f9a371db03"); } }
    /// <summary>
    /// Kapalı
    /// </summary>
            public static Guid Closed { get { return new Guid("96d4f27f-c29a-4b6c-abf7-b1dafcc80d00"); } }
    /// <summary>
    /// AçıkDevam
    /// </summary>
            public static Guid ClosedToNew { get { return new Guid("3951ac74-f6a8-4a47-9b50-fcf64cab44f0"); } }
        }

        public static BindingList<Episode> GetByLastUpdateDate(TTObjectContext objectContext, DateTime DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<Episode>(queryDef, paramList);
        }

        public static BindingList<Episode.OLAP_GetEpisodeInformation_Class> OLAP_GetEpisodeInformation(string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetEpisodeInformation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetEpisodeInformation_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetEpisodeInformation_Class> OLAP_GetEpisodeInformation(TTObjectContext objectContext, string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetEpisodeInformation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetEpisodeInformation_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetEpisodeDiagnosis_Class> OLAP_GetEpisodeDiagnosis(string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetEpisodeDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetEpisodeDiagnosis_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetEpisodeDiagnosis_Class> OLAP_GetEpisodeDiagnosis(TTObjectContext objectContext, string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetEpisodeDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetEpisodeDiagnosis_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetLastDiagnosis_Class> OLAP_GetLastDiagnosis(string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetLastDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetLastDiagnosis_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetLastDiagnosis_Class> OLAP_GetLastDiagnosis(TTObjectContext objectContext, string EID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetLastDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetLastDiagnosis_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Gets all episode instances
    /// </summary>
        public static BindingList<Episode> GetEpisodesByPatient(TTObjectContext objectContext, string PATIENT, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetEpisodesByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<Episode>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Episode.OLAP_GetEmergencyAdmission_Class> OLAP_GetEmergencyAdmission(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetEmergencyAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetEmergencyAdmission_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetEmergencyAdmission_Class> OLAP_GetEmergencyAdmission(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetEmergencyAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetEmergencyAdmission_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetEpisodeResourceByStatus_Class> OLAP_GetEpisodeResourceByStatus(string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetEpisodeResourceByStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetEpisodeResourceByStatus_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetEpisodeResourceByStatus_Class> OLAP_GetEpisodeResourceByStatus(TTObjectContext objectContext, string EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetEpisodeResourceByStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetEpisodeResourceByStatus_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetDischargedPatientCount_Class> GetDischargedPatientCount(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetDischargedPatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetDischargedPatientCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetDischargedPatientCount_Class> GetDischargedPatientCount(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetDischargedPatientCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetDischargedPatientCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetByPatientAndDayLimitNQL_Class> GetByPatientAndDayLimitNQL(DateTime DAYLIMIT, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetByPatientAndDayLimitNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DAYLIMIT", DAYLIMIT);
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Episode.GetByPatientAndDayLimitNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetByPatientAndDayLimitNQL_Class> GetByPatientAndDayLimitNQL(TTObjectContext objectContext, DateTime DAYLIMIT, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetByPatientAndDayLimitNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DAYLIMIT", DAYLIMIT);
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Episode.GetByPatientAndDayLimitNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetForCashOfficeSearch_Class> GetForCashOfficeSearch(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetForCashOfficeSearch"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Episode.GetForCashOfficeSearch_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Episode.GetForCashOfficeSearch_Class> GetForCashOfficeSearch(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetForCashOfficeSearch"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Episode.GetForCashOfficeSearch_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Episode> GetByDayLimitAndMainSpeciality(TTObjectContext objectContext, DateTime DAYLIMIT, IList<Guid> SPECIALITIES, string PATIENT, DateTime CURRENTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetByDayLimitAndMainSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DAYLIMIT", DAYLIMIT);
            paramList.Add("SPECIALITIES", SPECIALITIES);
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("CURRENTDATE", CURRENTDATE);

            return ((ITTQuery)objectContext).QueryObjects<Episode>(queryDef, paramList);
        }

        public static BindingList<Episode.GetNotDiagnosisExistsByDateInterval_Class> GetNotDiagnosisExistsByDateInterval(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetNotDiagnosisExistsByDateInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetNotDiagnosisExistsByDateInterval_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetNotDiagnosisExistsByDateInterval_Class> GetNotDiagnosisExistsByDateInterval(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetNotDiagnosisExistsByDateInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetNotDiagnosisExistsByDateInterval_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetCancelledEmergencyAdmission_Class> OLAP_GetCancelledEmergencyAdmission(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetCancelledEmergencyAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetCancelledEmergencyAdmission_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.OLAP_GetCancelledEmergencyAdmission_Class> OLAP_GetCancelledEmergencyAdmission(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["OLAP_GetCancelledEmergencyAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Episode.OLAP_GetCancelledEmergencyAdmission_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode> GetByHospitalProtocolNo(TTObjectContext objectContext, string HPROTOCOLNO, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetByHospitalProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HPROTOCOLNO", HPROTOCOLNO);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Episode>(queryDef, paramList);
        }

        public static BindingList<Episode.GetEpisodeInformation_RQ_Class> GetEpisodeInformation_RQ(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetEpisodeInformation_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetEpisodeInformation_RQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Episode.GetEpisodeInformation_RQ_Class> GetEpisodeInformation_RQ(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetEpisodeInformation_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetEpisodeInformation_RQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Episode.GetEpisodesToSendEHRs_Class> GetEpisodesToSendEHRs(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetEpisodesToSendEHRs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetEpisodesToSendEHRs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetEpisodesToSendEHRs_Class> GetEpisodesToSendEHRs(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetEpisodesToSendEHRs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetEpisodesToSendEHRs_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetDiagnosisByPatientExamination_Class> GetDiagnosisByPatientExamination(Guid PATIENTEXAMINATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetDiagnosisByPatientExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTEXAMINATION", PATIENTEXAMINATION);

            return TTReportNqlObject.QueryObjects<Episode.GetDiagnosisByPatientExamination_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetDiagnosisByPatientExamination_Class> GetDiagnosisByPatientExamination(TTObjectContext objectContext, Guid PATIENTEXAMINATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetDiagnosisByPatientExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTEXAMINATION", PATIENTEXAMINATION);

            return TTReportNqlObject.QueryObjects<Episode.GetDiagnosisByPatientExamination_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode> GetByOpeningDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetByOpeningDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Episode>(queryDef, paramList);
        }

        public static BindingList<Episode> GetOpenedOutPatientByDate(TTObjectContext objectContext, DateTime DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetOpenedOutPatientByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<Episode>(queryDef, paramList);
        }

        public static BindingList<Episode> GetEpisodes(TTObjectContext objectContext, IList<Guid> OBJECTIDS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetEpisodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return ((ITTQuery)objectContext).QueryObjects<Episode>(queryDef, paramList);
        }

        public static BindingList<Episode.GetVeteransOfEpisodesByDate_Class> GetVeteransOfEpisodesByDate(DateTime OPENINGDATE, DateTime ENDOPENINGDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetVeteransOfEpisodesByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OPENINGDATE", OPENINGDATE);
            paramList.Add("ENDOPENINGDATE", ENDOPENINGDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetVeteransOfEpisodesByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Episode.GetVeteransOfEpisodesByDate_Class> GetVeteransOfEpisodesByDate(TTObjectContext objectContext, DateTime OPENINGDATE, DateTime ENDOPENINGDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetVeteransOfEpisodesByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OPENINGDATE", OPENINGDATE);
            paramList.Add("ENDOPENINGDATE", ENDOPENINGDATE);

            return TTReportNqlObject.QueryObjects<Episode.GetVeteransOfEpisodesByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Episode> GetSameByDayLimitAndMainSpeciality(TTObjectContext objectContext, DateTime DAYLIMIT, IList<Guid> SPECIALITIES, string PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetSameByDayLimitAndMainSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DAYLIMIT", DAYLIMIT);
            paramList.Add("SPECIALITIES", SPECIALITIES);
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<Episode>(queryDef, paramList);
        }

        public static BindingList<Episode> GetEpisodesByAdmissionNumber(TTObjectContext objectContext, long AdmissionNumber)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].QueryDefs["GetEpisodesByAdmissionNumber"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ADMISSIONNUMBER", AdmissionNumber);

            return ((ITTQuery)objectContext).QueryObjects<Episode>(queryDef, paramList);
        }

    /// <summary>
    /// Hastanın Vakadaki Diş Tedavi Dosyası Bilgisini Taşıyan Alandır
    /// </summary>
        public object DentalExaminationFile
        {
            get { return (object)this["DENTALEXAMINATIONFILE"]; }
            set { this["DENTALEXAMINATIONFILE"] = value; }
        }

    /// <summary>
    /// Hastanın Vakadaki 'Evrak Tarihi' Bilgisini Taşıyan Alandır
    /// </summary>
        public DateTime? DocumentDate
        {
            get { return (DateTime?)this["DOCUMENTDATE"]; }
            set { this["DOCUMENTDATE"] = value; }
        }

    /// <summary>
    /// Hastanın Vakada Girilen 'Hasta Dosyası' Bilgisinin Tutulduğu Alandır
    /// </summary>
        public object PatientFolder
        {
            get { return (object)this["PATIENTFOLDER"]; }
            set { this["PATIENTFOLDER"] = value; }
        }

    /// <summary>
    /// Hastanın Kullanıdığı Devamlı İlaçların Tutulduğu Alandır
    /// </summary>
        public object ContinuousDrugs
        {
            get { return (object)this["CONTINUOUSDRUGS"]; }
            set { this["CONTINUOUSDRUGS"] = value; }
        }

    /// <summary>
    /// Vaka Açılış Tarihinin Tutulduğu Alandır
    /// </summary>
        public DateTime? OpeningDate
        {
            get { return (DateTime?)this["OPENINGDATE"]; }
            set { this["OPENINGDATE"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public double? Heigth
        {
            get { return (double?)this["HEIGTH"]; }
            set { this["HEIGTH"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Hastanın 'Şikayet' Bilgilerini Tutan Alandır
    /// </summary>
        public object Complaint
        {
            get { return (object)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

    /// <summary>
    /// Vakaya Özel Vaka No
    /// </summary>
        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Vakanın Hastanın Ölümü Sonucu Kapatıldığı Bilgisini Tutar
    /// </summary>
        public bool? ClosedByMorgue
        {
            get { return (bool?)this["CLOSEDBYMORGUE"]; }
            set { this["CLOSEDBYMORGUE"] = value; }
        }

    /// <summary>
    /// Vaka Kapanış Tarihi
    /// </summary>
        public DateTime? ClosingDate
        {
            get { return (DateTime?)this["CLOSINGDATE"]; }
            set { this["CLOSINGDATE"] = value; }
        }

    /// <summary>
    /// Hastanın Vakadaki 'Evrak Sayısı' Bilgisini Taşıyan Alandır
    /// </summary>
        public string DocumentNumber
        {
            get { return (string)this["DOCUMENTNUMBER"]; }
            set { this["DOCUMENTNUMBER"] = value; }
        }

    /// <summary>
    /// Hastanın Vakada Girilen Soygeçmiş Bilgisinin Tutulduğu Alandır
    /// </summary>
        public object PatientFamilyHistory
        {
            get { return (object)this["PATIENTFAMILYHISTORY"]; }
            set { this["PATIENTFAMILYHISTORY"] = value; }
        }

    /// <summary>
    /// Hastanın Kabul Önceliğini Belirten Alandır.
    /// </summary>
        public int? Priority
        {
            get { return (int?)this["PRIORITY"]; }
            set { this["PRIORITY"] = value; }
        }

    /// <summary>
    /// Hastanın Alışkanlıklarını Taşıyan Alandır
    /// </summary>
        public object Habits
        {
            get { return (object)this["HABITS"]; }
            set { this["HABITS"] = value; }
        }

    /// <summary>
    /// Hastanın Vakada Girilen 'Özgeçmiş' Bilgisinin Tutulduğu Alandır
    /// </summary>
        public object PatientHistory
        {
            get { return (object)this["PATIENTHISTORY"]; }
            set { this["PATIENTHISTORY"] = value; }
        }

    /// <summary>
    /// Hastanı Yatan / Ayaktan Hasta Olduğu Bilgisini Tutan Alandır
    /// </summary>
        public PatientStatusEnum? PatientStatus
        {
            get { return (PatientStatusEnum?)(int?)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu Muayenesinin Başlatıldığı Tarih
    /// </summary>
        public DateTime? HealthCommitteeStartDate
        {
            get { return (DateTime?)this["HEALTHCOMMITTEESTARTDATE"]; }
            set { this["HEALTHCOMMITTEESTARTDATE"] = value; }
        }

    /// <summary>
    /// Her Vaka Açılışında Alınan XXXXXX Protokol No
    /// </summary>
        public TTSequence HospitalProtocolNo
        {
            get { return GetSequence("HOSPITALPROTOCOLNO"); }
        }

    /// <summary>
    /// Diğer XXXXXXlerden Başlatılan Vakaları Başlatan Nesne Guidinin Tutulduğu Alan
    /// </summary>
        public Guid? sourceDispatchObjID
        {
            get { return (Guid?)this["SOURCEDISPATCHOBJID"]; }
            set { this["SOURCEDISPATCHOBJID"] = value; }
        }

    /// <summary>
    /// Sistem Sorgulaması
    /// </summary>
        public object SystemQuery
        {
            get { return (object)this["SYSTEMQUERY"]; }
            set { this["SYSTEMQUERY"] = value; }
        }

    /// <summary>
    /// Hastaya Vakada Girilen Önemli Bilgilein Bulunduğu Alan
    /// </summary>
        public object ImportantPatientInfo
        {
            get { return (object)this["IMPORTANTPATIENTINFO"]; }
            set { this["IMPORTANTPATIENTINFO"] = value; }
        }

    /// <summary>
    /// Hastaya Vakada Yapılan 'Fizik Muayene' Bilgisini Tutan Alandır
    /// </summary>
        public object PhysicalExamination
        {
            get { return (object)this["PHYSICALEXAMINATION"]; }
            set { this["PHYSICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Muayene Özeti
    /// </summary>
        public object ExaminationSummary
        {
            get { return (object)this["EXAMINATIONSUMMARY"]; }
            set { this["EXAMINATIONSUMMARY"] = value; }
        }

    /// <summary>
    /// Vakada Hasta Kabulün Yapıldığı Birimler
    /// </summary>
        public string AdmissionResource
        {
            get { return (string)this["ADMISSIONRESOURCE"]; }
            set { this["ADMISSIONRESOURCE"] = value; }
        }

        public bool? IsQuotaUsed
        {
            get { return (bool?)this["ISQUOTAUSED"]; }
            set { this["ISQUOTAUSED"] = value; }
        }

    /// <summary>
    /// Karar ve İşlem
    /// </summary>
        public object DecisionAndAction
        {
            get { return (object)this["DECISIONANDACTION"]; }
            set { this["DECISIONANDACTION"] = value; }
        }

    /// <summary>
    /// Hikayesi
    /// </summary>
        public object PatientStory
        {
            get { return (object)this["PATIENTSTORY"]; }
            set { this["PATIENTSTORY"] = value; }
        }

    /// <summary>
    /// Hastanın Yeni Doğan Olup Olmadığı Bilgisinin Tutulduğu Alandır
    /// </summary>
        public bool? IsNewBorn
        {
            get { return (bool?)this["ISNEWBORN"]; }
            set { this["ISNEWBORN"] = value; }
        }

    /// <summary>
    /// MTS Karar
    /// </summary>
        public object MTSConclusion
        {
            get { return (object)this["MTSCONCLUSION"]; }
            set { this["MTSCONCLUSION"] = value; }
        }

    /// <summary>
    /// Vakanın Bağlı Olduğu Hasta
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Vakadaki 'Kurum ' Bilgisini Taşıyan Alandır
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Vakada Asıl İlgilenilen Tanı 
    /// </summary>
        public DiagnosisGrid MainDiagnose
        {
            get { return (DiagnosisGrid)((ITTObject)this).GetParent("MAINDIAGNOSE"); }
            set { this["MAINDIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Vakadaki 'Kurum İli ' Bilgisini Taşıyan Alandır
    /// </summary>
        public City FoundationCity
        {
            get { return (City)((ITTObject)this).GetParent("FOUNDATIONCITY"); }
            set { this["FOUNDATIONCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastaları Birleştirilen Vakaların  Birleşmeden önceki  Hastası
    /// </summary>
        public Patient OldPatient
        {
            get { return (Patient)((ITTObject)this).GetParent("OLDPATIENT"); }
            set { this["OLDPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Vakanın Kabulünün Yapıldığı Birime Ait Uzmanlık Dalı
    /// </summary>
        public SpecialityDefinition MainSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("MAINSPECIALITY"); }
            set { this["MAINSPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InfluenzaResult Influenza
        {
            get { return (InfluenzaResult)((ITTObject)this).GetParent("INFLUENZA"); }
            set { this["INFLUENZA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hastanın Alie Reisi İle Arasındaki 'Yakınlık Derecesi ' Bilgisini Taşıyan Alandır
    /// </summary>
        public RelationshipDefinition Relationship
        {
            get { return (RelationshipDefinition)((ITTObject)this).GetParent("RELATIONSHIP"); }
            set { this["RELATIONSHIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yatan Hastanın Vakada Yattığı Yatağı Tutar
    /// </summary>
        public ResBed Bed
        {
            get { return (ResBed)((ITTObject)this).GetParent("BED"); }
            set { this["BED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Vakada Sağlık Kurulu Varsa Ne Maksatla Muayene Edildiği Alanınan Tutulduğu Alandır
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İştirak Tipi
    /// </summary>
        public PatientExamParticipationDefinition ParticipationType
        {
            get { return (PatientExamParticipationDefinition)((ITTObject)this).GetParent("PARTICIPATIONTYPE"); }
            set { this["PARTICIPATIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// EmergencyPatientStatusInfo
    /// </summary>
        public EmergencyPatientStatusInfo EmergencyPatientStatusInfo
        {
            get { return (EmergencyPatientStatusInfo)((ITTObject)this).GetParent("EMERGENCYPATIENTSTATUSINFO"); }
            set { this["EMERGENCYPATIENTSTATUSINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SigortaliTuru MedulaSigortaliTuru
        {
            get { return (SigortaliTuru)((ITTObject)this).GetParent("MEDULASIGORTALITURU"); }
            set { this["MEDULASIGORTALITURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Protokol
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSubActionProceduresCollectionViews()
        {
            _SubactionProcedureFlowables = new SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection(_SubActionProcedures, "SubactionProcedureFlowables");
            _CompanionProcedures = new CompanionProcedure.ChildCompanionProcedureCollection(_SubActionProcedures, "CompanionProcedures");
            _BaseBedProcedures = new BaseBedProcedure.ChildBaseBedProcedureCollection(_SubActionProcedures, "BaseBedProcedures");
        }

        virtual protected void CreateSubActionProceduresCollection()
        {
            _SubActionProcedures = new SubActionProcedure.ChildSubActionProcedureCollection(this, new Guid("30069c6c-0075-4653-bb0c-01f1428dc2ef"));
            CreateSubActionProceduresCollectionViews();
            ((ITTChildObjectCollection)_SubActionProcedures).GetChildren();
        }

        protected SubActionProcedure.ChildSubActionProcedureCollection _SubActionProcedures = null;
        public SubActionProcedure.ChildSubActionProcedureCollection SubActionProcedures
        {
            get
            {
                if (_SubActionProcedures == null)
                    CreateSubActionProceduresCollection();
                return _SubActionProcedures;
            }
        }

        private SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection _SubactionProcedureFlowables = null;
        public SubactionProcedureFlowable.ChildSubactionProcedureFlowableCollection SubactionProcedureFlowables
        {
            get
            {
                if (_SubActionProcedures == null)
                    CreateSubActionProceduresCollection();
                return _SubactionProcedureFlowables;
            }            
        }

        private CompanionProcedure.ChildCompanionProcedureCollection _CompanionProcedures = null;
        public CompanionProcedure.ChildCompanionProcedureCollection CompanionProcedures
        {
            get
            {
                if (_SubActionProcedures == null)
                    CreateSubActionProceduresCollection();
                return _CompanionProcedures;
            }            
        }

        private BaseBedProcedure.ChildBaseBedProcedureCollection _BaseBedProcedures = null;
        public BaseBedProcedure.ChildBaseBedProcedureCollection BaseBedProcedures
        {
            get
            {
                if (_SubActionProcedures == null)
                    CreateSubActionProceduresCollection();
                return _BaseBedProcedures;
            }            
        }

        virtual protected void CreatePatientAdmissionsCollection()
        {
            _PatientAdmissions = new PatientAdmission.ChildPatientAdmissionCollection(this, new Guid("d5ceb9b9-a645-49d7-ac84-05adc57d1f69"));
            ((ITTChildObjectCollection)_PatientAdmissions).GetChildren();
        }

        protected PatientAdmission.ChildPatientAdmissionCollection _PatientAdmissions = null;
    /// <summary>
    /// Child collection for Episode_PatientAdmission
    /// </summary>
        public PatientAdmission.ChildPatientAdmissionCollection PatientAdmissions
        {
            get
            {
                if (_PatientAdmissions == null)
                    CreatePatientAdmissionsCollection();
                return _PatientAdmissions;
            }
        }

        virtual protected void CreateCollectedPatientListCollection()
        {
            _CollectedPatientList = new CollectedPatientList.ChildCollectedPatientListCollection(this, new Guid("ea129a06-937e-4650-9bce-1d68eede7849"));
            ((ITTChildObjectCollection)_CollectedPatientList).GetChildren();
        }

        protected CollectedPatientList.ChildCollectedPatientListCollection _CollectedPatientList = null;
    /// <summary>
    /// Child collection for Hasta Dosyasıyla İlişki
    /// </summary>
        public CollectedPatientList.ChildCollectedPatientListCollection CollectedPatientList
        {
            get
            {
                if (_CollectedPatientList == null)
                    CreateCollectedPatientListCollection();
                return _CollectedPatientList;
            }
        }

        virtual protected void CreateBaseQuarantineValuableMaterialsCollectionViews()
        {
            _ValuableMaterials = new InpatientAdmissionValuableMaterial.ChildInpatientAdmissionValuableMaterialCollection(_BaseQuarantineValuableMaterials, "ValuableMaterials");
            _Money = new InpatientAdmissionMoney.ChildInpatientAdmissionMoneyCollection(_BaseQuarantineValuableMaterials, "Money");
        }

        virtual protected void CreateBaseQuarantineValuableMaterialsCollection()
        {
            _BaseQuarantineValuableMaterials = new BaseQuarantineValuableMaterial.ChildBaseQuarantineValuableMaterialCollection(this, new Guid("288de25f-6348-48b4-bba8-7045427cca54"));
            CreateBaseQuarantineValuableMaterialsCollectionViews();
            ((ITTChildObjectCollection)_BaseQuarantineValuableMaterials).GetChildren();
        }

        protected BaseQuarantineValuableMaterial.ChildBaseQuarantineValuableMaterialCollection _BaseQuarantineValuableMaterials = null;
        public BaseQuarantineValuableMaterial.ChildBaseQuarantineValuableMaterialCollection BaseQuarantineValuableMaterials
        {
            get
            {
                if (_BaseQuarantineValuableMaterials == null)
                    CreateBaseQuarantineValuableMaterialsCollection();
                return _BaseQuarantineValuableMaterials;
            }
        }

        private InpatientAdmissionValuableMaterial.ChildInpatientAdmissionValuableMaterialCollection _ValuableMaterials = null;
        public InpatientAdmissionValuableMaterial.ChildInpatientAdmissionValuableMaterialCollection ValuableMaterials
        {
            get
            {
                if (_BaseQuarantineValuableMaterials == null)
                    CreateBaseQuarantineValuableMaterialsCollection();
                return _ValuableMaterials;
            }            
        }

        private InpatientAdmissionMoney.ChildInpatientAdmissionMoneyCollection _Money = null;
        public InpatientAdmissionMoney.ChildInpatientAdmissionMoneyCollection Money
        {
            get
            {
                if (_BaseQuarantineValuableMaterials == null)
                    CreateBaseQuarantineValuableMaterialsCollection();
                return _Money;
            }            
        }

        virtual protected void CreateSubActionMaterialsCollectionViews()
        {
            _DrugOrders = new DrugOrder.ChildDrugOrderCollection(_SubActionMaterials, "DrugOrders");
            _DrugOrderDetails = new DrugOrderDetail.ChildDrugOrderDetailCollection(_SubActionMaterials, "DrugOrderDetails");
        }

        virtual protected void CreateSubActionMaterialsCollection()
        {
            _SubActionMaterials = new SubActionMaterial.ChildSubActionMaterialCollection(this, new Guid("f22ddb68-245e-4b36-999b-79c5b6da16f8"));
            CreateSubActionMaterialsCollectionViews();
            ((ITTChildObjectCollection)_SubActionMaterials).GetChildren();
        }

        protected SubActionMaterial.ChildSubActionMaterialCollection _SubActionMaterials = null;
        public SubActionMaterial.ChildSubActionMaterialCollection SubActionMaterials
        {
            get
            {
                if (_SubActionMaterials == null)
                    CreateSubActionMaterialsCollection();
                return _SubActionMaterials;
            }
        }

        private DrugOrder.ChildDrugOrderCollection _DrugOrders = null;
        public DrugOrder.ChildDrugOrderCollection DrugOrders
        {
            get
            {
                if (_SubActionMaterials == null)
                    CreateSubActionMaterialsCollection();
                return _DrugOrders;
            }            
        }

        private DrugOrderDetail.ChildDrugOrderDetailCollection _DrugOrderDetails = null;
        public DrugOrderDetail.ChildDrugOrderDetailCollection DrugOrderDetails
        {
            get
            {
                if (_SubActionMaterials == null)
                    CreateSubActionMaterialsCollection();
                return _DrugOrderDetails;
            }            
        }

        virtual protected void CreateAllocationsCollection()
        {
            _Allocations = new Allocation.ChildAllocationCollection(this, new Guid("2c8ebbc8-406c-4657-b0f9-8caa79d34422"));
            ((ITTChildObjectCollection)_Allocations).GetChildren();
        }

        protected Allocation.ChildAllocationCollection _Allocations = null;
        public Allocation.ChildAllocationCollection Allocations
        {
            get
            {
                if (_Allocations == null)
                    CreateAllocationsCollection();
                return _Allocations;
            }
        }

        virtual protected void CreateInpatientAdmissionGivenMaterialsCollection()
        {
            _InpatientAdmissionGivenMaterials = new InpatientAdmissionGivenMaterial.ChildInpatientAdmissionGivenMaterialCollection(this, new Guid("f5b733d2-c239-4ca0-94f5-729ff9b5e10c"));
            ((ITTChildObjectCollection)_InpatientAdmissionGivenMaterials).GetChildren();
        }

        protected InpatientAdmissionGivenMaterial.ChildInpatientAdmissionGivenMaterialCollection _InpatientAdmissionGivenMaterials = null;
    /// <summary>
    /// Child collection for Verilen Eşyalar Sekmesi
    /// </summary>
        public InpatientAdmissionGivenMaterial.ChildInpatientAdmissionGivenMaterialCollection InpatientAdmissionGivenMaterials
        {
            get
            {
                if (_InpatientAdmissionGivenMaterials == null)
                    CreateInpatientAdmissionGivenMaterialsCollection();
                return _InpatientAdmissionGivenMaterials;
            }
        }

        virtual protected void CreateDebentureFollowPaymentOrderListCollection()
        {
            _DebentureFollowPaymentOrderList = new DebentureFollowPaymentOrderList.ChildDebentureFollowPaymentOrderListCollection(this, new Guid("6f9541e9-ab47-46e3-8052-a8480da0f0a6"));
            ((ITTChildObjectCollection)_DebentureFollowPaymentOrderList).GetChildren();
        }

        protected DebentureFollowPaymentOrderList.ChildDebentureFollowPaymentOrderListCollection _DebentureFollowPaymentOrderList = null;
    /// <summary>
    /// Child collection for Hasta Dosyasıyla İlişkisi 
    /// </summary>
        public DebentureFollowPaymentOrderList.ChildDebentureFollowPaymentOrderListCollection DebentureFollowPaymentOrderList
        {
            get
            {
                if (_DebentureFollowPaymentOrderList == null)
                    CreateDebentureFollowPaymentOrderListCollection();
                return _DebentureFollowPaymentOrderList;
            }
        }

        virtual protected void CreateComplaintsCollection()
        {
            _Complaints = new Complaint.ChildComplaintCollection(this, new Guid("4f4d4b84-ac57-43b7-8b77-9d74d31508ea"));
            ((ITTChildObjectCollection)_Complaints).GetChildren();
        }

        protected Complaint.ChildComplaintCollection _Complaints = null;
        public Complaint.ChildComplaintCollection Complaints
        {
            get
            {
                if (_Complaints == null)
                    CreateComplaintsCollection();
                return _Complaints;
            }
        }

        virtual protected void CreateDiagnosisCollection()
        {
            _Diagnosis = new DiagnosisGrid.ChildDiagnosisGridCollection(this, new Guid("6c1ea7d7-f373-4aff-b343-b24befb0c47e"));
            ((ITTChildObjectCollection)_Diagnosis).GetChildren();
        }

        protected DiagnosisGrid.ChildDiagnosisGridCollection _Diagnosis = null;
        public DiagnosisGrid.ChildDiagnosisGridCollection Diagnosis
        {
            get
            {
                if (_Diagnosis == null)
                    CreateDiagnosisCollection();
                return _Diagnosis;
            }
        }

        virtual protected void CreateInpatientAdmissionTakenMaterialsCollection()
        {
            _InpatientAdmissionTakenMaterials = new InpatientAdmissionTakenMaterial.ChildInpatientAdmissionTakenMaterialCollection(this, new Guid("a6000e86-449f-4d1c-912e-76478c269d18"));
            ((ITTChildObjectCollection)_InpatientAdmissionTakenMaterials).GetChildren();
        }

        protected InpatientAdmissionTakenMaterial.ChildInpatientAdmissionTakenMaterialCollection _InpatientAdmissionTakenMaterials = null;
    /// <summary>
    /// Child collection for Alınan Eşyalar Sekmesi
    /// </summary>
        public InpatientAdmissionTakenMaterial.ChildInpatientAdmissionTakenMaterialCollection InpatientAdmissionTakenMaterials
        {
            get
            {
                if (_InpatientAdmissionTakenMaterials == null)
                    CreateInpatientAdmissionTakenMaterialsCollection();
                return _InpatientAdmissionTakenMaterials;
            }
        }

        virtual protected void CreateEpisodeActionsCollectionViews()
        {
            _AnesthesiaConsultations = new AnesthesiaConsultation.ChildAnesthesiaConsultationCollection(_EpisodeActions, "AnesthesiaConsultations");
            _StoneBreakUpRequests = new StoneBreakUpRequest.ChildStoneBreakUpRequestCollection(_EpisodeActions, "StoneBreakUpRequests");
            _TreatmentDischarges = new TreatmentDischarge.ChildTreatmentDischargeCollection(_EpisodeActions, "TreatmentDischarges");
            _InPatientTreatmentClinicApplications = new InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection(_EpisodeActions, "InPatientTreatmentClinicApplications");
            _ParticipatnFreeDrugReports = new ParticipatnFreeDrugReport.ChildParticipatnFreeDrugReportCollection(_EpisodeActions, "ParticipatnFreeDrugReports");
            _IntensiveCareAfterSurgeries = new IntensiveCareAfterSurgery.ChildIntensiveCareAfterSurgeryCollection(_EpisodeActions, "IntensiveCareAfterSurgeries");
            _HealthCommitteeWithThreeSpecialists = new HealthCommitteeWithThreeSpecialist.ChildHealthCommitteeWithThreeSpecialistCollection(_EpisodeActions, "HealthCommitteeWithThreeSpecialists");
            _AdvanceBacks = new AdvanceBack.ChildAdvanceBackCollection(_EpisodeActions, "AdvanceBacks");
            _InpatientAdmissions = new InpatientAdmission.ChildInpatientAdmissionCollection(_EpisodeActions, "InpatientAdmissions");
            _DeathMinutesRecords = new DeathMinutesRecord.ChildDeathMinutesRecordCollection(_EpisodeActions, "DeathMinutesRecords");
            _Advances = new Advance.ChildAdvanceCollection(_EpisodeActions, "Advances");
            _HealthCommittees = new HealthCommittee.ChildHealthCommitteeCollection(_EpisodeActions, "HealthCommittees");
            _Surgeries = new Surgery.ChildSurgeryCollection(_EpisodeActions, "Surgeries");
            _AutopsyReports = new AutopsyReport.ChildAutopsyReportCollection(_EpisodeActions, "AutopsyReports");
            _CompanionApplications = new CompanionApplication.ChildCompanionApplicationCollection(_EpisodeActions, "CompanionApplications");
            _ForensicMedicalReports = new ForensicMedicalReport.ChildForensicMedicalReportCollection(_EpisodeActions, "ForensicMedicalReports");
            _PatientExaminations = new PatientExamination.ChildPatientExaminationCollection(_EpisodeActions, "PatientExaminations");
            _OrthesisProsthesisRequests = new OrthesisProsthesisRequest.ChildOrthesisProsthesisRequestCollection(_EpisodeActions, "OrthesisProsthesisRequests");
            _InfectiousIllnesesInformations = new InfectiousIllnesesInformation.ChildInfectiousIllnesesInformationCollection(_EpisodeActions, "InfectiousIllnesesInformations");
            _Morgues = new Morgue.ChildMorgueCollection(_EpisodeActions, "Morgues");
            _Bonds = new Bond.ChildBondCollection(_EpisodeActions, "Bonds");
            _DentalExaminations = new DentalExamination.ChildDentalExaminationCollection(_EpisodeActions, "DentalExaminations");
            _RegularObstetrics = new RegularObstetric.ChildRegularObstetricCollection(_EpisodeActions, "RegularObstetrics");
            _PhysiotherapyRequests = new PhysiotherapyRequest.ChildPhysiotherapyRequestCollection(_EpisodeActions, "PhysiotherapyRequests");
            _DialysisRequests = new DialysisRequest.ChildDialysisRequestCollection(_EpisodeActions, "DialysisRequests");
            _PayerInvoices = new PayerInvoice.ChildPayerInvoiceCollection(_EpisodeActions, "PayerInvoices");
            _HyperbarikOxygenTreatmentRequests = new HyperbarikOxygenTreatmentRequest.ChildHyperbarikOxygenTreatmentRequestCollection(_EpisodeActions, "HyperbarikOxygenTreatmentRequests");
            _Manipulations = new Manipulation.ChildManipulationCollection(_EpisodeActions, "Manipulations");
            _CreatingEpicrisis = new CreatingEpicrisis.ChildCreatingEpicrisisCollection(_EpisodeActions, "CreatingEpicrisis");
            _EmergencyInterventions = new EmergencyIntervention.ChildEmergencyInterventionCollection(_EpisodeActions, "EmergencyInterventions");
        }

        virtual protected void CreateEpisodeActionsCollection()
        {
            _EpisodeActions = new EpisodeAction.ChildEpisodeActionCollection(this, new Guid("47112414-1c22-4ae4-876e-e995cd6a3fc7"));
            CreateEpisodeActionsCollectionViews();
            ((ITTChildObjectCollection)_EpisodeActions).GetChildren();
        }

        protected EpisodeAction.ChildEpisodeActionCollection _EpisodeActions = null;
    /// <summary>
    /// Child collection for İşlemin Bağlı Olduğu Vaka
    /// </summary>
        public EpisodeAction.ChildEpisodeActionCollection EpisodeActions
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _EpisodeActions;
            }
        }

        private AnesthesiaConsultation.ChildAnesthesiaConsultationCollection _AnesthesiaConsultations = null;
        public AnesthesiaConsultation.ChildAnesthesiaConsultationCollection AnesthesiaConsultations
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _AnesthesiaConsultations;
            }            
        }

        private StoneBreakUpRequest.ChildStoneBreakUpRequestCollection _StoneBreakUpRequests = null;
        public StoneBreakUpRequest.ChildStoneBreakUpRequestCollection StoneBreakUpRequests
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _StoneBreakUpRequests;
            }            
        }

        private TreatmentDischarge.ChildTreatmentDischargeCollection _TreatmentDischarges = null;
        public TreatmentDischarge.ChildTreatmentDischargeCollection TreatmentDischarges
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _TreatmentDischarges;
            }            
        }

        private InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection _InPatientTreatmentClinicApplications = null;
        public InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection InPatientTreatmentClinicApplications
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _InPatientTreatmentClinicApplications;
            }            
        }

        private ParticipatnFreeDrugReport.ChildParticipatnFreeDrugReportCollection _ParticipatnFreeDrugReports = null;
        public ParticipatnFreeDrugReport.ChildParticipatnFreeDrugReportCollection ParticipatnFreeDrugReports
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _ParticipatnFreeDrugReports;
            }            
        }

        private IntensiveCareAfterSurgery.ChildIntensiveCareAfterSurgeryCollection _IntensiveCareAfterSurgeries = null;
        public IntensiveCareAfterSurgery.ChildIntensiveCareAfterSurgeryCollection IntensiveCareAfterSurgeries
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _IntensiveCareAfterSurgeries;
            }            
        }

        private HealthCommitteeWithThreeSpecialist.ChildHealthCommitteeWithThreeSpecialistCollection _HealthCommitteeWithThreeSpecialists = null;
        public HealthCommitteeWithThreeSpecialist.ChildHealthCommitteeWithThreeSpecialistCollection HealthCommitteeWithThreeSpecialists
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _HealthCommitteeWithThreeSpecialists;
            }            
        }

        private AdvanceBack.ChildAdvanceBackCollection _AdvanceBacks = null;
        public AdvanceBack.ChildAdvanceBackCollection AdvanceBacks
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _AdvanceBacks;
            }            
        }

        private InpatientAdmission.ChildInpatientAdmissionCollection _InpatientAdmissions = null;
        public InpatientAdmission.ChildInpatientAdmissionCollection InpatientAdmissions
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _InpatientAdmissions;
            }            
        }

        private DeathMinutesRecord.ChildDeathMinutesRecordCollection _DeathMinutesRecords = null;
        public DeathMinutesRecord.ChildDeathMinutesRecordCollection DeathMinutesRecords
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _DeathMinutesRecords;
            }            
        }

        private Advance.ChildAdvanceCollection _Advances = null;
        public Advance.ChildAdvanceCollection Advances
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _Advances;
            }            
        }

        private HealthCommittee.ChildHealthCommitteeCollection _HealthCommittees = null;
        public HealthCommittee.ChildHealthCommitteeCollection HealthCommittees
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _HealthCommittees;
            }            
        }

        private Surgery.ChildSurgeryCollection _Surgeries = null;
        public Surgery.ChildSurgeryCollection Surgeries
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _Surgeries;
            }            
        }

        private AutopsyReport.ChildAutopsyReportCollection _AutopsyReports = null;
        public AutopsyReport.ChildAutopsyReportCollection AutopsyReports
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _AutopsyReports;
            }            
        }

        private CompanionApplication.ChildCompanionApplicationCollection _CompanionApplications = null;
        public CompanionApplication.ChildCompanionApplicationCollection CompanionApplications
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _CompanionApplications;
            }            
        }

        private ForensicMedicalReport.ChildForensicMedicalReportCollection _ForensicMedicalReports = null;
        public ForensicMedicalReport.ChildForensicMedicalReportCollection ForensicMedicalReports
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _ForensicMedicalReports;
            }            
        }

        private PatientExamination.ChildPatientExaminationCollection _PatientExaminations = null;
        public PatientExamination.ChildPatientExaminationCollection PatientExaminations
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _PatientExaminations;
            }            
        }

        private OrthesisProsthesisRequest.ChildOrthesisProsthesisRequestCollection _OrthesisProsthesisRequests = null;
        public OrthesisProsthesisRequest.ChildOrthesisProsthesisRequestCollection OrthesisProsthesisRequests
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _OrthesisProsthesisRequests;
            }            
        }

        private InfectiousIllnesesInformation.ChildInfectiousIllnesesInformationCollection _InfectiousIllnesesInformations = null;
        public InfectiousIllnesesInformation.ChildInfectiousIllnesesInformationCollection InfectiousIllnesesInformations
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _InfectiousIllnesesInformations;
            }            
        }

        private Morgue.ChildMorgueCollection _Morgues = null;
        public Morgue.ChildMorgueCollection Morgues
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _Morgues;
            }            
        }

        private Bond.ChildBondCollection _Bonds = null;
        public Bond.ChildBondCollection Bonds
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _Bonds;
            }            
        }

        private DentalExamination.ChildDentalExaminationCollection _DentalExaminations = null;
        public DentalExamination.ChildDentalExaminationCollection DentalExaminations
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _DentalExaminations;
            }            
        }

        private RegularObstetric.ChildRegularObstetricCollection _RegularObstetrics = null;
        public RegularObstetric.ChildRegularObstetricCollection RegularObstetrics
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _RegularObstetrics;
            }            
        }

        private PhysiotherapyRequest.ChildPhysiotherapyRequestCollection _PhysiotherapyRequests = null;
        public PhysiotherapyRequest.ChildPhysiotherapyRequestCollection PhysiotherapyRequests
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _PhysiotherapyRequests;
            }            
        }

        private DialysisRequest.ChildDialysisRequestCollection _DialysisRequests = null;
        public DialysisRequest.ChildDialysisRequestCollection DialysisRequests
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _DialysisRequests;
            }            
        }

        private PayerInvoice.ChildPayerInvoiceCollection _PayerInvoices = null;
        public PayerInvoice.ChildPayerInvoiceCollection PayerInvoices
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _PayerInvoices;
            }            
        }

        private HyperbarikOxygenTreatmentRequest.ChildHyperbarikOxygenTreatmentRequestCollection _HyperbarikOxygenTreatmentRequests = null;
        public HyperbarikOxygenTreatmentRequest.ChildHyperbarikOxygenTreatmentRequestCollection HyperbarikOxygenTreatmentRequests
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _HyperbarikOxygenTreatmentRequests;
            }            
        }

        private Manipulation.ChildManipulationCollection _Manipulations = null;
        public Manipulation.ChildManipulationCollection Manipulations
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _Manipulations;
            }            
        }

        private CreatingEpicrisis.ChildCreatingEpicrisisCollection _CreatingEpicrisis = null;
        public CreatingEpicrisis.ChildCreatingEpicrisisCollection CreatingEpicrisis
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _CreatingEpicrisis;
            }            
        }

        private EmergencyIntervention.ChildEmergencyInterventionCollection _EmergencyInterventions = null;
        public EmergencyIntervention.ChildEmergencyInterventionCollection EmergencyInterventions
        {
            get
            {
                if (_EpisodeActions == null)
                    CreateEpisodeActionsCollection();
                return _EmergencyInterventions;
            }            
        }

        virtual protected void CreateDebentureFollowExecutionListCollection()
        {
            _DebentureFollowExecutionList = new DebentureFollowExecutionList.ChildDebentureFollowExecutionListCollection(this, new Guid("2c885a7b-f076-47b0-b5c2-f65c673b45ee"));
            ((ITTChildObjectCollection)_DebentureFollowExecutionList).GetChildren();
        }

        protected DebentureFollowExecutionList.ChildDebentureFollowExecutionListCollection _DebentureFollowExecutionList = null;
    /// <summary>
    /// Child collection for Hasta Dosyasıyla İlişkisi
    /// </summary>
        public DebentureFollowExecutionList.ChildDebentureFollowExecutionListCollection DebentureFollowExecutionList
        {
            get
            {
                if (_DebentureFollowExecutionList == null)
                    CreateDebentureFollowExecutionListCollection();
                return _DebentureFollowExecutionList;
            }
        }

        virtual protected void CreateSendingInvoiceDetailsCollection()
        {
            _SendingInvoiceDetails = new SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection(this, new Guid("51429019-7dd3-421d-b309-164342f69429"));
            ((ITTChildObjectCollection)_SendingInvoiceDetails).GetChildren();
        }

        protected SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection _SendingInvoiceDetails = null;
    /// <summary>
    /// Child collection for Hasta epizotu ile ilişki
    /// </summary>
        public SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection SendingInvoiceDetails
        {
            get
            {
                if (_SendingInvoiceDetails == null)
                    CreateSendingInvoiceDetailsCollection();
                return _SendingInvoiceDetails;
            }
        }

        virtual protected void CreateEpisodeMedulaHastaKabulleriCollection()
        {
            _EpisodeMedulaHastaKabulleri = new PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection(this, new Guid("aba4ae0d-5384-4b8f-bb74-d53e3d0a33c6"));
            ((ITTChildObjectCollection)_EpisodeMedulaHastaKabulleri).GetChildren();
        }

        protected PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection _EpisodeMedulaHastaKabulleri = null;
        public PatientMedulaHastaKabul.ChildPatientMedulaHastaKabulCollection EpisodeMedulaHastaKabulleri
        {
            get
            {
                if (_EpisodeMedulaHastaKabulleri == null)
                    CreateEpisodeMedulaHastaKabulleriCollection();
                return _EpisodeMedulaHastaKabulleri;
            }
        }

        virtual protected void CreatePatientAuthorizedResourcesCollection()
        {
            _PatientAuthorizedResources = new PatientAuthorizedResource.ChildPatientAuthorizedResourceCollection(this, new Guid("b713c2f5-81fe-4da9-af6f-71d00d7f17e3"));
            ((ITTChildObjectCollection)_PatientAuthorizedResources).GetChildren();
        }

        protected PatientAuthorizedResource.ChildPatientAuthorizedResourceCollection _PatientAuthorizedResources = null;
        public PatientAuthorizedResource.ChildPatientAuthorizedResourceCollection PatientAuthorizedResources
        {
            get
            {
                if (_PatientAuthorizedResources == null)
                    CreatePatientAuthorizedResourcesCollection();
                return _PatientAuthorizedResources;
            }
        }

        virtual protected void CreateReadyToCollectedInvoiceDetailsCollection()
        {
            _ReadyToCollectedInvoiceDetails = new ReadyToCollectedInvoiceDetail.ChildReadyToCollectedInvoiceDetailCollection(this, new Guid("bbd133c0-e32e-47d7-8a96-c5c0fa6de13b"));
            ((ITTChildObjectCollection)_ReadyToCollectedInvoiceDetails).GetChildren();
        }

        protected ReadyToCollectedInvoiceDetail.ChildReadyToCollectedInvoiceDetailCollection _ReadyToCollectedInvoiceDetails = null;
        public ReadyToCollectedInvoiceDetail.ChildReadyToCollectedInvoiceDetailCollection ReadyToCollectedInvoiceDetails
        {
            get
            {
                if (_ReadyToCollectedInvoiceDetails == null)
                    CreateReadyToCollectedInvoiceDetailsCollection();
                return _ReadyToCollectedInvoiceDetails;
            }
        }

        virtual protected void CreateSubEpisodesCollection()
        {
            _SubEpisodes = new SubEpisode.ChildSubEpisodeCollection(this, new Guid("cf3d6f65-7653-4d6b-a317-46b1ae6ee776"));
            ((ITTChildObjectCollection)_SubEpisodes).GetChildren();
        }

        protected SubEpisode.ChildSubEpisodeCollection _SubEpisodes = null;
    /// <summary>
    /// Child collection for Episode
    /// </summary>
        public SubEpisode.ChildSubEpisodeCollection SubEpisodes
        {
            get
            {
                if (_SubEpisodes == null)
                    CreateSubEpisodesCollection();
                return _SubEpisodes;
            }
        }

        virtual protected void CreateExaminationMeasesCollection()
        {
            _ExaminationMeases = new ExaminationMeasGrid.ChildExaminationMeasGridCollection(this, new Guid("1fca1e3e-a26b-489a-8908-2247174d68ce"));
            ((ITTChildObjectCollection)_ExaminationMeases).GetChildren();
        }

        protected ExaminationMeasGrid.ChildExaminationMeasGridCollection _ExaminationMeases = null;
        public ExaminationMeasGrid.ChildExaminationMeasGridCollection ExaminationMeases
        {
            get
            {
                if (_ExaminationMeases == null)
                    CreateExaminationMeasesCollection();
                return _ExaminationMeases;
            }
        }

        virtual protected void CreateInvoiceCollectionDetailsCollection()
        {
            _InvoiceCollectionDetails = new InvoiceCollectionDetail.ChildInvoiceCollectionDetailCollection(this, new Guid("4b88920d-6532-4d49-b97c-892119449670"));
            ((ITTChildObjectCollection)_InvoiceCollectionDetails).GetChildren();
        }

        protected InvoiceCollectionDetail.ChildInvoiceCollectionDetailCollection _InvoiceCollectionDetails = null;
        public InvoiceCollectionDetail.ChildInvoiceCollectionDetailCollection InvoiceCollectionDetails
        {
            get
            {
                if (_InvoiceCollectionDetails == null)
                    CreateInvoiceCollectionDetailsCollection();
                return _InvoiceCollectionDetails;
            }
        }

        virtual protected void CreateSaglikNetProtocolsCollection()
        {
            _SaglikNetProtocols = new SaglikNetProtokol.ChildSaglikNetProtokolCollection(this, new Guid("8b432926-913f-4723-8fad-c9f0f74609e9"));
            ((ITTChildObjectCollection)_SaglikNetProtocols).GetChildren();
        }

        protected SaglikNetProtokol.ChildSaglikNetProtokolCollection _SaglikNetProtocols = null;
    /// <summary>
    /// Child collection for Episode
    /// </summary>
        public SaglikNetProtokol.ChildSaglikNetProtokolCollection SaglikNetProtocols
        {
            get
            {
                if (_SaglikNetProtocols == null)
                    CreateSaglikNetProtocolsCollection();
                return _SaglikNetProtocols;
            }
        }

        virtual protected void CreateInvoiceBlockingsCollection()
        {
            _InvoiceBlockings = new InvoiceBlocking.ChildInvoiceBlockingCollection(this, new Guid("dbe25098-c98d-4efb-86b6-8a9a32b8b692"));
            ((ITTChildObjectCollection)_InvoiceBlockings).GetChildren();
        }

        protected InvoiceBlocking.ChildInvoiceBlockingCollection _InvoiceBlockings = null;
    /// <summary>
    /// Child collection for Fatura Engelleri
    /// </summary>
        public InvoiceBlocking.ChildInvoiceBlockingCollection InvoiceBlockings
        {
            get
            {
                if (_InvoiceBlockings == null)
                    CreateInvoiceBlockingsCollection();
                return _InvoiceBlockings;
            }
        }

        virtual protected void CreateInpatientAdmissionDepositMaterialsCollection()
        {
            _InpatientAdmissionDepositMaterials = new InpatientAdmissionDepositMaterial.ChildInpatientAdmissionDepositMaterialCollection(this, new Guid("95616fd8-90da-4c07-9310-6155814e9a87"));
            ((ITTChildObjectCollection)_InpatientAdmissionDepositMaterials).GetChildren();
        }

        protected InpatientAdmissionDepositMaterial.ChildInpatientAdmissionDepositMaterialCollection _InpatientAdmissionDepositMaterials = null;
        public InpatientAdmissionDepositMaterial.ChildInpatientAdmissionDepositMaterialCollection InpatientAdmissionDepositMaterials
        {
            get
            {
                if (_InpatientAdmissionDepositMaterials == null)
                    CreateInpatientAdmissionDepositMaterialsCollection();
                return _InpatientAdmissionDepositMaterials;
            }
        }

        virtual protected void CreateBaseBlockAppointmentsCollection()
        {
            _BaseBlockAppointments = new BaseBlockAppointment.ChildBaseBlockAppointmentCollection(this, new Guid("fb6473ae-e30d-493f-8ae1-e358bd074bb2"));
            ((ITTChildObjectCollection)_BaseBlockAppointments).GetChildren();
        }

        protected BaseBlockAppointment.ChildBaseBlockAppointmentCollection _BaseBlockAppointments = null;
    /// <summary>
    /// Child collection for Randevu sonucu İşlemin Başlatılacağı episode
    /// </summary>
        public BaseBlockAppointment.ChildBaseBlockAppointmentCollection BaseBlockAppointments
        {
            get
            {
                if (_BaseBlockAppointments == null)
                    CreateBaseBlockAppointmentsCollection();
                return _BaseBlockAppointments;
            }
        }

        virtual protected void CreateUploadedDocumentsCollection()
        {
            _UploadedDocuments = new UploadedDocument.ChildUploadedDocumentCollection(this, new Guid("a820d523-4cc8-4d21-96e1-d6d432ae8a5f"));
            ((ITTChildObjectCollection)_UploadedDocuments).GetChildren();
        }

        protected UploadedDocument.ChildUploadedDocumentCollection _UploadedDocuments = null;
        public UploadedDocument.ChildUploadedDocumentCollection UploadedDocuments
        {
            get
            {
                if (_UploadedDocuments == null)
                    CreateUploadedDocumentsCollection();
                return _UploadedDocuments;
            }
        }

        virtual protected void CreateEpisodeFoldersCollection()
        {
            _EpisodeFolders = new EpisodeFolder.ChildEpisodeFolderCollection(this, new Guid("b2fed255-d5f3-43f7-b4a6-3bfe9b66b572"));
            ((ITTChildObjectCollection)_EpisodeFolders).GetChildren();
        }

        protected EpisodeFolder.ChildEpisodeFolderCollection _EpisodeFolders = null;
        public EpisodeFolder.ChildEpisodeFolderCollection EpisodeFolders
        {
            get
            {
                if (_EpisodeFolders == null)
                    CreateEpisodeFoldersCollection();
                return _EpisodeFolders;
            }
        }

        protected Episode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Episode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Episode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Episode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Episode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODE", dataRow) { }
        protected Episode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODE", dataRow, isImported) { }
        public Episode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Episode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Episode() : base() { }

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