
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseSurgeryProcedure")] 

    /// <summary>
    /// Ameliyat Procedure Ana Objesi
    /// </summary>
    public  partial class BaseSurgeryProcedure : BaseSurgeryAndManipulationProcedure
    {
        public class BaseSurgeryProcedureList : TTObjectCollection<BaseSurgeryProcedure> { }
                    
        public class ChildBaseSurgeryProcedureCollection : TTObject.TTChildObjectCollection<BaseSurgeryProcedure>
        {
            public ChildBaseSurgeryProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseSurgeryProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class VEM_AMELIYAT_Class : TTReportNqlObject 
        {
            public Guid? Ameliyat_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["AMELIYAT_KODU"]);
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

            public string Ameliyat_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYAT_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Ameliyat_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMELIYAT_TURU"]);
                }
            }

            public DateTime? Ameliyat_baslama_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYAT_BASLAMA_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Ameliyat_bitis_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYAT_BITIS_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Masa_cihaz_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASA_CIHAZ_KODU"]);
                }
            }

            public Guid? Birim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BIRIM_KODU"]);
                }
            }

            public long? Defter_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFTER_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public String Ameliyat_durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYAT_DURUMU"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public AnesthesiaTechniqueEnum? Anestezi_turu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTEZI_TURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIATECHNIQUE"].DataType;
                    return (AnesthesiaTechniqueEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Ameliyat_tipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYAT_TIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Skopi_suresi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SKOPI_SURESI"]);
                }
            }

            public Object Profilaksi_periyodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROFILAKSI_PERIYODU"]);
                }
            }

            public Object Profilaksi_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PROFILAKSI_KODU"]);
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

            public VEM_AMELIYAT_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_AMELIYAT_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_AMELIYAT_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_AMELIYAT_ISLEM_Class : TTReportNqlObject 
        {
            public Guid? Ameliyat_islem_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["AMELIYAT_ISLEM_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Ameliyat_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["AMELIYAT_KODU"]);
                }
            }

            public SurgeryProcedureGroup? Ameliyat_grubu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYAT_GRUBU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYDEFINITION"].AllPropertyDefs["SUTGROUP"].DataType;
                    return (SurgeryProcedureGroup?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Hasta_hizmet_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_HIZMET_KODU"]);
                }
            }

            public Object Kesi_sayisi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KESI_SAYISI"]);
                }
            }

            public Object Kesi_orani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["KESI_ORANI"]);
                }
            }

            public Guid? Kesi_seans_bilgisi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KESI_SEANS_BILGISI"]);
                }
            }

            public SurgeryLeftRight? Taraf_bilgisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TARAF_BILGISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYPROCEDURE"].AllPropertyDefs["POSITION"].DataType;
                    return (SurgeryLeftRight?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Komplikasyon
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOMPLIKASYON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["ISCOMPLICATIONSURGERY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Ameliyat_sonucu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMELIYAT_SONUCU"]);
                }
            }

            public object Ameliyat_notu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMELIYAT_NOTU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERY"].AllPropertyDefs["SURGERYREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public AnesthesiaASATypeEnum? Asa_skoru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASA_SKORU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ASATYPE"].DataType;
                    return (AnesthesiaASATypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Euro_bilgisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EURO_BILGISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EUROSCOREOFPROCEDURE"].AllPropertyDefs["SCORE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Object Yara_sinifi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YARA_SINIFI"]);
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

            public VEM_AMELIYAT_ISLEM_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_AMELIYAT_ISLEM_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_AMELIYAT_ISLEM_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<BaseSurgeryProcedure.VEM_AMELIYAT_Class> VEM_AMELIYAT(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASESURGERYPROCEDURE"].QueryDefs["VEM_AMELIYAT"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseSurgeryProcedure.VEM_AMELIYAT_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseSurgeryProcedure.VEM_AMELIYAT_Class> VEM_AMELIYAT(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASESURGERYPROCEDURE"].QueryDefs["VEM_AMELIYAT"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseSurgeryProcedure.VEM_AMELIYAT_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseSurgeryProcedure.VEM_AMELIYAT_ISLEM_Class> VEM_AMELIYAT_ISLEM(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASESURGERYPROCEDURE"].QueryDefs["VEM_AMELIYAT_ISLEM"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseSurgeryProcedure.VEM_AMELIYAT_ISLEM_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseSurgeryProcedure.VEM_AMELIYAT_ISLEM_Class> VEM_AMELIYAT_ISLEM(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASESURGERYPROCEDURE"].QueryDefs["VEM_AMELIYAT_ISLEM"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseSurgeryProcedure.VEM_AMELIYAT_ISLEM_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Taraf
    /// </summary>
        public SurgeryLeftRight? Position
        {
            get { return (SurgeryLeftRight?)(int?)this["POSITION"]; }
            set { this["POSITION"] = value; }
        }

    /// <summary>
    /// Kesi Bilgisi
    /// </summary>
        public IncisionType? IncisionType
        {
            get { return (IncisionType?)(int?)this["INCISIONTYPE"]; }
            set { this["INCISIONTYPE"] = value; }
        }

    /// <summary>
    /// Ameliyat İsmi Detaylı Tanım
    /// </summary>
        public object DescriptionOfProcedureObject
        {
            get { return (object)this["DESCRIPTIONOFPROCEDUREOBJECT"]; }
            set { this["DESCRIPTIONOFPROCEDUREOBJECT"] = value; }
        }

    /// <summary>
    /// Diş Numarası
    /// </summary>
        public string ToothNumber
        {
            get { return (string)this["TOOTHNUMBER"]; }
            set { this["TOOTHNUMBER"] = value; }
        }

    /// <summary>
    /// Anomali
    /// </summary>
        public bool? ToothAnomaly
        {
            get { return (bool?)this["TOOTHANOMALY"]; }
            set { this["TOOTHANOMALY"] = value; }
        }

    /// <summary>
    /// Diş Taahhüt Numarası
    /// </summary>
        public int? ToothCommitmentNumber
        {
            get { return (int?)this["TOOTHCOMMITMENTNUMBER"]; }
            set { this["TOOTHCOMMITMENTNUMBER"] = value; }
        }

    /// <summary>
    /// Paket Başlangıç Tarihi
    /// </summary>
        public DateTime? PackageStartDate
        {
            get { return (DateTime?)this["PACKAGESTARTDATE"]; }
            set { this["PACKAGESTARTDATE"] = value; }
        }

    /// <summary>
    /// Paket Bitiş Tarihi
    /// </summary>
        public DateTime? PackageEndDate
        {
            get { return (DateTime?)this["PACKAGEENDDATE"]; }
            set { this["PACKAGEENDDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

        public PackageProcedureDefinition PackageProcedureObject
        {
            get { return (PackageProcedureDefinition)((ITTObject)this).GetParent("PACKAGEPROCEDUREOBJECT"); }
            set { this["PACKAGEPROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseSurgeryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseSurgeryProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseSurgeryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseSurgeryProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseSurgeryProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASESURGERYPROCEDURE", dataRow) { }
        protected BaseSurgeryProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASESURGERYPROCEDURE", dataRow, isImported) { }
        public BaseSurgeryProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseSurgeryProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseSurgeryProcedure() : base() { }

    }
}