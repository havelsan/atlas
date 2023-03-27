
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="STCFirstInAction")] 

    /// <summary>
    /// Sayım Tartı Çizelgesinden İlk Giriş
    /// </summary>
    public  partial class STCFirstInAction : BaseAction, IWorkListBaseAction
    {
        public class STCFirstInActionList : TTObjectCollection<STCFirstInAction> { }
                    
        public class ChildSTCFirstInActionCollection : TTObject.TTChildObjectCollection<STCFirstInAction>
        {
            public ChildSTCFirstInActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSTCFirstInActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fd6d41d8-f168-4c18-b832-e58aff7cc574"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("15c7f951-c399-4f9f-b876-c78e078a35ed"); } }
        }

        public MainStoreDefinition MainStoreDefinition
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("MAINSTOREDEFINITION"); }
            set { this["MAINSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSTCActionsCollection()
        {
            _STCActions = new STCAction.ChildSTCActionCollection(this, new Guid("22a5fb87-81f5-4ebb-8dc3-00107a7c72f9"));
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

        protected STCFirstInAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected STCFirstInAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected STCFirstInAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected STCFirstInAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected STCFirstInAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STCFIRSTINACTION", dataRow) { }
        protected STCFirstInAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STCFIRSTINACTION", dataRow, isImported) { }
        public STCFirstInAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public STCFirstInAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public STCFirstInAction() : base() { }

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