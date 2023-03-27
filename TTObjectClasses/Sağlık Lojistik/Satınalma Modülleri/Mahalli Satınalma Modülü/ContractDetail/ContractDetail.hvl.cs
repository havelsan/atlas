
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ContractDetail")] 

    /// <summary>
    /// Sözleşmede Sözleşmesi Yapılan Her Kalem İçin Bilgilerin TutulDuğu Sınıftır
    /// </summary>
    public  partial class ContractDetail : TTObject
    {
        public class ContractDetailList : TTObjectCollection<ContractDetail> { }
                    
        public class ChildContractDetailCollection : TTObject.TTChildObjectCollection<ContractDetail>
        {
            public ChildContractDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildContractDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByContractNo_Class : TTReportNqlObject 
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

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IncludedToContract
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEDTOCONTRACT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACTDETAIL"].AllPropertyDefs["INCLUDEDTOCONTRACT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? ContractTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACTDETAIL"].AllPropertyDefs["CONTRACTTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetByContractNo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByContractNo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByContractNo_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("68a931b0-2db7-4577-a237-0112e811819e"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("bb4d9b72-d2cb-47f8-8453-d6d25f7f3a5b"); } }
        }

        public static BindingList<ContractDetail> GetOldPurchasesForPriceFormulation(TTObjectContext objectContext, string PURCHASEITEMDEF)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONTRACTDETAIL"].QueryDefs["GetOldPurchasesForPriceFormulation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASEITEMDEF", PURCHASEITEMDEF);

            return ((ITTQuery)objectContext).QueryObjects<ContractDetail>(queryDef, paramList);
        }

        public static BindingList<ContractDetail.GetByContractNo_Class> GetByContractNo(string CONTRACTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONTRACTDETAIL"].QueryDefs["GetByContractNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CONTRACTNO", CONTRACTNO);

            return TTReportNqlObject.QueryObjects<ContractDetail.GetByContractNo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ContractDetail.GetByContractNo_Class> GetByContractNo(TTObjectContext objectContext, string CONTRACTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONTRACTDETAIL"].QueryDefs["GetByContractNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CONTRACTNO", CONTRACTNO);

            return TTReportNqlObject.QueryObjects<ContractDetail.GetByContractNo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
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
    /// Sözleşmeye Dahil
    /// </summary>
        public bool? IncludedToContract
        {
            get { return (bool?)this["INCLUDEDTOCONTRACT"]; }
            set { this["INCLUDEDTOCONTRACT"] = value; }
        }

    /// <summary>
    /// Sözleşme Süresi
    /// </summary>
        public int? ContractTime
        {
            get { return (int?)this["CONTRACTTIME"]; }
            set { this["CONTRACTTIME"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProjectDetail PurchaseProjectDetail
        {
            get { return (PurchaseProjectDetail)((ITTObject)this).GetParent("PURCHASEPROJECTDETAIL"); }
            set { this["PURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Contract Contract
        {
            get { return (Contract)((ITTObject)this).GetParent("CONTRACT"); }
            set { this["CONTRACT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProposalDetailsCollection()
        {
            _ProposalDetails = new ProposalDetail.ChildProposalDetailCollection(this, new Guid("82ae8bcb-1389-4570-82f3-696e176436c4"));
            ((ITTChildObjectCollection)_ProposalDetails).GetChildren();
        }

        protected ProposalDetail.ChildProposalDetailCollection _ProposalDetails = null;
        public ProposalDetail.ChildProposalDetailCollection ProposalDetails
        {
            get
            {
                if (_ProposalDetails == null)
                    CreateProposalDetailsCollection();
                return _ProposalDetails;
            }
        }

        virtual protected void CreatePurchaseOrderDetailsCollection()
        {
            _PurchaseOrderDetails = new PurchaseOrderDetail.ChildPurchaseOrderDetailCollection(this, new Guid("c5f5a5b1-67a3-4e8b-923a-87148c575031"));
            ((ITTChildObjectCollection)_PurchaseOrderDetails).GetChildren();
        }

        protected PurchaseOrderDetail.ChildPurchaseOrderDetailCollection _PurchaseOrderDetails = null;
        public PurchaseOrderDetail.ChildPurchaseOrderDetailCollection PurchaseOrderDetails
        {
            get
            {
                if (_PurchaseOrderDetails == null)
                    CreatePurchaseOrderDetailsCollection();
                return _PurchaseOrderDetails;
            }
        }

        protected ContractDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ContractDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ContractDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ContractDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ContractDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONTRACTDETAIL", dataRow) { }
        protected ContractDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONTRACTDETAIL", dataRow, isImported) { }
        public ContractDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ContractDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ContractDetail() : base() { }

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