
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresChaDocWithPurchase")] 

    /// <summary>
    /// Taşınır Mal İşlemi Satın Alma Yoluyla (Reçeteler İçin)
    /// </summary>
    public  partial class PresChaDocWithPurchase : ChattelDocumentWithPurchase, IBasePrescriptionTransaction, IChattelDocumentWithPurchase, IAutoDocumentRecordLog
    {
        public class PresChaDocWithPurchaseList : TTObjectCollection<PresChaDocWithPurchase> { }
                    
        public class ChildPresChaDocWithPurchaseCollection : TTObject.TTChildObjectCollection<PresChaDocWithPurchase>
        {
            public ChildPresChaDocWithPurchaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresChaDocWithPurchaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approved { get { return new Guid("82fa71ce-4835-4787-8325-cfb174f26bb0"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("22d2e251-0eca-4826-9d0f-ad9dd9ce25ef"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("8cc98a9b-d3e8-4d29-832c-a18f7866a11a"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("35181875-e240-46fa-b2c3-59c5e288b2c1"); } }
    /// <summary>
    /// Belge Düzeltme
    /// </summary>
            public static Guid FixDocument { get { return new Guid("bc2c089c-d1f6-4877-aa8e-e2bbc4e060fc"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PresChaDocDetailsWithPurchase = new PresChaDocDetWithPurchase.ChildPresChaDocDetWithPurchaseCollection(_StockActionDetails, "PresChaDocDetailsWithPurchase");
        }

        private PresChaDocDetWithPurchase.ChildPresChaDocDetWithPurchaseCollection _PresChaDocDetailsWithPurchase = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresChaDocDetWithPurchase.ChildPresChaDocDetWithPurchaseCollection PresChaDocDetailsWithPurchase
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresChaDocDetailsWithPurchase;
            }            
        }

        protected PresChaDocWithPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresChaDocWithPurchase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresChaDocWithPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresChaDocWithPurchase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresChaDocWithPurchase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCHADOCWITHPURCHASE", dataRow) { }
        protected PresChaDocWithPurchase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCHADOCWITHPURCHASE", dataRow, isImported) { }
        public PresChaDocWithPurchase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresChaDocWithPurchase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresChaDocWithPurchase() : base() { }

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