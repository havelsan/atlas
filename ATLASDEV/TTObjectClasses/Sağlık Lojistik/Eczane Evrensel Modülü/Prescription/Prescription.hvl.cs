
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Prescription")] 

    /// <summary>
    /// Reçete Ana Sınıfı
    /// </summary>
    public  abstract  partial class Prescription : EpisodeAction
    {
        public class PrescriptionList : TTObjectCollection<Prescription> { }
                    
        public class ChildPrescriptionCollection : TTObject.TTChildObjectCollection<Prescription>
        {
            public ChildPrescriptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetPrescription_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public PrescriptionTypeEnum? Prescriptiontypeenum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONTYPEENUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (PrescriptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetPrescription_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPrescription_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPrescription_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFamilyForPrescriptionStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Familycount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FAMILYCOUNT"]);
                }
            }

            public GetFamilyForPrescriptionStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFamilyForPrescriptionStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFamilyForPrescriptionStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCivilianForPrescriptionStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Civiliancount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CIVILIANCOUNT"]);
                }
            }

            public GetCivilianForPrescriptionStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCivilianForPrescriptionStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCivilianForPrescriptionStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOfficerForPrescriptionStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Officercount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OFFICERCOUNT"]);
                }
            }

            public GetOfficerForPrescriptionStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOfficerForPrescriptionStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOfficerForPrescriptionStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPrescriptionSearchWithProtocolNOReportQuery_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
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

            public Object Birthcity
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BIRTHCITY"]);
                }
            }

            public string Birthtown
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHTOWN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPrescriptionSearchWithProtocolNOReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrescriptionSearchWithProtocolNOReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrescriptionSearchWithProtocolNOReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNCOfficerForPrescriptionStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Ncofficercount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NCOFFICERCOUNT"]);
                }
            }

            public GetNCOfficerForPrescriptionStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNCOfficerForPrescriptionStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNCOfficerForPrescriptionStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPrescriptionStatisticWithGroupReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Masterresourceid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCEID"]);
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

            public GetPrescriptionStatisticWithGroupReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrescriptionStatisticWithGroupReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrescriptionStatisticWithGroupReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOfficialForPrescriptionStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Officialcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["OFFICIALCOUNT"]);
                }
            }

            public GetOfficialForPrescriptionStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOfficialForPrescriptionStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOfficialForPrescriptionStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetExpertNonComForPrescriptionStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Expertnoncomcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EXPERTNONCOMCOUNT"]);
                }
            }

            public GetExpertNonComForPrescriptionStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExpertNonComForPrescriptionStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExpertNonComForPrescriptionStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPrivateForPrescriptionStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Privatecount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRIVATECOUNT"]);
                }
            }

            public GetPrivateForPrescriptionStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrivateForPrescriptionStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrivateForPrescriptionStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCadetForPrescriptionStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Cadetcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CADETCOUNT"]);
                }
            }

            public GetCadetForPrescriptionStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCadetForPrescriptionStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCadetForPrescriptionStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRetiredForPrescriptionStatisticReportQuery_Class : TTReportNqlObject 
        {
            public Object Retiredcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["RETIREDCOUNT"]);
                }
            }

            public GetRetiredForPrescriptionStatisticReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRetiredForPrescriptionStatisticReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRetiredForPrescriptionStatisticReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GunSonu_ReceteSayisi_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public GunSonu_ReceteSayisi_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GunSonu_ReceteSayisi_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GunSonu_ReceteSayisi_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledPrescription_Class : TTReportNqlObject 
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

            public OLAP_GetCancelledPrescription_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledPrescription_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledPrescription_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_RECETE_Class : TTReportNqlObject 
        {
            public Guid? Recete_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RECETE_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public DateTime? Recete_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECETE_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["FILLINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PrescriptionTypeEnum? Recete_turu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECETE_TURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (PrescriptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PrescriptionSubTypeEnum? Recete_alt_turu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECETE_ALT_TURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONSUBTYPE"].DataType;
                    return (PrescriptionSubTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Hekim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HEKIM_KODU"]);
                }
            }

            public string Defter_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFTER_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["PRESCRIPTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string E_recete_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["E_RECETE_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["ERECETENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Seri_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SERI_NUMARASI"]);
                }
            }

            public bool? E_imza_durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["E_IMZA_DURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].AllPropertyDefs["ISSIGNED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Takip_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TAKIP_NUMARASI"]);
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

            public VEM_RECETE_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_RECETE_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_RECETE_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPresciptionByEreceteNoAndPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetPresciptionByEreceteNoAndPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPresciptionByEreceteNoAndPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPresciptionByEreceteNoAndPatient_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("d737d750-0ba8-43db-b857-58c68fc9a3f5"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("890fb492-eed3-4e3f-aa97-8c59f680ed9d"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("3f2cc851-3464-4f1c-84a4-9afaabfce912"); } }
        }

        public static BindingList<Prescription> GetPrescription(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetPrescription"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Prescription>(queryDef, paramList);
        }

        public static BindingList<Prescription.OLAP_GetPrescription_Class> OLAP_GetPrescription(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["OLAP_GetPrescription"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Prescription.OLAP_GetPrescription_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.OLAP_GetPrescription_Class> OLAP_GetPrescription(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["OLAP_GetPrescription"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Prescription.OLAP_GetPrescription_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class> GetFamilyForPrescriptionStatisticReportQuery(string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetFamilyForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class> GetFamilyForPrescriptionStatisticReportQuery(TTObjectContext objectContext, string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetFamilyForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class> GetCivilianForPrescriptionStatisticReportQuery(string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetCivilianForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class> GetCivilianForPrescriptionStatisticReportQuery(TTObjectContext objectContext, string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetCivilianForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class> GetOfficerForPrescriptionStatisticReportQuery(string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetOfficerForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class> GetOfficerForPrescriptionStatisticReportQuery(TTObjectContext objectContext, string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetOfficerForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetPrescriptionSearchWithProtocolNOReportQuery_Class> GetPrescriptionSearchWithProtocolNOReportQuery(DateTime STARTDATE, DateTime ENDDATE, long PROTOCOLNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetPrescriptionSearchWithProtocolNOReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PROTOCOLNO", PROTOCOLNO);

            return TTReportNqlObject.QueryObjects<Prescription.GetPrescriptionSearchWithProtocolNOReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetPrescriptionSearchWithProtocolNOReportQuery_Class> GetPrescriptionSearchWithProtocolNOReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, long PROTOCOLNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetPrescriptionSearchWithProtocolNOReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PROTOCOLNO", PROTOCOLNO);

            return TTReportNqlObject.QueryObjects<Prescription.GetPrescriptionSearchWithProtocolNOReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class> GetNCOfficerForPrescriptionStatisticReportQuery(string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetNCOfficerForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class> GetNCOfficerForPrescriptionStatisticReportQuery(TTObjectContext objectContext, string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetNCOfficerForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class> GetPrescriptionStatisticWithGroupReportQuery(DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPEENUM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetPrescriptionStatisticWithGroupReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPEENUM", (int)PRESCRIPTIONTYPEENUM);

            return TTReportNqlObject.QueryObjects<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class> GetPrescriptionStatisticWithGroupReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPEENUM, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetPrescriptionStatisticWithGroupReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPEENUM", (int)PRESCRIPTIONTYPEENUM);

            return TTReportNqlObject.QueryObjects<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class> GetOfficialForPrescriptionStatisticReportQuery(string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetOfficialForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class> GetOfficialForPrescriptionStatisticReportQuery(TTObjectContext objectContext, string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetOfficialForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class> GetExpertNonComForPrescriptionStatisticReportQuery(string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetExpertNonComForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class> GetExpertNonComForPrescriptionStatisticReportQuery(TTObjectContext objectContext, string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetExpertNonComForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class> GetPrivateForPrescriptionStatisticReportQuery(string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetPrivateForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class> GetPrivateForPrescriptionStatisticReportQuery(TTObjectContext objectContext, string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetPrivateForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetCadetForPrescriptionStatisticReportQuery_Class> GetCadetForPrescriptionStatisticReportQuery(string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetCadetForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetCadetForPrescriptionStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetCadetForPrescriptionStatisticReportQuery_Class> GetCadetForPrescriptionStatisticReportQuery(TTObjectContext objectContext, string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetCadetForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetCadetForPrescriptionStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class> GetRetiredForPrescriptionStatisticReportQuery(string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetRetiredForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class> GetRetiredForPrescriptionStatisticReportQuery(TTObjectContext objectContext, string MASTERRESOURCEID, DateTime STARTDATE, DateTime ENDDATE, PrescriptionTypeEnum PRESCRIPTIONTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetRetiredForPrescriptionStatisticReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERRESOURCEID", MASTERRESOURCEID);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);

            return TTReportNqlObject.QueryObjects<Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GunSonu_ReceteSayisi_Class> GunSonu_ReceteSayisi(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GunSonu_ReceteSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Prescription.GunSonu_ReceteSayisi_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GunSonu_ReceteSayisi_Class> GunSonu_ReceteSayisi(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GunSonu_ReceteSayisi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Prescription.GunSonu_ReceteSayisi_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.OLAP_GetCancelledPrescription_Class> OLAP_GetCancelledPrescription(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["OLAP_GetCancelledPrescription"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Prescription.OLAP_GetCancelledPrescription_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.OLAP_GetCancelledPrescription_Class> OLAP_GetCancelledPrescription(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["OLAP_GetCancelledPrescription"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Prescription.OLAP_GetCancelledPrescription_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.VEM_RECETE_Class> VEM_RECETE(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["VEM_RECETE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Prescription.VEM_RECETE_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.VEM_RECETE_Class> VEM_RECETE(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["VEM_RECETE"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Prescription.VEM_RECETE_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetPresciptionByEreceteNoAndPatient_Class> GetPresciptionByEreceteNoAndPatient(string ERECETENO, string PATIENTGUID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetPresciptionByEreceteNoAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ERECETENO", ERECETENO);
            paramList.Add("PATIENTGUID", PATIENTGUID);

            return TTReportNqlObject.QueryObjects<Prescription.GetPresciptionByEreceteNoAndPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Prescription.GetPresciptionByEreceteNoAndPatient_Class> GetPresciptionByEreceteNoAndPatient(TTObjectContext objectContext, string ERECETENO, string PATIENTGUID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTION"].QueryDefs["GetPresciptionByEreceteNoAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ERECETENO", ERECETENO);
            paramList.Add("PATIENTGUID", PATIENTGUID);

            return TTReportNqlObject.QueryObjects<Prescription.GetPresciptionByEreceteNoAndPatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Reçete Numarası
    /// </summary>
        public string PrescriptionNO
        {
            get { return (string)this["PRESCRIPTIONNO"]; }
            set { this["PRESCRIPTIONNO"] = value; }
        }

    /// <summary>
    /// Elektronik olarak imzalandı mı?
    /// </summary>
        public bool? IsSigned
        {
            get { return (bool?)this["ISSIGNED"]; }
            set { this["ISSIGNED"] = value; }
        }

    /// <summary>
    /// EHU Tc Kimlik No
    /// </summary>
        public string EHUUniqueNo
        {
            get { return (string)this["EHUUNIQUENO"]; }
            set { this["EHUUNIQUENO"] = value; }
        }

    /// <summary>
    /// EHU E Reçete Şifresi 
    /// </summary>
        public string EHURecetePassword
        {
            get { return (string)this["EHURECETEPASSWORD"]; }
            set { this["EHURECETEPASSWORD"] = value; }
        }

    /// <summary>
    /// Dağıtım Numarası
    /// </summary>
        public string DistributionNo
        {
            get { return (string)this["DISTRIBUTIONNO"]; }
            set { this["DISTRIBUTIONNO"] = value; }
        }

    /// <summary>
    /// Reçete Toplam Tutar
    /// </summary>
        public double? PrescriptionPrice
        {
            get { return (double?)this["PRESCRIPTIONPRICE"]; }
            set { this["PRESCRIPTIONPRICE"] = value; }
        }

    /// <summary>
    /// e-Reçete Açıklaması
    /// </summary>
        public string EReceteDescription
        {
            get { return (string)this["ERECETEDESCRIPTION"]; }
            set { this["ERECETEDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Reçete Türü
    /// </summary>
        public PrescriptionTypeEnum? PrescriptionType
        {
            get { return (PrescriptionTypeEnum?)(int?)this["PRESCRIPTIONTYPE"]; }
            set { this["PRESCRIPTIONTYPE"] = value; }
        }

    /// <summary>
    /// İmzalanmış Veri
    /// </summary>
        public object SignedData
        {
            get { return (object)this["SIGNEDDATA"]; }
            set { this["SIGNEDDATA"] = value; }
        }

    /// <summary>
    /// Provizyon Tipi
    /// </summary>
        public ProvisionTypeEnum? ProvisionType
        {
            get { return (ProvisionTypeEnum?)(int?)this["PROVISIONTYPE"]; }
            set { this["PROVISIONTYPE"] = value; }
        }

    /// <summary>
    /// Reçete Alt Türü
    /// </summary>
        public PrescriptionSubTypeEnum? PrescriptionSubType
        {
            get { return (PrescriptionSubTypeEnum?)(int?)this["PRESCRIPTIONSUBTYPE"]; }
            set { this["PRESCRIPTIONSUBTYPE"] = value; }
        }

    /// <summary>
    /// Reçete Numarası
    /// </summary>
        public string EReceteNo
        {
            get { return (string)this["ERECETENO"]; }
            set { this["ERECETENO"] = value; }
        }

    /// <summary>
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
        }

    /// <summary>
    /// E Reçete Şifresi 
    /// </summary>
        public string ERecetePassword
        {
            get { return (string)this["ERECETEPASSWORD"]; }
            set { this["ERECETEPASSWORD"] = value; }
        }

    /// <summary>
    /// Bir Daha Sorma Kullanıcı Bilgilerine Kaydet
    /// </summary>
        public bool? IsRepeated
        {
            get { return (bool?)this["ISREPEATED"]; }
            set { this["ISREPEATED"] = value; }
        }

        public PrescriptionPaper PrescriptionPaper
        {
            get { return (PrescriptionPaper)((ITTObject)this).GetParent("PRESCRIPTIONPAPER"); }
            set { this["PRESCRIPTIONPAPER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDistributeDetailCollection()
        {
            _DistributeDetail = new DistributeDetail.ChildDistributeDetailCollection(this, new Guid("99d00efc-fccd-406f-ab37-884c636c8904"));
            ((ITTChildObjectCollection)_DistributeDetail).GetChildren();
        }

        protected DistributeDetail.ChildDistributeDetailCollection _DistributeDetail = null;
        public DistributeDetail.ChildDistributeDetailCollection DistributeDetail
        {
            get
            {
                if (_DistributeDetail == null)
                    CreateDistributeDetailCollection();
                return _DistributeDetail;
            }
        }

        virtual protected void CreateSPTSDiagnosisesCollection()
        {
            _SPTSDiagnosises = new DiagnosisForPresc.ChildDiagnosisForPrescCollection(this, new Guid("f9b91cf4-9aec-4687-8154-f2ee40fe31fd"));
            ((ITTChildObjectCollection)_SPTSDiagnosises).GetChildren();
        }

        protected DiagnosisForPresc.ChildDiagnosisForPrescCollection _SPTSDiagnosises = null;
        public DiagnosisForPresc.ChildDiagnosisForPrescCollection SPTSDiagnosises
        {
            get
            {
                if (_SPTSDiagnosises == null)
                    CreateSPTSDiagnosisesCollection();
                return _SPTSDiagnosises;
            }
        }

        virtual protected void CreateDiagnosisForSPTSsCollection()
        {
            _DiagnosisForSPTSs = new DiagnosisForSPTS.ChildDiagnosisForSPTSCollection(this, new Guid("ef596207-04e4-4ef7-b104-758cd9fba0a3"));
            ((ITTChildObjectCollection)_DiagnosisForSPTSs).GetChildren();
        }

        protected DiagnosisForSPTS.ChildDiagnosisForSPTSCollection _DiagnosisForSPTSs = null;
        public DiagnosisForSPTS.ChildDiagnosisForSPTSCollection DiagnosisForSPTSs
        {
            get
            {
                if (_DiagnosisForSPTSs == null)
                    CreateDiagnosisForSPTSsCollection();
                return _DiagnosisForSPTSs;
            }
        }

        protected Prescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Prescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Prescription(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Prescription(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Prescription(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTION", dataRow) { }
        protected Prescription(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTION", dataRow, isImported) { }
        public Prescription(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Prescription(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Prescription() : base() { }

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