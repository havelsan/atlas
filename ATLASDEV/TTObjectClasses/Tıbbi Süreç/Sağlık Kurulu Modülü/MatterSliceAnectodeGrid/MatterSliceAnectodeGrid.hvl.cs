
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MatterSliceAnectodeGrid")] 

    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
    public  partial class MatterSliceAnectodeGrid : TTObject
    {
        public class MatterSliceAnectodeGridList : TTObjectCollection<MatterSliceAnectodeGrid> { }
                    
        public class ChildMatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<MatterSliceAnectodeGrid>
        {
            public ChildMatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dilim
    /// </summary>
        public SliceEnum? Slice
        {
            get { return (SliceEnum?)(int?)this["SLICE"]; }
            set { this["SLICE"] = value; }
        }

    /// <summary>
    /// Fıkra
    /// </summary>
        public int? Anectode
        {
            get { return (int?)this["ANECTODE"]; }
            set { this["ANECTODE"] = value; }
        }

    /// <summary>
    /// Madde
    /// </summary>
        public int? Matter
        {
            get { return (int?)this["MATTER"]; }
            set { this["MATTER"] = value; }
        }

    /// <summary>
    /// Dilim
    /// </summary>
        public HalfSliceEnum? HalfSlice
        {
            get { return (HalfSliceEnum?)(int?)this["HALFSLICE"]; }
            set { this["HALFSLICE"] = value; }
        }

        protected MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATTERSLICEANECTODEGRID", dataRow) { }
        protected MatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public MatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MatterSliceAnectodeGrid() : base() { }

    }
}