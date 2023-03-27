
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSMainTOEDefinition")] 

    /// <summary>
    /// Ana TMK Tanımlama
    /// </summary>
    public  partial class MPBSMainTOEDefinition : TTDefinitionSet
    {
        public class MPBSMainTOEDefinitionList : TTObjectCollection<MPBSMainTOEDefinition> { }
                    
        public class ChildMPBSMainTOEDefinitionCollection : TTObject.TTChildObjectCollection<MPBSMainTOEDefinition>
        {
            public ChildMPBSMainTOEDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSMainTOEDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("1415065d-94da-42ca-9897-7839d5f3c57f"); } }
            public static Guid Completed { get { return new Guid("f0bf5eb0-7cf8-4976-b291-fc7c25224e97"); } }
        }

    /// <summary>
    /// Ana TMK Kodu
    /// </summary>
        public string MainTOECode
        {
            get { return (string)this["MAINTOECODE"]; }
            set { this["MAINTOECODE"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

        public MPBSUnitDefinition UnitDefinition
        {
            get { return (MPBSUnitDefinition)((ITTObject)this).GetParent("UNITDEFINITION"); }
            set { this["UNITDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSMainTOEDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSMainTOEDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSMainTOEDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSMainTOEDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSMainTOEDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSMAINTOEDEFINITION", dataRow) { }
        protected MPBSMainTOEDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSMAINTOEDEFINITION", dataRow, isImported) { }
        public MPBSMainTOEDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSMainTOEDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSMainTOEDefinition() : base() { }

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