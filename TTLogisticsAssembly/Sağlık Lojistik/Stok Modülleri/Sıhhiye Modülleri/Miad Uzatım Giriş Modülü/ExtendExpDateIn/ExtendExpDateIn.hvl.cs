
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExtendExpDateIn")] 

    /// <summary>
    /// Miad Güncelleme İşlemi (Giriş)
    /// </summary>
    public  partial class ExtendExpDateIn : BaseChattelDocument, IAutoDocumentNumber, IAutoDocumentRecordLog, IStockInTransaction, ICheckStockActionInDetail, IExtendExpDateIn
    {
        public class ExtendExpDateInList : TTObjectCollection<ExtendExpDateIn> { }
                    
        public class ChildExtendExpDateInCollection : TTObject.TTChildObjectCollection<ExtendExpDateIn>
        {
            public ChildExtendExpDateInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExtendExpDateInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approved { get { return new Guid("4fac4b42-a824-4878-a296-1e21548e9872"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("2e85bee1-0e33-4238-815c-c496082c57f0"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("668e737f-e9d2-452b-b358-713c6dee9f31"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("3cee9917-015c-4c2c-9514-ed95ebb4c87a"); } }
        }

    /// <summary>
    /// Çıkış İşlem ID
    /// </summary>
        public int? ExtendExpDateOutID
        {
            get { return (int?)this["EXTENDEXPDATEOUTID"]; }
            set { this["EXTENDEXPDATEOUTID"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ExtendExpDateOut ExtendExpDateOut
        {
            get { return (ExtendExpDateOut)((ITTObject)this).GetParent("EXTENDEXPDATEOUT"); }
            set { this["EXTENDEXPDATEOUT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ExtendExpDateInDetails = new ExtendExpDateInDetail.ChildExtendExpDateInDetailCollection(_StockActionDetails, "ExtendExpDateInDetails");
        }

        private ExtendExpDateInDetail.ChildExtendExpDateInDetailCollection _ExtendExpDateInDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ExtendExpDateInDetail.ChildExtendExpDateInDetailCollection ExtendExpDateInDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ExtendExpDateInDetails;
            }            
        }

        protected ExtendExpDateIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExtendExpDateIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExtendExpDateIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExtendExpDateIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExtendExpDateIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTENDEXPDATEIN", dataRow) { }
        protected ExtendExpDateIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTENDEXPDATEIN", dataRow, isImported) { }
        public ExtendExpDateIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExtendExpDateIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExtendExpDateIn() : base() { }

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