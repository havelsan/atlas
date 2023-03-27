
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TransferForDemand")] 

    /// <summary>
    /// İsteğe Yapılan Muvazeneler
    /// </summary>
    public  partial class TransferForDemand : TTObject
    {
        public class TransferForDemandList : TTObjectCollection<TransferForDemand> { }
                    
        public class ChildTransferForDemandCollection : TTObject.TTChildObjectCollection<TransferForDemand>
        {
            public ChildTransferForDemandCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTransferForDemandCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("de967606-1569-4ca2-9583-746b84d27180"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f4186c56-3f36-4985-ae4d-38da4c24a6f1"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("3b988e85-7e0b-43ef-8a9b-219f9e3908ef"); } }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public Demand Demand
        {
            get { return (Demand)((ITTObject)this).GetParent("DEMAND"); }
            set { this["DEMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DemandDetStoreStockDetail DemandDetStoreStockDetail
        {
            get { return (DemandDetStoreStockDetail)((ITTObject)this).GetParent("DEMANDDETSTORESTOCKDETAIL"); }
            set { this["DEMANDDETSTORESTOCKDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DemandDetail DemandDetail
        {
            get { return (DemandDetail)((ITTObject)this).GetParent("DEMANDDETAIL"); }
            set { this["DEMANDDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TransferForDemand(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TransferForDemand(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TransferForDemand(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TransferForDemand(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TransferForDemand(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRANSFERFORDEMAND", dataRow) { }
        protected TransferForDemand(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRANSFERFORDEMAND", dataRow, isImported) { }
        public TransferForDemand(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TransferForDemand(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TransferForDemand() : base() { }

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