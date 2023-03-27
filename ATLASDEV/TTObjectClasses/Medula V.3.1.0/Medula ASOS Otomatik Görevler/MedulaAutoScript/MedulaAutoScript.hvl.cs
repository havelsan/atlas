
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaAutoScript")] 

    /// <summary>
    /// Medula Otomatik Görevler
    /// </summary>
    public  partial class MedulaAutoScript : BaseScheduledTask
    {
        public class MedulaAutoScriptList : TTObjectCollection<MedulaAutoScript> { }
                    
        public class ChildMedulaAutoScriptCollection : TTObject.TTChildObjectCollection<MedulaAutoScript>
        {
            public ChildMedulaAutoScriptCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaAutoScriptCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MedulaAutoScript(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaAutoScript(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaAutoScript(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaAutoScript(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaAutoScript(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAAUTOSCRIPT", dataRow) { }
        protected MedulaAutoScript(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAAUTOSCRIPT", dataRow, isImported) { }
        public MedulaAutoScript(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaAutoScript(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaAutoScript() : base() { }

    }
}