
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetTransaction")] 

    /// <summary>
    /// Demirbaş Hareket
    /// </summary>
    public  partial class FixedAssetTransaction : TTObject
    {
        public class FixedAssetTransactionList : TTObjectCollection<FixedAssetTransaction> { }
                    
        public class ChildFixedAssetTransactionCollection : TTObject.TTChildObjectCollection<FixedAssetTransaction>
        {
            public ChildFixedAssetTransactionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetTransactionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("7b097d6f-e530-4171-a4af-3d510496129a"); } }
            public static Guid Completed { get { return new Guid("1977b576-267b-49af-8035-efec1c98967a"); } }
        }

    /// <summary>
    /// Stok Hareketi-Demirbaş Hareketleri
    /// </summary>
        public StockTransaction StockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("STOCKTRANSACTION"); }
            set { this["STOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kaynak
    /// </summary>
        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Demirbaş-Demirbaş Hareketleri
    /// </summary>
        public FixedAssetMaterialDefinition FixedAsset
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSET"); }
            set { this["FIXEDASSET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetTransaction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetTransaction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetTransaction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETTRANSACTION", dataRow) { }
        protected FixedAssetTransaction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETTRANSACTION", dataRow, isImported) { }
        public FixedAssetTransaction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetTransaction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetTransaction() : base() { }

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