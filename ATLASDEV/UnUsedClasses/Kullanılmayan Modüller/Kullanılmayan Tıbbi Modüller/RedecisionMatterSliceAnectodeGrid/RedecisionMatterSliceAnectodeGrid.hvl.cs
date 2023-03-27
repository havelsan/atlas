
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RedecisionMatterSliceAnectodeGrid")] 

    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
    public  partial class RedecisionMatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class RedecisionMatterSliceAnectodeGridList : TTObjectCollection<RedecisionMatterSliceAnectodeGrid> { }
                    
        public class ChildRedecisionMatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<RedecisionMatterSliceAnectodeGrid>
        {
            public ChildRedecisionMatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRedecisionMatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
        public Redecision Redecision
        {
            get { return (Redecision)((ITTObject)this).GetParent("REDECISION"); }
            set { this["REDECISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REDECISIONMATTERSLICEANECTODEGRID", dataRow) { }
        protected RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REDECISIONMATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public RedecisionMatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RedecisionMatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RedecisionMatterSliceAnectodeGrid() : base() { }

    }
}