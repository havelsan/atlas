
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MonetaryUnitDefinition")] 

    /// <summary>
    /// Para Birimi Tanımları
    /// </summary>
    public  partial class MonetaryUnitDefinition : TTDefinitionSet
    {
        public class MonetaryUnitDefinitionList : TTObjectCollection<MonetaryUnitDefinition> { }
                    
        public class ChildMonetaryUnitDefinitionCollection : TTObject.TTChildObjectCollection<MonetaryUnitDefinition>
        {
            public ChildMonetaryUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMonetaryUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Para Birimi
    /// </summary>
        public string MonetaryUnit
        {
            get { return (string)this["MONETARYUNIT"]; }
            set { this["MONETARYUNIT"] = value; }
        }

        public string MonetaryUnit_Shadow
        {
            get { return (string)this["MONETARYUNIT_SHADOW"]; }
        }

        protected MonetaryUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MonetaryUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MonetaryUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MonetaryUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MonetaryUnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MONETARYUNITDEFINITION", dataRow) { }
        protected MonetaryUnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MONETARYUNITDEFINITION", dataRow, isImported) { }
        protected MonetaryUnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MonetaryUnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MonetaryUnitDefinition() : base() { }

    }
}