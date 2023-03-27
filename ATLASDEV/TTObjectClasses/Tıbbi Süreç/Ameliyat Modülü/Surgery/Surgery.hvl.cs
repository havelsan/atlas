
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Surgery")] 

    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
    public  partial class Surgery : EpisodeActionWithDiagnosis, IAppointmentWithoutResources, IWorkListEpisodeAction, ITreatmentMaterialCollection, ICreateSubEpisode, IStockOutCancel
    {
        public class SurgeryList : TTObjectCollection<Surgery> { }
                    
        public class ChildSurgeryCollection : TTObject.TTChildObjectCollection<Surgery>
        {
            public ChildSurgeryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetSurgeryByDate_Class : TTReportNqlObject 
        {
            public Guid? Surgeryid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SURGERYID"]);
                }
            }

            public AnesthesiaTechniqueEnum? AnesthesiaTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIATECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIATECHNIQUE"].DataType;
                    return (AnesthesiaTechniqueEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Subsurgeryid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBSURGERYID"]);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Guid? Department
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPARTMENT"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
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

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetSurgeryByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgeryByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgeryByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSurgery10Day_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public OLAP_GetSurgery10Day_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgery10Day_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgery10Day_Class() : base() { }
        }

        [Serializable] 

        public partial class SurgeryReportNQL_Class : TTReportNqlObject 
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

            public object SurgeryReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYREPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYREPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? SurgeryReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYREPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Anesthesiaandreanimation
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ANESTHESIAANDREANIMATION"]);
                }
            }

            public AnesthesiaASATypeEnum? ASAType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASATYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ASATYPE"].DataType;
                    return (AnesthesiaASATypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public AnesthesiaTechniqueEnum? AnesthesiaTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIATECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIATECHNIQUE"].DataType;
                    return (AnesthesiaTechniqueEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string DiplomaNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EmploymentRecordID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
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

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SurgeryReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SurgeryReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SurgeryReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class SurgeryPatientByDateNQL_Class : TTReportNqlObject 
        {
            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
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

            public DateTime? Hastadogumtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTADOGUMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
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

            public string Ameliyathane
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYATHANE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Istekbirim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEKBIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Ameliyatsalonu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["AMELIYATSALONU"]);
                }
            }

            public Guid? Ameliyatmasasi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["AMELIYATMASASI"]);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["NOTESTOANESTHESIA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SurgeryPatientByDateNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SurgeryPatientByDateNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SurgeryPatientByDateNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class DirectPurchaseExpenditureInfoNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Sutisim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Miktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["CERTAINAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Olcubirimi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OLCUBIRIMI"]);
                }
            }

            public Guid? Ubb
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["UBB"]);
                }
            }

            public DirectPurchaseExpenditureInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DirectPurchaseExpenditureInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DirectPurchaseExpenditureInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class SurgeryCountQuery_Class : TTReportNqlObject 
        {
            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
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

            public Object Sayi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SAYI"]);
                }
            }

            public SurgeryCountQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SurgeryCountQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SurgeryCountQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class InCompleteSurgeryPatientListNQL_Class : TTReportNqlObject 
        {
            public long? Tckimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

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

            public DateTime? Planlanantarih
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANLANANTARIH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["PLANNEDSURGERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
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

            public long? XXXXXXprotno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXPROTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public InCompleteSurgeryPatientListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InCompleteSurgeryPatientListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InCompleteSurgeryPatientListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryByPlannedSurgeryDate_Class : TTReportNqlObject 
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

            public object SurgeryReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYREPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYREPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? SurgeryReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYREPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DiplomaNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EmploymentRecordID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
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

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryByPlannedSurgeryDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryByPlannedSurgeryDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryByPlannedSurgeryDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryForWL_Class : TTReportNqlObject 
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

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PlannedSurgeryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDSURGERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["PLANNEDSURGERYDATE"].DataType;
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

            public string Surgerystatusdefinitionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTATUSDEFINITIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgerydepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Inpatientclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgeryroom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgerydesk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDESK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Operator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPERATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Anesthesist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIST"]);
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

            public string Oncelikdurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONCELIKDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryForWL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryByStatusDefinitionDate_Class : TTReportNqlObject 
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

            public string Surgerystatusdefinitionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTATUSDEFINITIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryStatusDefinitionTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTATUSDEFINITIONTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTATUSDEFINITIONTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryByStatusDefinitionDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryByStatusDefinitionDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryByStatusDefinitionDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryListForChecklist_Class : TTReportNqlObject 
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryListForChecklist_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryListForChecklist_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryListForChecklist_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryByMasterAction_Class : TTReportNqlObject 
        {
            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Checklist
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CHECKLIST"]);
                }
            }

            public GetSurgeryByMasterAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryByMasterAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryByMasterAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryInfoByMasterAction_Class : TTReportNqlObject 
        {
            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Checklist
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CHECKLIST"]);
                }
            }

            public GetSurgeryInfoByMasterAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryInfoByMasterAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryInfoByMasterAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSurgeryInfoByID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Room
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masa
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SurgeryEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PlannedSurgeryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDSURGERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["PLANNEDSURGERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ComplicationDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLICATIONDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["COMPLICATIONDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsComplicationSurgery
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCOMPLICATIONSURGERY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["ISCOMPLICATIONSURGERY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object SurgeryReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
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

            public GetSurgeryInfoByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryInfoByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryInfoByID_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("d2b53a15-6bdb-407b-bb89-56343f7fdb4e"); } }
            public static Guid Rejected { get { return new Guid("76a2b0a5-c43f-450e-98f8-9e335fc61b96"); } }
            public static Guid Completed { get { return new Guid("bf4c0a89-9836-4459-8406-34d0f8cc4d23"); } }
            public static Guid Surgery { get { return new Guid("89e3ed82-f797-41ec-aa86-a22b7cb3b169"); } }
            public static Guid WaitingForSubSurgeries { get { return new Guid("41f8373b-d53a-453f-8c64-cba3f7ba1d65"); } }
            public static Guid SurgeryRequest { get { return new Guid("e8995933-3381-4409-8b7c-95c00f1a52d0"); } }
        }

        public static BindingList<Surgery.OLAP_GetSurgeryByDate_Class> OLAP_GetSurgeryByDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["OLAP_GetSurgeryByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Surgery.OLAP_GetSurgeryByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Surgery.OLAP_GetSurgeryByDate_Class> OLAP_GetSurgeryByDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["OLAP_GetSurgeryByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Surgery.OLAP_GetSurgeryByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Surgery.OLAP_GetSurgery10Day_Class> OLAP_GetSurgery10Day(string EID, DateTime DEATHTIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["OLAP_GetSurgery10Day"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);
            paramList.Add("DEATHTIME", DEATHTIME);

            return TTReportNqlObject.QueryObjects<Surgery.OLAP_GetSurgery10Day_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Surgery.OLAP_GetSurgery10Day_Class> OLAP_GetSurgery10Day(TTObjectContext objectContext, string EID, DateTime DEATHTIME, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["OLAP_GetSurgery10Day"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EID", EID);
            paramList.Add("DEATHTIME", DEATHTIME);

            return TTReportNqlObject.QueryObjects<Surgery.OLAP_GetSurgery10Day_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Surgery.SurgeryReportNQL_Class> SurgeryReportNQL(string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["SurgeryReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<Surgery.SurgeryReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Surgery.SurgeryReportNQL_Class> SurgeryReportNQL(TTObjectContext objectContext, string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["SurgeryReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<Surgery.SurgeryReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Surgery.SurgeryPatientByDateNQL_Class> SurgeryPatientByDateNQL(DateTime STARTDATE, DateTime ENDDATE, Guid SURGERYROOM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["SurgeryPatientByDateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SURGERYROOM", SURGERYROOM);

            return TTReportNqlObject.QueryObjects<Surgery.SurgeryPatientByDateNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Surgery.SurgeryPatientByDateNQL_Class> SurgeryPatientByDateNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid SURGERYROOM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["SurgeryPatientByDateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SURGERYROOM", SURGERYROOM);

            return TTReportNqlObject.QueryObjects<Surgery.SurgeryPatientByDateNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Surgery> GetByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<Surgery>(queryDef, paramList);
        }

    /// <summary>
    /// 22F Sarf Malzeme Listesi
    /// </summary>
        public static BindingList<Surgery.DirectPurchaseExpenditureInfoNQL_Class> DirectPurchaseExpenditureInfoNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["DirectPurchaseExpenditureInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<Surgery.DirectPurchaseExpenditureInfoNQL_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// 22F Sarf Malzeme Listesi
    /// </summary>
        public static BindingList<Surgery.DirectPurchaseExpenditureInfoNQL_Class> DirectPurchaseExpenditureInfoNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["DirectPurchaseExpenditureInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<Surgery.DirectPurchaseExpenditureInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Surgery.SurgeryCountQuery_Class> SurgeryCountQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["SurgeryCountQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Surgery.SurgeryCountQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Surgery.SurgeryCountQuery_Class> SurgeryCountQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["SurgeryCountQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Surgery.SurgeryCountQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Surgery.InCompleteSurgeryPatientListNQL_Class> InCompleteSurgeryPatientListNQL(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["InCompleteSurgeryPatientListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<Surgery.InCompleteSurgeryPatientListNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Surgery.InCompleteSurgeryPatientListNQL_Class> InCompleteSurgeryPatientListNQL(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["InCompleteSurgeryPatientListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<Surgery.InCompleteSurgeryPatientListNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Surgery.GetSurgeryByPlannedSurgeryDate_Class> GetSurgeryByPlannedSurgeryDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryByPlannedSurgeryDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryByPlannedSurgeryDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Surgery.GetSurgeryByPlannedSurgeryDate_Class> GetSurgeryByPlannedSurgeryDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryByPlannedSurgeryDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryByPlannedSurgeryDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Surgery.GetSurgeryForWL_Class> GetSurgeryForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Surgery.GetSurgeryForWL_Class> GetSurgeryForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Surgery.GetSurgeryByStatusDefinitionDate_Class> GetSurgeryByStatusDefinitionDate(DateTime StartDate, DateTime EndDate, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryByStatusDefinitionDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", StartDate);
            paramList.Add("ENDDATE", EndDate);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryByStatusDefinitionDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Surgery.GetSurgeryByStatusDefinitionDate_Class> GetSurgeryByStatusDefinitionDate(TTObjectContext objectContext, DateTime StartDate, DateTime EndDate, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryByStatusDefinitionDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", StartDate);
            paramList.Add("ENDDATE", EndDate);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryByStatusDefinitionDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Surgery.GetSurgeryListForChecklist_Class> GetSurgeryListForChecklist(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryListForChecklist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryListForChecklist_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Surgery.GetSurgeryListForChecklist_Class> GetSurgeryListForChecklist(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryListForChecklist"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryListForChecklist_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Surgery.GetSurgeryByMasterAction_Class> GetSurgeryByMasterAction(Guid MASTERACTIONID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONID", MASTERACTIONID);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryByMasterAction_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Surgery.GetSurgeryByMasterAction_Class> GetSurgeryByMasterAction(TTObjectContext objectContext, Guid MASTERACTIONID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONID", MASTERACTIONID);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryByMasterAction_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Surgery> GetUnreportedSurgeryList(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetUnreportedSurgeryList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Surgery>(queryDef, paramList);
        }

        public static BindingList<Surgery.GetSurgeryInfoByMasterAction_Class> GetSurgeryInfoByMasterAction(Guid MASTERACTIONID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryInfoByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONID", MASTERACTIONID);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryInfoByMasterAction_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Surgery.GetSurgeryInfoByMasterAction_Class> GetSurgeryInfoByMasterAction(TTObjectContext objectContext, Guid MASTERACTIONID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryInfoByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTIONID", MASTERACTIONID);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryInfoByMasterAction_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Surgery.GetSurgeryInfoByID_Class> GetSurgeryInfoByID(string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryInfoByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryInfoByID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Surgery.GetSurgeryInfoByID_Class> GetSurgeryInfoByID(TTObjectContext objectContext, string SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].QueryDefs["GetSurgeryInfoByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<Surgery.GetSurgeryInfoByID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Anestezi Puanı
    /// </summary>
        public double? SurgeryAnesthesiaPoint
        {
            get { return (double?)this["SURGERYANESTHESIAPOINT"]; }
            set { this["SURGERYANESTHESIAPOINT"] = value; }
        }

    /// <summary>
    /// Ameliyatı Sonlandırma Tarih/Saat
    /// </summary>
        public DateTime? SurgeryEndTime
        {
            get { return (DateTime?)this["SURGERYENDTIME"]; }
            set { this["SURGERYENDTIME"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Sorumlu Doktora İade Sebebi
    /// </summary>
        public string ReturnToDoctorReason
        {
            get { return (string)this["RETURNTODOCTORREASON"]; }
            set { this["RETURNTODOCTORREASON"] = value; }
        }

    /// <summary>
    /// Ön Hazırlık İçin Direktifler
    /// </summary>
        public object DescriptionToPreOp
        {
            get { return (object)this["DESCRIPTIONTOPREOP"]; }
            set { this["DESCRIPTIONTOPREOP"] = value; }
        }

    /// <summary>
    /// Ön Hazırlık Açıklamaları
    /// </summary>
        public string PreOpDescriptions
        {
            get { return (string)this["PREOPDESCRIPTIONS"]; }
            set { this["PREOPDESCRIPTIONS"] = value; }
        }

    /// <summary>
    /// Ameliyat Raporu
    /// </summary>
        public object SurgeryReport
        {
            get { return (object)this["SURGERYREPORT"]; }
            set { this["SURGERYREPORT"] = value; }
        }

        public TTSequence SurgeryReportNo
        {
            get { return GetSequence("SURGERYREPORTNO"); }
        }

    /// <summary>
    /// Ameliyatı Başlatma Tarih/Saat
    /// </summary>
        public DateTime? SurgeryStartTime
        {
            get { return (DateTime?)this["SURGERYSTARTTIME"]; }
            set { this["SURGERYSTARTTIME"] = value; }
        }

    /// <summary>
    /// Anestezi Bölümü İçin Açıklamalar
    /// </summary>
        public string NotesToAnesthesia
        {
            get { return (string)this["NOTESTOANESTHESIA"]; }
            set { this["NOTESTOANESTHESIA"] = value; }
        }

    /// <summary>
    /// Planlanan Ameliyat Tarihi
    /// </summary>
        public DateTime? PlannedSurgeryDate
        {
            get { return (DateTime?)this["PLANNEDSURGERYDATE"]; }
            set { this["PLANNEDSURGERYDATE"] = value; }
        }

    /// <summary>
    /// Toplam Puan
    /// </summary>
        public double? SurgeryTotalPoint
        {
            get { return (double?)this["SURGERYTOTALPOINT"]; }
            set { this["SURGERYTOTALPOINT"] = value; }
        }

        public DateTime? SurgeryReportDate
        {
            get { return (DateTime?)this["SURGERYREPORTDATE"]; }
            set { this["SURGERYREPORTDATE"] = value; }
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
    /// Ameliyat Şablonu
    /// </summary>
        public bool? SurgeryTemplate
        {
            get { return (bool?)this["SURGERYTEMPLATE"]; }
            set { this["SURGERYTEMPLATE"] = value; }
        }

    /// <summary>
    /// Medula Açıklaması
    /// </summary>
        public string MedulaAciklamasi
        {
            get { return (string)this["MEDULAACIKLAMASI"]; }
            set { this["MEDULAACIKLAMASI"] = value; }
        }

        public bool? IsNeedAnesthesia
        {
            get { return (bool?)this["ISNEEDANESTHESIA"]; }
            set { this["ISNEEDANESTHESIA"] = value; }
        }

        public bool? IsComplicationSurgery
        {
            get { return (bool?)this["ISCOMPLICATIONSURGERY"]; }
            set { this["ISCOMPLICATIONSURGERY"] = value; }
        }

        public string ComplicationDescription
        {
            get { return (string)this["COMPLICATIONDESCRIPTION"]; }
            set { this["COMPLICATIONDESCRIPTION"] = value; }
        }

        public string PlannedSurgeryDescription
        {
            get { return (string)this["PLANNEDSURGERYDESCRIPTION"]; }
            set { this["PLANNEDSURGERYDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Mesai Durumu
    /// </summary>
        public SurgeryShiftEnum? SurgeryShift
        {
            get { return (SurgeryShiftEnum?)(int?)this["SURGERYSHIFT"]; }
            set { this["SURGERYSHIFT"] = value; }
        }

    /// <summary>
    /// Ameliyat Durumu
    /// </summary>
        public SurgeryStatusEnum? SurgeryStatus
        {
            get { return (SurgeryStatusEnum?)(int?)this["SURGERYSTATUS"]; }
            set { this["SURGERYSTATUS"] = value; }
        }

    /// <summary>
    /// true ise ertelenen ameliyat
    /// </summary>
        public bool? IsDelayedSurgery
        {
            get { return (bool?)this["ISDELAYEDSURGERY"]; }
            set { this["ISDELAYEDSURGERY"] = value; }
        }

    /// <summary>
    /// Ameliyat Süreci Durumu Güncelleme Zamanı
    /// </summary>
        public DateTime? SurgeryStatusDefinitionTime
        {
            get { return (DateTime?)this["SURGERYSTATUSDEFINITIONTIME"]; }
            set { this["SURGERYSTATUSDEFINITIONTIME"] = value; }
        }

    /// <summary>
    /// Ameliyat Tipi
    /// </summary>
        public SurgeryPointGroupEnum? SurgeryPointGroup
        {
            get { return (SurgeryPointGroupEnum?)(int?)this["SURGERYPOINTGROUP"]; }
            set { this["SURGERYPOINTGROUP"] = value; }
        }

    /// <summary>
    /// Anestezi ve Reanimasyon İşlemi
    /// </summary>
        public AnesthesiaAndReanimation AnesthesiaAndReanimation
        {
            get { return (AnesthesiaAndReanimation)((ITTObject)this).GetParent("ANESTHESIAANDREANIMATION"); }
            set { this["ANESTHESIAANDREANIMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ameliyat Salonu
    /// </summary>
        public ResSurgeryRoom SurgeryRoom
        {
            get { return (ResSurgeryRoom)((ITTObject)this).GetParent("SURGERYROOM"); }
            set { this["SURGERYROOM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ameliyat Masası
    /// </summary>
        public ResSurgeryDesk SurgeryDesk
        {
            get { return (ResSurgeryDesk)((ITTObject)this).GetParent("SURGERYDESK"); }
            set { this["SURGERYDESK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SurgeryExtension SurgeryExtension
        {
            get { return (SurgeryExtension)((ITTObject)this).GetParent("SURGERYEXTENSION"); }
            set { this["SURGERYEXTENSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Robson Grubu
    /// </summary>
        public SurgeryRobsonDefinition SurgeryRobson
        {
            get { return (SurgeryRobsonDefinition)((ITTObject)this).GetParent("SURGERYROBSON"); }
            set { this["SURGERYROBSON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ameliyat Sonucu
    /// </summary>
        public SurgeryResultDefinition SurgeryResult
        {
            get { return (SurgeryResultDefinition)((ITTObject)this).GetParent("SURGERYRESULT"); }
            set { this["SURGERYRESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Güvenli Cerrahi Kontrol Listesi
    /// </summary>
        public SafeSurgeryCheckList SafeSurgeryCheckList
        {
            get { return (SafeSurgeryCheckList)((ITTObject)this).GetParent("SAFESURGERYCHECKLIST"); }
            set { this["SAFESURGERYCHECKLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ameliyat Ret Sebebi
    /// </summary>
        public SurgeryRejectReason SurgeryRejectReason
        {
            get { return (SurgeryRejectReason)((ITTObject)this).GetParent("SURGERYREJECTREASON"); }
            set { this["SURGERYREJECTREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ameliyat Durumu
    /// </summary>
        public SurgeryStatusDefinition SurgeryStatusDefinition
        {
            get { return (SurgeryStatusDefinition)((ITTObject)this).GetParent("SURGERYSTATUSDEFINITION"); }
            set { this["SURGERYSTATUSDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSurgeryPackageProceduresCollection()
        {
            _SurgeryPackageProcedures = new SurgeryPackageProcedure.ChildSurgeryPackageProcedureCollection(this, new Guid("da439565-d036-4aa7-b631-20bced4d6604"));
            ((ITTChildObjectCollection)_SurgeryPackageProcedures).GetChildren();
        }

        protected SurgeryPackageProcedure.ChildSurgeryPackageProcedureCollection _SurgeryPackageProcedures = null;
        public SurgeryPackageProcedure.ChildSurgeryPackageProcedureCollection SurgeryPackageProcedures
        {
            get
            {
                if (_SurgeryPackageProcedures == null)
                    CreateSurgeryPackageProceduresCollection();
                return _SurgeryPackageProcedures;
            }
        }

        virtual protected void CreateSubSurgeriesCollection()
        {
            _SubSurgeries = new SubSurgery.ChildSubSurgeryCollection(this, new Guid("7680264f-2f77-44c0-a681-0a4e9838e188"));
            ((ITTChildObjectCollection)_SubSurgeries).GetChildren();
        }

        protected SubSurgery.ChildSubSurgeryCollection _SubSurgeries = null;
        public SubSurgery.ChildSubSurgeryCollection SubSurgeries
        {
            get
            {
                if (_SubSurgeries == null)
                    CreateSubSurgeriesCollection();
                return _SubSurgeries;
            }
        }

        virtual protected void CreateParticipantDepartmantsCollection()
        {
            _ParticipantDepartmants = new SurgeryParticipantDepartment.ChildSurgeryParticipantDepartmentCollection(this, new Guid("e2c794eb-858b-4bdf-93df-29290771670e"));
            ((ITTChildObjectCollection)_ParticipantDepartmants).GetChildren();
        }

        protected SurgeryParticipantDepartment.ChildSurgeryParticipantDepartmentCollection _ParticipantDepartmants = null;
        public SurgeryParticipantDepartment.ChildSurgeryParticipantDepartmentCollection ParticipantDepartmants
        {
            get
            {
                if (_ParticipantDepartmants == null)
                    CreateParticipantDepartmantsCollection();
                return _ParticipantDepartmants;
            }
        }

        virtual protected void CreateIntensiveCareAfterSurgeriesCollection()
        {
            _IntensiveCareAfterSurgeries = new IntensiveCareAfterSurgery.ChildIntensiveCareAfterSurgeryCollection(this, new Guid("bc5a4135-3725-4f44-986e-3f18f88c6ff2"));
            ((ITTChildObjectCollection)_IntensiveCareAfterSurgeries).GetChildren();
        }

        protected IntensiveCareAfterSurgery.ChildIntensiveCareAfterSurgeryCollection _IntensiveCareAfterSurgeries = null;
        public IntensiveCareAfterSurgery.ChildIntensiveCareAfterSurgeryCollection IntensiveCareAfterSurgeries
        {
            get
            {
                if (_IntensiveCareAfterSurgeries == null)
                    CreateIntensiveCareAfterSurgeriesCollection();
                return _IntensiveCareAfterSurgeries;
            }
        }

        virtual protected void CreateMainSurgeryProceduresCollection()
        {
            _MainSurgeryProcedures = new MainSurgeryProcedure.ChildMainSurgeryProcedureCollection(this, new Guid("ad7680ba-c712-41d5-bf45-298695c1de81"));
            ((ITTChildObjectCollection)_MainSurgeryProcedures).GetChildren();
        }

        protected MainSurgeryProcedure.ChildMainSurgeryProcedureCollection _MainSurgeryProcedures = null;
        public MainSurgeryProcedure.ChildMainSurgeryProcedureCollection MainSurgeryProcedures
        {
            get
            {
                if (_MainSurgeryProcedures == null)
                    CreateMainSurgeryProceduresCollection();
                return _MainSurgeryProcedures;
            }
        }

        virtual protected void CreateAllSurgeryPersonnelsCollection()
        {
            _AllSurgeryPersonnels = new SurgeryPersonnel.ChildSurgeryPersonnelCollection(this, new Guid("2df4ae0a-8ce8-496c-80c2-7a5f11270be8"));
            ((ITTChildObjectCollection)_AllSurgeryPersonnels).GetChildren();
        }

        protected SurgeryPersonnel.ChildSurgeryPersonnelCollection _AllSurgeryPersonnels = null;
    /// <summary>
    /// Child collection for Ameliyat Ekibi Sekmesi
    /// </summary>
        public SurgeryPersonnel.ChildSurgeryPersonnelCollection AllSurgeryPersonnels
        {
            get
            {
                if (_AllSurgeryPersonnels == null)
                    CreateAllSurgeryPersonnelsCollection();
                return _AllSurgeryPersonnels;
            }
        }

        virtual protected void CreateKvcRiskScoresCollection()
        {
            _KvcRiskScores = new KvcRiskScore.ChildKvcRiskScoreCollection(this, new Guid("c942d859-24cd-4028-9957-15156590f0b0"));
            ((ITTChildObjectCollection)_KvcRiskScores).GetChildren();
        }

        protected KvcRiskScore.ChildKvcRiskScoreCollection _KvcRiskScores = null;
        public KvcRiskScore.ChildKvcRiskScoreCollection KvcRiskScores
        {
            get
            {
                if (_KvcRiskScores == null)
                    CreateKvcRiskScoresCollection();
                return _KvcRiskScores;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _SurgeryProcedures = new SurgeryProcedure.ChildSurgeryProcedureCollection(_SubactionProcedures, "SurgeryProcedures");
            _SurgeryNewBornProcedures = new SurgeryNewBornProcedure.ChildSurgeryNewBornProcedureCollection(_SubactionProcedures, "SurgeryNewBornProcedures");
        }

        private SurgeryProcedure.ChildSurgeryProcedureCollection _SurgeryProcedures = null;
        public SurgeryProcedure.ChildSurgeryProcedureCollection SurgeryProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _SurgeryProcedures;
            }            
        }

        private SurgeryNewBornProcedure.ChildSurgeryNewBornProcedureCollection _SurgeryNewBornProcedures = null;
        public SurgeryNewBornProcedure.ChildSurgeryNewBornProcedureCollection SurgeryNewBornProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _SurgeryNewBornProcedures;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _SurgeryExpends = new SurgeryExpend.ChildSurgeryExpendCollection(_TreatmentMaterials, "SurgeryExpends");
            _SurgeryDirectPurchaseGrids = new SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection(_TreatmentMaterials, "SurgeryDirectPurchaseGrids");
            _Surgery_CodelessMaterialDirectPurchaseGrids = new CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection(_TreatmentMaterials, "Surgery_CodelessMaterialDirectPurchaseGrids");
        }

        private SurgeryExpend.ChildSurgeryExpendCollection _SurgeryExpends = null;
        public SurgeryExpend.ChildSurgeryExpendCollection SurgeryExpends
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _SurgeryExpends;
            }            
        }

        private SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection _SurgeryDirectPurchaseGrids = null;
        public SurgeryDirectPurchaseGrid.ChildSurgeryDirectPurchaseGridCollection SurgeryDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _SurgeryDirectPurchaseGrids;
            }            
        }

        private CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection _Surgery_CodelessMaterialDirectPurchaseGrids = null;
        public CodelessMaterialDirectPurchaseGrid.ChildCodelessMaterialDirectPurchaseGridCollection Surgery_CodelessMaterialDirectPurchaseGrids
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _Surgery_CodelessMaterialDirectPurchaseGrids;
            }            
        }

        protected Surgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Surgery(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Surgery(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Surgery(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Surgery(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERY", dataRow) { }
        protected Surgery(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERY", dataRow, isImported) { }
        public Surgery(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Surgery(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Surgery() : base() { }

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