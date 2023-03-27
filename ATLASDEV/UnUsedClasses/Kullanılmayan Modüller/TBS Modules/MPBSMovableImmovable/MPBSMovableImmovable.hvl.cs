
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSMovableImmovable")] 

    public  partial class MPBSMovableImmovable : MPBSAsset
    {
        public class MPBSMovableImmovableList : TTObjectCollection<MPBSMovableImmovable> { }
                    
        public class ChildMPBSMovableImmovableCollection : TTObject.TTChildObjectCollection<MPBSMovableImmovable>
        {
            public ChildMPBSMovableImmovableCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSMovableImmovableCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tutar
    /// </summary>
        public double? Value
        {
            get { return (double?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public string Kind
        {
            get { return (string)this["KIND"]; }
            set { this["KIND"] = value; }
        }

    /// <summary>
    /// Adet
    /// </summary>
        public int? PieceNumber
        {
            get { return (int?)this["PIECENUMBER"]; }
            set { this["PIECENUMBER"] = value; }
        }

        protected MPBSMovableImmovable(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSMovableImmovable(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSMovableImmovable(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSMovableImmovable(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSMovableImmovable(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSMOVABLEIMMOVABLE", dataRow) { }
        protected MPBSMovableImmovable(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSMOVABLEIMMOVABLE", dataRow, isImported) { }
        public MPBSMovableImmovable(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSMovableImmovable(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSMovableImmovable() : base() { }

    }
}