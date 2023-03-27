
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountingLinesForCash")] 

    /// <summary>
    /// Sonaradan muhasebeleşecek nakit ödemelerle ilgili bilgileri tutar
    /// </summary>
    public  partial class AccountingLinesForCash : TTObject
    {
        public class AccountingLinesForCashList : TTObjectCollection<AccountingLinesForCash> { }
                    
        public class ChildAccountingLinesForCashCollection : TTObject.TTChildObjectCollection<AccountingLinesForCash>
        {
            public ChildAccountingLinesForCashCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountingLinesForCashCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hesap Kodu
    /// </summary>
        public string AccountCode
        {
            get { return (string)this["ACCOUNTCODE"]; }
            set { this["ACCOUNTCODE"] = value; }
        }

    /// <summary>
    /// Tutar
    /// </summary>
        public double? Price
        {
            get { return (double?)this["PRICE"]; }
            set { this["PRICE"] = value; }
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
    /// Muhasebe yetkilisi mutemedi alındısı ile ilişki
    /// </summary>
        public ReceiptDocument ReceiptDocument
        {
            get { return (ReceiptDocument)((ITTObject)this).GetParent("RECEIPTDOCUMENT"); }
            set { this["RECEIPTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Genel muhasebe yetkilisi mutemedi alındısı ile ilişki
    /// </summary>
        public GeneralReceiptDocument GeneralReceiptDocument
        {
            get { return (GeneralReceiptDocument)((ITTObject)this).GetParent("GENERALRECEIPTDOCUMENT"); }
            set { this["GENERALRECEIPTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountingLinesForCash(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountingLinesForCash(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountingLinesForCash(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountingLinesForCash(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountingLinesForCash(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTINGLINESFORCASH", dataRow) { }
        protected AccountingLinesForCash(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTINGLINESFORCASH", dataRow, isImported) { }
        public AccountingLinesForCash(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountingLinesForCash(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountingLinesForCash() : base() { }

    }
}