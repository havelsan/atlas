
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExtendExpDateOut")] 

    /// <summary>
    /// Miad Güncelleme İşlemi (Çıkış)
    /// </summary>
    public  partial class ExtendExpDateOut : BaseChattelDocument, IAutoDocumentNumber, IAutoDocumentRecordLog, ICheckStockActionOutDetail, IStockOutTransaction
    {
        public class ExtendExpDateOutList : TTObjectCollection<ExtendExpDateOut> { }
                    
        public class ChildExtendExpDateOutCollection : TTObject.TTChildObjectCollection<ExtendExpDateOut>
        {
            public ChildExtendExpDateOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExtendExpDateOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approved { get { return new Guid("3bd5fbce-0c5a-414c-90d1-6cef65746d0a"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("e000caa2-558f-4237-b52c-16dbcc174e47"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("19cbbe80-db97-494e-8a54-727193f804d4"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("f1bcef3d-1092-4373-b387-ac4b0aa11590"); } }
        }

    /// <summary>
    /// MKYS Giriş Kontrol 
    /// </summary>
        public bool? InMkysControl
        {
            get { return (bool?)this["INMKYSCONTROL"]; }
            set { this["INMKYSCONTROL"] = value; }
        }

        public int? MKYS_AyniyatMakbuzIDGiris
        {
            get { return (int?)this["MKYS_AYNIYATMAKBUZIDGIRIS"]; }
            set { this["MKYS_AYNIYATMAKBUZIDGIRIS"] = value; }
        }

    /// <summary>
    /// MKYS Çıkış Kontrol 
    /// </summary>
        public bool? OutMkysControl
        {
            get { return (bool?)this["OUTMKYSCONTROL"]; }
            set { this["OUTMKYSCONTROL"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateExtendExpDateInsCollection()
        {
            _ExtendExpDateIns = new ExtendExpDateIn.ChildExtendExpDateInCollection(this, new Guid("7706ab79-4646-4f21-8654-0ea8ab0db80a"));
            ((ITTChildObjectCollection)_ExtendExpDateIns).GetChildren();
        }

        protected ExtendExpDateIn.ChildExtendExpDateInCollection _ExtendExpDateIns = null;
        public ExtendExpDateIn.ChildExtendExpDateInCollection ExtendExpDateIns
        {
            get
            {
                if (_ExtendExpDateIns == null)
                    CreateExtendExpDateInsCollection();
                return _ExtendExpDateIns;
            }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ExtendExpDateOutDetails = new ExtendExpDateOutDetail.ChildExtendExpDateOutDetailCollection(_StockActionDetails, "ExtendExpDateOutDetails");
        }

        private ExtendExpDateOutDetail.ChildExtendExpDateOutDetailCollection _ExtendExpDateOutDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ExtendExpDateOutDetail.ChildExtendExpDateOutDetailCollection ExtendExpDateOutDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ExtendExpDateOutDetails;
            }            
        }

        protected ExtendExpDateOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExtendExpDateOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExtendExpDateOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExtendExpDateOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExtendExpDateOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTENDEXPDATEOUT", dataRow) { }
        protected ExtendExpDateOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTENDEXPDATEOUT", dataRow, isImported) { }
        public ExtendExpDateOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExtendExpDateOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExtendExpDateOut() : base() { }

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