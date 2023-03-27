
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="XXXActionGroupDefinition")] 

    /// <summary>
    /// İşlem Grupu Tanımları
    /// </summary>
    public  partial class XXXActionGroupDefinition : TTDefinitionSet
    {
        public class XXXActionGroupDefinitionList : TTObjectCollection<XXXActionGroupDefinition> { }
                    
        public class ChildXXXActionGroupDefinitionCollection : TTObject.TTChildObjectCollection<XXXActionGroupDefinition>
        {
            public ChildXXXActionGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildXXXActionGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// ID
    /// </summary>
        public string ID
        {
            get { return (string)this["ID"]; }
            set { this["ID"] = value; }
        }

        protected XXXActionGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected XXXActionGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected XXXActionGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected XXXActionGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected XXXActionGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "XXXACTIONGROUPDEFINITION", dataRow) { }
        protected XXXActionGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "XXXACTIONGROUPDEFINITION", dataRow, isImported) { }
        protected XXXActionGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public XXXActionGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public XXXActionGroupDefinition() : base() { }

    }
}