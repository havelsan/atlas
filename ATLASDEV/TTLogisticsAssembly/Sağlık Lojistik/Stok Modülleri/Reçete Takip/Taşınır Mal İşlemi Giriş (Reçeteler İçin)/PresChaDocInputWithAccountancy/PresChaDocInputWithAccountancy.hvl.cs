
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresChaDocInputWithAccountancy")] 

    /// <summary>
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
    public  partial class PresChaDocInputWithAccountancy : ChattelDocumentInputWithAccountancy, IBasePrescriptionTransaction, IAutoDocumentNumber, IAutoDocumentRecordLog, IChattelDocumentInputWithAccountancy, ICheckStockActionInDetail, IStockInTransaction
    {
        public class PresChaDocInputWithAccountancyList : TTObjectCollection<PresChaDocInputWithAccountancy> { }
                    
        public class ChildPresChaDocInputWithAccountancyCollection : TTObject.TTChildObjectCollection<PresChaDocInputWithAccountancy>
        {
            public ChildPresChaDocInputWithAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresChaDocInputWithAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("1299152e-2ba9-4890-8051-de2cde06cfbd"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approved { get { return new Guid("6cd42bda-5b4a-4efb-9325-5035658bbee0"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f63728f9-91ae-4ab3-8f5d-d6afd1a1d8ee"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("9c29b530-939f-41c5-8d1b-e48114c25133"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PresChaDocInputWithAccountancyDetails = new PresChaDocInputDetWithAccountancy.ChildPresChaDocInputDetWithAccountancyCollection(_StockActionDetails, "PresChaDocInputWithAccountancyDetails");
        }

        private PresChaDocInputDetWithAccountancy.ChildPresChaDocInputDetWithAccountancyCollection _PresChaDocInputWithAccountancyDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresChaDocInputDetWithAccountancy.ChildPresChaDocInputDetWithAccountancyCollection PresChaDocInputWithAccountancyDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresChaDocInputWithAccountancyDetails;
            }            
        }

        protected PresChaDocInputWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresChaDocInputWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresChaDocInputWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresChaDocInputWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresChaDocInputWithAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCHADOCINPUTWITHACCOUNTANCY", dataRow) { }
        protected PresChaDocInputWithAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCHADOCINPUTWITHACCOUNTANCY", dataRow, isImported) { }
        public PresChaDocInputWithAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresChaDocInputWithAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresChaDocInputWithAccountancy() : base() { }

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