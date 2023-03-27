
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSMovable")] 

    /// <summary>
    /// Menkul
    /// </summary>
    public  partial class MPBSMovable : MPBSMovableImmovable
    {
        public class MPBSMovableList : TTObjectCollection<MPBSMovable> { }
                    
        public class ChildMPBSMovableCollection : TTObject.TTChildObjectCollection<MPBSMovable>
        {
            public ChildMPBSMovableCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSMovableCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("edbafea1-a6fa-4910-9e7e-089a677bf8ef"); } }
            public static Guid New { get { return new Guid("4478d48f-d8eb-4460-9c60-a87d894f23bc"); } }
        }

        protected MPBSMovable(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSMovable(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSMovable(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSMovable(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSMovable(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSMOVABLE", dataRow) { }
        protected MPBSMovable(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSMOVABLE", dataRow, isImported) { }
        public MPBSMovable(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSMovable(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSMovable() : base() { }

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