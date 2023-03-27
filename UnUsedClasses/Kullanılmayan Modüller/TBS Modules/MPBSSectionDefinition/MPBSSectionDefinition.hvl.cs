
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSSectionDefinition")] 

    /// <summary>
    /// Kısım Tanımlama
    /// </summary>
    public  partial class MPBSSectionDefinition : TTDefinitionSet
    {
        public class MPBSSectionDefinitionList : TTObjectCollection<MPBSSectionDefinition> { }
                    
        public class ChildMPBSSectionDefinitionCollection : TTObject.TTChildObjectCollection<MPBSSectionDefinition>
        {
            public ChildMPBSSectionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSSectionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("a96c7397-fd02-4f10-9495-9252fbab8542"); } }
            public static Guid New { get { return new Guid("3a53cb48-47ea-47d1-a164-f135f0062530"); } }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public MPBSOfficeDefinition OfficeDefinition
        {
            get { return (MPBSOfficeDefinition)((ITTObject)this).GetParent("OFFICEDEFINITION"); }
            set { this["OFFICEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSSectionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSSectionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSSectionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSSectionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSSectionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSSECTIONDEFINITION", dataRow) { }
        protected MPBSSectionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSSECTIONDEFINITION", dataRow, isImported) { }
        public MPBSSectionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSSectionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSSectionDefinition() : base() { }

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