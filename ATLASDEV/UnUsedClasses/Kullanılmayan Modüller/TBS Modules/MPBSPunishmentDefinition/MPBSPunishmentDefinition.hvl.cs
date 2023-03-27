
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSPunishmentDefinition")] 

    /// <summary>
    /// Ceza Tanımlama
    /// </summary>
    public  partial class MPBSPunishmentDefinition : TTDefinitionSet
    {
        public class MPBSPunishmentDefinitionList : TTObjectCollection<MPBSPunishmentDefinition> { }
                    
        public class ChildMPBSPunishmentDefinitionCollection : TTObject.TTChildObjectCollection<MPBSPunishmentDefinition>
        {
            public ChildMPBSPunishmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSPunishmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("1593060e-1123-4f78-bb66-45f0e4577155"); } }
            public static Guid Completed { get { return new Guid("af4f8ce5-9e58-4486-b4bf-5ff0293605fd"); } }
        }

    /// <summary>
    /// Ceza Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSPunishmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSPunishmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSPunishmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSPunishmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSPunishmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSPUNISHMENTDEFINITION", dataRow) { }
        protected MPBSPunishmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSPUNISHMENTDEFINITION", dataRow, isImported) { }
        public MPBSPunishmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSPunishmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSPunishmentDefinition() : base() { }

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