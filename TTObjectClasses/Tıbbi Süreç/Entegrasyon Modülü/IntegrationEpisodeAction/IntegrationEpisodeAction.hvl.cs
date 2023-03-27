
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntegrationEpisodeAction")] 

    public  partial class IntegrationEpisodeAction : EpisodeActionWithDiagnosis
    {
        public class IntegrationEpisodeActionList : TTObjectCollection<IntegrationEpisodeAction> { }
                    
        public class ChildIntegrationEpisodeActionCollection : TTObject.TTChildObjectCollection<IntegrationEpisodeAction>
        {
            public ChildIntegrationEpisodeActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntegrationEpisodeActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İşlemde
    /// </summary>
            public static Guid New { get { return new Guid("c51d2722-6cda-4173-a051-f50b2c8ed178"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("0354b2c4-6466-4cd2-90ed-c3cb34800f4b"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("b4c1549a-2a34-4faf-a122-c6d06c1663f2"); } }
        }

        protected IntegrationEpisodeAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntegrationEpisodeAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntegrationEpisodeAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntegrationEpisodeAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntegrationEpisodeAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTEGRATIONEPISODEACTION", dataRow) { }
        protected IntegrationEpisodeAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTEGRATIONEPISODEACTION", dataRow, isImported) { }
        public IntegrationEpisodeAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntegrationEpisodeAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntegrationEpisodeAction() : base() { }

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