
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSGarrisonDefinition")] 

    /// <summary>
    /// Garnizon Tanımlama
    /// </summary>
    public  partial class MPBSGarrisonDefinition : TTDefinitionSet
    {
        public class MPBSGarrisonDefinitionList : TTObjectCollection<MPBSGarrisonDefinition> { }
                    
        public class ChildMPBSGarrisonDefinitionCollection : TTObject.TTChildObjectCollection<MPBSGarrisonDefinition>
        {
            public ChildMPBSGarrisonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSGarrisonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("4ab102de-b28b-49d3-aee4-d3e4b3202a16"); } }
            public static Guid Completed { get { return new Guid("8295b0ee-3197-45d1-a21a-de5f33a02e72"); } }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSGarrisonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSGarrisonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSGarrisonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSGarrisonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSGarrisonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSGARRISONDEFINITION", dataRow) { }
        protected MPBSGarrisonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSGARRISONDEFINITION", dataRow, isImported) { }
        public MPBSGarrisonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSGarrisonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSGarrisonDefinition() : base() { }

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