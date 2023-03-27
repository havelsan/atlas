
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresChaDocOutputWithAccountancy")] 

    /// <summary>
    /// Taşınır Mal İşlemi Çıkış (Reçeteler İçin)
    /// </summary>
    public  partial class PresChaDocOutputWithAccountancy : ChattelDocumentOutputWithAccountancy, IAutoDocumentNumber, IAutoDocumentRecordLog, IBasePrescriptionTransaction, IChattelDocumentOutputWithAccountancy, ICheckStockActionOutDetail, IStockOutTransaction, IStockReservation
    {
        public class PresChaDocOutputWithAccountancyList : TTObjectCollection<PresChaDocOutputWithAccountancy> { }
                    
        public class ChildPresChaDocOutputWithAccountancyCollection : TTObject.TTChildObjectCollection<PresChaDocOutputWithAccountancy>
        {
            public ChildPresChaDocOutputWithAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresChaDocOutputWithAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approved { get { return new Guid("a0af1914-b635-40cd-b4ca-5bf9488ed751"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c6840f2a-809a-423e-853d-3e6e563705ea"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("fdedf2db-6dc6-450d-9c67-e831f83e4ed7"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("2ec463fc-c96e-4797-9164-651fffbbe487"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PresChaDocOutputWithAccountancyDetails = new PresChaDocOutputDetWithAccountancy.ChildPresChaDocOutputDetWithAccountancyCollection(_StockActionDetails, "PresChaDocOutputWithAccountancyDetails");
        }

        private PresChaDocOutputDetWithAccountancy.ChildPresChaDocOutputDetWithAccountancyCollection _PresChaDocOutputWithAccountancyDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresChaDocOutputDetWithAccountancy.ChildPresChaDocOutputDetWithAccountancyCollection PresChaDocOutputWithAccountancyDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresChaDocOutputWithAccountancyDetails;
            }            
        }

        protected PresChaDocOutputWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresChaDocOutputWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresChaDocOutputWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresChaDocOutputWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresChaDocOutputWithAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCHADOCOUTPUTWITHACCOUNTANCY", dataRow) { }
        protected PresChaDocOutputWithAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCHADOCOUTPUTWITHACCOUNTANCY", dataRow, isImported) { }
        public PresChaDocOutputWithAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresChaDocOutputWithAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresChaDocOutputWithAccountancy() : base() { }

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