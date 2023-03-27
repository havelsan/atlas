
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSTrainingUnitDefinition")] 

    /// <summary>
    /// Staj Birimi Tanımlama
    /// </summary>
    public  partial class MPBSTrainingUnitDefinition : TTDefinitionSet
    {
        public class MPBSTrainingUnitDefinitionList : TTObjectCollection<MPBSTrainingUnitDefinition> { }
                    
        public class ChildMPBSTrainingUnitDefinitionCollection : TTObject.TTChildObjectCollection<MPBSTrainingUnitDefinition>
        {
            public ChildMPBSTrainingUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSTrainingUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("633a482a-0b1d-41b8-80fe-8d0dc02ba7dc"); } }
            public static Guid Completed { get { return new Guid("0645f7ec-9734-4753-beb4-aa6b9894fc72"); } }
        }

    /// <summary>
    /// Staj Birimi Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSTrainingUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSTrainingUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSTrainingUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSTrainingUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSTrainingUnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSTRAININGUNITDEFINITION", dataRow) { }
        protected MPBSTrainingUnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSTRAININGUNITDEFINITION", dataRow, isImported) { }
        public MPBSTrainingUnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSTrainingUnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSTrainingUnitDefinition() : base() { }

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