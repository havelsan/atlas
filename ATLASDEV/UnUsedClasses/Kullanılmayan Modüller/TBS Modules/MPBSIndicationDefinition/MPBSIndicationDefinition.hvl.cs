
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSIndicationDefinition")] 

    /// <summary>
    /// Gösterge Tanımlama
    /// </summary>
    public  partial class MPBSIndicationDefinition : TTDefinitionSet
    {
        public class MPBSIndicationDefinitionList : TTObjectCollection<MPBSIndicationDefinition> { }
                    
        public class ChildMPBSIndicationDefinitionCollection : TTObject.TTChildObjectCollection<MPBSIndicationDefinition>
        {
            public ChildMPBSIndicationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSIndicationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("639f74db-0a9f-4c25-a9f9-d4e1c403fba3"); } }
            public static Guid Completed { get { return new Guid("049aafce-90b8-43c2-806e-c18b2760905f"); } }
        }

    /// <summary>
    /// Gösterge Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSIndicationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSIndicationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSIndicationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSIndicationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSIndicationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSINDICATIONDEFINITION", dataRow) { }
        protected MPBSIndicationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSINDICATIONDEFINITION", dataRow, isImported) { }
        public MPBSIndicationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSIndicationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSIndicationDefinition() : base() { }

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