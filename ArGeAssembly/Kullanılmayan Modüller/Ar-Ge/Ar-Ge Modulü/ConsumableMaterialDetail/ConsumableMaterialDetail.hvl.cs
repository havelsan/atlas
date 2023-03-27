
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ConsumableMaterialDetail")] 

    public  partial class ConsumableMaterialDetail : TTObject
    {
        public class ConsumableMaterialDetailList : TTObjectCollection<ConsumableMaterialDetail> { }
                    
        public class ChildConsumableMaterialDetailCollection : TTObject.TTChildObjectCollection<ConsumableMaterialDetail>
        {
            public ChildConsumableMaterialDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildConsumableMaterialDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("a4911aba-c74e-4022-863e-7e1f331815cd"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("6bcbc867-1e46-4a65-8385-557db29e36f9"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("e287385e-1321-4444-8ddb-da51e34251ad"); } }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public ExchangeTypeDef ExchangeType
        {
            get { return (ExchangeTypeDef)((ITTObject)this).GetParent("EXCHANGETYPE"); }
            set { this["EXCHANGETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockOut StockOut
        {
            get { return (StockOut)((ITTObject)this).GetParent("STOCKOUT"); }
            set { this["STOCKOUT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ArgeProject ArgeProject
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("ARGEPROJECT"); }
            set { this["ARGEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ConsumableMaterialDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ConsumableMaterialDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ConsumableMaterialDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ConsumableMaterialDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ConsumableMaterialDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONSUMABLEMATERIALDETAIL", dataRow) { }
        protected ConsumableMaterialDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONSUMABLEMATERIALDETAIL", dataRow, isImported) { }
        public ConsumableMaterialDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ConsumableMaterialDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ConsumableMaterialDetail() : base() { }

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