
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Cash")] 

    /// <summary>
    /// Nakit Ödeme Türü
    /// </summary>
    public  partial class Cash : Payment
    {
        public class CashList : TTObjectCollection<Cash> { }
                    
        public class ChildCashCollection : TTObject.TTChildObjectCollection<Cash>
        {
            public ChildCashCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Cash ile CurrencyType arasindaki iliski
    /// </summary>
        public CurrencyTypeDefinition CurrencyType
        {
            get { return (CurrencyTypeDefinition)((ITTObject)this).GetParent("CURRENCYTYPE"); }
            set { this["CURRENCYTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Cash(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Cash(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Cash(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Cash(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Cash(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASH", dataRow) { }
        protected Cash(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASH", dataRow, isImported) { }
        public Cash(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Cash(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Cash() : base() { }

    }
}