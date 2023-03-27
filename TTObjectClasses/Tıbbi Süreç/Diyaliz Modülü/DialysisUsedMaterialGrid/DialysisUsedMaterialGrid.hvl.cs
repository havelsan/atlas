
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DialysisUsedMaterialGrid")] 

    /// <summary>
    /// Diyalizde Kullanılan Malzemeler
    /// </summary>
    public  partial class DialysisUsedMaterialGrid : TTObject
    {
        public class DialysisUsedMaterialGridList : TTObjectCollection<DialysisUsedMaterialGrid> { }
                    
        public class ChildDialysisUsedMaterialGridCollection : TTObject.TTChildObjectCollection<DialysisUsedMaterialGrid>
        {
            public ChildDialysisUsedMaterialGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDialysisUsedMaterialGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Diyalizde Kullanılan Malzemeler
    /// </summary>
        public DialysisDefinition DialysisDefinition
        {
            get { return (DialysisDefinition)((ITTObject)this).GetParent("DIALYSISDEFINITION"); }
            set { this["DIALYSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DialysisUsedMaterialGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DialysisUsedMaterialGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DialysisUsedMaterialGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DialysisUsedMaterialGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DialysisUsedMaterialGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIALYSISUSEDMATERIALGRID", dataRow) { }
        protected DialysisUsedMaterialGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIALYSISUSEDMATERIALGRID", dataRow, isImported) { }
        protected DialysisUsedMaterialGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DialysisUsedMaterialGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DialysisUsedMaterialGrid() : base() { }

    }
}