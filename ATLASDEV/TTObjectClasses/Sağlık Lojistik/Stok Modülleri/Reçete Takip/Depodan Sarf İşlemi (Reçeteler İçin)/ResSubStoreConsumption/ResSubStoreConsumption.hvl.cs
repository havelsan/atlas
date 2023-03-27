
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResSubStoreConsumption")] 

    /// <summary>
    /// Depodan Sarf İşlemi (Reçeteler İçin)
    /// </summary>
    public  partial class ResSubStoreConsumption : StockAction, IBasePrescriptionTransaction, ICheckStockActionOutDetail, IStockOutTransaction
    {
        public class ResSubStoreConsumptionList : TTObjectCollection<ResSubStoreConsumption> { }
                    
        public class ChildResSubStoreConsumptionCollection : TTObject.TTChildObjectCollection<ResSubStoreConsumption>
        {
            public ChildResSubStoreConsumptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResSubStoreConsumptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Klinik Şefi Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("9a066b36-09d3-48f4-a0fa-53577e81feba"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("3018ab17-2df4-42c4-93f8-5ee825ed21a3"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("38f82c78-78c5-4b5b-9c33-97a1acefce8d"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("5c6903de-22eb-4c3c-bd5c-542bcd2d6a2e"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ResSubStoreConsumptionDetails = new ResSubStoreConsumptionDetail.ChildResSubStoreConsumptionDetailCollection(_StockActionDetails, "ResSubStoreConsumptionDetails");
        }

        private ResSubStoreConsumptionDetail.ChildResSubStoreConsumptionDetailCollection _ResSubStoreConsumptionDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ResSubStoreConsumptionDetail.ChildResSubStoreConsumptionDetailCollection ResSubStoreConsumptionDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ResSubStoreConsumptionDetails;
            }            
        }

        protected ResSubStoreConsumption(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResSubStoreConsumption(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResSubStoreConsumption(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResSubStoreConsumption(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResSubStoreConsumption(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSUBSTORECONSUMPTION", dataRow) { }
        protected ResSubStoreConsumption(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSUBSTORECONSUMPTION", dataRow, isImported) { }
        public ResSubStoreConsumption(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResSubStoreConsumption(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResSubStoreConsumption() : base() { }

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