
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActionDefaultMasterResourceGrid")] 

    public  partial class ActionDefaultMasterResourceGrid : TTDefinitionSet
    {
        public class ActionDefaultMasterResourceGridList : TTObjectCollection<ActionDefaultMasterResourceGrid> { }
                    
        public class ChildActionDefaultMasterResourceGridCollection : TTObject.TTChildObjectCollection<ActionDefaultMasterResourceGrid>
        {
            public ChildActionDefaultMasterResourceGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActionDefaultMasterResourceGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResSection Resource
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ActionDefaultMasterResourceDefinition ActionDefMasterResDefinition
        {
            get { return (ActionDefaultMasterResourceDefinition)((ITTObject)this).GetParent("ACTIONDEFMASTERRESDEFINITION"); }
            set { this["ACTIONDEFMASTERRESDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ActionDefaultMasterResourceGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActionDefaultMasterResourceGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActionDefaultMasterResourceGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActionDefaultMasterResourceGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActionDefaultMasterResourceGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIONDEFAULTMASTERRESOURCEGRID", dataRow) { }
        protected ActionDefaultMasterResourceGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIONDEFAULTMASTERRESOURCEGRID", dataRow, isImported) { }
        public ActionDefaultMasterResourceGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActionDefaultMasterResourceGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActionDefaultMasterResourceGrid() : base() { }

    }
}