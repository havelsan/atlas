
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OLAPBaseAction")] 

    public  abstract  partial class OLAPBaseAction : BaseOLAPDefinition
    {
        public class OLAPBaseActionList : TTObjectCollection<OLAPBaseAction> { }
                    
        public class ChildOLAPBaseActionCollection : TTObject.TTChildObjectCollection<OLAPBaseAction>
        {
            public ChildOLAPBaseActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOLAPBaseActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected OLAPBaseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OLAPBaseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OLAPBaseAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OLAPBaseAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OLAPBaseAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLAPBASEACTION", dataRow) { }
        protected OLAPBaseAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLAPBASEACTION", dataRow, isImported) { }
        public OLAPBaseAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OLAPBaseAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OLAPBaseAction() : base() { }

    }
}