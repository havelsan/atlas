
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresChaDocInputDetWithAccountancy")] 

    public  partial class PresChaDocInputDetWithAccountancy : ChattelDocumentInputDetailWithAccountancy
    {
        public class PresChaDocInputDetWithAccountancyList : TTObjectCollection<PresChaDocInputDetWithAccountancy> { }
                    
        public class ChildPresChaDocInputDetWithAccountancyCollection : TTObject.TTChildObjectCollection<PresChaDocInputDetWithAccountancy>
        {
            public ChildPresChaDocInputDetWithAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresChaDocInputDetWithAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresChaDocInputWithAccountancy PresChaDocInputWithAccountancy
        {
            get 
            {   
                if (StockAction is PresChaDocInputWithAccountancy)
                    return (PresChaDocInputWithAccountancy)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresChaDocInputDetWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresChaDocInputDetWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresChaDocInputDetWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresChaDocInputDetWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresChaDocInputDetWithAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCHADOCINPUTDETWITHACCOUNTANCY", dataRow) { }
        protected PresChaDocInputDetWithAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCHADOCINPUTDETWITHACCOUNTANCY", dataRow, isImported) { }
        public PresChaDocInputDetWithAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresChaDocInputDetWithAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresChaDocInputDetWithAccountancy() : base() { }

    }
}