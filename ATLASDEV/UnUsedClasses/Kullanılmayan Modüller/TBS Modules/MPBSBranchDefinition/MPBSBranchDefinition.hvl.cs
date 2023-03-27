
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSBranchDefinition")] 

    /// <summary>
    /// Branş Tanımlama
    /// </summary>
    public  partial class MPBSBranchDefinition : TTDefinitionSet
    {
        public class MPBSBranchDefinitionList : TTObjectCollection<MPBSBranchDefinition> { }
                    
        public class ChildMPBSBranchDefinitionCollection : TTObject.TTChildObjectCollection<MPBSBranchDefinition>
        {
            public ChildMPBSBranchDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSBranchDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("82b338eb-3a8c-4485-93e2-2b8fecbd1e8d"); } }
            public static Guid New { get { return new Guid("3713cff7-5053-4665-8c37-6a6bb3444701"); } }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSBranchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSBranchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSBranchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSBranchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSBranchDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSBRANCHDEFINITION", dataRow) { }
        protected MPBSBranchDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSBRANCHDEFINITION", dataRow, isImported) { }
        public MPBSBranchDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSBranchDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSBranchDefinition() : base() { }

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