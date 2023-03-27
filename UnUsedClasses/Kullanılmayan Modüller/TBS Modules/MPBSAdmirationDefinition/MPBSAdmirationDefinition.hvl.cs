
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSAdmirationDefinition")] 

    /// <summary>
    /// Takdir Tanımlama
    /// </summary>
    public  partial class MPBSAdmirationDefinition : TTDefinitionSet
    {
        public class MPBSAdmirationDefinitionList : TTObjectCollection<MPBSAdmirationDefinition> { }
                    
        public class ChildMPBSAdmirationDefinitionCollection : TTObject.TTChildObjectCollection<MPBSAdmirationDefinition>
        {
            public ChildMPBSAdmirationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSAdmirationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("10364032-5f2b-4900-9626-9fa6a8e8e973"); } }
            public static Guid New { get { return new Guid("ffe47164-6e55-4a4d-9861-798bef92bb24"); } }
        }

    /// <summary>
    /// Takdir Kodu
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Takdir Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSAdmirationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSAdmirationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSAdmirationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSAdmirationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSAdmirationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSADMIRATIONDEFINITION", dataRow) { }
        protected MPBSAdmirationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSADMIRATIONDEFINITION", dataRow, isImported) { }
        public MPBSAdmirationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSAdmirationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSAdmirationDefinition() : base() { }

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