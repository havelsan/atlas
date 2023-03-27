
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DistributionDepStore")] 

    /// <summary>
    /// Bağlı Birlik İçin Dağıtım Belgesi
    /// </summary>
    public  partial class DistributionDepStore : StockAction, IDistributionDepStore, IStockInTransaction, ICheckStockActionInDetail
    {
        public class DistributionDepStoreList : TTObjectCollection<DistributionDepStore> { }
                    
        public class ChildDistributionDepStoreCollection : TTObject.TTChildObjectCollection<DistributionDepStore>
        {
            public ChildDistributionDepStoreCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDistributionDepStoreCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("94d935b8-1807-4a4e-b97a-311e19dc22ed"); } }
    /// <summary>
    /// Saymanlık Onay
    /// </summary>
            public static Guid AccountancyApproval { get { return new Guid("515ec818-19e1-40a2-a076-122a3aab43a2"); } }
    /// <summary>
    /// Birlik Onay
    /// </summary>
            public static Guid UnitApproval { get { return new Guid("a8230989-af60-4fbe-9772-04d2d46eb5d5"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("6a944ea1-223d-47c3-a132-b25c6961708f"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("87975fc6-b0bf-4f36-86e5-51e196e32dfa"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _DistributionDepStoreMats = new DistributionDepStoreMat.ChildDistributionDepStoreMatCollection(_StockActionDetails, "DistributionDepStoreMats");
        }

        private DistributionDepStoreMat.ChildDistributionDepStoreMatCollection _DistributionDepStoreMats = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public DistributionDepStoreMat.ChildDistributionDepStoreMatCollection DistributionDepStoreMats
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _DistributionDepStoreMats;
            }            
        }

        protected DistributionDepStore(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DistributionDepStore(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DistributionDepStore(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DistributionDepStore(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DistributionDepStore(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTRIBUTIONDEPSTORE", dataRow) { }
        protected DistributionDepStore(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTRIBUTIONDEPSTORE", dataRow, isImported) { }
        public DistributionDepStore(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DistributionDepStore(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DistributionDepStore() : base() { }

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