
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountTrxDocument")] 

    /// <summary>
    /// AccountTransaction ile AccountDocumentDetail i bağlayan ara class
    /// </summary>
    public  partial class AccountTrxDocument : TTObject
    {
        public class AccountTrxDocumentList : TTObjectCollection<AccountTrxDocument> { }
                    
        public class ChildAccountTrxDocumentCollection : TTObject.TTChildObjectCollection<AccountTrxDocument>
        {
            public ChildAccountTrxDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountTrxDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// AccountTransaction a relation
    /// </summary>
        public AccountTransaction AccountTransaction
        {
            get { return (AccountTransaction)((ITTObject)this).GetParent("ACCOUNTTRANSACTION"); }
            set { this["ACCOUNTTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// AccountDocumentDetail e relation
    /// </summary>
        public AccountDocumentDetail AccountDocumentDetail
        {
            get { return (AccountDocumentDetail)((ITTObject)this).GetParent("ACCOUNTDOCUMENTDETAIL"); }
            set { this["ACCOUNTDOCUMENTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountTrxDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountTrxDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountTrxDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountTrxDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountTrxDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTTRXDOCUMENT", dataRow) { }
        protected AccountTrxDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTTRXDOCUMENT", dataRow, isImported) { }
        public AccountTrxDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountTrxDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountTrxDocument() : base() { }

    }
}