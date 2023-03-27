
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CreditCard")] 

    /// <summary>
    /// Kredi kartı ödeme tipi
    /// </summary>
    public  partial class CreditCard : Payment
    {
        public class CreditCardList : TTObjectCollection<CreditCard> { }
                    
        public class ChildCreditCardCollection : TTObject.TTChildObjectCollection<CreditCard>
        {
            public ChildCreditCardCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCreditCardCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Telefon Numarası
    /// </summary>
        public string PhoneNo
        {
            get { return (string)this["PHONENO"]; }
            set { this["PHONENO"] = value; }
        }

    /// <summary>
    /// Kart Sahibi
    /// </summary>
        public string Owner
        {
            get { return (string)this["OWNER"]; }
            set { this["OWNER"] = value; }
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ValidDate
        {
            get { return (DateTime?)this["VALIDDATE"]; }
            set { this["VALIDDATE"] = value; }
        }

    /// <summary>
    /// Kart Tipi
    /// </summary>
        public CreditCardTypeEnum? CardType
        {
            get { return (CreditCardTypeEnum?)(int?)this["CARDTYPE"]; }
            set { this["CARDTYPE"] = value; }
        }

    /// <summary>
    /// Kart No
    /// </summary>
        public string CardNo
        {
            get { return (string)this["CARDNO"]; }
            set { this["CARDNO"] = value; }
        }

    /// <summary>
    /// Bankayla ilişki
    /// </summary>
        public BankDefinition BankName
        {
            get { return (BankDefinition)((ITTObject)this).GetParent("BANKNAME"); }
            set { this["BANKNAME"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CreditCard(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CreditCard(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CreditCard(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CreditCard(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CreditCard(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CREDITCARD", dataRow) { }
        protected CreditCard(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CREDITCARD", dataRow, isImported) { }
        public CreditCard(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CreditCard(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CreditCard() : base() { }

    }
}