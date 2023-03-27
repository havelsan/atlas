
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InPatientTreatmentClinicApplication")] 

    /// <summary>
    /// Klinik İşlemleri
    /// </summary>
    public  partial class InPatientTreatmentClinicApplication : EpisodeAction, IWorkListInpatient, IAllocateSpeciality, IOAInPatientApplication, IWorkListEpisodeAction, ICreateSubEpisode
    {
        public class InPatientTreatmentClinicApplicationList : TTObjectCollection<InPatientTreatmentClinicApplication> { }
                    
        public class ChildInPatientTreatmentClinicApplicationCollection : TTObject.TTChildObjectCollection<InPatientTreatmentClinicApplication>
        {
            public ChildInPatientTreatmentClinicApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInPatientTreatmentClinicApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInpatientListReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

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

            public PatientStatusEnum? Hastadurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTADURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? XXXXXXyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Klinikyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tibbiprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIBBIPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedaviklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVIKLINIK"]);
                }
            }

            public string Sorumludoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Yattigiklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATTIGIKLINIK"]);
                }
            }

            public Guid? Odagrubu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODAGRUBU"]);
                }
            }

            public Guid? Oda
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA"]);
                }
            }

            public Guid? Yatak
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK"]);
                }
            }

            public GetInpatientListReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientListReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientListReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientStatistics_Class : TTReportNqlObject 
        {
            public Guid? PhysicalStateClinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSICALSTATECLINIC"]);
                }
            }

            public string Physicalstateclinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALSTATECLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetInpatientStatistics_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientStatistics_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientStatistics_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientStatisticsByDate_Class : TTReportNqlObject 
        {
            public Guid? PhysicalStateClinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSICALSTATECLINIC"]);
                }
            }

            public string Physicalstateclinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALSTATECLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetInpatientStatisticsByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientStatisticsByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientStatisticsByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByEpisodeAndMasterResourceReport_Class : TTReportNqlObject 
        {
            public DateTime? ClinicInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetByEpisodeAndMasterResourceReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByEpisodeAndMasterResourceReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByEpisodeAndMasterResourceReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetpatientListReportByDaysNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

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

            public PatientStatusEnum? Hastadurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTADURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? XXXXXXyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Klinikyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Kliniktaburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKTABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tibbiprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIBBIPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedaviklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVIKLINIK"]);
                }
            }

            public string Sorumludoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Yattigiklinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Odagrubu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODAGRUBU"]);
                }
            }

            public Guid? Oda
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA"]);
                }
            }

            public Guid? Yatak
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK"]);
                }
            }

            public GetpatientListReportByDaysNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetpatientListReportByDaysNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetpatientListReportByDaysNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetpatientListReportByInpatientDayNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

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

            public PatientStatusEnum? Hastadurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTADURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? XXXXXXyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Klinikyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Kliniktaburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKTABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tibbiprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIBBIPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedaviklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVIKLINIK"]);
                }
            }

            public string Sorumludoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Yattigiklinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Odagrubu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODAGRUBU"]);
                }
            }

            public Guid? Oda
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA"]);
                }
            }

            public Guid? Yatak
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK"]);
                }
            }

            public GetpatientListReportByInpatientDayNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetpatientListReportByInpatientDayNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetpatientListReportByInpatientDayNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientByPatientGroup_Class : TTReportNqlObject 
        {
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

            public DateTime? XXXXXXyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Oda
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yatak
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
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

            public GetInpatientByPatientGroup_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientByPatientGroup_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientByPatientGroup_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_YatanHasta_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Ward
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARD"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public Guid? Responsibledoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEDOCTOR"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public Guid? Room
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOM"]);
                }
            }

            public Guid? RoomGroup
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOMGROUP"]);
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

            public DateTime? Yatis_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATIS_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Taburcu_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TABURCU_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Object Kabultur
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KABULTUR"]);
                }
            }

            public OLAP_YatanHasta_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_YatanHasta_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_YatanHasta_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInPatientBeds_Class : TTReportNqlObject 
        {
            public Object Usedbedcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["USEDBEDCOUNT"]);
                }
            }

            public GetInPatientBeds_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInPatientBeds_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInPatientBeds_Class() : base() { }
        }

        [Serializable] 

        public partial class GetpatientListReportByDateNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

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

            public PatientStatusEnum? Hastadurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTADURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? XXXXXXyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Klinikyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Kliniktaburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKTABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tibbiprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIBBIPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedaviklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVIKLINIK"]);
                }
            }

            public string Sorumludoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Yattigiklinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Odagrubu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODAGRUBU"]);
                }
            }

            public Guid? Oda
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA"]);
                }
            }

            public Guid? Yatak
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK"]);
                }
            }

            public GetpatientListReportByDateNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetpatientListReportByDateNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetpatientListReportByDateNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientBedsByResWard_Class : TTReportNqlObject 
        {
            public Guid? Wardobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARDOBJECTID"]);
                }
            }

            public string Wardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalbed
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALBED"]);
                }
            }

            public GetInpatientBedsByResWard_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientBedsByResWard_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientBedsByResWard_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientInformation_RQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

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

            public Object Hastadurumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTADURUMU"]);
                }
            }

            public Object Hastagrubu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTAGRUBU"]);
                }
            }

            public DateTime? XXXXXXyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? XXXXXXcikistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXCIKISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HOSPITALDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Klinikyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Tibbiprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIBBIPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedaviklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVIKLINIK"]);
                }
            }

            public string Tedaviklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sorumludoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Yattigiklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATTIGIKLINIK"]);
                }
            }

            public string Yattigiklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Odagrubu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODAGRUBU"]);
                }
            }

            public string Odagrubuadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAGRUBUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Oda
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA"]);
                }
            }

            public string Odaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Yatak
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK"]);
                }
            }

            public string Yatakadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientInformation_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientInformation_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientInformation_RQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetJustInpatientStatistic_Class : TTReportNqlObject 
        {
            public Guid? PhysicalStateClinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PHYSICALSTATECLINIC"]);
                }
            }

            public string Physicalstateclinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALSTATECLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public GetJustInpatientStatistic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetJustInpatientStatistic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetJustInpatientStatistic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveInpatientTrtClinicAppByMasterResource_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaHastaCikisKayitFailed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAHASTACIKISKAYITFAILED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["MEDULAHASTACIKISKAYITFAILED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsDailyOperation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDAILYOPERATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ISDAILYOPERATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ShotInpatientReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOTINPATIENTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["SHOTINPATIENTREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public InpatientAcceptionTypeEnum? InpatientAcceptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTACCEPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["INPATIENTACCEPTIONTYPE"].DataType;
                    return (InpatientAcceptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string LongInpatientReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGINPATIENTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["LONGINPATIENTREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetActiveInpatientTrtClinicAppByMasterResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveInpatientTrtClinicAppByMasterResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveInpatientTrtClinicAppByMasterResource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInPatientInfoByPatients_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

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

            public DateTime? XXXXXXyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Klinikyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Brans
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BRANS"]);
                }
            }

            public string Bransadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANSADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tibbiprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIBBIPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedaviklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVIKLINIK"]);
                }
            }

            public string Tedaviklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Yattigiklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATTIGIKLINIK"]);
                }
            }

            public bool? Yogunbakim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YOGUNBAKIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["ISINTENSIVECARE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Yattigiklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Istegiyapandoktor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ISTEGIYAPANDOKTOR"]);
                }
            }

            public string Istegiyapandoktoradi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEGIYAPANDOKTORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yattigiklinikkati
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIKKATI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["FLOOR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sorumludoktor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SORUMLUDOKTOR"]);
                }
            }

            public string Sorumludoktoradi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Oda
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA"]);
                }
            }

            public string Odaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Yatak
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK"]);
                }
            }

            public string Yatakadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInPatientInfoByPatients_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInPatientInfoByPatients_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInPatientInfoByPatients_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientAdmissionInfoByTreatmentClinic_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yattigi_klinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGI_KLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? SubEpisode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Geldigi_klinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GELDIGI_KLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public string MotherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["MOTHERNAME"].DataType;
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

            public string BirthPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Yatis_karari_veren
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATIS_KARARI_VEREN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Odagrup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAGRUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Oda
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yatak
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
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

            public GetInpatientAdmissionInfoByTreatmentClinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientAdmissionInfoByTreatmentClinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientAdmissionInfoByTreatmentClinic_Class() : base() { }
        }

        [Serializable] 

        public partial class GetYatanHastaListesi_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

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

            public DateTime? XXXXXXyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Klinikyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Kliniktaburcutarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKTABURCUTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedaviklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVIKLINIK"]);
                }
            }

            public string Sorumludoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public string Yattigiklinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Odagrubu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAGRUBU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Oda
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yatak
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Statu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATU"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetYatanHastaListesi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetYatanHastaListesi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetYatanHastaListesi_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWaitingClinicAcceptionPatient_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicDischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICDISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICDISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ClinicInpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICINPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? MedulaHastaCikisKayitFailed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAHASTACIKISKAYITFAILED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["MEDULAHASTACIKISKAYITFAILED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsDailyOperation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDAILYOPERATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["ISDAILYOPERATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ShotInpatientReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOTINPATIENTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["SHOTINPATIENTREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public InpatientAcceptionTypeEnum? InpatientAcceptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTACCEPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["INPATIENTACCEPTIONTYPE"].DataType;
                    return (InpatientAcceptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string LongInpatientReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGINPATIENTREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["LONGINPATIENTREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWaitingClinicAcceptionPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWaitingClinicAcceptionPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWaitingClinicAcceptionPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientInfoForHospitalInfo_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

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

            public DateTime? XXXXXXyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HOSPITALINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Klinikyatistarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KLINIKYATISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Brans
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BRANS"]);
                }
            }

            public string Bransadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANSADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tibbiprotokolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TIBBIPROTOKOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedaviklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVIKLINIK"]);
                }
            }

            public string Tedaviklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Yattigiklinik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATTIGIKLINIK"]);
                }
            }

            public bool? Yogunbakim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YOGUNBAKIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["ISINTENSIVECARE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Yattigiklinikadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Istegiyapandoktor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ISTEGIYAPANDOKTOR"]);
                }
            }

            public string Istegiyapandoktoradi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEGIYAPANDOKTORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yattigiklinikkati
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIKKATI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["FLOOR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sorumludoktor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SORUMLUDOKTOR"]);
                }
            }

            public string Sorumludoktoradi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTORADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Oda
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ODA"]);
                }
            }

            public string Odaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Yatak
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["YATAK"]);
                }
            }

            public string Yatakadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAKADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientInfoForHospitalInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientInfoForHospitalInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientInfoForHospitalInfo_Class() : base() { }
        }

        public static class States
        {
            public static Guid Rejected { get { return new Guid("14578653-ccdb-4098-aa8c-3a0495d3c722"); } }
            public static Guid Discharged { get { return new Guid("4ac56537-0836-43ef-9e8b-40e49cf2d9fe"); } }
            public static Guid Acception { get { return new Guid("8e6c3495-3684-4406-a2ca-78f4ca29c505"); } }
            public static Guid Procedure { get { return new Guid("12a7a584-d7b8-46cd-b4bd-bd9f1626e677"); } }
            public static Guid Transferred { get { return new Guid("a6d08976-5cdf-41fd-8462-992dae13bb76"); } }
            public static Guid Cancelled { get { return new Guid("1f3dfa44-0cc6-4df9-8f44-9fd61178e788"); } }
    /// <summary>
    /// Kliniğe Kabul Etmeden önce kontrol ve onay vermek için
    /// </summary>
            public static Guid PreAcception { get { return new Guid("c2d84f9d-6f7d-4d5e-a9d0-9e6d74d1f59e"); } }
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetActiveByPhysicalStateClinic(TTObjectContext objectContext, Guid PHYSICALSTATECLINIC)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetActiveByPhysicalStateClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSICALSTATECLINIC", PHYSICALSTATECLINIC);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

    /// <summary>
    /// Yatan Hasta Listesi
    /// </summary>
        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class> GetInpatientListReportNQL(Guid PHYSICALSTATECLINIC, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSICALSTATECLINIC", PHYSICALSTATECLINIC);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Yatan Hasta Listesi
    /// </summary>
        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class> GetInpatientListReportNQL(TTObjectContext objectContext, Guid PHYSICALSTATECLINIC, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSICALSTATECLINIC", PHYSICALSTATECLINIC);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientStatistics_Class> GetInpatientStatistics(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientStatistics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientStatistics_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientStatistics_Class> GetInpatientStatistics(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientStatistics"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientStatistics_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate_Class> GetInpatientStatisticsByDate(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientStatisticsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate_Class> GetInpatientStatisticsByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientStatisticsByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetAllActiveInPatientTreatmentClinicApp(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetAllActiveInPatientTreatmentClinicApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetByEpisodeAndProcedureSpeciality(TTObjectContext objectContext, Guid EPISODE, Guid PROCEDURESPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetByEpisodeAndProcedureSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("PROCEDURESPECIALITY", PROCEDURESPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResourceReport_Class> GetByEpisodeAndMasterResourceReport(Guid EPISODE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetByEpisodeAndMasterResourceReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResourceReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResourceReport_Class> GetByEpisodeAndMasterResourceReport(TTObjectContext objectContext, Guid EPISODE, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetByEpisodeAndMasterResourceReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResourceReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetByEpisodeAndProcedureSpecialityASC(TTObjectContext objectContext, Guid PROCEDURESPECIALITY, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetByEpisodeAndProcedureSpecialityASC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROCEDURESPECIALITY", PROCEDURESPECIALITY);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

    /// <summary>
    /// Order By ını değiştirmeyiniz!
    /// </summary>
        public static BindingList<InPatientTreatmentClinicApplication> GetAllClinicDischargeDatesByEpisode(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetAllClinicDischargeDatesByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class> GetpatientListReportByDaysNQL(int INPATIENTDAYS, Guid PHYSICALSTATECLINIC, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetpatientListReportByDaysNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTDAYS", INPATIENTDAYS);
            paramList.Add("PHYSICALSTATECLINIC", PHYSICALSTATECLINIC);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class> GetpatientListReportByDaysNQL(TTObjectContext objectContext, int INPATIENTDAYS, Guid PHYSICALSTATECLINIC, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetpatientListReportByDaysNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTDAYS", INPATIENTDAYS);
            paramList.Add("PHYSICALSTATECLINIC", PHYSICALSTATECLINIC);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class> GetpatientListReportByInpatientDayNQL(Guid PHYSICALSTATECLINIC, DateTime STARTDATE, int INPATIENTDAYS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetpatientListReportByInpatientDayNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSICALSTATECLINIC", PHYSICALSTATECLINIC);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("INPATIENTDAYS", INPATIENTDAYS);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class> GetpatientListReportByInpatientDayNQL(TTObjectContext objectContext, Guid PHYSICALSTATECLINIC, DateTime STARTDATE, int INPATIENTDAYS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetpatientListReportByInpatientDayNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSICALSTATECLINIC", PHYSICALSTATECLINIC);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("INPATIENTDAYS", INPATIENTDAYS);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientByPatientGroup_Class> GetInpatientByPatientGroup(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientByPatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientByPatientGroup_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientByPatientGroup_Class> GetInpatientByPatientGroup(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientByPatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientByPatientGroup_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.OLAP_YatanHasta_Class> OLAP_YatanHasta(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["OLAP_YatanHasta"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.OLAP_YatanHasta_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.OLAP_YatanHasta_Class> OLAP_YatanHasta(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["OLAP_YatanHasta"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.OLAP_YatanHasta_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInPatientBeds_Class> GetInPatientBeds(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInPatientBeds"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInPatientBeds_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInPatientBeds_Class> GetInPatientBeds(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInPatientBeds"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInPatientBeds_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByDateNQL_Class> GetpatientListReportByDateNQL(Guid PHYSICALSTATECLINIC, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetpatientListReportByDateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSICALSTATECLINIC", PHYSICALSTATECLINIC);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetpatientListReportByDateNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByDateNQL_Class> GetpatientListReportByDateNQL(TTObjectContext objectContext, Guid PHYSICALSTATECLINIC, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetpatientListReportByDateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PHYSICALSTATECLINIC", PHYSICALSTATECLINIC);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetpatientListReportByDateNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientBedsByResWard_Class> GetInpatientBedsByResWard(Guid SELECTEDWARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientBedsByResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SELECTEDWARD", SELECTEDWARD);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientBedsByResWard_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientBedsByResWard_Class> GetInpatientBedsByResWard(TTObjectContext objectContext, Guid SELECTEDWARD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientBedsByResWard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SELECTEDWARD", SELECTEDWARD);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientBedsByResWard_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientInformation_RQ_Class> GetInpatientInformation_RQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientInformation_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientInformation_RQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientInformation_RQ_Class> GetInpatientInformation_RQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientInformation_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientInformation_RQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetJustInpatientStatistic_Class> GetJustInpatientStatistic(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetJustInpatientStatistic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetJustInpatientStatistic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetJustInpatientStatistic_Class> GetJustInpatientStatistic(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetJustInpatientStatistic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetJustInpatientStatistic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetByEpisodeAndMasterResource(TTObjectContext objectContext, Guid EPISODE, Guid MASTERRESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetByEpisodeAndMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource_Class> GetActiveInpatientTrtClinicAppByMasterResource(Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetActiveInpatientTrtClinicAppByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource_Class> GetActiveInpatientTrtClinicAppByMasterResource(TTObjectContext objectContext, Guid MASTERRESOURCE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetActiveInpatientTrtClinicAppByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MASTERRESOURCE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetBySubEpisodeAndProcedureSpeciality(TTObjectContext objectContext, Guid EPISODE, Guid SUBEPISODE, Guid PROCEDURESPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetBySubEpisodeAndProcedureSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("PROCEDURESPECIALITY", PROCEDURESPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInPatientInfoByPatients_Class> GetInPatientInfoByPatients(IList<Guid> PATIENTS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInPatientInfoByPatients"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTS", PATIENTS);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInPatientInfoByPatients_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInPatientInfoByPatients_Class> GetInPatientInfoByPatients(TTObjectContext objectContext, IList<Guid> PATIENTS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInPatientInfoByPatients"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTS", PATIENTS);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInPatientInfoByPatients_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetAllActiveByNurse(TTObjectContext objectContext, Guid ResponsibleNurse, Guid PhysicalStateClinic)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetAllActiveByNurse"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESPONSIBLENURSE", ResponsibleNurse);
            paramList.Add("PHYSICALSTATECLINIC", PhysicalStateClinic);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientAdmissionInfoByTreatmentClinic_Class> GetInpatientAdmissionInfoByTreatmentClinic(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientAdmissionInfoByTreatmentClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientAdmissionInfoByTreatmentClinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientAdmissionInfoByTreatmentClinic_Class> GetInpatientAdmissionInfoByTreatmentClinic(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientAdmissionInfoByTreatmentClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientAdmissionInfoByTreatmentClinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetAllActiveByTreatmentClinic(TTObjectContext objectContext, Guid TreatmentClinic)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetAllActiveByTreatmentClinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TREATMENTCLINIC", TreatmentClinic);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetLastActiveInPatientTreatmentClinicApp(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetLastActiveInPatientTreatmentClinicApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetByBaseInpatientAdmission(TTObjectContext objectContext, string BASEINPATIENTADMISSION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetByBaseInpatientAdmission"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BASEINPATIENTADMISSION", BASEINPATIENTADMISSION);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetLastActiveInPatientTreatClinicAppBySEProtocolNo(TTObjectContext objectContext, string SEPROTOCOLNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetLastActiveInPatientTreatClinicAppBySEProtocolNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEPROTOCOLNO", SEPROTOCOLNO);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetInPatientTreatClinicAppInAcceptionStateForWL(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInPatientTreatClinicAppInAcceptionStateForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetActiveInpatientTrtClinicAppByPatient(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetActiveInpatientTrtClinicAppByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetDailyInpatientTreatClinicAppForWL(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetDailyInpatientTreatClinicAppForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication> GetDailyAppForDischarge(TTObjectContext objectContext, DateTime TODAY, DateTime PAST)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetDailyAppForDischarge"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TODAY", TODAY);
            paramList.Add("PAST", PAST);

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetYatanHastaListesi_Class> GetYatanHastaListesi(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetYatanHastaListesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetYatanHastaListesi_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetYatanHastaListesi_Class> GetYatanHastaListesi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetYatanHastaListesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetYatanHastaListesi_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Uzun yada kısa yatış sebebi girilmiş hastalar
    /// </summary>
        public static BindingList<InPatientTreatmentClinicApplication> GetLongOrShortReasonPatient(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetLongOrShortReasonPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<InPatientTreatmentClinicApplication>(queryDef, paramList);
        }

    /// <summary>
    /// Yatış Bekliyor Durumunda Olan Hastalar
    /// </summary>
        public static BindingList<InPatientTreatmentClinicApplication.GetWaitingClinicAcceptionPatient_Class> GetWaitingClinicAcceptionPatient(Guid MasterResource, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetWaitingClinicAcceptionPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MasterResource);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetWaitingClinicAcceptionPatient_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Yatış Bekliyor Durumunda Olan Hastalar
    /// </summary>
        public static BindingList<InPatientTreatmentClinicApplication.GetWaitingClinicAcceptionPatient_Class> GetWaitingClinicAcceptionPatient(TTObjectContext objectContext, Guid MasterResource, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetWaitingClinicAcceptionPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCE", MasterResource);

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetWaitingClinicAcceptionPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientInfoForHospitalInfo_Class> GetInpatientInfoForHospitalInfo(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientInfoForHospitalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientInfoForHospitalInfo_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InPatientTreatmentClinicApplication.GetInpatientInfoForHospitalInfo_Class> GetInpatientInfoForHospitalInfo(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].QueryDefs["GetInpatientInfoForHospitalInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InPatientTreatmentClinicApplication.GetInpatientInfoForHospitalInfo_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Klinik Çıkış Tarihi
    /// </summary>
        public DateTime? ClinicDischargeDate
        {
            get { return (DateTime?)this["CLINICDISCHARGEDATE"]; }
            set { this["CLINICDISCHARGEDATE"] = value; }
        }

    /// <summary>
    /// Klinik Yatış Tarihi
    /// </summary>
        public DateTime? ClinicInpatientDate
        {
            get { return (DateTime?)this["CLINICINPATIENTDATE"]; }
            set { this["CLINICINPATIENTDATE"] = value; }
        }

    /// <summary>
    /// Klinik Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Ön taburcu sırasında medula hasta çıkışı yapılamadıysa true olur
    /// </summary>
        public bool? MedulaHastaCikisKayitFailed
        {
            get { return (bool?)this["MEDULAHASTACIKISKAYITFAILED"]; }
            set { this["MEDULAHASTACIKISKAYITFAILED"] = value; }
        }

    /// <summary>
    /// Günübirlik işlemleri kontrol etmek için
    /// </summary>
        public bool? IsDailyOperation
        {
            get { return (bool?)this["ISDAILYOPERATION"]; }
            set { this["ISDAILYOPERATION"] = value; }
        }

    /// <summary>
    /// Kısa Yatış Nedeni
    /// </summary>
        public string ShotInpatientReason
        {
            get { return (string)this["SHOTINPATIENTREASON"]; }
            set { this["SHOTINPATIENTREASON"] = value; }
        }

    /// <summary>
    /// Yatış bekleyen hasta tipi(transfer vb.)
    /// </summary>
        public InpatientAcceptionTypeEnum? InpatientAcceptionType
        {
            get { return (InpatientAcceptionTypeEnum?)(int?)this["INPATIENTACCEPTIONTYPE"]; }
            set { this["INPATIENTACCEPTIONTYPE"] = value; }
        }

    /// <summary>
    /// Uzun Yatış Nedeni
    /// </summary>
        public string LongInpatientReason
        {
            get { return (string)this["LONGINPATIENTREASON"]; }
            set { this["LONGINPATIENTREASON"] = value; }
        }

    /// <summary>
    /// Sorumlu Hemşire
    /// </summary>
        public ResUser ResponsibleNurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLENURSE"); }
            set { this["RESPONSIBLENURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseInpatientAdmission BaseInpatientAdmission
        {
            get { return (BaseInpatientAdmission)((ITTObject)this).GetParent("BASEINPATIENTADMISSION"); }
            set { this["BASEINPATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public TreatmentDischarge TreatmentDischarge
        {
            get { return (TreatmentDischarge)((ITTObject)this).GetParent("TREATMENTDISCHARGE"); }
            set { this["TREATMENTDISCHARGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication FromInPatientTrtmentClinicApp
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("FROMINPATIENTTRTMENTCLINICAPP"); }
            set { this["FROMINPATIENTTRTMENTCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNursingApplicationsCollection()
        {
            _NursingApplications = new NursingApplication.ChildNursingApplicationCollection(this, new Guid("100310ce-8dea-4e64-892b-1516edcf7554"));
            ((ITTChildObjectCollection)_NursingApplications).GetChildren();
        }

        protected NursingApplication.ChildNursingApplicationCollection _NursingApplications = null;
        public NursingApplication.ChildNursingApplicationCollection NursingApplications
        {
            get
            {
                if (_NursingApplications == null)
                    CreateNursingApplicationsCollection();
                return _NursingApplications;
            }
        }

        virtual protected void CreateResponsibleNursesCollection()
        {
            _ResponsibleNurses = new InpatientResponsibleNurse.ChildInpatientResponsibleNurseCollection(this, new Guid("a136a2d1-844a-4e77-a797-7cfc4f89cd73"));
            ((ITTChildObjectCollection)_ResponsibleNurses).GetChildren();
        }

        protected InpatientResponsibleNurse.ChildInpatientResponsibleNurseCollection _ResponsibleNurses = null;
        public InpatientResponsibleNurse.ChildInpatientResponsibleNurseCollection ResponsibleNurses
        {
            get
            {
                if (_ResponsibleNurses == null)
                    CreateResponsibleNursesCollection();
                return _ResponsibleNurses;
            }
        }

        virtual protected void CreateResponsibleDoctorsCollection()
        {
            _ResponsibleDoctors = new InpatientResponsibleDoctor.ChildInpatientResponsibleDoctorCollection(this, new Guid("4ebe7d4c-742c-48e2-a023-617545b04247"));
            ((ITTChildObjectCollection)_ResponsibleDoctors).GetChildren();
        }

        protected InpatientResponsibleDoctor.ChildInpatientResponsibleDoctorCollection _ResponsibleDoctors = null;
        public InpatientResponsibleDoctor.ChildInpatientResponsibleDoctorCollection ResponsibleDoctors
        {
            get
            {
                if (_ResponsibleDoctors == null)
                    CreateResponsibleDoctorsCollection();
                return _ResponsibleDoctors;
            }
        }

        virtual protected void CreateInPatientPhysicianApplicationCollection()
        {
            _InPatientPhysicianApplication = new InPatientPhysicianApplication.ChildInPatientPhysicianApplicationCollection(this, new Guid("05676969-497c-4899-929e-b48aab5bac6e"));
            ((ITTChildObjectCollection)_InPatientPhysicianApplication).GetChildren();
        }

        protected InPatientPhysicianApplication.ChildInPatientPhysicianApplicationCollection _InPatientPhysicianApplication = null;
        public InPatientPhysicianApplication.ChildInPatientPhysicianApplicationCollection InPatientPhysicianApplication
        {
            get
            {
                if (_InPatientPhysicianApplication == null)
                    CreateInPatientPhysicianApplicationCollection();
                return _InPatientPhysicianApplication;
            }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("9c8bf640-1396-47e6-9177-b88d481017dc"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        virtual protected void CreateToInPatientTrtmentClinicAppCollection()
        {
            _ToInPatientTrtmentClinicApp = new InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection(this, new Guid("64b8f42c-fd51-421f-bfb5-d1a41ded9c9f"));
            ((ITTChildObjectCollection)_ToInPatientTrtmentClinicApp).GetChildren();
        }

        protected InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection _ToInPatientTrtmentClinicApp = null;
        public InPatientTreatmentClinicApplication.ChildInPatientTreatmentClinicApplicationCollection ToInPatientTrtmentClinicApp
        {
            get
            {
                if (_ToInPatientTrtmentClinicApp == null)
                    CreateToInPatientTrtmentClinicAppCollection();
                return _ToInPatientTrtmentClinicApp;
            }
        }

        virtual protected void CreateInpatientAppointmentsCollection()
        {
            _InpatientAppointments = new InpatientAppointment.ChildInpatientAppointmentCollection(this, new Guid("dc02992c-314d-4c6f-9bae-1deb8a82844c"));
            ((ITTChildObjectCollection)_InpatientAppointments).GetChildren();
        }

        protected InpatientAppointment.ChildInpatientAppointmentCollection _InpatientAppointments = null;
    /// <summary>
    /// Child collection for Randveu başlatan episodeaction
    /// </summary>
        public InpatientAppointment.ChildInpatientAppointmentCollection InpatientAppointments
        {
            get
            {
                if (_InpatientAppointments == null)
                    CreateInpatientAppointmentsCollection();
                return _InpatientAppointments;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _BaseBedProcedures = new BaseBedProcedure.ChildBaseBedProcedureCollection(_SubactionProcedures, "BaseBedProcedures");
            _Bedprocedures = new BedProcedure.ChildBedProcedureCollection(_SubactionProcedures, "Bedprocedures");
        }

        private BaseBedProcedure.ChildBaseBedProcedureCollection _BaseBedProcedures = null;
        public BaseBedProcedure.ChildBaseBedProcedureCollection BaseBedProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _BaseBedProcedures;
            }            
        }

        private BedProcedure.ChildBedProcedureCollection _Bedprocedures = null;
        public BedProcedure.ChildBedProcedureCollection Bedprocedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _Bedprocedures;
            }            
        }

        override protected void CreateLinkedActionsCollectionViews()
        {
            base.CreateLinkedActionsCollectionViews();
            _CompanionApplications = new CompanionApplication.ChildCompanionApplicationCollection(_LinkedActions, "CompanionApplications");
        }

        private CompanionApplication.ChildCompanionApplicationCollection _CompanionApplications = null;
        public CompanionApplication.ChildCompanionApplicationCollection CompanionApplications
        {
            get
            {
                if (_LinkedActions == null)
                    CreateLinkedActionsCollection();
                return _CompanionApplications;
            }            
        }

        protected InPatientTreatmentClinicApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InPatientTreatmentClinicApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InPatientTreatmentClinicApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InPatientTreatmentClinicApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InPatientTreatmentClinicApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTTREATMENTCLINICAPPLICATION", dataRow) { }
        protected InPatientTreatmentClinicApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTTREATMENTCLINICAPPLICATION", dataRow, isImported) { }
        public InPatientTreatmentClinicApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InPatientTreatmentClinicApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InPatientTreatmentClinicApplication() : base() { }

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