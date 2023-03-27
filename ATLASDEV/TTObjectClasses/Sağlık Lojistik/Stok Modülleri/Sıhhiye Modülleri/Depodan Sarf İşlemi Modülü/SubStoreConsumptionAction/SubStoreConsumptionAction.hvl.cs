
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubStoreConsumptionAction")] 

    /// <summary>
    /// Depodan Sarf İşlemi için kullanılan temel sınıftır
    /// </summary>
    public  partial class SubStoreConsumptionAction : StockAction, ICheckStockActionOutDetail, IStockOutTransaction
    {
        public class SubStoreConsumptionActionList : TTObjectCollection<SubStoreConsumptionAction> { }
                    
        public class ChildSubStoreConsumptionActionCollection : TTObject.TTChildObjectCollection<SubStoreConsumptionAction>
        {
            public ChildSubStoreConsumptionActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubStoreConsumptionActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("4ca2dc25-1a3f-4093-85f3-8277ae327746"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("6e0a2b7e-5db7-4c6b-a87e-0332296d0704"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("069c21c1-512b-4109-bb73-779f7adce620"); } }
    /// <summary>
    /// Klinik Şefi Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("e092da2c-6c36-4d4d-a0b3-ba4e67ea1827"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Control { get { return new Guid("e2264c73-7b92-4ea7-b2a7-ef9158e3b3ba"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _SubStoreConsumptionActionDetails = new SubStoreConsumptionDetail.ChildSubStoreConsumptionDetailCollection(_StockActionDetails, "SubStoreConsumptionActionDetails");
        }

        private SubStoreConsumptionDetail.ChildSubStoreConsumptionDetailCollection _SubStoreConsumptionActionDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public SubStoreConsumptionDetail.ChildSubStoreConsumptionDetailCollection SubStoreConsumptionActionDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _SubStoreConsumptionActionDetails;
            }            
        }

        protected SubStoreConsumptionAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubStoreConsumptionAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubStoreConsumptionAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubStoreConsumptionAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubStoreConsumptionAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBSTORECONSUMPTIONACTION", dataRow) { }
        protected SubStoreConsumptionAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBSTORECONSUMPTIONACTION", dataRow, isImported) { }
        public SubStoreConsumptionAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubStoreConsumptionAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubStoreConsumptionAction() : base() { }

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