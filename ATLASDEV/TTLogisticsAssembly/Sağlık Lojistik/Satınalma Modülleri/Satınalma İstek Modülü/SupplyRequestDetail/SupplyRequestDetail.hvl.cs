
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SupplyRequestDetail")] 

    /// <summary>
    /// Tadarik Talep Detayı
    /// </summary>
    public  partial class SupplyRequestDetail : TTObject
    {
        public class SupplyRequestDetailList : TTObjectCollection<SupplyRequestDetail> { }
                    
        public class ChildSupplyRequestDetailCollection : TTObject.TTChildObjectCollection<SupplyRequestDetail>
        {
            public ChildSupplyRequestDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSupplyRequestDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SupplyrequestReportQuery_Class : TTReportNqlObject 
        {
            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUEST"].AllPropertyDefs["STOCKACTIONID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUEST"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Deststorename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTSTORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materailname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERAILNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barkode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARKODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Mkyskodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["MKYSMALZEMEKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTDETAIL"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? PurchaseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTDETAIL"].AllPropertyDefs["PURCHASEAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Personelname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONELNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SupplyrequestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SupplyrequestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SupplyrequestReportQuery_Class() : base() { }
        }

        public static BindingList<SupplyRequestDetail.SupplyrequestReportQuery_Class> SupplyrequestReportQuery(Guid STOREOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTDETAIL"].QueryDefs["SupplyrequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);

            return TTReportNqlObject.QueryObjects<SupplyRequestDetail.SupplyrequestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SupplyRequestDetail.SupplyrequestReportQuery_Class> SupplyrequestReportQuery(TTObjectContext objectContext, Guid STOREOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTDETAIL"].QueryDefs["SupplyrequestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);

            return TTReportNqlObject.QueryObjects<SupplyRequestDetail.SupplyrequestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SupplyRequestDetail> GetSupplyReqDetsByStoreAndDemandType(TTObjectContext objectContext, Guid STORE, SupplyRequestTypeEnum DEMANDTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTDETAIL"].QueryDefs["GetSupplyReqDetsByStoreAndDemandType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("DEMANDTYPE", (int)DEMANDTYPE);

            return ((ITTQuery)objectContext).QueryObjects<SupplyRequestDetail>(queryDef, paramList);
        }

    /// <summary>
    /// Tedarik Talep Durumu
    /// </summary>
        public SupplyRequestStatusEnum? SupplyRequestStatus
        {
            get { return (SupplyRequestStatusEnum?)(int?)this["SUPPLYREQUESTSTATUS"]; }
            set { this["SUPPLYREQUESTSTATUS"] = value; }
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
    /// Açıklama
    /// </summary>
        public string DetailDescription
        {
            get { return (string)this["DETAILDESCRIPTION"]; }
            set { this["DETAILDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Satınalma Miktarı
    /// </summary>
        public Currency? PurchaseAmount
        {
            get { return (Currency?)this["PURCHASEAMOUNT"]; }
            set { this["PURCHASEAMOUNT"] = value; }
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? IsImmediateMat
        {
            get { return (bool?)this["ISIMMEDIATEMAT"]; }
            set { this["ISIMMEDIATEMAT"] = value; }
        }

        public SupplyRequestPoolDetail SupplyRequestPoolDetail
        {
            get { return (SupplyRequestPoolDetail)((ITTObject)this).GetParent("SUPPLYREQUESTPOOLDETAIL"); }
            set { this["SUPPLYREQUESTPOOLDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ölçü Birimi
    /// </summary>
        public DistributionTypeDefinition DistributionType
        {
            get { return (DistributionTypeDefinition)((ITTObject)this).GetParent("DISTRIBUTIONTYPE"); }
            set { this["DISTRIBUTIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek İşlemi
    /// </summary>
        public SupplyRequest SupplyRequest
        {
            get { return (SupplyRequest)((ITTObject)this).GetParent("SUPPLYREQUEST"); }
            set { this["SUPPLYREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
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
    /// Satınalma Kalemi
    /// </summary>
        public PurchaseGroup PurchaseGroup
        {
            get { return (PurchaseGroup)((ITTObject)this).GetParent("PURCHASEGROUP"); }
            set { this["PURCHASEGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SupplyRequestDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SupplyRequestDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SupplyRequestDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SupplyRequestDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SupplyRequestDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUPPLYREQUESTDETAIL", dataRow) { }
        protected SupplyRequestDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUPPLYREQUESTDETAIL", dataRow, isImported) { }
        public SupplyRequestDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SupplyRequestDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SupplyRequestDetail() : base() { }

    }
}