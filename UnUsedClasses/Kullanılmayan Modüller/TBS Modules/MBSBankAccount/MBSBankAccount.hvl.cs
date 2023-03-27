
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSBankAccount")] 

    public  partial class MBSBankAccount : TTObject
    {
        public class MBSBankAccountList : TTObjectCollection<MBSBankAccount> { }
                    
        public class ChildMBSBankAccountCollection : TTObject.TTChildObjectCollection<MBSBankAccount>
        {
            public ChildMBSBankAccountCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSBankAccountCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Şube kod
    /// </summary>
        public string AgencyCode
        {
            get { return (string)this["AGENCYCODE"]; }
            set { this["AGENCYCODE"] = value; }
        }

    /// <summary>
    /// Banka şube
    /// </summary>
        public string BankAgency
        {
            get { return (string)this["BANKAGENCY"]; }
            set { this["BANKAGENCY"] = value; }
        }

    /// <summary>
    /// Varsayılan Hesap mı?
    /// </summary>
        public YesNoEnum? isDefault
        {
            get { return (YesNoEnum?)(int?)this["ISDEFAULT"]; }
            set { this["ISDEFAULT"] = value; }
        }

    /// <summary>
    /// Banka ad
    /// </summary>
        public string BankName
        {
            get { return (string)this["BANKNAME"]; }
            set { this["BANKNAME"] = value; }
        }

    /// <summary>
    /// Hesap No
    /// </summary>
        public string AccountNumber
        {
            get { return (string)this["ACCOUNTNUMBER"]; }
            set { this["ACCOUNTNUMBER"] = value; }
        }

        protected MBSBankAccount(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSBankAccount(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSBankAccount(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSBankAccount(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSBankAccount(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSBANKACCOUNT", dataRow) { }
        protected MBSBankAccount(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSBANKACCOUNT", dataRow, isImported) { }
        public MBSBankAccount(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSBankAccount(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSBankAccount() : base() { }

    }
}