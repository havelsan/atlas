
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DepStoreFirstInAction")] 

    /// <summary>
    /// Bağlı Birlik İlk Giriş İşlemi
    /// </summary>
    public  partial class DepStoreFirstInAction : BaseAction, IWorkListBaseAction
    {
        public class DepStoreFirstInActionList : TTObjectCollection<DepStoreFirstInAction> { }
                    
        public class ChildDepStoreFirstInActionCollection : TTObject.TTChildObjectCollection<DepStoreFirstInAction>
        {
            public ChildDepStoreFirstInActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDepStoreFirstInActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("c3111e95-68d3-4f5e-a520-cc79a4081419"); } }
    /// <summary>
    /// Bağlı Birliğe Gönderildi
    /// </summary>
            public static Guid SendDependentStore { get { return new Guid("84f333d0-8d5e-4004-94bd-717b85e6d057"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("fe4eec4b-5610-47cb-a782-4b914e9659ce"); } }
        }

        public DependentStoreDefinition DependentStore
        {
            get { return (DependentStoreDefinition)((ITTObject)this).GetParent("DEPENDENTSTORE"); }
            set { this["DEPENDENTSTORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDepStoreFirstInActionDetailsCollection()
        {
            _DepStoreFirstInActionDetails = new DepStoreFirstInActionDet.ChildDepStoreFirstInActionDetCollection(this, new Guid("40933b81-7977-41b7-9aca-689adc5ccf8a"));
            ((ITTChildObjectCollection)_DepStoreFirstInActionDetails).GetChildren();
        }

        protected DepStoreFirstInActionDet.ChildDepStoreFirstInActionDetCollection _DepStoreFirstInActionDetails = null;
        public DepStoreFirstInActionDet.ChildDepStoreFirstInActionDetCollection DepStoreFirstInActionDetails
        {
            get
            {
                if (_DepStoreFirstInActionDetails == null)
                    CreateDepStoreFirstInActionDetailsCollection();
                return _DepStoreFirstInActionDetails;
            }
        }

        protected DepStoreFirstInAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DepStoreFirstInAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DepStoreFirstInAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DepStoreFirstInAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DepStoreFirstInAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEPSTOREFIRSTINACTION", dataRow) { }
        protected DepStoreFirstInAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEPSTOREFIRSTINACTION", dataRow, isImported) { }
        public DepStoreFirstInAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DepStoreFirstInAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DepStoreFirstInAction() : base() { }

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