
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyTestDescriptionDefinition")] 

    public  partial class PathologyTestDescriptionDefinition : TTDefinitionSet
    {
        public class PathologyTestDescriptionDefinitionList : TTObjectCollection<PathologyTestDescriptionDefinition> { }
                    
        public class ChildPathologyTestDescriptionDefinitionCollection : TTObject.TTChildObjectCollection<PathologyTestDescriptionDefinition>
        {
            public ChildPathologyTestDescriptionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyTestDescriptionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("076ec7d5-aaa2-4160-b251-6ae39a4009a4"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("6ee1dcd9-0a32-435a-980f-b795d3e8aa93"); } }
        }

    /// <summary>
    /// Kısa Açıklama
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected PathologyTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyTestDescriptionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYTESTDESCRIPTIONDEFINITION", dataRow) { }
        protected PathologyTestDescriptionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYTESTDESCRIPTIONDEFINITION", dataRow, isImported) { }
        public PathologyTestDescriptionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyTestDescriptionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyTestDescriptionDefinition() : base() { }

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