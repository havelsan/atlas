
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReasonOfDayLimitChangeDefinition")] 

    /// <summary>
    /// Sevk Süresi Uzatma Sebepleri
    /// </summary>
    public  partial class ReasonOfDayLimitChangeDefinition : TTDefinitionSet
    {
        public class ReasonOfDayLimitChangeDefinitionList : TTObjectCollection<ReasonOfDayLimitChangeDefinition> { }
                    
        public class ChildReasonOfDayLimitChangeDefinitionCollection : TTObject.TTChildObjectCollection<ReasonOfDayLimitChangeDefinition>
        {
            public ChildReasonOfDayLimitChangeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReasonOfDayLimitChangeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("ac9af258-f329-450a-b49a-04583ea3bc36"); } }
            public static Guid Completed { get { return new Guid("1a1732ff-b8d0-4f08-b51b-fe0713cc2925"); } }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Sevk Süresi Erteleme Sebebi
    /// </summary>
        public string Reason
        {
            get { return (string)this["REASON"]; }
            set { this["REASON"] = value; }
        }

        public string Reason_Shadow
        {
            get { return (string)this["REASON_SHADOW"]; }
        }

        protected ReasonOfDayLimitChangeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReasonOfDayLimitChangeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReasonOfDayLimitChangeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReasonOfDayLimitChangeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReasonOfDayLimitChangeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REASONOFDAYLIMITCHANGEDEFINITION", dataRow) { }
        protected ReasonOfDayLimitChangeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REASONOFDAYLIMITCHANGEDEFINITION", dataRow, isImported) { }
        public ReasonOfDayLimitChangeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReasonOfDayLimitChangeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReasonOfDayLimitChangeDefinition() : base() { }

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