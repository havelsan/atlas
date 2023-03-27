
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TigEpisode")] 

    /// <summary>
    /// İçerisinde Episode Bulunduran Teşhis İlişkili Gruplar Nesnesi
    /// </summary>
    public  partial class TigEpisode : TTObject
    {
        public class TigEpisodeList : TTObjectCollection<TigEpisode> { }
                    
        public class ChildTigEpisodeCollection : TTObject.TTChildObjectCollection<TigEpisode>
        {
            public ChildTigEpisodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTigEpisodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class TigEpisodeNQL_Class : TTReportNqlObject 
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

            public Guid? ResourceGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOURCEGUID"]);
                }
            }

            public DateTime? DischargeDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCHARGEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["DISCHARGEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? DoctorGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTORGUID"]);
                }
            }

            public Guid? DischargerDoctorGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISCHARGERDOCTORGUID"]);
                }
            }

            public Guid? BranchGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BRANCHGUID"]);
                }
            }

            public bool? AppointmentStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["APPOINTMENTSTATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? EpicrisisStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPICRISISSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["EPICRISISSTATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PathologyRequestStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGYREQUESTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["PATHOLOGYREQUESTSTATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PathologyReportStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGYREPORTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["PATHOLOGYREPORTSTATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? InvoiceStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["INVOICESTATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Cancelled
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["CANCELLED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? InpatientDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["INPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public TIGPatientTypeEnum? PatientType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["PATIENTTYPE"].DataType;
                    return (TIGPatientTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string InPatientProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["INPATIENTPROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgeries
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["SURGERIES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? XMLStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XMLSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["XMLSTATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? XMLCreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XMLCREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["XMLCREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? CodingStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODINGSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["CODINGSTATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CodingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["CODINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? EpisodeGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEGUID"]);
                }
            }

            public Guid? PatientGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTGUID"]);
                }
            }

            public Guid? SEPGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEPGUID"]);
                }
            }

            public bool? IsCreatedByTreatmentCure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCREATEDBYTREATMENTCURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].AllPropertyDefs["ISCREATEDBYTREATMENTCURE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Xmlcreatedbyusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XMLCREATEDBYUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Codingbyusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODINGBYUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public TigEpisodeNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public TigEpisodeNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected TigEpisodeNQL_Class() : base() { }
        }

        public static BindingList<TigEpisode.TigEpisodeNQL_Class> TigEpisodeNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].QueryDefs["TigEpisodeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TigEpisode.TigEpisodeNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TigEpisode.TigEpisodeNQL_Class> TigEpisodeNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TIGEPISODE"].QueryDefs["TigEpisodeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TigEpisode.TigEpisodeNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tig Modülü Servis Guidi
    /// </summary>
        public Guid? ResourceGuid
        {
            get { return (Guid?)this["RESOURCEGUID"]; }
            set { this["RESOURCEGUID"] = value; }
        }

    /// <summary>
    /// Taburcu Tarihi
    /// </summary>
        public DateTime? DischargeDate
        {
            get { return (DateTime?)this["DISCHARGEDATE"]; }
            set { this["DISCHARGEDATE"] = value; }
        }

    /// <summary>
    /// Tig Modülü Doktor Guidi
    /// </summary>
        public Guid? DoctorGuid
        {
            get { return (Guid?)this["DOCTORGUID"]; }
            set { this["DOCTORGUID"] = value; }
        }

    /// <summary>
    /// Taburcu Eden Doktor Guidi
    /// </summary>
        public Guid? DischargerDoctorGuid
        {
            get { return (Guid?)this["DISCHARGERDOCTORGUID"]; }
            set { this["DISCHARGERDOCTORGUID"] = value; }
        }

    /// <summary>
    /// Tig Modülü Branş Guidi
    /// </summary>
        public Guid? BranchGuid
        {
            get { return (Guid?)this["BRANCHGUID"]; }
            set { this["BRANCHGUID"] = value; }
        }

    /// <summary>
    /// Tig Modülü Randevu Durumu
    /// </summary>
        public bool? AppointmentStatus
        {
            get { return (bool?)this["APPOINTMENTSTATUS"]; }
            set { this["APPOINTMENTSTATUS"] = value; }
        }

    /// <summary>
    /// Tig Modülü Epikriz Durumu
    /// </summary>
        public bool? EpicrisisStatus
        {
            get { return (bool?)this["EPICRISISSTATUS"]; }
            set { this["EPICRISISSTATUS"] = value; }
        }

    /// <summary>
    /// Tig Modülü Patoloji İstem Durumu
    /// </summary>
        public bool? PathologyRequestStatus
        {
            get { return (bool?)this["PATHOLOGYREQUESTSTATUS"]; }
            set { this["PATHOLOGYREQUESTSTATUS"] = value; }
        }

    /// <summary>
    /// Tig Modülü Patoloji Rapor Durumu
    /// </summary>
        public bool? PathologyReportStatus
        {
            get { return (bool?)this["PATHOLOGYREPORTSTATUS"]; }
            set { this["PATHOLOGYREPORTSTATUS"] = value; }
        }

    /// <summary>
    /// Tig Modülü Fatura Durumu
    /// </summary>
        public bool? InvoiceStatus
        {
            get { return (bool?)this["INVOICESTATUS"]; }
            set { this["INVOICESTATUS"] = value; }
        }

    /// <summary>
    /// Tig Modülü Aktif-Pasif
    /// </summary>
        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

    /// <summary>
    /// Tig Modülü Yatış Tarihi
    /// </summary>
        public DateTime? InpatientDate
        {
            get { return (DateTime?)this["INPATIENTDATE"]; }
            set { this["INPATIENTDATE"] = value; }
        }

        public TIGPatientTypeEnum? PatientType
        {
            get { return (TIGPatientTypeEnum?)(int?)this["PATIENTTYPE"]; }
            set { this["PATIENTTYPE"] = value; }
        }

    /// <summary>
    /// Tig Modülü Yatış Numarası
    /// </summary>
        public string InPatientProtocolNo
        {
            get { return (string)this["INPATIENTPROTOCOLNO"]; }
            set { this["INPATIENTPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Tig Modülü Ameliyat İşlemleri
    /// </summary>
        public string Surgeries
        {
            get { return (string)this["SURGERIES"]; }
            set { this["SURGERIES"] = value; }
        }

    /// <summary>
    /// XML Kaydı Oluşturuldu mu?
    /// </summary>
        public bool? XMLStatus
        {
            get { return (bool?)this["XMLSTATUS"]; }
            set { this["XMLSTATUS"] = value; }
        }

    /// <summary>
    /// XML Oluşturulma Tarihi
    /// </summary>
        public DateTime? XMLCreationDate
        {
            get { return (DateTime?)this["XMLCREATIONDATE"]; }
            set { this["XMLCREATIONDATE"] = value; }
        }

    /// <summary>
    /// Kodlama Yapıldı mı?
    /// </summary>
        public bool? CodingStatus
        {
            get { return (bool?)this["CODINGSTATUS"]; }
            set { this["CODINGSTATUS"] = value; }
        }

    /// <summary>
    /// Kodlamanın Yapıldığı Tarih
    /// </summary>
        public DateTime? CodingDate
        {
            get { return (DateTime?)this["CODINGDATE"]; }
            set { this["CODINGDATE"] = value; }
        }

    /// <summary>
    /// Mevcut TİG Nesnesi ile İlgili Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Tig Modülü Episode Guidi
    /// </summary>
        public Guid? EpisodeGuid
        {
            get { return (Guid?)this["EPISODEGUID"]; }
            set { this["EPISODEGUID"] = value; }
        }

    /// <summary>
    /// Tig Modülü Hasta Guidi
    /// </summary>
        public Guid? PatientGuid
        {
            get { return (Guid?)this["PATIENTGUID"]; }
            set { this["PATIENTGUID"] = value; }
        }

    /// <summary>
    /// Tig Modülü SEP Guidi
    /// </summary>
        public Guid? SEPGuid
        {
            get { return (Guid?)this["SEPGUID"]; }
            set { this["SEPGUID"] = value; }
        }

        public bool? IsCreatedByTreatmentCure
        {
            get { return (bool?)this["ISCREATEDBYTREATMENTCURE"]; }
            set { this["ISCREATEDBYTREATMENTCURE"] = value; }
        }

    /// <summary>
    /// XML Oluşturan Kullanıcı
    /// </summary>
        public ResUser XMLCreatedByUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("XMLCREATEDBYUSER"); }
            set { this["XMLCREATEDBYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kodlamayı Yapan Kullanıcı
    /// </summary>
        public ResUser CodingByUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("CODINGBYUSER"); }
            set { this["CODINGBYUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TigEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TigEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TigEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TigEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TigEpisode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TIGEPISODE", dataRow) { }
        protected TigEpisode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TIGEPISODE", dataRow, isImported) { }
        public TigEpisode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TigEpisode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TigEpisode() : base() { }

    }
}