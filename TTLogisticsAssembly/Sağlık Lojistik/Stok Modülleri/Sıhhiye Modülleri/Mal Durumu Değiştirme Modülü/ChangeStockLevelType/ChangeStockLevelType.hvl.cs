
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChangeStockLevelType")] 

    /// <summary>
    /// İhtiyaç Fazlası İade
    /// </summary>
    public  partial class ChangeStockLevelType : StockAction, IChangeStockLevelType, IStockOutTransaction, IAutoDocumentRecordLog
    {
        public class ChangeStockLevelTypeList : TTObjectCollection<ChangeStockLevelType> { }
                    
        public class ChildChangeStockLevelTypeCollection : TTObject.TTChildObjectCollection<ChangeStockLevelType>
        {
            public ChildChangeStockLevelTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChangeStockLevelTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Et
    /// </summary>
            public static Guid Cancel { get { return new Guid("ea8ff2a8-b4d8-4d44-bb7c-19049c537a5b"); } }
    /// <summary>
    /// Kayıt
    /// </summary>
            public static Guid Registry { get { return new Guid("bec09a6c-88d8-4269-a3bc-9dc14ba215d0"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("b772c4a5-999e-402d-9f58-f6685111b74a"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ChangeStockLevelTypeDetails = new ChangeStockLevelTypeDetail.ChildChangeStockLevelTypeDetailCollection(_StockActionDetails, "ChangeStockLevelTypeDetails");
        }

        private ChangeStockLevelTypeDetail.ChildChangeStockLevelTypeDetailCollection _ChangeStockLevelTypeDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ChangeStockLevelTypeDetail.ChildChangeStockLevelTypeDetailCollection ChangeStockLevelTypeDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ChangeStockLevelTypeDetails;
            }            
        }

        protected ChangeStockLevelType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChangeStockLevelType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChangeStockLevelType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChangeStockLevelType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChangeStockLevelType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHANGESTOCKLEVELTYPE", dataRow) { }
        protected ChangeStockLevelType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHANGESTOCKLEVELTYPE", dataRow, isImported) { }
        public ChangeStockLevelType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChangeStockLevelType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChangeStockLevelType() : base() { }

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