
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseMedulaDefinitionAction")] 

    /// <summary>
    /// Temel Medula Tanım İşlemi
    /// </summary>
    public  abstract  partial class BaseMedulaDefinitionAction : BaseMedulaWLAction
    {
        public class BaseMedulaDefinitionActionList : TTObjectCollection<BaseMedulaDefinitionAction> { }
                    
        public class ChildBaseMedulaDefinitionActionCollection : TTObject.TTChildObjectCollection<BaseMedulaDefinitionAction>
        {
            public ChildBaseMedulaDefinitionActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseMedulaDefinitionActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("f52228d6-4444-4f84-b48d-d0e40cbad58a"); } }
            public static Guid SentMedula { get { return new Guid("a30d5d80-5025-4948-9f64-5c188c86d721"); } }
            public static Guid SentServer { get { return new Guid("c6d2a58a-a2e0-44b2-8e95-ea712bc64c64"); } }
            public static Guid Successfully { get { return new Guid("cf746204-2484-450e-9c23-bfb2c0961237"); } }
            public static Guid Cancelled { get { return new Guid("367867b2-4f3f-4889-9861-79869f6cf5b7"); } }
            public static Guid Unsuccessfully { get { return new Guid("93c48e26-1d6d-455d-ad02-84eb65484a97"); } }
            public static Guid Completed { get { return new Guid("0de41346-12c7-4388-a041-adb8e765e6f8"); } }
        }

        protected BaseMedulaDefinitionAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseMedulaDefinitionAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseMedulaDefinitionAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseMedulaDefinitionAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseMedulaDefinitionAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEMEDULADEFINITIONACTION", dataRow) { }
        protected BaseMedulaDefinitionAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEMEDULADEFINITIONACTION", dataRow, isImported) { }
        public BaseMedulaDefinitionAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseMedulaDefinitionAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseMedulaDefinitionAction() : base() { }

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