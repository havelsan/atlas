
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrMatterSliceAnectodeGrid")] 

    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
    public  partial class ehrMatterSliceAnectodeGrid : BaseEhr
    {
        public class ehrMatterSliceAnectodeGridList : TTObjectCollection<ehrMatterSliceAnectodeGrid> { }
                    
        public class ChildehrMatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<ehrMatterSliceAnectodeGrid>
        {
            public ChildehrMatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrMatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
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
    ///  Dilim
    /// </summary>
        public SliceEnum? Slice
        {
            get { return (SliceEnum?)(int?)this["SLICE"]; }
            set { this["SLICE"] = value; }
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

        protected ehrMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRMATTERSLICEANECTODEGRID", dataRow) { }
        protected ehrMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRMATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public ehrMatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrMatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrMatterSliceAnectodeGrid() : base() { }

    }
}