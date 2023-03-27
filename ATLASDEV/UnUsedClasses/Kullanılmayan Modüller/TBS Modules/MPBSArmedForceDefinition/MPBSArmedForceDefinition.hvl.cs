
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSArmedForceDefinition")] 

    /// <summary>
    /// Kuvvet Tanımlama
    /// </summary>
    public  partial class MPBSArmedForceDefinition : TTDefinitionSet
    {
        public class MPBSArmedForceDefinitionList : TTObjectCollection<MPBSArmedForceDefinition> { }
                    
        public class ChildMPBSArmedForceDefinitionCollection : TTObject.TTChildObjectCollection<MPBSArmedForceDefinition>
        {
            public ChildMPBSArmedForceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSArmedForceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("70961198-6b54-43e6-876d-1e17943d6399"); } }
            public static Guid New { get { return new Guid("ec79a812-9efc-4a1f-ab21-6fc50480e807"); } }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSArmedForceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSArmedForceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSArmedForceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSArmedForceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSArmedForceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSARMEDFORCEDEFINITION", dataRow) { }
        protected MPBSArmedForceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSARMEDFORCEDEFINITION", dataRow, isImported) { }
        public MPBSArmedForceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSArmedForceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSArmedForceDefinition() : base() { }

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