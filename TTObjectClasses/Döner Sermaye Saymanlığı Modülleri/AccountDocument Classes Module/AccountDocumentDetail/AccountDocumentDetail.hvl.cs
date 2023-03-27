
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountDocumentDetail")] 

    /// <summary>
    /// Finansal Döküman türlerinin detaylarının ana sınıfıdır
    /// </summary>
    public  partial class AccountDocumentDetail : TTObject
    {
        public class AccountDocumentDetailList : TTObjectCollection<AccountDocumentDetail> { }
                    
        public class ChildAccountDocumentDetailCollection : TTObject.TTChildObjectCollection<AccountDocumentDetail>
        {
            public ChildAccountDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Detaydaki hizmet/malzemenin açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
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
    /// Detaydaki hizmet/malzemenin kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Detayın birim fiyatı
    /// </summary>
        public Currency? UnitPrice
        {
            get { return (Currency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Detaya uygulanan toplam indirim tutarı
    /// </summary>
        public Currency? TotalDiscountPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTPRICE"]; }
            set { this["TOTALDISCOUNTPRICE"] = value; }
        }

    /// <summary>
    /// KDV tutarı
    /// </summary>
        public Currency? VATPrice
        {
            get { return (Currency?)this["VATPRICE"]; }
            set { this["VATPRICE"] = value; }
        }

    /// <summary>
    /// Detayın İndirim uygulanmış toplam fiyatı
    /// </summary>
        public Currency? TotalDiscountedPrice
        {
            get { return (Currency?)this["TOTALDISCOUNTEDPRICE"]; }
            set { this["TOTALDISCOUNTEDPRICE"] = value; }
        }

    /// <summary>
    /// Finansal Döküman Gruplarıyla ilişki
    /// </summary>
        public AccountDocumentGroup AccountDocumentGroup
        {
            get { return (AccountDocumentGroup)((ITTObject)this).GetParent("ACCOUNTDOCUMENTGROUP"); }
            set { this["ACCOUNTDOCUMENTGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Para birimleriyle ilişki
    /// </summary>
        public CurrencyTypeDefinition CurrencyType
        {
            get { return (CurrencyTypeDefinition)((ITTObject)this).GetParent("CURRENCYTYPE"); }
            set { this["CURRENCYTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTrxDocumentCollection()
        {
            _AccountTrxDocument = new AccountTrxDocument.ChildAccountTrxDocumentCollection(this, new Guid("f152437a-e992-4864-85f9-fc9cce912b8a"));
            ((ITTChildObjectCollection)_AccountTrxDocument).GetChildren();
        }

        protected AccountTrxDocument.ChildAccountTrxDocumentCollection _AccountTrxDocument = null;
    /// <summary>
    /// Child collection for AccountDocumentDetail e relation
    /// </summary>
        public AccountTrxDocument.ChildAccountTrxDocumentCollection AccountTrxDocument
        {
            get
            {
                if (_AccountTrxDocument == null)
                    CreateAccountTrxDocumentCollection();
                return _AccountTrxDocument;
            }
        }

        protected AccountDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTDOCUMENTDETAIL", dataRow) { }
        protected AccountDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTDOCUMENTDETAIL", dataRow, isImported) { }
        public AccountDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountDocumentDetail() : base() { }

    }
}