
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SupplyTracking")] 

    /// <summary>
    /// Tedarik Takip Modülü temel sınıfıdır
    /// </summary>
    public  partial class SupplyTracking : BasePurchaseAction
    {
        public class SupplyTrackingList : TTObjectCollection<SupplyTracking> { }
                    
        public class ChildSupplyTrackingCollection : TTObject.TTChildObjectCollection<SupplyTracking>
        {
            public ChildSupplyTrackingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSupplyTrackingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("250be067-2d24-4ec7-aafd-c0690d323639"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("50055ec4-0c21-4668-98ae-c4ef5a6315c7"); } }
        }

        public PurchaseProject TmpPurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("TMPPURCHASEPROJECT"); }
            set { this["TMPPURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseOrder TmpPurchaseOrder
        {
            get { return (PurchaseOrder)((ITTObject)this).GetParent("TMPPURCHASEORDER"); }
            set { this["TMPPURCHASEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Contract TmpContract
        {
            get { return (Contract)((ITTObject)this).GetParent("TMPCONTRACT"); }
            set { this["TMPCONTRACT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SupplyTracking(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SupplyTracking(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SupplyTracking(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SupplyTracking(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SupplyTracking(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUPPLYTRACKING", dataRow) { }
        protected SupplyTracking(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUPPLYTRACKING", dataRow, isImported) { }
        public SupplyTracking(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SupplyTracking(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SupplyTracking() : base() { }

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