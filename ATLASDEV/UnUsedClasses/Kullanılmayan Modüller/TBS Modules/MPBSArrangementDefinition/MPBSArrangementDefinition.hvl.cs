
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSArrangementDefinition")] 

    /// <summary>
    /// Tertip Tanımlama
    /// </summary>
    public  partial class MPBSArrangementDefinition : TTDefinitionSet
    {
        public class MPBSArrangementDefinitionList : TTObjectCollection<MPBSArrangementDefinition> { }
                    
        public class ChildMPBSArrangementDefinitionCollection : TTObject.TTChildObjectCollection<MPBSArrangementDefinition>
        {
            public ChildMPBSArrangementDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSArrangementDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("1f02e3e6-1ac0-4cf6-891d-39d8c48730fd"); } }
            public static Guid Completed { get { return new Guid("f0a3dfdd-4656-437c-85b8-d34d51f29572"); } }
        }

    /// <summary>
    /// Tertip Kodu
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Tertip Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSArrangementDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSArrangementDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSArrangementDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSArrangementDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSArrangementDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSARRANGEMENTDEFINITION", dataRow) { }
        protected MPBSArrangementDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSARRANGEMENTDEFINITION", dataRow, isImported) { }
        public MPBSArrangementDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSArrangementDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSArrangementDefinition() : base() { }

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