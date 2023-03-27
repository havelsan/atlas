
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSMainMajorDefinition")] 

    /// <summary>
    /// Ana Bilim Dalı Tanımlama
    /// </summary>
    public  partial class MPBSMainMajorDefinition : TTDefinitionSet
    {
        public class MPBSMainMajorDefinitionList : TTObjectCollection<MPBSMainMajorDefinition> { }
                    
        public class ChildMPBSMainMajorDefinitionCollection : TTObject.TTChildObjectCollection<MPBSMainMajorDefinition>
        {
            public ChildMPBSMainMajorDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSMainMajorDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("00642549-c5f2-4872-9b3f-907f6651c85d"); } }
            public static Guid New { get { return new Guid("379b85a0-0446-4f84-b718-91c6f9c1b028"); } }
        }

    /// <summary>
    /// Ana Bilim Dalı Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSMainMajorDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSMainMajorDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSMainMajorDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSMainMajorDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSMainMajorDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSMAINMAJORDEFINITION", dataRow) { }
        protected MPBSMainMajorDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSMAINMAJORDEFINITION", dataRow, isImported) { }
        public MPBSMainMajorDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSMainMajorDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSMainMajorDefinition() : base() { }

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