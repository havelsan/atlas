
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Store")] 

    /// <summary>
    /// Depo tanımları için kullanılan ana sınıftır. Her türlü depo tanımı için kullanılan sınıflar bu sınıftan türer
    /// </summary>
    public  partial class Store : TTDefinitionSet, IStore
    {
        public class StoreList : TTObjectCollection<Store> { }
                    
        public class ChildStoreCollection : TTObject.TTChildObjectCollection<Store>
        {
            public ChildStoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class StoreListBySubTypeNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StoreListBySubTypeNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StoreListBySubTypeNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StoreListBySubTypeNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStoreNamesReportQuery_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetStoreNamesReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStoreNamesReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStoreNamesReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllStoreReportNQL_Class : TTReportNqlObject 
        {
            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetAllStoreReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllStoreReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllStoreReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_DEPO_Class : TTReportNqlObject 
        {
            public Guid? Depo_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPO_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Depo_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPO_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Depo_turu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEPO_TURU"]);
                }
            }

            public Object Bina_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BINA_KODU"]);
                }
            }

            public Object Mkys_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MKYS_KODU"]);
                }
            }

            public Object Mkys_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MKYS_KULLANICI_KODU"]);
                }
            }

            public Object Mkys_kullanici_sifresi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MKYS_KULLANICI_SIFRESI"]);
                }
            }

            public OpenCloseEnum? Aktiflik_bilgisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKTIFLIK_BILGISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["STATUS"].DataType;
                    return (OpenCloseEnum?)(int)dataType.ConvertValue(val);
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

            public VEM_DEPO_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_DEPO_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_DEPO_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveStores_Class : TTReportNqlObject 
        {
            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
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

            public GetActiveStores_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveStores_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveStores_Class() : base() { }
        }

        public static BindingList<Store.StoreListBySubTypeNQL_Class> StoreListBySubTypeNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["StoreListBySubTypeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.StoreListBySubTypeNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Store.StoreListBySubTypeNQL_Class> StoreListBySubTypeNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["StoreListBySubTypeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.StoreListBySubTypeNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Store.GetStoreNamesReportQuery_Class> GetStoreNamesReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["GetStoreNamesReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.GetStoreNamesReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Store.GetStoreNamesReportQuery_Class> GetStoreNamesReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["GetStoreNamesReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.GetStoreNamesReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Store> OLAP_Store(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["OLAP_Store"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Store>(queryDef, paramList);
        }

        public static BindingList<Store> GetAllStores(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["GetAllStores"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Store>(queryDef, paramList);
        }

        public static BindingList<Store.GetAllStoreReportNQL_Class> GetAllStoreReportNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["GetAllStoreReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.GetAllStoreReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Store.GetAllStoreReportNQL_Class> GetAllStoreReportNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["GetAllStoreReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.GetAllStoreReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Store.VEM_DEPO_Class> VEM_DEPO(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["VEM_DEPO"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.VEM_DEPO_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Store.VEM_DEPO_Class> VEM_DEPO(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["VEM_DEPO"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.VEM_DEPO_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Store.GetActiveStores_Class> GetActiveStores(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["GetActiveStores"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.GetActiveStores_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Store.GetActiveStores_Class> GetActiveStores(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STORE"].QueryDefs["GetActiveStores"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Store.GetActiveStores_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public OpenCloseEnum? Status
        {
            get { return (OpenCloseEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Hızlı Referans
    /// </summary>
        public string QREF
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Otomatik İade Belgesi Oluştur
    /// </summary>
        public bool? AutoReturningDocumentCreat
        {
            get { return (bool?)this["AUTORETURNINGDOCUMENTCREAT"]; }
            set { this["AUTORETURNINGDOCUMENTCREAT"] = value; }
        }

    /// <summary>
    /// MKYS Deposu
    /// </summary>
        public bool? MkysStore
        {
            get { return (bool?)this["MKYSSTORE"]; }
            set { this["MKYSSTORE"] = value; }
        }

    /// <summary>
    /// Acil Depo
    /// </summary>
        public bool? IsEmergencyStore
        {
            get { return (bool?)this["ISEMERGENCYSTORE"]; }
            set { this["ISEMERGENCYSTORE"] = value; }
        }

    /// <summary>
    /// MKYSStore
    /// </summary>
        public UnitStoreGetData UnitStoreGetData
        {
            get { return (UnitStoreGetData)((ITTObject)this).GetParent("UNITSTOREGETDATA"); }
            set { this["UNITSTOREGETDATA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStocksCollection()
        {
            _Stocks = new Stock.ChildStockCollection(this, new Guid("9942fc0a-bf92-4e46-9545-2da7e09b22e9"));
            ((ITTChildObjectCollection)_Stocks).GetChildren();
        }

        protected Stock.ChildStockCollection _Stocks = null;
    /// <summary>
    /// Child collection for Depo-Stoklar
    /// </summary>
        public Stock.ChildStockCollection Stocks
        {
            get
            {
                if (_Stocks == null)
                    CreateStocksCollection();
                return _Stocks;
            }
        }

        virtual protected void CreateAnnualRequirement_StoreStocksCollection()
        {
            _AnnualRequirement_StoreStocks = new AnnualRequirement_StoreStock.ChildAnnualRequirement_StoreStockCollection(this, new Guid("0389b4c3-9cc9-4cec-9b71-95670207a2bc"));
            ((ITTChildObjectCollection)_AnnualRequirement_StoreStocks).GetChildren();
        }

        protected AnnualRequirement_StoreStock.ChildAnnualRequirement_StoreStockCollection _AnnualRequirement_StoreStocks = null;
        public AnnualRequirement_StoreStock.ChildAnnualRequirement_StoreStockCollection AnnualRequirement_StoreStocks
        {
            get
            {
                if (_AnnualRequirement_StoreStocks == null)
                    CreateAnnualRequirement_StoreStocksCollection();
                return _AnnualRequirement_StoreStocks;
            }
        }

        virtual protected void CreateStoreSMSUsersCollection()
        {
            _StoreSMSUsers = new StoreSMSUser.ChildStoreSMSUserCollection(this, new Guid("7bfd9d34-e996-471a-b9ae-96e237cff7d2"));
            ((ITTChildObjectCollection)_StoreSMSUsers).GetChildren();
        }

        protected StoreSMSUser.ChildStoreSMSUserCollection _StoreSMSUsers = null;
        public StoreSMSUser.ChildStoreSMSUserCollection StoreSMSUsers
        {
            get
            {
                if (_StoreSMSUsers == null)
                    CreateStoreSMSUsersCollection();
                return _StoreSMSUsers;
            }
        }

        protected Store(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Store(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Store(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Store(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Store(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STORE", dataRow) { }
        protected Store(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STORE", dataRow, isImported) { }
        public Store(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Store(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Store() : base() { }

    }
}