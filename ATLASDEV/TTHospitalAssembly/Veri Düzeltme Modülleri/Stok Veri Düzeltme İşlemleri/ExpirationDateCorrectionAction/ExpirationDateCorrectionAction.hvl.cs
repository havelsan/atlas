
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExpirationDateCorrectionAction")] 

    /// <summary>
    /// Son Kullanma Tarihi Güncelleme
    /// </summary>
    public  partial class ExpirationDateCorrectionAction : BaseDataCorrection, IWorkListBaseAction, IExpirationDateCorrectionAction
    {
        public class ExpirationDateCorrectionActionList : TTObjectCollection<ExpirationDateCorrectionAction> { }
                    
        public class ChildExpirationDateCorrectionActionCollection : TTObject.TTChildObjectCollection<ExpirationDateCorrectionAction>
        {
            public ChildExpirationDateCorrectionActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExpirationDateCorrectionActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("bea0001d-7b0e-488b-9552-f824acfb99dd"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("9e267914-5a0e-42bf-bc32-ee8af45972dc"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("c2be960f-b398-4ab5-af14-7d773709c937"); } }
        }

    /// <summary>
    /// Eski Son Kullanma Tarihi
    /// </summary>
        public DateTime? OldExpirationDate
        {
            get { return (DateTime?)this["OLDEXPIRATIONDATE"]; }
            set { this["OLDEXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// Yeni Son Kullanma Tarihi
    /// </summary>
        public DateTime? NewExpirationDate
        {
            get { return (DateTime?)this["NEWEXPIRATIONDATE"]; }
            set { this["NEWEXPIRATIONDATE"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MainStoreDefinition MainStoreDefinition
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("MAINSTOREDEFINITION"); }
            set { this["MAINSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFirstInStockActionsCollection()
        {
            _FirstInStockActions = new FirstInStockAction.ChildFirstInStockActionCollection(this, new Guid("c1dce0ee-9e34-44be-a003-43fda7dc8519"));
            ((ITTChildObjectCollection)_FirstInStockActions).GetChildren();
        }

        protected FirstInStockAction.ChildFirstInStockActionCollection _FirstInStockActions = null;
        public FirstInStockAction.ChildFirstInStockActionCollection FirstInStockActions
        {
            get
            {
                if (_FirstInStockActions == null)
                    CreateFirstInStockActionsCollection();
                return _FirstInStockActions;
            }
        }

        protected ExpirationDateCorrectionAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExpirationDateCorrectionAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExpirationDateCorrectionAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExpirationDateCorrectionAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExpirationDateCorrectionAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXPIRATIONDATECORRECTIONACTION", dataRow) { }
        protected ExpirationDateCorrectionAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXPIRATIONDATECORRECTIONACTION", dataRow, isImported) { }
        public ExpirationDateCorrectionAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExpirationDateCorrectionAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExpirationDateCorrectionAction() : base() { }

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