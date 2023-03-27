
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresChaDocOutputDetWithAccountancy")] 

    public  partial class PresChaDocOutputDetWithAccountancy : ChattelDocumentOutputDetailWithAccountancy
    {
        public class PresChaDocOutputDetWithAccountancyList : TTObjectCollection<PresChaDocOutputDetWithAccountancy> { }
                    
        public class ChildPresChaDocOutputDetWithAccountancyCollection : TTObject.TTChildObjectCollection<PresChaDocOutputDetWithAccountancy>
        {
            public ChildPresChaDocOutputDetWithAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresChaDocOutputDetWithAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresChaDocOutputWithAccountancy PresChaDocOutputWithAccountancy
        {
            get 
            {   
                if (StockAction is PresChaDocOutputWithAccountancy)
                    return (PresChaDocOutputWithAccountancy)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresChaDocOutputDetWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresChaDocOutputDetWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresChaDocOutputDetWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresChaDocOutputDetWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresChaDocOutputDetWithAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCHADOCOUTPUTDETWITHACCOUNTANCY", dataRow) { }
        protected PresChaDocOutputDetWithAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCHADOCOUTPUTDETWITHACCOUNTANCY", dataRow, isImported) { }
        public PresChaDocOutputDetWithAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresChaDocOutputDetWithAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresChaDocOutputDetWithAccountancy() : base() { }

    }
}