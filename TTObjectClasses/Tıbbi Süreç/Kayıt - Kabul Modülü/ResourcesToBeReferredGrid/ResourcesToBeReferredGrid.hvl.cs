
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResourcesToBeReferredGrid")] 

    /// <summary>
    /// Havale Edilecek Birimler
    /// </summary>
    public  partial class ResourcesToBeReferredGrid : TTObject
    {
        public class ResourcesToBeReferredGridList : TTObjectCollection<ResourcesToBeReferredGrid> { }
                    
        public class ChildResourcesToBeReferredGridCollection : TTObject.TTChildObjectCollection<ResourcesToBeReferredGrid>
        {
            public ChildResourcesToBeReferredGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResourcesToBeReferredGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Birimler
    /// </summary>
        public ResSection Resource
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResourcesToBeReferredGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResourcesToBeReferredGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResourcesToBeReferredGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResourcesToBeReferredGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResourcesToBeReferredGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESOURCESTOBEREFERREDGRID", dataRow) { }
        protected ResourcesToBeReferredGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESOURCESTOBEREFERREDGRID", dataRow, isImported) { }
        public ResourcesToBeReferredGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResourcesToBeReferredGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResourcesToBeReferredGrid() : base() { }

    }
}