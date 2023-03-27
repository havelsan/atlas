
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BankDecount")] 

    /// <summary>
    /// Banka Dekontu ile ödeme türü
    /// </summary>
    public  partial class BankDecount : Payment
    {
        public class BankDecountList : TTObjectCollection<BankDecount> { }
                    
        public class ChildBankDecountCollection : TTObject.TTChildObjectCollection<BankDecount>
        {
            public ChildBankDecountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBankDecountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dekont Numarası
    /// </summary>
        public string DecountNo
        {
            get { return (string)this["DECOUNTNO"]; }
            set { this["DECOUNTNO"] = value; }
        }

    /// <summary>
    /// Dekont Tarihi
    /// </summary>
        public DateTime? DecountDate
        {
            get { return (DateTime?)this["DECOUNTDATE"]; }
            set { this["DECOUNTDATE"] = value; }
        }

    /// <summary>
    /// Banka Hesap No
    /// </summary>
        public BankAccountDefinition BankAccount
        {
            get { return (BankAccountDefinition)((ITTObject)this).GetParent("BANKACCOUNT"); }
            set { this["BANKACCOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BankDecount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BankDecount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BankDecount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BankDecount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BankDecount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BANKDECOUNT", dataRow) { }
        protected BankDecount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BANKDECOUNT", dataRow, isImported) { }
        public BankDecount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BankDecount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BankDecount() : base() { }

    }
}