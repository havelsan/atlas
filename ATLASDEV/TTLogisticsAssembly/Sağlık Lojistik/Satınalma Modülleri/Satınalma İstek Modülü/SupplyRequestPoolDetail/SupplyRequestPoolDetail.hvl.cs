
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SupplyRequestPoolDetail")] 

    /// <summary>
    /// Tedarik Talepleri Havuz Detayı
    /// </summary>
    public  partial class SupplyRequestPoolDetail : TTObject
    {
        public class SupplyRequestPoolDetailList : TTObjectCollection<SupplyRequestPoolDetail> { }
                    
        public class ChildSupplyRequestPoolDetailCollection : TTObject.TTChildObjectCollection<SupplyRequestPoolDetail>
        {
            public ChildSupplyRequestPoolDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSupplyRequestPoolDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSupplyRequestPoolDetRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Malzemeadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALZEMEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Tur
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TUR"]);
                }
            }

            public Currency? Istenenmiktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTENENMIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTPOOLDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Materialobjcetid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJCETID"]);
                }
            }

            public Guid? SupplyRequestPool
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUPPLYREQUESTPOOL"]);
                }
            }

            public Currency? Satinalmamiktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SATINALMAMIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTPOOLDETAIL"].AllPropertyDefs["PURCHASEAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Personel
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PERSONEL"]);
                }
            }

            public string Depo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSupplyRequestPoolDetRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSupplyRequestPoolDetRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSupplyRequestPoolDetRQ_Class() : base() { }
        }

        public static BindingList<SupplyRequestPoolDetail.GetSupplyRequestPoolDetRQ_Class> GetSupplyRequestPoolDetRQ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTPOOLDETAIL"].QueryDefs["GetSupplyRequestPoolDetRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SupplyRequestPoolDetail.GetSupplyRequestPoolDetRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SupplyRequestPoolDetail.GetSupplyRequestPoolDetRQ_Class> GetSupplyRequestPoolDetRQ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTPOOLDETAIL"].QueryDefs["GetSupplyRequestPoolDetRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SupplyRequestPoolDetail.GetSupplyRequestPoolDetRQ_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Redimo Kartı
    /// </summary>
        public int? RedimoStockCard
        {
            get { return (int?)this["REDIMOSTOCKCARD"]; }
            set { this["REDIMOSTOCKCARD"] = value; }
        }

    /// <summary>
    /// I.F ile Karşılanacak Miktar
    /// </summary>
        public Currency? ExcessAmount
        {
            get { return (Currency?)this["EXCESSAMOUNT"]; }
            set { this["EXCESSAMOUNT"] = value; }
        }

    /// <summary>
    /// Satınalmaya Çıkacak Miktar
    /// </summary>
        public Currency? PurchaseAmount
        {
            get { return (Currency?)this["PURCHASEAMOUNT"]; }
            set { this["PURCHASEAMOUNT"] = value; }
        }

    /// <summary>
    /// Toplam Talep Miktarı
    /// </summary>
        public Currency? TotalRequestAmount
        {
            get { return (Currency?)this["TOTALREQUESTAMOUNT"]; }
            set { this["TOTALREQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// İstenecek Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
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
    /// Talep Durumu
    /// </summary>
        public SupplyRqstPlDetStatusEnum? SupplyRqstPlDetStatus
        {
            get { return (SupplyRqstPlDetStatusEnum?)(int?)this["SUPPLYRQSTPLDETSTATUS"]; }
            set { this["SUPPLYRQSTPLDETSTATUS"] = value; }
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ölçü Birimi
    /// </summary>
        public DistributionTypeDefinition DistributionType
        {
            get { return (DistributionTypeDefinition)((ITTObject)this).GetParent("DISTRIBUTIONTYPE"); }
            set { this["DISTRIBUTIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SupplyRequestPool SupplyRequestPool
        {
            get { return (SupplyRequestPool)((ITTObject)this).GetParent("SUPPLYREQUESTPOOL"); }
            set { this["SUPPLYREQUESTPOOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Satınalma Kalemi
    /// </summary>
        public PurchaseGroup PurchaseGroup
        {
            get { return (PurchaseGroup)((ITTObject)this).GetParent("PURCHASEGROUP"); }
            set { this["PURCHASEGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSupplyRequestDetailsCollection()
        {
            _SupplyRequestDetails = new SupplyRequestDetail.ChildSupplyRequestDetailCollection(this, new Guid("63a1325e-7bd1-456f-9664-3488ac3e0699"));
            ((ITTChildObjectCollection)_SupplyRequestDetails).GetChildren();
        }

        protected SupplyRequestDetail.ChildSupplyRequestDetailCollection _SupplyRequestDetails = null;
        public SupplyRequestDetail.ChildSupplyRequestDetailCollection SupplyRequestDetails
        {
            get
            {
                if (_SupplyRequestDetails == null)
                    CreateSupplyRequestDetailsCollection();
                return _SupplyRequestDetails;
            }
        }

        protected SupplyRequestPoolDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SupplyRequestPoolDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SupplyRequestPoolDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SupplyRequestPoolDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SupplyRequestPoolDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUPPLYREQUESTPOOLDETAIL", dataRow) { }
        protected SupplyRequestPoolDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUPPLYREQUESTPOOLDETAIL", dataRow, isImported) { }
        public SupplyRequestPoolDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SupplyRequestPoolDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SupplyRequestPoolDetail() : base() { }

    }
}