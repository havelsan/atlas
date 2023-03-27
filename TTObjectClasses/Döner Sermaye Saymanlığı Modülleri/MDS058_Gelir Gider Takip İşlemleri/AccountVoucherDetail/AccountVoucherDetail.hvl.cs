
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountVoucherDetail")] 

    public  partial class AccountVoucherDetail : TTObject
    {
        public class AccountVoucherDetailList : TTObjectCollection<AccountVoucherDetail> { }
                    
        public class ChildAccountVoucherDetailCollection : TTObject.TTChildObjectCollection<AccountVoucherDetail>
        {
            public ChildAccountVoucherDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountVoucherDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// İptal
    /// </summary>
        public bool? IsCancel
        {
            get { return (bool?)this["ISCANCEL"]; }
            set { this["ISCANCEL"] = value; }
        }

    /// <summary>
    /// İade
    /// </summary>
        public bool? IsBack
        {
            get { return (bool?)this["ISBACK"]; }
            set { this["ISBACK"] = value; }
        }

        public AccountVoucher AccountVoucher
        {
            get { return (AccountVoucher)((ITTObject)this).GetParent("ACCOUNTVOUCHER"); }
            set { this["ACCOUNTVOUCHER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountDocument AccountDocument
        {
            get { return (AccountDocument)((ITTObject)this).GetParent("ACCOUNTDOCUMENT"); }
            set { this["ACCOUNTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReceiptDocumentDetail ReceiptDocumentDetail
        {
            get { return (ReceiptDocumentDetail)((ITTObject)this).GetParent("RECEIPTDOCUMENTDETAIL"); }
            set { this["RECEIPTDOCUMENTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountVoucherDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountVoucherDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountVoucherDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountVoucherDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountVoucherDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTVOUCHERDETAIL", dataRow) { }
        protected AccountVoucherDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTVOUCHERDETAIL", dataRow, isImported) { }
        public AccountVoucherDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountVoucherDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountVoucherDetail() : base() { }

    }
}