
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DemandDetail")] 

    /// <summary>
    /// Malzeme/Hizmet İstek modülünde her istek kalemi için detayların ana sınıfıdır
    /// </summary>
    public  partial class DemandDetail : TTObject
    {
        public class DemandDetailList : TTObjectCollection<DemandDetail> { }
                    
        public class ChildDemandDetailCollection : TTObject.TTChildObjectCollection<DemandDetail>
        {
            public ChildDemandDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDemandDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SatınalmaIstek_DemandDetailQuery_Class : TTReportNqlObject 
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

            public bool? Cancelled
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CANCELLED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["CANCELLED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? AccountancyAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["ACCOUNTANCYAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? StoreStocks
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORESTOCKS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["STORESTOCKS"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ClinicApprovedAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICAPPROVEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["CLINICAPPROVEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string SpRefToAdMatters
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPREFTOADMATTERS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["SPREFTOADMATTERS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? TransferAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSFERAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["TRANSFERAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FeasibilityEtude
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FEASIBILITYETUDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["FEASIBILITYETUDE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string TechnicalSpecificationNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICALSPECIFICATIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["TECHNICALSPECIFICATIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Purchaseitemclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEITEMCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SatınalmaIstek_DemandDetailQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SatınalmaIstek_DemandDetailQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SatınalmaIstek_DemandDetailQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetManagerialMatterReportQuery_Class : TTReportNqlObject 
        {
            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Nsn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NSN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SpRefToAdMatters
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPREFTOADMATTERS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["SPREFTOADMATTERS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicalSpecificationNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICALSPECIFICATIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["TECHNICALSPECIFICATIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? AccountancyAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["ACCOUNTANCYAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ClinicApprovedAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLINICAPPROVEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["CLINICAPPROVEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? StoreStocks
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORESTOCKS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].AllPropertyDefs["STORESTOCKS"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetManagerialMatterReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetManagerialMatterReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetManagerialMatterReportQuery_Class() : base() { }
        }

        public static BindingList<DemandDetail.SatınalmaIstek_DemandDetailQuery_Class> SatınalmaIstek_DemandDetailQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].QueryDefs["SatınalmaIstek_DemandDetailQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DemandDetail.SatınalmaIstek_DemandDetailQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DemandDetail.SatınalmaIstek_DemandDetailQuery_Class> SatınalmaIstek_DemandDetailQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].QueryDefs["SatınalmaIstek_DemandDetailQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DemandDetail.SatınalmaIstek_DemandDetailQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DemandDetail.GetManagerialMatterReportQuery_Class> GetManagerialMatterReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].QueryDefs["GetManagerialMatterReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DemandDetail.GetManagerialMatterReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DemandDetail.GetManagerialMatterReportQuery_Class> GetManagerialMatterReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEMANDDETAIL"].QueryDefs["GetManagerialMatterReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DemandDetail.GetManagerialMatterReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İptal
    /// </summary>
        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

    /// <summary>
    /// Saymanlık Mevcudu
    /// </summary>
        public Currency? AccountancyAmount
        {
            get { return (Currency?)this["ACCOUNTANCYAMOUNT"]; }
            set { this["ACCOUNTANCYAMOUNT"] = value; }
        }

    /// <summary>
    /// Bağlı malzemelerin toplam mevcudu
    /// </summary>
        public Currency? StoreStocks
        {
            get { return (Currency?)this["STORESTOCKS"]; }
            set { this["STORESTOCKS"] = value; }
        }

    /// <summary>
    /// Klinik Onay Miktarı
    /// </summary>
        public Currency? ClinicApprovedAmount
        {
            get { return (Currency?)this["CLINICAPPROVEDAMOUNT"]; }
            set { this["CLINICAPPROVEDAMOUNT"] = value; }
        }

    /// <summary>
    /// İdari Şartnameye Atıfta Bulunan Hususlar
    /// </summary>
        public string SpRefToAdMatters
        {
            get { return (string)this["SPREFTOADMATTERS"]; }
            set { this["SPREFTOADMATTERS"] = value; }
        }

    /// <summary>
    /// Muvazene Miktarı
    /// </summary>
        public Currency? TransferAmount
        {
            get { return (Currency?)this["TRANSFERAMOUNT"]; }
            set { this["TRANSFERAMOUNT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string DetailDescription
        {
            get { return (string)this["DETAILDESCRIPTION"]; }
            set { this["DETAILDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Olurluk Etüdü
    /// </summary>
        public string FeasibilityEtude
        {
            get { return (string)this["FEASIBILITYETUDE"]; }
            set { this["FEASIBILITYETUDE"] = value; }
        }

    /// <summary>
    /// Miktarı
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İstek Miktarı
    /// </summary>
        public Currency? RequestAmount
        {
            get { return (Currency?)this["REQUESTAMOUNT"]; }
            set { this["REQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// Teknik Şartname Nu
    /// </summary>
        public string TechnicalSpecificationNo
        {
            get { return (string)this["TECHNICALSPECIFICATIONNO"]; }
            set { this["TECHNICALSPECIFICATIONNO"] = value; }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnnualRequirementDetailOutOfList AnnualRequirementDetOutOfList
        {
            get { return (AnnualRequirementDetailOutOfList)((ITTObject)this).GetParent("ANNUALREQUIREMENTDETOUTOFLIST"); }
            set { this["ANNUALREQUIREMENTDETOUTOFLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Demand Demand
        {
            get { return (Demand)((ITTObject)this).GetParent("DEMAND"); }
            set { this["DEMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProjectDetail PurchaseProjectDetail
        {
            get { return (PurchaseProjectDetail)((ITTObject)this).GetParent("PURCHASEPROJECTDETAIL"); }
            set { this["PURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnnualRequirementDetailInList AnnualRequirementDetailInList
        {
            get { return (AnnualRequirementDetailInList)((ITTObject)this).GetParent("ANNUALREQUIREMENTDETAILINLIST"); }
            set { this["ANNUALREQUIREMENTDETAILINLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DemandDetailStoreStock TmpDemandDetailStoreStock
        {
            get { return (DemandDetailStoreStock)((ITTObject)this).GetParent("TMPDEMANDDETAILSTORESTOCK"); }
            set { this["TMPDEMANDDETAILSTORESTOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDemandDetailStoreStocksCollection()
        {
            _DemandDetailStoreStocks = new DemandDetailStoreStock.ChildDemandDetailStoreStockCollection(this, new Guid("c881d2ff-4cb8-4848-8a28-26b65aee326d"));
            ((ITTChildObjectCollection)_DemandDetailStoreStocks).GetChildren();
        }

        protected DemandDetailStoreStock.ChildDemandDetailStoreStockCollection _DemandDetailStoreStocks = null;
        public DemandDetailStoreStock.ChildDemandDetailStoreStockCollection DemandDetailStoreStocks
        {
            get
            {
                if (_DemandDetailStoreStocks == null)
                    CreateDemandDetailStoreStocksCollection();
                return _DemandDetailStoreStocks;
            }
        }

        protected DemandDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DemandDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DemandDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DemandDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DemandDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEMANDDETAIL", dataRow) { }
        protected DemandDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEMANDDETAIL", dataRow, isImported) { }
        public DemandDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DemandDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DemandDetail() : base() { }

    }
}