
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSMobilizationCategoryDefinition")] 

    /// <summary>
    /// Seferberlik Kategori Tanımlama
    /// </summary>
    public  partial class MPBSMobilizationCategoryDefinition : TTDefinitionSet
    {
        public class MPBSMobilizationCategoryDefinitionList : TTObjectCollection<MPBSMobilizationCategoryDefinition> { }
                    
        public class ChildMPBSMobilizationCategoryDefinitionCollection : TTObject.TTChildObjectCollection<MPBSMobilizationCategoryDefinition>
        {
            public ChildMPBSMobilizationCategoryDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSMobilizationCategoryDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("1a86a8b3-ff4d-4a3f-864b-832ea682e41c"); } }
            public static Guid New { get { return new Guid("c16b724b-9d01-4caf-8f38-adc473b263f3"); } }
        }

    /// <summary>
    /// Seferberlik Kategori Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSMobilizationCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSMobilizationCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSMobilizationCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSMobilizationCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSMobilizationCategoryDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSMOBILIZATIONCATEGORYDEFINITION", dataRow) { }
        protected MPBSMobilizationCategoryDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSMOBILIZATIONCATEGORYDEFINITION", dataRow, isImported) { }
        public MPBSMobilizationCategoryDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSMobilizationCategoryDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSMobilizationCategoryDefinition() : base() { }

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