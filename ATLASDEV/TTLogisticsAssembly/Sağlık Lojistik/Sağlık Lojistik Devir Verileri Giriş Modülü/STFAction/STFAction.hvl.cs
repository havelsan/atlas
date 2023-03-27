
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="STFAction")] 

    /// <summary>
    /// Sayım Tartı Verilerinin Girilmesi 
    /// </summary>
    public  partial class STFAction : BaseAction, IWorkListBaseAction
    {
        public class STFActionList : TTObjectCollection<STFAction> { }
                    
        public class ChildSTFActionCollection : TTObject.TTChildObjectCollection<STFAction>
        {
            public ChildSTFActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSTFActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("d66260a2-e3cb-48db-b365-8c82552c7f55"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("81c1df19-f58e-47b9-92f3-debc7ba4ca65"); } }
        }

        virtual protected void CreateSTCActionsCollection()
        {
            _STCActions = new STCAction.ChildSTCActionCollection(this, new Guid("bf936e0f-d68e-4abd-bd8b-1239ce43617c"));
            ((ITTChildObjectCollection)_STCActions).GetChildren();
        }

        protected STCAction.ChildSTCActionCollection _STCActions = null;
        public STCAction.ChildSTCActionCollection STCActions
        {
            get
            {
                if (_STCActions == null)
                    CreateSTCActionsCollection();
                return _STCActions;
            }
        }

        protected STFAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected STFAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected STFAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected STFAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected STFAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STFACTION", dataRow) { }
        protected STFAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STFACTION", dataRow, isImported) { }
        public STFAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public STFAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public STFAction() : base() { }

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