
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientFolderTransaction")] 

    /// <summary>
    /// Dosya hareketleri
    /// </summary>
    public  partial class PatientFolderTransaction : TTObject
    {
        public class PatientFolderTransactionList : TTObjectCollection<PatientFolderTransaction> { }
                    
        public class ChildPatientFolderTransactionCollection : TTObject.TTChildObjectCollection<PatientFolderTransaction>
        {
            public ChildPatientFolderTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientFolderTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class VEM_HASTA_ARSIV_HAREKET_Class : TTReportNqlObject 
        {
            public Guid? Hasta_arsiv_hareket_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_ARSIV_HAREKET_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public Guid? Hasta_arsiv_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA_ARSIV_KODU"]);
                }
            }

            public Object Hasta_basvuru_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HASTA_BASVURU_KODU"]);
                }
            }

            public Guid? Alan_birim_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ALAN_BIRIM_KODU"]);
                }
            }

            public DateTime? Alindigi_zaman
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALINDIGI_ZAMAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDERTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Alan_kullanici_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ALAN_KULLANICI_KODU"]);
                }
            }

            public Object Veren_birim_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["VEREN_BIRIM_KODU"]);
                }
            }

            public Object Verildigi_zaman
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["VERILDIGI_ZAMAN"]);
                }
            }

            public Object Veren_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["VEREN_KULLANICI_KODU"]);
                }
            }

            public Object Aciklama
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                }
            }

            public DateTime? Kayit_zamani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KAYIT_ZAMANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDERTRANSACTION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public VEM_HASTA_ARSIV_HAREKET_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_HASTA_ARSIV_HAREKET_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_HASTA_ARSIV_HAREKET_Class() : base() { }
        }

        public static BindingList<PatientFolderTransaction.VEM_HASTA_ARSIV_HAREKET_Class> VEM_HASTA_ARSIV_HAREKET(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDERTRANSACTION"].QueryDefs["VEM_HASTA_ARSIV_HAREKET"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientFolderTransaction.VEM_HASTA_ARSIV_HAREKET_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientFolderTransaction.VEM_HASTA_ARSIV_HAREKET_Class> VEM_HASTA_ARSIV_HAREKET(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTFOLDERTRANSACTION"].QueryDefs["VEM_HASTA_ARSIV_HAREKET"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientFolderTransaction.VEM_HASTA_ARSIV_HAREKET_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İşlem No
    /// </summary>
        public long? TransactionID
        {
            get { return (long?)this["TRANSACTIONID"]; }
            set { this["TRANSACTIONID"] = value; }
        }

    /// <summary>
    /// İşlem Tipi
    /// </summary>
        public FolderTransactionTypeEnum? TransactionType
        {
            get { return (FolderTransactionTypeEnum?)(int?)this["TRANSACTIONTYPE"]; }
            set { this["TRANSACTIONTYPE"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? TransactionDate
        {
            get { return (DateTime?)this["TRANSACTIONDATE"]; }
            set { this["TRANSACTIONDATE"] = value; }
        }

    /// <summary>
    /// İşlemi Yapan Kullanıcı
    /// </summary>
        public ResUser TransactionUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("TRANSACTIONUSER"); }
            set { this["TRANSACTIONUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dosyanın Yeri
    /// </summary>
        public ResSection FolderLocation
        {
            get { return (ResSection)((ITTObject)this).GetParent("FOLDERLOCATION"); }
            set { this["FOLDERLOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta Dosyası Hareketleri
    /// </summary>
        public PatientFolder PatientFolder
        {
            get { return (PatientFolder)((ITTObject)this).GetParent("PATIENTFOLDER"); }
            set { this["PATIENTFOLDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientFolderTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientFolderTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientFolderTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientFolderTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientFolderTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTFOLDERTRANSACTION", dataRow) { }
        protected PatientFolderTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTFOLDERTRANSACTION", dataRow, isImported) { }
        public PatientFolderTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientFolderTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientFolderTransaction() : base() { }

    }
}