
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BranchGrid")] 

    public  partial class BranchGrid : TTObject
    {
        public class BranchGridList : TTObjectCollection<BranchGrid> { }
                    
        public class ChildBranchGridCollection : TTObject.TTChildObjectCollection<BranchGrid>
        {
            public ChildBranchGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBranchGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected BranchGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BranchGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BranchGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BranchGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BranchGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BRANCHGRID", dataRow) { }
        protected BranchGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BRANCHGRID", dataRow, isImported) { }
        public BranchGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BranchGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BranchGrid() : base() { }

    }
}