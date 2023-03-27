
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="STCUpdateAction")] 

    /// <summary>
    /// Sayım Tartı Çizelgesinin Güncellenmesi
    /// </summary>
    public  partial class STCUpdateAction : BaseAction
    {
        public class STCUpdateActionList : TTObjectCollection<STCUpdateAction> { }
                    
        public class ChildSTCUpdateActionCollection : TTObject.TTChildObjectCollection<STCUpdateAction>
        {
            public ChildSTCUpdateActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSTCUpdateActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("84431f64-3a57-45cc-aeca-46ec10b52fec"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("dd286174-877b-4de1-b33a-383e32a811b6"); } }
        }

        public STCAction STCAction
        {
            get { return (STCAction)((ITTObject)this).GetParent("STCACTION"); }
            set { this["STCACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected STCUpdateAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected STCUpdateAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected STCUpdateAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected STCUpdateAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected STCUpdateAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STCUPDATEACTION", dataRow) { }
        protected STCUpdateAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STCUPDATEACTION", dataRow, isImported) { }
        public STCUpdateAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public STCUpdateAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public STCUpdateAction() : base() { }

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