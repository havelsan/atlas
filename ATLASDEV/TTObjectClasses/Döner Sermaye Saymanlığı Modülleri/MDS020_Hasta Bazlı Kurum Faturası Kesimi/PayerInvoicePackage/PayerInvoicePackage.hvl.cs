
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerInvoicePackage")] 

    /// <summary>
    /// Kurum Faturası Paket Hizmet Kalemleri
    /// </summary>
    public  partial class PayerInvoicePackage : TTObject
    {
        public class PayerInvoicePackageList : TTObjectCollection<PayerInvoicePackage> { }
                    
        public class ChildPayerInvoicePackageCollection : TTObject.TTChildObjectCollection<PayerInvoicePackage>
        {
            public ChildPayerInvoicePackageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerInvoicePackageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Paket Adı
    /// </summary>
        public string PackageName
        {
            get { return (string)this["PACKAGENAME"]; }
            set { this["PACKAGENAME"] = value; }
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
    /// Ödenecek
    /// </summary>
        public bool? Paid
        {
            get { return (bool?)this["PAID"]; }
            set { this["PAID"] = value; }
        }

    /// <summary>
    /// Toplam İndirim tutarı
    /// </summary>
        public Currency? TotalDiscountPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
        }

    /// <summary>
    /// Paket Fiyatı
    /// </summary>
        public Currency? PackagePrice
        {
            get { return (Currency?)this["PACKAGEPRICE"]; }
            set { this["PACKAGEPRICE"] = value; }
        }

    /// <summary>
    /// İndirimli toplam fiyat
    /// </summary>
        public Currency? TotalDiscountedPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTEDPRICE"]; }
            set { this["TOTALDISCOUNTEDPRICE"] = value; }
        }

    /// <summary>
    /// Paket Kodu
    /// </summary>
        public string PackageCode
        {
            get { return (string)this["PACKAGECODE"]; }
            set { this["PACKAGECODE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
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
    /// Kurum Faturası İşlemiyle İlişki
    /// </summary>
        public PayerInvoice PayerInvoice
        {
            get { return (PayerInvoice)((ITTObject)this).GetParent("PAYERINVOICE"); }
            set { this["PAYERINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePackageAccountTransactionCollection()
        {
            _PackageAccountTransaction = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("7944e783-fcfc-4cfc-8fd9-739b12cf8672"));
            ((ITTChildObjectCollection)_PackageAccountTransaction).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _PackageAccountTransaction = null;
    /// <summary>
    /// Child collection for Kurum faturası paket bilgisine ilişki
    /// </summary>
        public AccountTransaction.ChildAccountTransactionCollection PackageAccountTransaction
        {
            get
            {
                if (_PackageAccountTransaction == null)
                    CreatePackageAccountTransactionCollection();
                return _PackageAccountTransaction;
            }
        }

        protected PayerInvoicePackage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerInvoicePackage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerInvoicePackage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerInvoicePackage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerInvoicePackage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERINVOICEPACKAGE", dataRow) { }
        protected PayerInvoicePackage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERINVOICEPACKAGE", dataRow, isImported) { }
        public PayerInvoicePackage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerInvoicePackage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerInvoicePackage() : base() { }

    }
}