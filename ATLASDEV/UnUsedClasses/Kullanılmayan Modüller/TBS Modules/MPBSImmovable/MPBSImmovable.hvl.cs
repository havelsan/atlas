
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSImmovable")] 

    /// <summary>
    /// GayriMenkul
    /// </summary>
    public  partial class MPBSImmovable : MPBSMovableImmovable
    {
        public class MPBSImmovableList : TTObjectCollection<MPBSImmovable> { }
                    
        public class ChildMPBSImmovableCollection : TTObject.TTChildObjectCollection<MPBSImmovable>
        {
            public ChildMPBSImmovableCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSImmovableCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("074ee4f3-9251-4f82-9251-06f2353e7773"); } }
            public static Guid New { get { return new Guid("645f1001-b537-4e8a-966e-3cb17039c968"); } }
        }

        protected MPBSImmovable(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSImmovable(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSImmovable(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSImmovable(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSImmovable(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSIMMOVABLE", dataRow) { }
        protected MPBSImmovable(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSIMMOVABLE", dataRow, isImported) { }
        public MPBSImmovable(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSImmovable(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSImmovable() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}