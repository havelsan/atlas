
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseMedulaDefinition")] 

    public  abstract  partial class BaseMedulaDefinition : TerminologyManagerDef
    {
        public class BaseMedulaDefinitionList : TTObjectCollection<BaseMedulaDefinition> { }
                    
        public class ChildBaseMedulaDefinitionCollection : TTObject.TTChildObjectCollection<BaseMedulaDefinition>
        {
            public ChildBaseMedulaDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseMedulaDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected BaseMedulaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseMedulaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseMedulaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseMedulaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseMedulaDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEMEDULADEFINITION", dataRow) { }
        protected BaseMedulaDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEMEDULADEFINITION", dataRow, isImported) { }
        public BaseMedulaDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseMedulaDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseMedulaDefinition() : base() { }

    }
}