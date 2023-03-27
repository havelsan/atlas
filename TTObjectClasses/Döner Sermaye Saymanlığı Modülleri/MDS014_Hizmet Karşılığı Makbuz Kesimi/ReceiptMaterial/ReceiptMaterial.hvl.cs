
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptMaterial")] 

    /// <summary>
    /// Muh. Yetkilisi Mutemedi  Malzeme ve İlaçlar
    /// </summary>
    public  partial class ReceiptMaterial : TTObject
    {
        public class ReceiptMaterialList : TTObjectCollection<ReceiptMaterial> { }
                    
        public class ChildReceiptMaterialCollection : TTObject.TTChildObjectCollection<ReceiptMaterial>
        {
            public ChildReceiptMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
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
    /// Mlz. İlaç  Ödemesi yapılırken seçilmelidir
    /// </summary>
        public bool? Paid
        {
            get { return (bool?)this["PAID"]; }
            set { this["PAID"] = value; }
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public Currency? UnitPrice
        {
            get { return (Currency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
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
    /// Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Toplam Fiyat
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

    /// <summary>
    /// Toplam indirim tutarı
    /// </summary>
        public Currency? TotalDiscountPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
        }

    /// <summary>
    /// Toplam indirimli fiyat
    /// </summary>
        public Currency? TotalDiscountedPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTEDPRICE"]; }
            set { this["TOTALDISCOUNTEDPRICE"] = value; }
        }

    /// <summary>
    /// Ödenen malzeme tutarı
    /// </summary>
        public Currency? PaymentPrice
        {
            get { return (Currency?)this["PAYMENTPRICE"]; }
            set { this["PAYMENTPRICE"] = value; }
        }

    /// <summary>
    /// Kalan Tutar
    /// </summary>
        public Currency? RemainingPrice
        {
            get { return (Currency?)this["REMAININGPRICE"]; }
            set { this["REMAININGPRICE"] = value; }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı ilişkisi
    /// </summary>
        public Receipt Receipt
        {
            get { return (Receipt)((ITTObject)this).GetParent("RECEIPT"); }
            set { this["RECEIPT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTransactionCollection()
        {
            _AccountTransaction = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("0ef730e8-d06f-449d-9992-1f8575a59bc8"));
            ((ITTChildObjectCollection)_AccountTransaction).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransaction = null;
    /// <summary>
    /// Child collection for Muhasebe yetkilisi mutemedi alındısı malzeme bilgisine ilişki
    /// </summary>
        public AccountTransaction.ChildAccountTransactionCollection AccountTransaction
        {
            get
            {
                if (_AccountTransaction == null)
                    CreateAccountTransactionCollection();
                return _AccountTransaction;
            }
        }

        protected ReceiptMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTMATERIAL", dataRow) { }
        protected ReceiptMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTMATERIAL", dataRow, isImported) { }
        public ReceiptMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptMaterial() : base() { }

    }
}