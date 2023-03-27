
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProposalDetail")] 

    /// <summary>
    /// Proposal Sınıfına Bağlıdır. Firmaların Verdiği Her Teklif İçin Bir Adet Proposal Instance'ı Yaratılırken Her Teklif Detayı, Yani Her Kalem İçin Bir Adette ProposalDetail Instance'ı Yaratılır.
    /// </summary>
    public  partial class ProposalDetail : TTObject
    {
        public class ProposalDetailList : TTObjectCollection<ProposalDetail> { }
                    
        public class ChildProposalDetailCollection : TTObject.TTChildObjectCollection<ProposalDetail>
        {
            public ChildProposalDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProposalDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWinnerFirmsWithObjectID_Class : TTReportNqlObject 
        {
            public Guid? Proposalobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROPOSALOBJECTID"]);
                }
            }

            public GetWinnerFirmsWithObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWinnerFirmsWithObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWinnerFirmsWithObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTotalPriceForDirectPurchaseQuery_Class : TTReportNqlObject 
        {
            public Guid? Proposalid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROPOSALID"]);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Address
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public GetTotalPriceForDirectPurchaseQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTotalPriceForDirectPurchaseQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTotalPriceForDirectPurchaseQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProposalledTotalPrices_Class : TTReportNqlObject 
        {
            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalproposalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPROPOSALPRICE"]);
                }
            }

            public GetProposalledTotalPrices_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProposalledTotalPrices_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProposalledTotalPrices_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProposalledTotalPricesByGroup_Class : TTReportNqlObject 
        {
            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalproposalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPROPOSALPRICE"]);
                }
            }

            public GetProposalledTotalPricesByGroup_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProposalledTotalPricesByGroup_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProposalledTotalPricesByGroup_Class() : base() { }
        }

        public static BindingList<ProposalDetail.GetWinnerFirmsWithObjectID_Class> GetWinnerFirmsWithObjectID(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].QueryDefs["GetWinnerFirmsWithObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProposalDetail.GetWinnerFirmsWithObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProposalDetail.GetWinnerFirmsWithObjectID_Class> GetWinnerFirmsWithObjectID(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].QueryDefs["GetWinnerFirmsWithObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProposalDetail.GetWinnerFirmsWithObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class> GetTotalPriceForDirectPurchaseQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].QueryDefs["GetTotalPriceForDirectPurchaseQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class> GetTotalPriceForDirectPurchaseQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].QueryDefs["GetTotalPriceForDirectPurchaseQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProposalDetail.GetTotalPriceForDirectPurchaseQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProposalDetail.GetProposalledTotalPrices_Class> GetProposalledTotalPrices(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].QueryDefs["GetProposalledTotalPrices"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProposalDetail.GetProposalledTotalPrices_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProposalDetail.GetProposalledTotalPrices_Class> GetProposalledTotalPrices(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].QueryDefs["GetProposalledTotalPrices"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ProposalDetail.GetProposalledTotalPrices_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProposalDetail.GetProposalledTotalPricesByGroup_Class> GetProposalledTotalPricesByGroup(string PROJECTGROUPID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].QueryDefs["GetProposalledTotalPricesByGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTGROUPID", PROJECTGROUPID);

            return TTReportNqlObject.QueryObjects<ProposalDetail.GetProposalledTotalPricesByGroup_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProposalDetail.GetProposalledTotalPricesByGroup_Class> GetProposalledTotalPricesByGroup(TTObjectContext objectContext, string PROJECTGROUPID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].QueryDefs["GetProposalledTotalPricesByGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTGROUPID", PROJECTGROUPID);

            return TTReportNqlObject.QueryObjects<ProposalDetail.GetProposalledTotalPricesByGroup_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Teklif Fiyatı
    /// </summary>
        public double? ProposalPrice
        {
            get { return (double?)this["PROPOSALPRICE"]; }
            set { this["PROPOSALPRICE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Durumu
    /// </summary>
        public ProposalDetailStatusEnum? Status
        {
            get { return (ProposalDetailStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Fiyat Dışı Unsurlar ....
    /// </summary>
        public double? FDUDA
        {
            get { return (double?)this["FDUDA"]; }
            set { this["FDUDA"] = value; }
        }

    /// <summary>
    /// Yerli İstekliler Lehine Fiyat Avantajı....
    /// </summary>
        public double? YILFA
        {
            get { return (double?)this["YILFA"]; }
            set { this["YILFA"] = value; }
        }

    /// <summary>
    /// Kur
    /// </summary>
        public double? Rate
        {
            get { return (double?)this["RATE"]; }
            set { this["RATE"] = value; }
        }

        public Proposal Proposal
        {
            get { return (Proposal)((ITTObject)this).GetParent("PROPOSAL"); }
            set { this["PROPOSAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProjectDetail PurchaseProjectDetail
        {
            get { return (PurchaseProjectDetail)((ITTObject)this).GetParent("PURCHASEPROJECTDETAIL"); }
            set { this["PURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ContractDetail ContractDetail
        {
            get { return (ContractDetail)((ITTObject)this).GetParent("CONTRACTDETAIL"); }
            set { this["CONTRACTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProposalDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProposalDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProposalDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProposalDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProposalDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROPOSALDETAIL", dataRow) { }
        protected ProposalDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROPOSALDETAIL", dataRow, isImported) { }
        public ProposalDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProposalDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProposalDetail() : base() { }

    }
}