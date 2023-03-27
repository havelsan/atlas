
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSExpenseCenterDefinition")] 

    /// <summary>
    /// Masraf Merkezi
    /// </summary>
    public  partial class MhSExpenseCenterDefinition : TTDefinitionSet
    {
        public class MhSExpenseCenterDefinitionList : TTObjectCollection<MhSExpenseCenterDefinition> { }
                    
        public class ChildMhSExpenseCenterDefinitionCollection : TTObject.TTChildObjectCollection<MhSExpenseCenterDefinition>
        {
            public ChildMhSExpenseCenterDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSExpenseCenterDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MhSExpenseCenterDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSExpenseCenterDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSExpenseCenterDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSExpenseCenterDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSExpenseCenterDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSEXPENSECENTERDEFINITION", dataRow) { }
        protected MhSExpenseCenterDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSEXPENSECENTERDEFINITION", dataRow, isImported) { }
        public MhSExpenseCenterDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSExpenseCenterDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSExpenseCenterDefinition() : base() { }

    }
}