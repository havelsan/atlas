
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugOrder")] 

    /// <summary>
    /// İlaç Direktifi
    /// </summary>
    public  partial class DrugOrder : BaseDrugOrder
    {
        public class DrugOrderList : TTObjectCollection<DrugOrder> { }
                    
        public class ChildDrugOrderCollection : TTObject.TTChildObjectCollection<DrugOrder>
        {
            public ChildDrugOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAllDrugsWithDetailForDoctorReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetAllDrugsWithDetailForDoctorReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllDrugsWithDetailForDoctorReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllDrugsWithDetailForDoctorReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugsFromPharmacyReportQuery_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public GetDrugsFromPharmacyReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsFromPharmacyReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsFromPharmacyReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugsToPatientWithPrescriptionReportQuery_Class : TTReportNqlObject 
        {
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugsToPatientWithPrescriptionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsToPatientWithPrescriptionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsToPatientWithPrescriptionReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllDrugsForPatientGroupsReportQuery_Class : TTReportNqlObject 
        {
            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetAllDrugsForPatientGroupsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllDrugsForPatientGroupsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllDrugsForPatientGroupsReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugsExceededMaxPackageAmountReportQuery_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Day
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? PackageAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALBARCODELEVEL"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetDrugsExceededMaxPackageAmountReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsExceededMaxPackageAmountReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsExceededMaxPackageAmountReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugsToPatientsForEpisodeReportQuery_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetDrugsToPatientsForEpisodeReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsToPatientsForEpisodeReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsToPatientsForEpisodeReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugsToPatientsForDateReportQuery_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetDrugsToPatientsForDateReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsToPatientsForDateReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsToPatientsForDateReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetDrugOrder_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? PlannedStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
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

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public Guid? ProcedureDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDOCTOR"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public int? Day
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetDrugOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDrugOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDrugOrder_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledDrugOrder_Class : TTReportNqlObject 
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

            public OLAP_GetCancelledDrugOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledDrugOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledDrugOrder_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForDrugOrder_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? Drugappdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGAPPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requested
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public GetOldInfoForDrugOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForDrugOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForDrugOrder_Class() : base() { }
        }

        [Serializable] 

        public partial class IlacOdemeQuery_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public IlacOdemeQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public IlacOdemeQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected IlacOdemeQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_RECETE_ILAC_ACIKLAMA_Class : TTReportNqlObject 
        {
            public Guid? Recete_ilac_aciklama_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RECETE_ILAC_ACIKLAMA_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Recete_ilac_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RECETE_ILAC_KODU"]);
                }
            }

            public Guid? Recete_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RECETE_KODU"]);
                }
            }

            public Object Aciklama_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACIKLAMA_TURU"]);
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTDRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_RECETE_ILAC_ACIKLAMA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_RECETE_ILAC_ACIKLAMA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_RECETE_ILAC_ACIKLAMA_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForDrugOrderCount_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOldInfoForDrugOrderCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForDrugOrderCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForDrugOrderCount_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCaseOfNeedsDrugOrderRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterresource_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetCaseOfNeedsDrugOrderRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCaseOfNeedsDrugOrderRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCaseOfNeedsDrugOrderRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class FindSameOrderAllPatientByDate_Class : TTReportNqlObject 
        {
            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public FindSameOrderAllPatientByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FindSameOrderAllPatientByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FindSameOrderAllPatientByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveDrugOrderByEpisode_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetActiveDrugOrderByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveDrugOrderByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveDrugOrderByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStoppedDrugOrderByDate_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public GetStoppedDrugOrderByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStoppedDrugOrderByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStoppedDrugOrderByDate_Class() : base() { }
        }

        [Serializable] 

        public partial class FindSameOrder_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public FindSameOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FindSameOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FindSameOrder_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderForOrderInfoReport_Class : TTReportNqlObject 
        {
            public Guid? Orderobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTID"]);
                }
            }

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

            public bool? Orderturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PATIENTOWNDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Uygulama_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UYGULAMA_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Tedavi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedavi_objectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVI_OBJECTID"]);
                }
            }

            public String Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Doz_araligi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_ARALIGI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? Doz_miktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_MIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? Orderday
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DrugUsageTypeEnum? DrugUsageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGUSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DRUGUSAGETYPE"].DataType;
                    return (DrugUsageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? Olusturma_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURMA_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderForOrderInfoReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderForOrderInfoReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderForOrderInfoReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderByNursingApp_Class : TTReportNqlObject 
        {
            public Guid? Orderobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTID"]);
                }
            }

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

            public bool? Orderturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PATIENTOWNDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Tedavi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedavi_objectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVI_OBJECTID"]);
                }
            }

            public String Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Doz_araligi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_ARALIGI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? Doz_miktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_MIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Olusturma_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURMA_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DrugUsageTypeEnum? DrugUsageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGUSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DRUGUSAGETYPE"].DataType;
                    return (DrugUsageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderByNursingApp_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderByNursingApp_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderByNursingApp_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderNursingAppNQL_Class : TTReportNqlObject 
        {
            public Guid? Orderobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTID"]);
                }
            }

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

            public string Tedavi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doz_araligi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_ARALIGI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALTIMESCHEDULE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Doz_miktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_MIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderNursingAppNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderNursingAppNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderNursingAppNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDailyConfirmDrugRQ_Class : TTReportNqlObject 
        {
            public Guid? Drugorderobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDEROBJECTID"]);
                }
            }

            public string Drugname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
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

            public Object Patientnamesurname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAMESURNAME"]);
                }
            }

            public string Hospitaltimeschedule
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALTIMESCHEDULE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALTIMESCHEDULE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Clinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public String Drugorderstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public int? DetailNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["DETAILNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? Detaildoseamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public String Detailstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public DateTime? Detailplaneddatetime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILPLANEDDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDailyConfirmDrugRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDailyConfirmDrugRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDailyConfirmDrugRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveSameDayOrderRQ_Class : TTReportNqlObject 
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

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DonorID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DONORID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? UseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["USEAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string UBBCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UBBCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["UBBCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? PlannedStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string UsageNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGENOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Day
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SelectedMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SELECTEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["SELECTEDMATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BarcodeLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODELEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["BARCODELEVEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? PatientOwnDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTOWNDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PATIENTOWNDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DescriptionTypeEnum? DescriptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DESCRIPTIONTYPE"].DataType;
                    return (DescriptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DrugUsageTypeEnum? DrugUsageType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGUSAGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DRUGUSAGETYPE"].DataType;
                    return (DrugUsageTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsImmediate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISIMMEDIATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ISIMMEDIATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DrugOrderTypeEnum? DrugOrderType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGORDERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DRUGORDERTYPE"].DataType;
                    return (DrugOrderTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? CaseOfNeed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASEOFNEED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["CASEOFNEED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentDrugOrder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTDRUGORDER"]);
                }
            }

            public bool? OutOfTreatment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTOFTREATMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["OUTOFTREATMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsTransfered
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTRANSFERED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ISTRANSFERED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCV
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCV"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ISCV"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string EHUCancelReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EHUCANCELREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["EHUCANCELREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsUpgraded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISUPGRADED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ISUPGRADED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? OldHospitalTimeScheduleID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OLDHOSPITALTIMESCHEDULEID"]);
                }
            }

            public string RepeatDayWarning
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPEATDAYWARNING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["REPEATDAYWARNING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsTeleOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTELEORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["ISTELEORDER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetActiveSameDayOrderRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveSameDayOrderRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveSameDayOrderRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveDrugOrderForFoodInt_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetActiveDrugOrderForFoodInt_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveDrugOrderForFoodInt_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveDrugOrderForFoodInt_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("c423baa7-7c23-4a04-beef-0162ad204877"); } }
    /// <summary>
    /// Devam Ediyor
    /// </summary>
            public static Guid Continued { get { return new Guid("c227b72e-56bc-4279-81dd-a2be3a843ee0"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("66c795fb-1c52-4e78-b70b-5ad565573360"); } }
    /// <summary>
    /// Durduruldu
    /// </summary>
            public static Guid Stopped { get { return new Guid("0198f5d6-ae3d-44ba-9376-b40105df11c7"); } }
    /// <summary>
    /// EHU Onay
    /// </summary>
            public static Guid Approve { get { return new Guid("7948c2a0-8e18-40a3-a8aa-84bc3799e379"); } }
    /// <summary>
    /// Planlandı
    /// </summary>
            public static Guid Planned { get { return new Guid("f6027756-71ad-4d06-8b16-853fb5122a5d"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("6877bd5b-36b8-4ac8-ae8d-abc5da92f706"); } }
        }

        public static BindingList<DrugOrder.GetAllDrugsWithDetailForDoctorReportQuery_Class> GetAllDrugsWithDetailForDoctorReportQuery(DateTime STARTDATE, DateTime ENDDATE, string DOCTORID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetAllDrugsWithDetailForDoctorReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTORID", DOCTORID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetAllDrugsWithDetailForDoctorReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetAllDrugsWithDetailForDoctorReportQuery_Class> GetAllDrugsWithDetailForDoctorReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string DOCTORID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetAllDrugsWithDetailForDoctorReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTORID", DOCTORID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetAllDrugsWithDetailForDoctorReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugsFromPharmacyReportQuery_Class> GetDrugsFromPharmacyReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsFromPharmacyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsFromPharmacyReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugsFromPharmacyReportQuery_Class> GetDrugsFromPharmacyReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsFromPharmacyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsFromPharmacyReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery_Class> GetDrugsToPatientWithPrescriptionReportQuery(DateTime STARTDATE, DateTime ENDDATE, string DOCTORID, string DRUGID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsToPatientWithPrescriptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTORID", DOCTORID);
            paramList.Add("DRUGID", DRUGID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery_Class> GetDrugsToPatientWithPrescriptionReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string DOCTORID, string DRUGID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsToPatientWithPrescriptionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTORID", DOCTORID);
            paramList.Add("DRUGID", DRUGID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsToPatientWithPrescriptionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder> OLAP_GetDrugOrder_OLD(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["OLAP_GetDrugOrder_OLD"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrder>(queryDef, paramList);
        }

        public static BindingList<DrugOrder.GetAllDrugsForPatientGroupsReportQuery_Class> GetAllDrugsForPatientGroupsReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetAllDrugsForPatientGroupsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetAllDrugsForPatientGroupsReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetAllDrugsForPatientGroupsReportQuery_Class> GetAllDrugsForPatientGroupsReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetAllDrugsForPatientGroupsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetAllDrugsForPatientGroupsReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder> GetDrugOrderForPatient(TTObjectContext objectContext, string EPISODEID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrderForPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrder>(queryDef, paramList);
        }

        public static BindingList<DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery_Class> GetDrugsExceededMaxPackageAmountReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsExceededMaxPackageAmountReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery_Class> GetDrugsExceededMaxPackageAmountReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsExceededMaxPackageAmountReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder> GetSequenceDrugOrdes(TTObjectContext objectContext, string MATERIAL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetSequenceDrugOrdes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrder>(queryDef, paramList);
        }

        public static BindingList<DrugOrder> GetDrugOrderStates(TTObjectContext objectContext, string PLANNED)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrderStates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PLANNED", PLANNED);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrder>(queryDef, paramList);
        }

        public static BindingList<DrugOrder.GetDrugsToPatientsForEpisodeReportQuery_Class> GetDrugsToPatientsForEpisodeReportQuery(DateTime STARTDATE, DateTime ENDDATE, long EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsToPatientsForEpisodeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsToPatientsForEpisodeReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugsToPatientsForEpisodeReportQuery_Class> GetDrugsToPatientsForEpisodeReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, long EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsToPatientsForEpisodeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsToPatientsForEpisodeReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugsToPatientsForDateReportQuery_Class> GetDrugsToPatientsForDateReportQuery(DateTime STARTDATE, DateTime ENDDATE, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsToPatientsForDateReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsToPatientsForDateReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugsToPatientsForDateReportQuery_Class> GetDrugsToPatientsForDateReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugsToPatientsForDateReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugsToPatientsForDateReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder> GetDrugOrdersByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrdersByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrder>(queryDef, paramList);
        }

        public static BindingList<DrugOrder.OLAP_GetDrugOrder_Class> OLAP_GetDrugOrder(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["OLAP_GetDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.OLAP_GetDrugOrder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.OLAP_GetDrugOrder_Class> OLAP_GetDrugOrder(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["OLAP_GetDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.OLAP_GetDrugOrder_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.OLAP_GetCancelledDrugOrder_Class> OLAP_GetCancelledDrugOrder(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["OLAP_GetCancelledDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.OLAP_GetCancelledDrugOrder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.OLAP_GetCancelledDrugOrder_Class> OLAP_GetCancelledDrugOrder(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["OLAP_GetCancelledDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.OLAP_GetCancelledDrugOrder_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Geçmişi İlaçlar
    /// </summary>
        public static BindingList<DrugOrder.GetOldInfoForDrugOrder_Class> GetOldInfoForDrugOrder(Guid PATIENTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetOldInfoForDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetOldInfoForDrugOrder_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi İlaçlar
    /// </summary>
        public static BindingList<DrugOrder.GetOldInfoForDrugOrder_Class> GetOldInfoForDrugOrder(TTObjectContext objectContext, Guid PATIENTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetOldInfoForDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetOldInfoForDrugOrder_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrder> GetDrugOrdersBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrdersBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrder>(queryDef, paramList);
        }

        public static BindingList<DrugOrder> GetDrugOrderForPatientbyDrug(TTObjectContext objectContext, Guid EPISODEID, Guid DRUGID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrderForPatientbyDrug"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);
            paramList.Add("DRUGID", DRUGID);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrder>(queryDef, paramList);
        }

        public static BindingList<DrugOrder.IlacOdemeQuery_Class> IlacOdemeQuery(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["IlacOdemeQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.IlacOdemeQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.IlacOdemeQuery_Class> IlacOdemeQuery(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["IlacOdemeQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.IlacOdemeQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.VEM_RECETE_ILAC_ACIKLAMA_Class> VEM_RECETE_ILAC_ACIKLAMA(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["VEM_RECETE_ILAC_ACIKLAMA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugOrder.VEM_RECETE_ILAC_ACIKLAMA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.VEM_RECETE_ILAC_ACIKLAMA_Class> VEM_RECETE_ILAC_ACIKLAMA(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["VEM_RECETE_ILAC_ACIKLAMA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugOrder.VEM_RECETE_ILAC_ACIKLAMA_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetOldInfoForDrugOrderCount_Class> GetOldInfoForDrugOrderCount(Guid PATIENTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetOldInfoForDrugOrderCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetOldInfoForDrugOrderCount_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrder.GetOldInfoForDrugOrderCount_Class> GetOldInfoForDrugOrderCount(TTObjectContext objectContext, Guid PATIENTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetOldInfoForDrugOrderCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetOldInfoForDrugOrderCount_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrder> GetPatientOwnDrugOrdersByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetPatientOwnDrugOrdersByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrder>(queryDef, paramList);
        }

        public static BindingList<DrugOrder.GetCaseOfNeedsDrugOrderRQ_Class> GetCaseOfNeedsDrugOrderRQ(IList<Guid> MASTERRESOURCES, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetCaseOfNeedsDrugOrderRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetCaseOfNeedsDrugOrderRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrder.GetCaseOfNeedsDrugOrderRQ_Class> GetCaseOfNeedsDrugOrderRQ(TTObjectContext objectContext, IList<Guid> MASTERRESOURCES, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetCaseOfNeedsDrugOrderRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetCaseOfNeedsDrugOrderRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrder.FindSameOrderAllPatientByDate_Class> FindSameOrderAllPatientByDate(DateTime ORDERPLANNEDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["FindSameOrderAllPatientByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERPLANNEDDATE", ORDERPLANNEDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.FindSameOrderAllPatientByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.FindSameOrderAllPatientByDate_Class> FindSameOrderAllPatientByDate(TTObjectContext objectContext, DateTime ORDERPLANNEDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["FindSameOrderAllPatientByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERPLANNEDDATE", ORDERPLANNEDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.FindSameOrderAllPatientByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetActiveDrugOrderByEpisode_Class> GetActiveDrugOrderByEpisode(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetActiveDrugOrderByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetActiveDrugOrderByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetActiveDrugOrderByEpisode_Class> GetActiveDrugOrderByEpisode(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetActiveDrugOrderByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetActiveDrugOrderByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetStoppedDrugOrderByDate_Class> GetStoppedDrugOrderByDate(DateTime STARTDATE, DateTime ENDDATE, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetStoppedDrugOrderByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetStoppedDrugOrderByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetStoppedDrugOrderByDate_Class> GetStoppedDrugOrderByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetStoppedDrugOrderByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetStoppedDrugOrderByDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.FindSameOrder_Class> FindSameOrder(DateTime ORDERPLANNEDDATE, Guid EPISODE, Guid MATERIAL, FrequencyEnum FREQUENCY, int DOSEAMOUNT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["FindSameOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERPLANNEDDATE", ORDERPLANNEDDATE);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("FREQUENCY", (int)FREQUENCY);
            paramList.Add("DOSEAMOUNT", DOSEAMOUNT);

            return TTReportNqlObject.QueryObjects<DrugOrder.FindSameOrder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.FindSameOrder_Class> FindSameOrder(TTObjectContext objectContext, DateTime ORDERPLANNEDDATE, Guid EPISODE, Guid MATERIAL, FrequencyEnum FREQUENCY, int DOSEAMOUNT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["FindSameOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERPLANNEDDATE", ORDERPLANNEDDATE);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("FREQUENCY", (int)FREQUENCY);
            paramList.Add("DOSEAMOUNT", DOSEAMOUNT);

            return TTReportNqlObject.QueryObjects<DrugOrder.FindSameOrder_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugOrderForOrderInfoReport_Class> GetDrugOrderForOrderInfoReport(string NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrderForOrderInfoReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugOrderForOrderInfoReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugOrderForOrderInfoReport_Class> GetDrugOrderForOrderInfoReport(TTObjectContext objectContext, string NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrderForOrderInfoReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugOrderForOrderInfoReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugOrderByNursingApp_Class> GetDrugOrderByNursingApp(DateTime STARTDATE, DateTime EndDate, string NURSINGAPP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrderByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", EndDate);
            paramList.Add("NURSINGAPP", NURSINGAPP);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugOrderByNursingApp_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugOrderByNursingApp_Class> GetDrugOrderByNursingApp(TTObjectContext objectContext, DateTime STARTDATE, DateTime EndDate, string NURSINGAPP, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrderByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", EndDate);
            paramList.Add("NURSINGAPP", NURSINGAPP);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugOrderByNursingApp_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugOrderNursingAppNQL_Class> GetDrugOrderNursingAppNQL(Guid NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrderNursingAppNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugOrderNursingAppNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDrugOrderNursingAppNQL_Class> GetDrugOrderNursingAppNQL(TTObjectContext objectContext, Guid NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDrugOrderNursingAppNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDrugOrderNursingAppNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrder.GetDailyConfirmDrugRQ_Class> GetDailyConfirmDrugRQ(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDailyConfirmDrugRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDailyConfirmDrugRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrder.GetDailyConfirmDrugRQ_Class> GetDailyConfirmDrugRQ(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetDailyConfirmDrugRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetDailyConfirmDrugRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrder.GetActiveSameDayOrderRQ_Class> GetActiveSameDayOrderRQ(Guid EPISODEID, DateTime DATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetActiveSameDayOrderRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetActiveSameDayOrderRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrder.GetActiveSameDayOrderRQ_Class> GetActiveSameDayOrderRQ(TTObjectContext objectContext, Guid EPISODEID, DateTime DATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetActiveSameDayOrderRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetActiveSameDayOrderRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Diyet İlaç Etkileşimi
    /// </summary>
        public static BindingList<DrugOrder.GetActiveDrugOrderForFoodInt_Class> GetActiveDrugOrderForFoodInt(Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetActiveDrugOrderForFoodInt"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetActiveDrugOrderForFoodInt_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Diyet İlaç Etkileşimi
    /// </summary>
        public static BindingList<DrugOrder.GetActiveDrugOrderForFoodInt_Class> GetActiveDrugOrderForFoodInt(TTObjectContext objectContext, Guid EPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].QueryDefs["GetActiveDrugOrderForFoodInt"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);

            return TTReportNqlObject.QueryObjects<DrugOrder.GetActiveDrugOrderForFoodInt_Class>(objectContext, queryDef, paramList, pi);
        }

        public string SelectedMaterial
        {
            get { return (string)this["SELECTEDMATERIAL"]; }
            set { this["SELECTEDMATERIAL"] = value; }
        }

    /// <summary>
    /// Piyasa İsmi
    /// </summary>
        public string BarcodeLevel
        {
            get { return (string)this["BARCODELEVEL"]; }
            set { this["BARCODELEVEL"] = value; }
        }

    /// <summary>
    /// Type
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Hasta Yanında Getirdi
    /// </summary>
        public bool? PatientOwnDrug
        {
            get { return (bool?)this["PATIENTOWNDRUG"]; }
            set { this["PATIENTOWNDRUG"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Açıklama Türü
    /// </summary>
        public DescriptionTypeEnum? DescriptionType
        {
            get { return (DescriptionTypeEnum?)(int?)this["DESCRIPTIONTYPE"]; }
            set { this["DESCRIPTIONTYPE"] = value; }
        }

    /// <summary>
    /// Kullanım Şekli
    /// </summary>
        public DrugUsageTypeEnum? DrugUsageType
        {
            get { return (DrugUsageTypeEnum?)(int?)this["DRUGUSAGETYPE"]; }
            set { this["DRUGUSAGETYPE"] = value; }
        }

    /// <summary>
    /// Acil İlaç
    /// </summary>
        public bool? IsImmediate
        {
            get { return (bool?)this["ISIMMEDIATE"]; }
            set { this["ISIMMEDIATE"] = value; }
        }

        public DrugOrderTypeEnum? DrugOrderType
        {
            get { return (DrugOrderTypeEnum?)(int?)this["DRUGORDERTYPE"]; }
            set { this["DRUGORDERTYPE"] = value; }
        }

    /// <summary>
    /// Lüzum Halinde
    /// </summary>
        public bool? CaseOfNeed
        {
            get { return (bool?)this["CASEOFNEED"]; }
            set { this["CASEOFNEED"] = value; }
        }

    /// <summary>
    /// ParentDrugOrder
    /// </summary>
        public Guid? ParentDrugOrder
        {
            get { return (Guid?)this["PARENTDRUGORDER"]; }
            set { this["PARENTDRUGORDER"] = value; }
        }

    /// <summary>
    /// Tedavi Dışı
    /// </summary>
        public bool? OutOfTreatment
        {
            get { return (bool?)this["OUTOFTREATMENT"]; }
            set { this["OUTOFTREATMENT"] = value; }
        }

    /// <summary>
    /// Diğer Yatışa Taşınacak
    /// </summary>
        public bool? IsTransfered
        {
            get { return (bool?)this["ISTRANSFERED"]; }
            set { this["ISTRANSFERED"] = value; }
        }

    /// <summary>
    /// Kontravisit
    /// </summary>
        public bool? IsCV
        {
            get { return (bool?)this["ISCV"]; }
            set { this["ISCV"] = value; }
        }

    /// <summary>
    /// EHU İptal Nedeni
    /// </summary>
        public string EHUCancelReason
        {
            get { return (string)this["EHUCANCELREASON"]; }
            set { this["EHUCANCELREASON"] = value; }
        }

    /// <summary>
    /// Güncellenmiş Order
    /// </summary>
        public bool? IsUpgraded
        {
            get { return (bool?)this["ISUPGRADED"]; }
            set { this["ISUPGRADED"] = value; }
        }

        public Guid? OldHospitalTimeScheduleID
        {
            get { return (Guid?)this["OLDHOSPITALTIMESCHEDULEID"]; }
            set { this["OLDHOSPITALTIMESCHEDULEID"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string RepeatDayWarning
        {
            get { return (string)this["REPEATDAYWARNING"]; }
            set { this["REPEATDAYWARNING"] = value; }
        }

    /// <summary>
    /// Sözel Order
    /// </summary>
        public bool? IsTeleOrder
        {
            get { return (bool?)this["ISTELEORDER"]; }
            set { this["ISTELEORDER"] = value; }
        }

        public NursingApplication NursingApplication
        {
            get { return (NursingApplication)((ITTObject)this).GetParent("NURSINGAPPLICATION"); }
            set { this["NURSINGAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientPhysicianApplication InPatientPhysicianApplication
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIANAPPLICATION"); }
            set { this["INPATIENTPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaterialBarcodeLevel MaterialBarcodeLevel
        {
            get { return (MaterialBarcodeLevel)((ITTObject)this).GetParent("MATERIALBARCODELEVEL"); }
            set { this["MATERIALBARCODELEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationAction MagistralPreparationAction
        {
            get { return (MagistralPreparationAction)((ITTObject)this).GetParent("MAGISTRALPREPARATIONACTION"); }
            set { this["MAGISTRALPREPARATIONACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material PhysicianOrderedDrug
        {
            get { return (Material)((ITTObject)this).GetParent("PHYSICIANORDEREDDRUG"); }
            set { this["PHYSICIANORDEREDDRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePatientRestDosesCollection()
        {
            _PatientRestDoses = new PatientRestDose.ChildPatientRestDoseCollection(this, new Guid("d9a319f3-47af-46d4-9010-3d6d43467c98"));
            ((ITTChildObjectCollection)_PatientRestDoses).GetChildren();
        }

        protected PatientRestDose.ChildPatientRestDoseCollection _PatientRestDoses = null;
        public PatientRestDose.ChildPatientRestDoseCollection PatientRestDoses
        {
            get
            {
                if (_PatientRestDoses == null)
                    CreatePatientRestDosesCollection();
                return _PatientRestDoses;
            }
        }

        virtual protected void CreateDrugOrderTransactionsCollection()
        {
            _DrugOrderTransactions = new DrugOrderTransaction.ChildDrugOrderTransactionCollection(this, new Guid("7db9c09f-b1d6-44ab-bbc7-ae5559466e22"));
            ((ITTChildObjectCollection)_DrugOrderTransactions).GetChildren();
        }

        protected DrugOrderTransaction.ChildDrugOrderTransactionCollection _DrugOrderTransactions = null;
        public DrugOrderTransaction.ChildDrugOrderTransactionCollection DrugOrderTransactions
        {
            get
            {
                if (_DrugOrderTransactions == null)
                    CreateDrugOrderTransactionsCollection();
                return _DrugOrderTransactions;
            }
        }

        virtual protected void CreateDrugOrderDetailsCollection()
        {
            _DrugOrderDetails = new DrugOrderDetail.ChildDrugOrderDetailCollection(this, new Guid("f36aacf5-3e14-4df9-854f-f2af140e22b5"));
            ((ITTChildObjectCollection)_DrugOrderDetails).GetChildren();
        }

        protected DrugOrderDetail.ChildDrugOrderDetailCollection _DrugOrderDetails = null;
        public DrugOrderDetail.ChildDrugOrderDetailCollection DrugOrderDetails
        {
            get
            {
                if (_DrugOrderDetails == null)
                    CreateDrugOrderDetailsCollection();
                return _DrugOrderDetails;
            }
        }

        virtual protected void CreateMagistralDrugDetailsCollection()
        {
            _MagistralDrugDetails = new MagistralDrugDetail.ChildMagistralDrugDetailCollection(this, new Guid("c5c3b098-2430-4e77-acf6-934c525337fa"));
            ((ITTChildObjectCollection)_MagistralDrugDetails).GetChildren();
        }

        protected MagistralDrugDetail.ChildMagistralDrugDetailCollection _MagistralDrugDetails = null;
        public MagistralDrugDetail.ChildMagistralDrugDetailCollection MagistralDrugDetails
        {
            get
            {
                if (_MagistralDrugDetails == null)
                    CreateMagistralDrugDetailsCollection();
                return _MagistralDrugDetails;
            }
        }

        virtual protected void CreateMagistralChemicalDetailsCollection()
        {
            _MagistralChemicalDetails = new MagistralChemicalDetail.ChildMagistralChemicalDetailCollection(this, new Guid("abba2410-59b1-40da-bf8a-bf550c1c0b10"));
            ((ITTChildObjectCollection)_MagistralChemicalDetails).GetChildren();
        }

        protected MagistralChemicalDetail.ChildMagistralChemicalDetailCollection _MagistralChemicalDetails = null;
        public MagistralChemicalDetail.ChildMagistralChemicalDetailCollection MagistralChemicalDetails
        {
            get
            {
                if (_MagistralChemicalDetails == null)
                    CreateMagistralChemicalDetailsCollection();
                return _MagistralChemicalDetails;
            }
        }

        protected DrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGORDER", dataRow) { }
        protected DrugOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGORDER", dataRow, isImported) { }
        public DrugOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugOrder() : base() { }

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