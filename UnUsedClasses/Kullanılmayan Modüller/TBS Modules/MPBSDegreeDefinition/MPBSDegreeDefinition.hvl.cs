
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSDegreeDefinition")] 

    /// <summary>
    /// Derece Tanımlama
    /// </summary>
    public  partial class MPBSDegreeDefinition : TTDefinitionSet
    {
        public class MPBSDegreeDefinitionList : TTObjectCollection<MPBSDegreeDefinition> { }
                    
        public class ChildMPBSDegreeDefinitionCollection : TTObject.TTChildObjectCollection<MPBSDegreeDefinition>
        {
            public ChildMPBSDegreeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSDegreeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("d79aa8cb-0025-4cf1-9c23-4bee6c9c91c7"); } }
            public static Guid Completed { get { return new Guid("2de43f1e-4de9-4bd3-aea3-b064a3aaf177"); } }
        }

    /// <summary>
    /// Derece Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSDegreeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSDegreeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSDegreeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSDegreeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSDegreeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSDEGREEDEFINITION", dataRow) { }
        protected MPBSDegreeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSDEGREEDEFINITION", dataRow, isImported) { }
        public MPBSDegreeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSDegreeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSDegreeDefinition() : base() { }

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