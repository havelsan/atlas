
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainStoreDistributionDoc")] 

    /// <summary>
    /// Ana Depo Dağıtım Belgesi
    /// </summary>
    public  partial class MainStoreDistributionDoc : StockAction, IAutoDocumentNumber, IAutoDocumentRecordLog, ICheckStockActionOutDetail, IDistributionDocument, IStockReservation, IStockTransferTransaction
    {
        public class MainStoreDistributionDocList : TTObjectCollection<MainStoreDistributionDoc> { }
                    
        public class ChildMainStoreDistributionDocCollection : TTObject.TTChildObjectCollection<MainStoreDistributionDoc>
        {
            public ChildMainStoreDistributionDocCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainStoreDistributionDocCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("8c227c02-517c-4b21-b4d5-cc3a7b1fea91"); } }
            public static Guid Completed { get { return new Guid("5b0e6a48-0902-4986-a02e-3282544f7b88"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("30c8c1e7-59a4-405c-9b4b-4a5b1ad74a67"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("0b1d7674-3971-4a55-b622-18d3b80dc836"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _MainStoreDistDocDetails = new MainStoreDistDocDetail.ChildMainStoreDistDocDetailCollection(_StockActionDetails, "MainStoreDistDocDetails");
        }

        private MainStoreDistDocDetail.ChildMainStoreDistDocDetailCollection _MainStoreDistDocDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public MainStoreDistDocDetail.ChildMainStoreDistDocDetailCollection MainStoreDistDocDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _MainStoreDistDocDetails;
            }            
        }

        protected MainStoreDistributionDoc(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainStoreDistributionDoc(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainStoreDistributionDoc(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainStoreDistributionDoc(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainStoreDistributionDoc(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINSTOREDISTRIBUTIONDOC", dataRow) { }
        protected MainStoreDistributionDoc(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINSTOREDISTRIBUTIONDOC", dataRow, isImported) { }
        public MainStoreDistributionDoc(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainStoreDistributionDoc(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainStoreDistributionDoc() : base() { }

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