
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MartialStatusDefinition")] 

    /// <summary>
    /// Medeni Durum Tanımlama 
    /// </summary>
    public  partial class MartialStatusDefinition : TTObject
    {
        public class MartialStatusDefinitionList : TTObjectCollection<MartialStatusDefinition> { }
                    
        public class ChildMartialStatusDefinitionCollection : TTObject.TTChildObjectCollection<MartialStatusDefinition>
        {
            public ChildMartialStatusDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMartialStatusDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MartialStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MartialStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MartialStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MartialStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MartialStatusDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MARTIALSTATUSDEFINITION", dataRow) { }
        protected MartialStatusDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MARTIALSTATUSDEFINITION", dataRow, isImported) { }
        public MartialStatusDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MartialStatusDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MartialStatusDefinition() : base() { }

    }
}