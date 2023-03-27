
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountingProcessProtocol")] 

    public  partial class AccountingProcessProtocol : TTObject
    {
        public class AccountingProcessProtocolList : TTObjectCollection<AccountingProcessProtocol> { }
                    
        public class ChildAccountingProcessProtocolCollection : TTObject.TTChildObjectCollection<AccountingProcessProtocol>
        {
            public ChildAccountingProcessProtocolCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountingProcessProtocolCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açılış Tarihi
    /// </summary>
        public DateTime? OPENINGDATE
        {
            get { return (DateTime?)this["OPENINGDATE"]; }
            set { this["OPENINGDATE"] = value; }
        }

    /// <summary>
    /// EP ObjectID
    /// </summary>
        public string EPOBJECTID
        {
            get { return (string)this["EPOBJECTID"]; }
            set { this["EPOBJECTID"] = value; }
        }

    /// <summary>
    /// Kurum Adı
    /// </summary>
        public string PAYERNAME
        {
            get { return (string)this["PAYERNAME"]; }
            set { this["PAYERNAME"] = value; }
        }

    /// <summary>
    /// Anlaşma Adı
    /// </summary>
        public string PROTOCOLNAME
        {
            get { return (string)this["PROTOCOLNAME"]; }
            set { this["PROTOCOLNAME"] = value; }
        }

    /// <summary>
    /// Anlaşma Durumu
    /// </summary>
        public string PROTOCOLSTATUS
        {
            get { return (string)this["PROTOCOLSTATUS"]; }
            set { this["PROTOCOLSTATUS"] = value; }
        }

        public AccountingProcess AccountingProcess
        {
            get { return (AccountingProcess)((ITTObject)this).GetParent("ACCOUNTINGPROCESS"); }
            set { this["ACCOUNTINGPROCESS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountingProcessProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountingProcessProtocol(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountingProcessProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountingProcessProtocol(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountingProcessProtocol(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTINGPROCESSPROTOCOL", dataRow) { }
        protected AccountingProcessProtocol(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTINGPROCESSPROTOCOL", dataRow, isImported) { }
        public AccountingProcessProtocol(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountingProcessProtocol(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountingProcessProtocol() : base() { }

    }
}