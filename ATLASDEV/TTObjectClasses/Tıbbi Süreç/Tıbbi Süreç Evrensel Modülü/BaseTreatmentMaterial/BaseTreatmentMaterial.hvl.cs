
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseTreatmentMaterial")] 

    /// <summary>
    /// Ana Tedavi Sarf Tabı
    /// </summary>
    public  partial class BaseTreatmentMaterial : SubActionMaterial, IMedulaChildOfEpisodeAction
    {
        public class BaseTreatmentMaterialList : TTObjectCollection<BaseTreatmentMaterial> { }
                    
        public class ChildBaseTreatmentMaterialCollection : TTObject.TTChildObjectCollection<BaseTreatmentMaterial>
        {
            public ChildBaseTreatmentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseTreatmentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTreatmentMaterialByEpisode_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetTreatmentMaterialByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTreatmentMaterialByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTreatmentMaterialByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTreatmentMaterialsByNSNAndStore_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ELIGIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["PRICINGDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["DONORID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["USEAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["UBBCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Kdv
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KDV"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["KDV"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MalzemeBrans
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMEBRANS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["MALZEMEBRANS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MalzemeSatinAlisTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMESATINALISTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["MALZEMESATINALISTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? KodsuzMalzemeFiyati
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODSUZMALZEMEFIYATI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["KODSUZMALZEMEFIYATI"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string DealerNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEALERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["DEALERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTreatmentMaterialsByNSNAndStore_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTreatmentMaterialsByNSNAndStore_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTreatmentMaterialsByNSNAndStore_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTreatmentMaterialBySubEpisode_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetTreatmentMaterialBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTreatmentMaterialBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTreatmentMaterialBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_STOK_FIS_Class : TTReportNqlObject 
        {
            public Guid? Stok_fis_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOK_FIS_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Object Bagli_malzeme_hareket_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BAGLI_MALZEME_HAREKET_KODU"]);
                }
            }

            public Guid? Depo_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPO_KODU"]);
                }
            }

            public Object Hareket_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HAREKET_TURU"]);
                }
            }

            public Object Mkys_ayniyat_makbuz_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MKYS_AYNIYAT_MAKBUZ_KODU"]);
                }
            }

            public DateTime? Hareket_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HAREKET_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Toplam_tutar
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOPLAM_TUTAR"]);
                }
            }

            public Guid? Hasta_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_KODU"]);
                }
            }

            public Guid? Hasta_basvuru_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Object Hareket_sekli
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HAREKET_SEKLI"]);
                }
            }

            public Object Islemi_yapan_personel_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ISLEMI_YAPAN_PERSONEL_KODU"]);
                }
            }

            public DateTime? Islem_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEM_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Firma_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FIRMA_KODU"]);
                }
            }

            public Object Ihale_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IHALE_NUMARASI"]);
                }
            }

            public Object Ihale_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IHALE_TARIHI"]);
                }
            }

            public Object Ihale_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IHALE_TURU"]);
                }
            }

            public string Muayene_numarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENE_NUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Muayene_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUAYENE_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Teslim_eden
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TESLIM_EDEN"]);
                }
            }

            public Object Teslim_eden_unvani
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TESLIM_EDEN_UNVANI"]);
                }
            }

            public Object Butce_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BUTCE_TURU"]);
                }
            }

            public Object Fatura_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FATURA_NUMARASI"]);
                }
            }

            public Object Fatura_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["FATURA_TARIHI"]);
                }
            }

            public Object Irsaliye_numarasi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IRSALIYE_NUMARASI"]);
                }
            }

            public Object Irsaliye_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["IRSALIYE_TARIHI"]);
                }
            }

            public Object Mkys_stok_hareket_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MKYS_STOK_HAREKET_KODU"]);
                }
            }

            public Object Mkys_kurum_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MKYS_KURUM_KODU"]);
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

            public Guid? StockCard
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKCARD"]);
                }
            }

            public VEM_STOK_FIS_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_STOK_FIS_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_STOK_FIS_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForTreatmentMaterial_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForTreatmentMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForTreatmentMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForTreatmentMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoCountForTreatmentMaterial_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOldInfoCountForTreatmentMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoCountForTreatmentMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoCountForTreatmentMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnnotifiedUsedMaterialBySource_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Utsusenotification
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UTSUSENOTIFICATION"]);
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

            public GetUnnotifiedUsedMaterialBySource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnnotifiedUsedMaterialBySource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnnotifiedUsedMaterialBySource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTreatmentMatByParameter_Class : TTReportNqlObject 
        {
            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjectdefid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTDEFID"]);
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

            public GetTreatmentMatByParameter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTreatmentMatByParameter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTreatmentMatByParameter_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("992adf01-83e6-4cfd-8b2d-b4e5ec7c6ce9"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("5b5b0e4f-bc4f-46dc-b5c8-6b64c3add14c"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ca1c1c02-0674-47ad-ae79-e1bb1503065d"); } }
        }

        public static BindingList<BaseTreatmentMaterial.GetTreatmentMaterialByEpisode_Class> GetTreatmentMaterialByEpisode(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetTreatmentMaterialByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetTreatmentMaterialByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseTreatmentMaterial.GetTreatmentMaterialByEpisode_Class> GetTreatmentMaterialByEpisode(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetTreatmentMaterialByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetTreatmentMaterialByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseTreatmentMaterial> GetMaterialByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetMaterialByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<BaseTreatmentMaterial>(queryDef, paramList);
        }

        public static BindingList<BaseTreatmentMaterial.GetTreatmentMaterialsByNSNAndStore_Class> GetTreatmentMaterialsByNSNAndStore(string NATOSTOCKNO, string STORE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetTreatmentMaterialsByNSNAndStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NATOSTOCKNO", NATOSTOCKNO);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetTreatmentMaterialsByNSNAndStore_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseTreatmentMaterial.GetTreatmentMaterialsByNSNAndStore_Class> GetTreatmentMaterialsByNSNAndStore(TTObjectContext objectContext, string NATOSTOCKNO, string STORE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetTreatmentMaterialsByNSNAndStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NATOSTOCKNO", NATOSTOCKNO);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetTreatmentMaterialsByNSNAndStore_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseTreatmentMaterial.GetTreatmentMaterialBySubEpisode_Class> GetTreatmentMaterialBySubEpisode(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetTreatmentMaterialBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetTreatmentMaterialBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseTreatmentMaterial.GetTreatmentMaterialBySubEpisode_Class> GetTreatmentMaterialBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetTreatmentMaterialBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetTreatmentMaterialBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseTreatmentMaterial> GetMaterialBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetMaterialBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<BaseTreatmentMaterial>(queryDef, paramList);
        }

        public static BindingList<BaseTreatmentMaterial.VEM_STOK_FIS_Class> VEM_STOK_FIS(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["VEM_STOK_FIS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.VEM_STOK_FIS_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseTreatmentMaterial.VEM_STOK_FIS_Class> VEM_STOK_FIS(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["VEM_STOK_FIS"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.VEM_STOK_FIS_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Malzeme Sarf
    /// </summary>
        public static BindingList<BaseTreatmentMaterial.GetOldInfoForTreatmentMaterial_Class> GetOldInfoForTreatmentMaterial(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetOldInfoForTreatmentMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetOldInfoForTreatmentMaterial_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Geçmişi Malzeme Sarf
    /// </summary>
        public static BindingList<BaseTreatmentMaterial.GetOldInfoForTreatmentMaterial_Class> GetOldInfoForTreatmentMaterial(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetOldInfoForTreatmentMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetOldInfoForTreatmentMaterial_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseTreatmentMaterial.GetOldInfoCountForTreatmentMaterial_Class> GetOldInfoCountForTreatmentMaterial(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetOldInfoCountForTreatmentMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetOldInfoCountForTreatmentMaterial_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseTreatmentMaterial.GetOldInfoCountForTreatmentMaterial_Class> GetOldInfoCountForTreatmentMaterial(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetOldInfoCountForTreatmentMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetOldInfoCountForTreatmentMaterial_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseTreatmentMaterial> GetUnnotifiedBaseTreatmentMaterialBySource(TTObjectContext objectContext, IList<Guid> ResourceIds, IList<Guid> StockActionDetailIds)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetUnnotifiedBaseTreatmentMaterialBySource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEIDS", ResourceIds);
            paramList.Add("STOCKACTIONDETAILIDS", StockActionDetailIds);

            return ((ITTQuery)objectContext).QueryObjects<BaseTreatmentMaterial>(queryDef, paramList);
        }

        public static BindingList<BaseTreatmentMaterial.GetUnnotifiedUsedMaterialBySource_Class> GetUnnotifiedUsedMaterialBySource(IList<Guid> ResourceIds, IList<Guid> StockActionDetailIds, bool ALLRESOURCES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetUnnotifiedUsedMaterialBySource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEIDS", ResourceIds);
            paramList.Add("STOCKACTIONDETAILIDS", StockActionDetailIds);
            paramList.Add("ALLRESOURCES", ALLRESOURCES);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetUnnotifiedUsedMaterialBySource_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseTreatmentMaterial.GetUnnotifiedUsedMaterialBySource_Class> GetUnnotifiedUsedMaterialBySource(TTObjectContext objectContext, IList<Guid> ResourceIds, IList<Guid> StockActionDetailIds, bool ALLRESOURCES, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetUnnotifiedUsedMaterialBySource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEIDS", ResourceIds);
            paramList.Add("STOCKACTIONDETAILIDS", StockActionDetailIds);
            paramList.Add("ALLRESOURCES", ALLRESOURCES);

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetUnnotifiedUsedMaterialBySource_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseTreatmentMaterial.GetTreatmentMatByParameter_Class> GetTreatmentMatByParameter(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetTreatmentMatByParameter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetTreatmentMatByParameter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseTreatmentMaterial.GetTreatmentMatByParameter_Class> GetTreatmentMatByParameter(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASETREATMENTMATERIAL"].QueryDefs["GetTreatmentMatByParameter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseTreatmentMaterial.GetTreatmentMatByParameter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// KDV
    /// </summary>
        public int? Kdv
        {
            get { return (int?)this["KDV"]; }
            set { this["KDV"] = value; }
        }

    /// <summary>
    /// Malzeme Branş Bilgisi
    /// </summary>
        public string MalzemeBrans
        {
            get { return (string)this["MALZEMEBRANS"]; }
            set { this["MALZEMEBRANS"] = value; }
        }

    /// <summary>
    /// Malzeme Satın Alış Tarihi
    /// </summary>
        public DateTime? MalzemeSatinAlisTarihi
        {
            get { return (DateTime?)this["MALZEMESATINALISTARIHI"]; }
            set { this["MALZEMESATINALISTARIHI"] = value; }
        }

    /// <summary>
    /// Kodsuz malzemenin fiyatı
    /// </summary>
        public double? KodsuzMalzemeFiyati
        {
            get { return (double?)this["KODSUZMALZEMEFIYATI"]; }
            set { this["KODSUZMALZEMEFIYATI"] = value; }
        }

        public double? UnitPrice
        {
            get { return (double?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

        public string DealerNo
        {
            get { return (string)this["DEALERNO"]; }
            set { this["DEALERNO"] = value; }
        }

        public SubactionProcedureFlowable SubactionProcedureFlowable
        {
            get { return (SubactionProcedureFlowable)((ITTObject)this).GetParent("SUBACTIONPROCEDUREFLOWABLE"); }
            set { this["SUBACTIONPROCEDUREFLOWABLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MalzemeBilgisi OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MalzemeBilgisi MalzemeTuru
    /// </summary>
        public MalzemeTuru MalzemeTuru
        {
            get { return (MalzemeTuru)((ITTObject)this).GetParent("MALZEMETURU"); }
            set { this["MALZEMETURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SetMaterial SetMaterial
        {
            get { return (SetMaterial)((ITTObject)this).GetParent("SETMATERIAL"); }
            set { this["SETMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("092a6179-99f0-42f2-8f79-d2192f19baa2"));
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

        override protected void CreateAccountTransactionsCollectionViews()
        {
            base.CreateAccountTransactionsCollectionViews();
        }

        protected BaseTreatmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseTreatmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseTreatmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseTreatmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseTreatmentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASETREATMENTMATERIAL", dataRow) { }
        protected BaseTreatmentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASETREATMENTMATERIAL", dataRow, isImported) { }
        public BaseTreatmentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseTreatmentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseTreatmentMaterial() : base() { }

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