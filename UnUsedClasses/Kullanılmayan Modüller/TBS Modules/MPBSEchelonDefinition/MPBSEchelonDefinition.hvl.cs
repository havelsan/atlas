
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSEchelonDefinition")] 

    /// <summary>
    /// Kademe Tanımlama
    /// </summary>
    public  partial class MPBSEchelonDefinition : TTDefinitionSet
    {
        public class MPBSEchelonDefinitionList : TTObjectCollection<MPBSEchelonDefinition> { }
                    
        public class ChildMPBSEchelonDefinitionCollection : TTObject.TTChildObjectCollection<MPBSEchelonDefinition>
        {
            public ChildMPBSEchelonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSEchelonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("1f60f165-2d33-4ffa-9551-4d00ff707d81"); } }
            public static Guid Completed { get { return new Guid("3c62851a-a78c-47aa-b643-db55d9dd574c"); } }
        }

    /// <summary>
    /// Kademe Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSEchelonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSEchelonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSEchelonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSEchelonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSEchelonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSECHELONDEFINITION", dataRow) { }
        protected MPBSEchelonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSECHELONDEFINITION", dataRow, isImported) { }
        public MPBSEchelonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSEchelonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSEchelonDefinition() : base() { }

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