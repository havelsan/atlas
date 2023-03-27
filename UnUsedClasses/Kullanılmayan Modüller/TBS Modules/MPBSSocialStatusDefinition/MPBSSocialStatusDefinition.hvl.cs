
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSSocialStatusDefinition")] 

    /// <summary>
    /// Sosyal Statü Tanımlama
    /// </summary>
    public  partial class MPBSSocialStatusDefinition : TTDefinitionSet
    {
        public class MPBSSocialStatusDefinitionList : TTObjectCollection<MPBSSocialStatusDefinition> { }
                    
        public class ChildMPBSSocialStatusDefinitionCollection : TTObject.TTChildObjectCollection<MPBSSocialStatusDefinition>
        {
            public ChildMPBSSocialStatusDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSSocialStatusDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("9a4873f7-9797-45bb-a9a6-6c766f83c27c"); } }
            public static Guid Completed { get { return new Guid("f70320a8-5da5-424d-a352-dd3001680dae"); } }
        }

    /// <summary>
    /// Sosyal Statü Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSSocialStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSSocialStatusDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSSocialStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSSocialStatusDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSSocialStatusDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSSOCIALSTATUSDEFINITION", dataRow) { }
        protected MPBSSocialStatusDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSSOCIALSTATUSDEFINITION", dataRow, isImported) { }
        public MPBSSocialStatusDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSSocialStatusDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSSocialStatusDefinition() : base() { }

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