
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankBloodProducts")] 

    /// <summary>
    /// Kan Ürünleri(Testler)
    /// </summary>
    public  partial class BloodBankBloodProducts : SubactionProcedureFlowable, IWorkList
    {
        public class BloodBankBloodProductsList : TTObjectCollection<BloodBankBloodProducts> { }
                    
        public class ChildBloodBankBloodProductsCollection : TTObject.TTChildObjectCollection<BloodBankBloodProducts>
        {
            public ChildBloodBankBloodProductsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankBloodProductsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBloodProductBySubEpisode_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ProductNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Returned
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].AllPropertyDefs["RETURNED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetBloodProductBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBloodProductBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBloodProductBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBloodProductByEpisode_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ProductNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Returned
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].AllPropertyDefs["RETURNED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACTION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetBloodProductByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBloodProductByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBloodProductByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetBloodProducts_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? RequestDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTDOCTOR"]);
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

            public Guid? Fromres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FROMRES"]);
                }
            }

            public Guid? Masres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASRES"]);
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

            public string Product
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BLOODPRODUCTREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetBloodProducts_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetBloodProducts_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetBloodProducts_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Waiting { get { return new Guid("a33e04d0-a0b7-4741-9c1a-55ceeaa1119e"); } }
            public static Guid Accepted { get { return new Guid("f2ef4e46-d664-47a2-86ab-64b251b62c8d"); } }
            public static Guid TransfusionCompleted { get { return new Guid("69688edd-c137-479f-b0a1-df3d22ec0324"); } }
            public static Guid Completed { get { return new Guid("bac4a77e-d5ee-4bb3-99db-07a435d7ac7b"); } }
            public static Guid New { get { return new Guid("5874f003-eab2-4044-9658-100fd9c11c24"); } }
            public static Guid Cancelled { get { return new Guid("3e25b8f3-1ada-49e8-bc92-d77ca7624016"); } }
    /// <summary>
    /// İade Edildi
    /// </summary>
            public static Guid ReturnToBloodBank { get { return new Guid("9cfcf6d3-6013-4ef5-b4cd-bfd907b00df4"); } }
            public static Guid Reserved { get { return new Guid("530be19d-7a17-4bc1-b3cf-794f2a93a848"); } }
        }

        public static BindingList<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class> GetBloodProductBySubEpisode(Guid SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].QueryDefs["GetBloodProductBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class> GetBloodProductBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].QueryDefs["GetBloodProductBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BloodBankBloodProducts> GetExpiredBloodProductsToCancel(TTObjectContext objectContext, DateTime CHECKDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].QueryDefs["GetExpiredBloodProductsToCancel"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CHECKDATE", CHECKDATE);

            return ((ITTQuery)objectContext).QueryObjects<BloodBankBloodProducts>(queryDef, paramList);
        }

        public static BindingList<BloodBankBloodProducts.GetBloodProductByEpisode_Class> GetBloodProductByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].QueryDefs["GetBloodProductByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BloodBankBloodProducts.GetBloodProductByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BloodBankBloodProducts.GetBloodProductByEpisode_Class> GetBloodProductByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].QueryDefs["GetBloodProductByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<BloodBankBloodProducts.GetBloodProductByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BloodBankBloodProducts.OLAP_GetBloodProducts_Class> OLAP_GetBloodProducts(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].QueryDefs["OLAP_GetBloodProducts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<BloodBankBloodProducts.OLAP_GetBloodProducts_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BloodBankBloodProducts.OLAP_GetBloodProducts_Class> OLAP_GetBloodProducts(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].QueryDefs["OLAP_GetBloodProducts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<BloodBankBloodProducts.OLAP_GetBloodProducts_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BloodBankBloodProducts> GetExpiredBloodProducts(TTObjectContext objectContext, DateTime CHECKDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].QueryDefs["GetExpiredBloodProducts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CHECKDATE", CHECKDATE);

            return ((ITTQuery)objectContext).QueryObjects<BloodBankBloodProducts>(queryDef, paramList);
        }

        public static BindingList<BloodBankBloodProducts> GetBloodProductsByExternalID(TTObjectContext objectContext, string EXTERNALID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BLOODBANKBLOODPRODUCTS"].QueryDefs["GetBloodProductsByExternalID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALID", EXTERNALID);

            return ((ITTQuery)objectContext).QueryObjects<BloodBankBloodProducts>(queryDef, paramList);
        }

    /// <summary>
    /// ISBT ünite numarası
    /// </summary>
        public string ISBTUnitNumber
        {
            get { return (string)this["ISBTUNITNUMBER"]; }
            set { this["ISBTUNITNUMBER"] = value; }
        }

    /// <summary>
    /// Kullanıldı
    /// </summary>
        public bool? Used
        {
            get { return (bool?)this["USED"]; }
            set { this["USED"] = value; }
        }

    /// <summary>
    /// Torba No
    /// </summary>
        public string ProductNumber
        {
            get { return (string)this["PRODUCTNUMBER"]; }
            set { this["PRODUCTNUMBER"] = value; }
        }

        public DateTime? ProductDate
        {
            get { return (DateTime?)this["PRODUCTDATE"]; }
            set { this["PRODUCTDATE"] = value; }
        }

    /// <summary>
    /// Filtreleme
    /// </summary>
        public bool? IsFilter
        {
            get { return (bool?)this["ISFILTER"]; }
            set { this["ISFILTER"] = value; }
        }

    /// <summary>
    /// İade
    /// </summary>
        public bool? Returned
        {
            get { return (bool?)this["RETURNED"]; }
            set { this["RETURNED"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Notes
        {
            get { return (string)this["NOTES"]; }
            set { this["NOTES"] = value; }
        }

    /// <summary>
    /// ISBT bileşen kodu
    /// </summary>
        public string ISBTElementCode
        {
            get { return (string)this["ISBTELEMENTCODE"]; }
            set { this["ISBTELEMENTCODE"] = value; }
        }

    /// <summary>
    /// Işınlama
    /// </summary>
        public bool? IsIsinlama
        {
            get { return (bool?)this["ISISINLAMA"]; }
            set { this["ISISINLAMA"] = value; }
        }

    /// <summary>
    /// Kan bankası sisteminden istenilen ürünün ID bilgisi
    /// </summary>
        public string BloodProductExternalID
        {
            get { return (string)this["BLOODPRODUCTEXTERNALID"]; }
            set { this["BLOODPRODUCTEXTERNALID"] = value; }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BloodProductRequest BloodProductRequest
        {
            get 
            {   
                if (EpisodeAction is BloodProductRequest)
                    return (BloodProductRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("343149df-7ca1-4704-b647-59a27d9c143d"));
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

        override protected void CreateChildSubActionProcedureCollectionViews()
        {
            base.CreateChildSubActionProcedureCollectionViews();
            _BloodBankSubProducts = new BloodBankSubProduct.ChildBloodBankSubProductCollection(_ChildSubActionProcedure, "BloodBankSubProducts");
        }

        private BloodBankSubProduct.ChildBloodBankSubProductCollection _BloodBankSubProducts = null;
        public BloodBankSubProduct.ChildBloodBankSubProductCollection BloodBankSubProducts
        {
            get
            {
                if (_ChildSubActionProcedure == null)
                    CreateChildSubActionProcedureCollection();
                return _BloodBankSubProducts;
            }            
        }

        protected BloodBankBloodProducts(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankBloodProducts(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankBloodProducts(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankBloodProducts(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankBloodProducts(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKBLOODPRODUCTS", dataRow) { }
        protected BloodBankBloodProducts(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKBLOODPRODUCTS", dataRow, isImported) { }
        public BloodBankBloodProducts(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankBloodProducts(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankBloodProducts() : base() { }

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