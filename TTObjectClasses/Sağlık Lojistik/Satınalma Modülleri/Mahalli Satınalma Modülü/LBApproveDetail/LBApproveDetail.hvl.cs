
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBApproveDetail")] 

    /// <summary>
    /// Mahalli Satınalma Projesinde Lojistik Dairenin Her Kalem İçin Verdiği Onay Bilgilerini Barındıran Sınıftır
    /// </summary>
    public  partial class LBApproveDetail : TTObject
    {
        public class LBApproveDetailList : TTObjectCollection<LBApproveDetail> { }
                    
        public class ChildLBApproveDetailCollection : TTObject.TTChildObjectCollection<LBApproveDetail>
        {
            public ChildLBApproveDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBApproveDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Onay Şekli
    /// </summary>
        public LBApproveDetailTypeEnum? ApproveType
        {
            get { return (LBApproveDetailTypeEnum?)(int?)this["APPROVETYPE"]; }
            set { this["APPROVETYPE"] = value; }
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
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public LBPurchaseProjectDetail LBPurchaseProjectDetail
        {
            get { return (LBPurchaseProjectDetail)((ITTObject)this).GetParent("LBPURCHASEPROJECTDETAIL"); }
            set { this["LBPURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProjectDetail PurchaseProjectDetail
        {
            get { return (PurchaseProjectDetail)((ITTObject)this).GetParent("PURCHASEPROJECTDETAIL"); }
            set { this["PURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tertip Emri Gidecek Olan Saymanlık
    /// </summary>
        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LBApproveDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBApproveDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBApproveDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBApproveDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBApproveDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBAPPROVEDETAIL", dataRow) { }
        protected LBApproveDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBAPPROVEDETAIL", dataRow, isImported) { }
        public LBApproveDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBApproveDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBApproveDetail() : base() { }

    }
}