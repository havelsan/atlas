
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSLeaveDefinition")] 

    /// <summary>
    /// İzin Nedeni Tanımlama
    /// </summary>
    public  partial class MPBSLeaveDefinition : TTDefinitionSet
    {
        public class MPBSLeaveDefinitionList : TTObjectCollection<MPBSLeaveDefinition> { }
                    
        public class ChildMPBSLeaveDefinitionCollection : TTObject.TTChildObjectCollection<MPBSLeaveDefinition>
        {
            public ChildMPBSLeaveDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSLeaveDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Completed { get { return new Guid("45b51994-6cbc-4602-8ed3-816f3a7dc19b"); } }
            public static Guid New { get { return new Guid("43c28e07-1637-42fa-93b1-c68887a47266"); } }
        }

    /// <summary>
    /// İzin Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected MPBSLeaveDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSLeaveDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSLeaveDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSLeaveDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSLeaveDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSLEAVEDEFINITION", dataRow) { }
        protected MPBSLeaveDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSLEAVEDEFINITION", dataRow, isImported) { }
        public MPBSLeaveDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSLeaveDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSLeaveDefinition() : base() { }

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