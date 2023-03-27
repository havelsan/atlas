
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseItemDemand")] 

    /// <summary>
    /// Satınalma Kalemi Talep
    /// </summary>
    public  partial class PurchaseItemDemand : BaseCentralAction
    {
        public class PurchaseItemDemandList : TTObjectCollection<PurchaseItemDemand> { }
                    
        public class ChildPurchaseItemDemandCollection : TTObject.TTChildObjectCollection<PurchaseItemDemand>
        {
            public ChildPurchaseItemDemandCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseItemDemandCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("17933d2d-c77d-48da-a988-27e14a1b10b3"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("a037bce0-bdf2-48f6-898e-fe23bac27606"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("39274b04-fb4b-47b2-9256-843ec5c8cd73"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("7cad3a3a-5fd5-4d6f-8ae1-800f315d263c"); } }
        }

    /// <summary>
    /// Kalem Adı
    /// </summary>
        public string ItemName
        {
            get { return (string)this["ITEMNAME"]; }
            set { this["ITEMNAME"] = value; }
        }

        public string ItemName_Shadow
        {
            get { return (string)this["ITEMNAME_SHADOW"]; }
            set { this["ITEMNAME_SHADOW"] = value; }
        }

        public PurchaseItemDef NewPurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("NEWPURCHASEITEMDEF"); }
            set { this["NEWPURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PurchaseItemDemand(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseItemDemand(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseItemDemand(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseItemDemand(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseItemDemand(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEITEMDEMAND", dataRow) { }
        protected PurchaseItemDemand(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEITEMDEMAND", dataRow, isImported) { }
        public PurchaseItemDemand(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseItemDemand(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseItemDemand() : base() { }

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