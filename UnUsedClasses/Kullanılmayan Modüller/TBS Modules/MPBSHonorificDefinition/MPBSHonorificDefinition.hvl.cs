
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSHonorificDefinition")] 

    /// <summary>
    /// Unvan Tanımlama
    /// </summary>
    public  partial class MPBSHonorificDefinition : TTDefinitionSet
    {
        public class MPBSHonorificDefinitionList : TTObjectCollection<MPBSHonorificDefinition> { }
                    
        public class ChildMPBSHonorificDefinitionCollection : TTObject.TTChildObjectCollection<MPBSHonorificDefinition>
        {
            public ChildMPBSHonorificDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSHonorificDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("1262f706-d56e-4a41-abba-3ed948726737"); } }
            public static Guid New { get { return new Guid("81b3cbc2-9f38-431b-b491-6627ee4ba95e"); } }
        }

    /// <summary>
    /// Unvan Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSHonorificDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSHonorificDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSHonorificDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSHonorificDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSHonorificDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSHONORIFICDEFINITION", dataRow) { }
        protected MPBSHonorificDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSHONORIFICDEFINITION", dataRow, isImported) { }
        public MPBSHonorificDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSHonorificDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSHonorificDefinition() : base() { }

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